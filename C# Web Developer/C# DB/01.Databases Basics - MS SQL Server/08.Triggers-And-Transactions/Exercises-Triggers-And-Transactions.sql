/* 1.	Create Table Log ------------------------------------------------------------------------------*/

USE Bank

CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY, 
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id), 
	OldSum DECIMAL(15, 2), 
	NewSum DECIMAL(15, 2)
)

GO

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
DECLARE @accountId INT = (SELECT Id FROM inserted)

INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
(@accountId, @newSum, @oldSum)

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

SELECT * FROM Accounts WHERE Id = 1

SELECT * FROM Logs

/* 2.	Create Table Emails ---------------------------------------------------------------------------*/

CREATE TABLE NotificationEmails (
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] VARCHAR(50), 
	Body VARCHAR(MAX)
)

GO

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
DECLARE @oldSum DECIMAL(15, 2) = (SELECT TOP(1) OldSum FROM inserted)
DECLARE @newSum DECIMAL(15, 2) = (SELECT TOP(1) NewSum FROM inserted)

INSERT INTO NotificationEmails (Recipient, [Subject], Body) VALUES
(@accountId, 'Balance change for account: ' + CAST(@accountId AS varchar(20)), 'On ' + CONVERT(varchar(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@oldSum AS varchar(20)) + ' to ' + CAST(@newSum AS varchar(20)))

SELECT * FROM NotificationEmails WHERE Id = 1

UPDATE Accounts
SET Balance += 100
WHERE Id = 1

/* 3.	Deposit Money ---------------------------------------------------------------------------------*/

GO

CREATE PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(15, 4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

IF (@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid account Id!', 16, 1)
	RETURN
END

IF (@moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Negative amount!', 16, 1)
	RETURN
END

UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

EXEC usp_DepositMoney 1, 247.78
SELECT * FROM Accounts WHERE Id = 1



/* 4.	Withdraw Money --------------------------------------------------------------------------------*/

GO

CREATE PROC usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15, 4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
DECLARE @accountBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)

IF (@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid account Id!', 16, 1)
	RETURN
END

IF (@moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Negative amount!', 16, 1)
	RETURN
END

IF (@accountBalance - @moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient funds!', 16, 1)
	RETURN
END

UPDATE Accounts
SET Balance -= @moneyAmount
WHERE Id = @accountId
COMMIT

EXEC usp_WithdrawMoney 1, 230
SELECT * FROM Accounts WHERE Id = 1

/* 5.	Money Transfer --------------------------------------------------------------------------------*/

GO

CREATE PROC usp_TransferMoney (@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @senderId, @amount
	EXEC usp_DepositMoney @receiverId, @amount
COMMIT

SELECT * FROM Accounts WHERE Id = 1 OR Id = 2
EXEC usp_TransferMoney 1, 2, 100

/* 6.	Trigger ---------------------------------------------------------------------------------------*/

GO

USE Diablo

SELECT * 
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id

SELECT * 
	FROM Items

GO

CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId INT = (SELECT ItemId FROM inserted)
DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

IF (@userGameLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
	(@itemId, @userGameId)
END

SELECT * 
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	WHERE g.[Name] = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid')

UPDATE UsersGames
	SET Cash += 50000
	WHERE GameId = (SELECT Id FROM Games WHERE [Name] = 'Bali') 
	AND UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid'))

GO

SELECT * FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid')

DECLARE @itemId INT = 251;

WHILE (@itemId <= 299)
BEGIN
	EXEC usp_BuyItem 22, @itemId, 212
	EXEC usp_BuyItem 37, @itemId, 212
	EXEC usp_BuyItem 52, @itemId, 212
	EXEC usp_BuyItem 61, @itemId, 212
	
	SET @itemId += 1	
END

SELECT * FROM UsersGames WHERE GameId = 212

DECLARE @counter INT = 501;

WHILE (@counter <= 539)
BEGIN
	EXEC usp_BuyItem 22, @counter, 212
	EXEC usp_BuyItem 37, @counter, 212
	EXEC usp_BuyItem 52, @counter, 212
	EXEC usp_BuyItem 61, @counter, 212
	
	SET @counter += 1	
END

GO

CREATE PROC usp_BuyItem @userId INT, @itemId INT, @gameId INT
AS
BEGIN TRANSACTION
DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @userId)
DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)

IF (@user IS NULL OR @item IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid user or item Id!', 16, 1)
	RETURN
END

DECLARE @userCash DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @itemId)

IF (@userCash - @itemPrice < 0)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient funds!', 16, 1)
	RETURN
END

UPDATE UsersGames
	SET Cash -= @itemPrice
	WHERE UserId = @userId AND GameId = @gameId

DECLARE @userGameId DECIMAL(15, 2) = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
(@itemId, @userGameId)

COMMIT

SELECT u.Username, g.[Name], ug.Cash, i.[Name] 
	FROM Users AS u
		JOIN UsersGames AS ug ON ug.UserId = u.Id
		JOIN Games AS g ON g.Id = ug.GameId
		JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
		JOIN Items AS i ON i.Id = ugi.ItemId
	WHERE g.[Name] = 'Bali'
	ORDER BY u.Username, i.[Name]

/* 7.	*Massive Shopping -----------------------------------------------------------------------------*/

GO

DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)

DECLARE @stamatCash DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
DECLARE @itemsPrice DECIMAL(15, 2) = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF (@stamatCash >=  @itemsPrice)
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
	WHERE Id = @userGameId

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items
		WHERE MinLevel BETWEEN 11 AND 12
	COMMIT
END

SET @stamatCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
SET @itemsPrice = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF (@stamatCash >=  @itemsPrice)
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
	WHERE Id = @userGameId

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items
		WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END

SELECT i.[Name] 
	FROM Users AS u
		JOIN UsersGames AS ug ON ug.UserId = u.Id
		JOIN Games AS g ON g.Id = UG.GameId
		JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
		JOIN Items AS i ON i.Id = ugi.ItemId
	WHERE u.Username = 'Stamat' AND g.[Name] = 'Safflower'
	ORDER BY i.[Name]

/* 8.	Employees with Three Projects -----------------------------------------------------------------*/

GO

USE SoftUni

GO

CREATE PROCEDURE usp_AssignProject(@employeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @employeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)

IF (@employee IS NULL OR @project IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid employee Id or project Id!', 16, 1)
	RETURN
END

DECLARE @employeeProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @employeeId)

IF (@employeeProjects >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 2)
	RETURN
END

INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES
(@employeeId, @projectID)
COMMIT

SELECT * FROM EmployeesProjects WHERE EmployeeID = 2

EXEC usp_AssignProject 2, 1

/* 9.	Delete Employees ------------------------------------------------------------------------------*/

GO

CREATE TABLE Deleted_Employees (
	EmployeeId INT PRIMARY KEY, 
	FirstName VARCHAR(50), 
	LastName VARCHAR(50), 
	MiddleName VARCHAR(50), 
	JobTitle VARCHAR(50), 
	DepartmentId INT, 
	Salary DECIMAL(15, 2)
)

GO

CREATE TRIGGER tr_DeletedEmployees ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted
