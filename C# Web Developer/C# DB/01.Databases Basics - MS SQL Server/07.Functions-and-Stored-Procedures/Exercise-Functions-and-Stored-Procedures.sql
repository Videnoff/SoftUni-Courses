/* 1.	Employees with Salary Above 35000 -------------------------------------------------------------*/

 USE [SoftUni]

 GO

 CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
 AS
 BEGIN
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary > 35000
 END

 EXEC usp_GetEmployeesSalaryAbove35000

/* 2.	Employees with Salary Above Number ------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18, 4))
AS
BEGIN
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary >= @minSalary
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100


/* 3.	Town Names Starting With ----------------------------------------------------------------------*/



/* 4.	Employees from Town ---------------------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_GetEmployeesFromTown(@townName VARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName 
	FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

/* 5.	Salary Level Function -------------------------------------------------------------------------*/

GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7);

	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low';
	END
	ELSE IF (@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average';
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High';
	END

	RETURN @salaryLevel;
END

GO

SELECT FirstName,
	   LastName,
	   dbo.ufn_GetSalaryLevel(Salary) AS [SalarYLevel] 
FROM Employees

/* 6.	Employees by Salary Level ---------------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(7))
AS
BEGIN
	SELECT FirstName, 
		   LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

EXEC usp_EmployeesBySalaryLevel 'High'

/* 7.	Define Function -------------------------------------------------------------------------------*/

GO

USE SoftUni

GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;
	
	WHILE(@i <= LEN(@word))
		BEGIN
			DECLARE @currChar CHAR = SUBSTRING(@word, @i, 1);
			DECLARE @charIndex INT = CHARINDEX(@currChar, @setOfLetters)

			IF (@charIndex = 0)
				BEGIN
					RETURN 0;
				END

				SET @i = @i + 1;
		END

		RETURN 1;
END

GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

/* 8.	* Delete Employees and Departments ------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN  ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)


	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 1

/* 9.	Find Full Name --------------------------------------------------------------------------------*/

GO

USE Bank

/* 10.	People with Balance Higher Than ---------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@minBalance DECIMAL(18, 4))
AS
BEGIN
	SELECT FirstName, LastName FROM Accounts AS a
	INNER JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @minBalance
	ORDER BY FirstName, LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 25000

/* 11.	Future Value Function -------------------------------------------------------------------------*/

GO

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 4), @yir FLOAT, @yearsCount INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(18, 4);

	SET @futureValue = @sum * (POWER((1 + @yir), @yearsCount));

	RETURN @futureValue
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

/* 12.	Calculating Interest --------------------------------------------------------------------------*/



/* 13.	*Scalar Function: Cash in User Games Odd Rows -------------------------------------------------*/

GO

USE Diablo

GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT (
				SELECT SUM(Cash) AS [SumCash] 
				FROM (
					SELECT g.[Name], 
						   ug.Cash, 
						   ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [RowNum] 
						FROM GAMES AS g
						INNER JOIN UsersGames AS ug
						ON g.Id = ug.GameId
						WHERE g.[Name] = @gameName
					) AS [RowNumQuery]
				 WHERE [RowNum] % 2 <> 0
				 ) AS [SumCash]

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')
