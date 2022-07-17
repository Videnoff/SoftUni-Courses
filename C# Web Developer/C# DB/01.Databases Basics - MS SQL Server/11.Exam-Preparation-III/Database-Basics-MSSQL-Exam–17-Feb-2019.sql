CREATE DATABASE School

USE School

/* 1. Database Design ---------------------------------------------------------------------------------*/

CREATE TABLE Students (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	Phone CHAR(10) CHECK(LEN(Phone) = 10)
)

CREATE TABLE Subjects (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects (
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT REFERENCES Students(Id) NOT NULL,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(13, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams (
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams (
	StudentId INT REFERENCES Students(Id) NOT NULL,
	ExamId INT REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(13, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL,
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10) CHECK(LEN(Phone) = 10),
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers (
	StudentId INT REFERENCES Students(Id) NOT NULL,
	TeacherId INT REFERENCES Teachers(Id) NOT NULL,
	PRIMARY KEY(StudentId, TeacherId)
)

/* 2. Insert ------------------------------------------------------------------------------------------*/

INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard',	'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects ([Name], Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)


/* 3. Update ------------------------------------------------------------------------------------------*/

UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE SubjectId IN (1, 2) AND Grade >= 5.50


/* 4. Delete ------------------------------------------------------------------------------------------*/

DELETE  
	FROM StudentsTeachers
	WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

	DELETE  
		FROM Teachers
		WHERE Phone LIKE '%72%'

/* 5. Teen Students -----------------------------------------------------------------------------------*/

SELECT FirstName, LastName, Age 
	FROM Students
	WHERE Age >= 12
	ORDER BY FirstName, LastName

/* 6. Students Teachers -------------------------------------------------------------------------------*/

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS [TeachersCount] 
	FROM Students AS s 
	JOIN StudentsTeachers AS st ON s.Id = st.StudentId
	GROUP BY FirstName, LastName

/* 7. Students to Go ----------------------------------------------------------------------------------*/

SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name] 
	FROM Students AS s
	LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
	LEFT JOIN Exams AS e ON se.ExamId = e.Id
	WHERE e.Id IS NULL
	ORDER BY [Full Name]

/* 8. Top Students ------------------------------------------------------------------------------------*/

SELECT TOP(10) s.FirstName, s.LastName, CONVERT(numeric(10, 2), AVG(se.Grade)) AS [Grade]
	FROM Students AS s
	JOIN StudentsExams AS se ON s.Id = se.StudentId
	GROUP BY s.FirstName, s.LastName
	ORDER BY AVG(se.Grade) DESC, FirstName, LastName

/* 9. Not So In The Studying --------------------------------------------------------------------------*/



/* 10. Average Grade per Subject ----------------------------------------------------------------------*/



/* 11. Exam Grades ------------------------------------------------------------------------------------*/



/* 12. Exclude from school ----------------------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @Student INT = (SELECT Id FROM Students WHERE Id = @StudentId)

	IF(@Student IS NULL)
		THROW 50001, 'This school has no student with the provided id!', 1

	DELETE FROM StudentsSubjects
		WHERE @StudentId = @Student

	DELETE FROM StudentsExams
		WHERE @StudentId = @Student

	DELETE FROM StudentsTeachers
		WHERE @StudentId = @Student

	DELETE FROM Students
		WHERE @StudentId = @Student