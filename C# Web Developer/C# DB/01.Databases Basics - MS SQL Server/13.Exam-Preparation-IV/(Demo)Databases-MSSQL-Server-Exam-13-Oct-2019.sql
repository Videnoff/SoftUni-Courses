/* 1.	Database Design -------------------------------------------------------------------------------*/

CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors (
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL,
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(MAX) NOT NULL,
	IssueStatus NVARCHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits (
	Id INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Files (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Size DECIMAL(15, 2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

/* 2.	Insert */

INSERT INTO Files ([Name], Size, ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)


/* 3.	Update */

SELECT * FROM Issues

UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId = 6

/* 4.	Delete */

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3

DELETE FROM Issues
	WHERE RepositoryId = 3

/* 5.	Commits */

SELECT Id, 
	   [Message], 
	   RepositoryId, 
	   ContributorId 
	FROM Commits
	ORDER BY ID, 
			 [Message], 
			 RepositoryId, 
			 ContributorId

/* 6.	Heavy HTML */

SELECT Id, 
	   [Name], 
	   Size 
	FROM Files
	WHERE Size > 1000 AND [Name] LIKE '%html%'
	ORDER BY Size DESC, 
			 Id, 
			 [Name]

/* 7.	Issues and Users */

SELECT i.Id, 
	   CONCAT(u.Username, ' : ', i.Title) AS [IssueAssignee]
	FROM Issues AS i
	JOIN Users AS u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, 
			 [IssueAssignee]

/* 8.	Non-Directory Files */

SELECT f2.Id, 
	   f2.[Name], 
	   CONCAT(f2.Size, 'KB') AS [Size]  
	FROM Files AS f
	RIGHT JOIN Files AS f2 ON F.ParentId = F2.Id
	WHERE f.ParentId IS NULL 
	ORDER BY f2.Id, 
			 f2.[Name], 
			 Size DESC

/* 9.	Most Contributed Repositories */

SELECT TOP(5) r.Id, 
			  r.[Name], 
			  COUNT(c.Id) AS [Commits]
	FROM Repositories AS r
	JOIN Commits AS c ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, 
			 r.[Name]
	ORDER BY [Commits] DESC, 
			 r.Id, 
			 r.[Name]

/* 10.	User and Files */

SELECT u.Username, 
	   AVG(f.Size) AS [Size] 
	FROM Users AS u
		JOIN Commits AS c ON u.Id = c.ContributorId
		JOIN Files AS f ON c.Id = f.CommitId
	WHERE u.Id = c.ContributorId AND c.Id = f.CommitId
	GROUP BY u.Username
	ORDER BY [Size] DESC, 
			 u.Username

/* 11.	 User Total Commits */

GO

CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
		(
		 SELECT COUNT(*) FROM Users AS u
		 	 JOIN Commits AS c ON u.Id = c.ContributorId		
		 	 WHERE u.Username = @username
		)
END

GO

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

/* 12.	 Find by Extensions */

GO

CREATE PROCEDURE usp_FindByExtension(@extension NVARCHAR(10))
AS
BEGIN
	SELECT f.Id, 
		   f.[Name], 
		   CONCAT(f.Size, 'KB') FROM Files AS f
		WHERE (
				SELECT RIGHT(f.[Name], CHARINDEX('.', REVERSE(f.[Name])) - 1)
			  ) = @extension
		ORDER BY f.Id, 
				 f.[Name], 
				 f.Size DESC
END

GO

EXEC usp_FindByExtension 'txt'

