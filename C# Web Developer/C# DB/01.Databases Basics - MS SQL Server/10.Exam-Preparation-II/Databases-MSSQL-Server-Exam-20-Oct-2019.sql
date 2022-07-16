/* 1.	Table design ----------------------------------------------------------------------------------*/

CREATE DATABASE Service

USE Service

GO

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age >= 14 AND Age <= 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age >= 18 AND Age <= 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE [Status] (
	Id INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports (
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES [Status](Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)


/* 2.	Insert ----------------------------------------------------------------------------------------*/

/* SET IDENTITY_INSERT [REPORTS] OFF*/

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21',	1),
('Niki', 'Stanaghan', '1969-11-26',	4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)


/* 3.	Update ----------------------------------------------------------------------------------------*/

UPDATE Reports
SET CloseDate = GETDATE()
WHERE [CloseDate] IS NULL


/* 4.	Delete ----------------------------------------------------------------------------------------*/

DELETE FROM Reports
WHERE StatusId = 4


/* 5.	Unassigned Reports ----------------------------------------------------------------------------*/

SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate 
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY Reports.OpenDate ASC, [Description] ASC

/* 6.	Reports & Categories --------------------------------------------------------------------------*/

SELECT r.[Description], c.[Name] AS CategoryName
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	ORDER BY [Description] ASC, CategoryName ASC
	/*WHERE CategoryId IN NOT NULL*/


/* 7.	Most Reported Category ------------------------------------------------------------------------*/

SELECT TOP(5) c.[Name], COUNT(*) AS ReportsNumber 
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	GROUP BY CategoryId, c.[Name]
	ORDER BY ReportsNumber DESC, [Name] ASC

	/* OR: */

SELECT TOP(5) [Name],
	(SELECT COUNT(*) FROM Reports WHERE CategoryId = c.Id) AS ReportsNumber
	FROM Categories AS c
	ORDER BY [ReportsNumber] DESC, [Name] ASC

/* 8.	Birthday Report -------------------------------------------------------------------------------*/

SELECT Username, c.[Name] AS CategoryName 
	FROM Reports AS r
	JOIN Users AS u ON u.Id = r.UserId
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE 
		DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
		AND DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
	ORDER BY Username ASC, CategoryName ASC

/* 9.	Users per Employee  ---------------------------------------------------------------------------*/

SELECT FirstName + ' ' + LastName AS FullName,
	(SELECT COUNT(DISTINCT UserId) FROM Reports WHERE EmployeeId = e.Id) AS UsersCount
	FROM Employees AS e
	ORDER BY UsersCount DESC, FullName ASC

/* 10.	Full Info -------------------------------------------------------------------------------------*/

SELECT ISNULL(e.FirstName +  ' ' + e.LastName, 'None') AS Employee,
	   ISNULL(d.[Name], 'None') AS Department,
	   ISNULL(c.[Name], 'None') AS Category,
	   r.[Description],
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.[Label] AS [Status],
	   ISNULL(u.[Name], 'None') AS [User]
	FROM Reports AS r
	LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
	LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
	LEFT JOIN [Status] AS s ON s.ID = r.StatusId
	LEFT JOIN Users AS u ON u.ID = r.UserId
	ORDER BY FirstName DESC, 
			 LastName DESC,
			 d.[Name] ASC, 
			 c.[Name] ASC, 
			 r.[Description] ASC,
			 r.OpenDate ASC,
			 s.[Label] ASC, 
			 u.[Name] ASC

/* 11.	Hours to Complete -----------------------------------------------------------------------------*/

GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF (@StartDate IS NULL)
		RETURN 0;
	IF (@EndDate IS NULL)
		RETURN 0;
	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

/* 12.	Assign Employee -------------------------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @EmployeeDepartmentId INT = 
		(SELECT DepartmentId 
		FROM Employees 
		WHERE Id = @EmployeeId)

	DECLARE @ReportDepartmentId INT = 
		(SELECT c.DepartmentId 
		FROM Reports AS r 
		JOIN Categories AS c ON c.Id = r.CategoryId
		WHERE r.Id = @ReportId)

	IF(@EmployeeDepartmentId != @ReportDepartmentId)
		THROW 50000, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
END