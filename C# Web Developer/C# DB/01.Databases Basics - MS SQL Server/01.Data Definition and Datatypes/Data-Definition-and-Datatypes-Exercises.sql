/* Problem 1.	Create Database -----------------------------------------------------------------------*/

CREATE DATABASE Minions;
USE Minions;

/* Problem 2.	Create Tables -------------------------------------------------------------------------*/

CREATE TABLE Minions
(Id     INT NOT NULL, 
 [Name] NVARCHAR(50) NOT NULL, 
 Age    INT
);
CREATE TABLE Towns
(Id     INT CONSTRAINT PK_TownId PRIMARY KEY(Id), 
 [Name] NVARCHAR(50) NOT NULL
);


ALTER TABLE dbo.Minions
ADD CONSTRAINT PK_Id PRIMARY KEY(Id);


/* Problem 3.	Alter Minions Table -------------------------------------------------------------------*/

ALTER TABLE dbo.Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id);


/* Problem 4.	Insert Records in Both Tables ---------------------------------------------------------*/

INSERT INTO dbo.Towns
(Id, 
 [Name]
)
VALUES
(1, 
 'Sofia'
),
(2, 
 'Plovdiv'
),
(3, 
 'Varna'
);


INSERT INTO dbo.Minions
(Id, 
 [Name], 
 Age,
 TownId
)
VALUES
(1, 
 'Kevin', 
 22, 
 1
),
(2, 
 'Bob', 
 15, 
 3
),
(3, 
 'Steward', 
 NULL, 
 2
);


/* Problem 5.	Truncate Table Minions ----------------------------------------------------------------*/

TRUNCATE TABLE Minions

GO

/* Problem 6.	Drop All Tables -----------------------------------------------------------------------*/

DROP TABLE Minions
DROP TABLE Towns

GO

/* Problem 7.	Create Table People -------------------------------------------------------------------*/

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) > 1024 * 1024 * 2),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(4, 2),
	Gender CHAR CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE NOT NULL, 
	Biography NVARCHAR(MAX)
)

INSERT INTO People (
	[Name],
	Height,
	[Weight],
	Gender,
	Birthdate
)
VALUES (
	'Ivan Ivanov',
	1.80,
	72.23,
	'm',
	'1995/04/02'
),
	  (
	'Georgi Ivanov',
	1.70,
	62.83,
	'm',
	'1993/06/07'
),
	  (
	'Stoyan Stoychev',
	1.75,
	72.23,
	'm',
	'1991/09/21'
),
	  (
	'Dobromira Stoyanova',
	1.65,
	52.32,
	'f',
	'1995/11/23'
),
(
	'Kristiyan Dimitrov',
	1.88,
	80.98,
	'm',
	'1991/10/18'
)

/* Problem 8.	Create Table Users --------------------------------------------------------------------*/

CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL, 
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) < 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users (
	Username,
	[Password],
	LastLoginTime,
	IsDeleted
)
VALUES (
	'someUser',
	'123456asd',
	'05-01-2020',
	0
),
	(
	'PESHO0',
	'1234567asd',
	'06-01-2020',
	1
),
	(
	'PESHO1',
	'12345678asd',
	'07-01-2020',
	0
),
	(
	'PESHO2',
	'123456789asd',
	'08-01-2020',
	1
),
	(
	'PESHO3',
	'123456987asd',
	'09-01-2020',
	0
)

/* Problem 9.	Change Primary Key --------------------------------------------------------------------*/

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC0775ECE835]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername PRIMARY KEY(Id, Username)


/* Problem 10.	Add Check Constraint ------------------------------------------------------------------*/

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Passwords_Length CHECK(LEN([Password]) >= 5)

/* Problem 11.	Set Default Value of a Field ----------------------------------------------------------*/

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime
/* Problem 12.	Set Unique Field ----------------------------------------------------------------------*/

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)

/* Problem 13.	Movies Database -----------------------------------------------------------------------*/

CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY, 
	DirectorName NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY, 
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)


)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY, 
	Title NVARCHAR(50) NOT NULL, 
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL, 
	CopyrightYear INT NOT NULL, 
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
	Rating DECIMAL(2, 1) NOT NULL, 
	Notes NVARCHAR(MAX)
)


INSERT INTO Directors (
	DirectorName
)
VALUES (
	'Alfred Hitchcock'
),
	   (	
	'Stanley Kubrick'
),
	   (
	'Martin Scorsese'
),
	   (
	'Francis Ford Coppola'
),
	   (
	'Steven Spielberg'
)

INSERT INTO Genres (
	GenreName
)
VALUES (
	'Crime'
),
	   (
	'Sci-Fi'
),
	   (
	'Drama'
),
	   (
	'Thriller'
),
	   (
	'Comedy'
)

INSERT INTO Categories (
	CategoryName
)
VALUES (
	'1'
),
	   (
	'2'
),
	   (
	'3'
),
	   (
	'4'
),
	   (
	'5'
)

INSERT INTO Movies (
	Title,
	DirectorId,
	CopyrightYear,
	[Length],
	GenreId,
	CategoryId,
	Rating
)
VALUES (
	'Dial M for Murder', 1, 1954, '1:45:00', 1, 5, 8.2
),
	   (
	'2001: A Space Odyssey', 2, 1968, '2:29:00', 2, 4, 8.3
),
	   (
	'Taxi Driver', 3, 1976, '1:54:00', 3, 3, 8.3
),
	   (
	'Apocalypse Now', 4, 1979, '2:27:00', 3, 2, 8.5
),
	   (
	'Jaws', 5, 1975, '2:04:00', 4, 1, 8.0
)


/* Problem 14.	Car Rental Database -------------------------------------------------------------------*/

CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL, 
	DailyRate INT, 
	WeeklyRate INT, 
	MonthlyRate INT, 
	WeekendRate INT
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber NVARCHAR(10) NOT NULL, 
	Manufacturer NVARCHAR(50) NOT NULL, 
	Model NVARCHAR(50) NOT NULL, 
	CarYear INT NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
	Doors INT NOT NULL, 
	Picture VARBINARY(MAX), 
	Condition NVARCHAR(50), 
	Available BIT NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(30), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber NVARCHAR(50) NOT NULL, 
	FullName NVARCHAR(100) NOT NULL, 
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL, 
	ZIPCode NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id), 
	CarId INT FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel INT NOT NULL, 
	KilometrageStart INT NOT NULL, 
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage AS KilometrageEnd - KilometrageStart, 
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate), 
	RateApplied INT NOT NULL, 
	TaxRate AS RateApplied * 0.2, 
	OrderStatus BIT NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (
	CategoryName
)
VALUES
	('Grand tourer'),
	('Roadster'),
	('SUV')

INSERT INTO Cars (
	PlateNumber, 
	Manufacturer, 
	Model, 
	CarYear, 
	CategoryId, 
	Doors, 
	Available
)
VALUES
	('CA1234KP', 'Aston Martin Lagonda Limited', 'Aston Martin DB9', 2004, 1, 2, 1),
	('CA567KP', 'BMW', 'BMW Z', 2018, 2, 2, 0),
	('CA8910KP', 'Honda', 'Honda CR-V', 2015, 2, 5, 1)

INSERT INTO Employees (
	FirstName, 
	LastName
) 
VALUES
	('Ivan', 'Ivanov'),
	('Georgi', 'Stoyanov'),
	('Iliyan', 'Angelov')

INSERT INTO Customers (
	DriverLicenceNumber, 
	FullName, 
	[Address], 
	City, 
	ZIPCode
) 
VALUES
	('1351363612', 'Martin Georgiev', 'Pirotska 4', 'Sofia', '1000'),
	('2155125125', 'Dimcho Ivanov', 'Vasil Levski 37', 'Shumen', '9700'),
	('2353515151', 'Lazar Lazarov', 'Yane Sandanski 5', 'Sandanski', '2800')

INSERT INTO RentalOrders(
	EmployeeId, 
	CustomerId, 
	CarId, 
	TankLevel, 
	KilometrageStart, 
	KilometrageEnd, 
	StartDate, 
	EndDate, 
	RateApplied, 
	OrderStatus
) 
VALUES
	(1, 1, 3, 70, 12400, 40153, '2018-02-10', '2018-08-10', 250, 1),
	(2, 2, 2, 60, 120000, 150245, '2018-09-18', '2018-10-24', 1500, 0),
	(3, 3, 1, 50, 28268, 30001, '2018-05-08', '2018-06-01', 850, 0)

/* Problem 15.	Hotel Database ------------------------------------------------------------------------*/

CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(10), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	PhoneNumber NVARCHAR(30), 
	EmergencyName NVARCHAR(30), 
	EmergencyNumber NVARCHAR(30), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes (
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY, 
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL, 
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL, 
	Rate DECIMAL(6, 2) NOT NULL, 
	RoomStatus BIT NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	PaymentDate DATETIME2 NOT NULL, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied), 
	AmountCharged DECIMAL(7, 2) NOT NULL, 
	TaxRate DECIMAL(6, 2) NOT NULL, 
	TaxAmount AS AmountCharged * TaxRate, 
	PaymentTotal AS AmountCharged + AmountCharged * TaxRate, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL, 
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL, 
	RateApplied DECIMAL(7, 2) NOT NULL, 
	PhoneCharge DECIMAL(8, 2) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (
	FirstName, 
	LastName, 
	Title
) 
VALUES
	('Ivan', 'Ivanov', 'Physicist'),
	('Stoyan', 'Georgiev', 'Biologist'),
	('Petar', 'Stoychev', 'Programmer')

INSERT INTO Customers (
	FirstName, 
	LastName
)
VALUES
	('Stoycho', 'Stoychev'),
	('Krasimir', 'Botev'),
	('Gencho', 'Dimitrov')

INSERT INTO RoomStatus (
	RoomStatus
)
VALUES
	('Occupied'),
	('Free'),
	('In Repair')

INSERT INTO RoomTypes (
	RoomType
) 
VALUES
	('Single'),
	('Double'),
	('Appartment')

INSERT INTO BedTypes (
	BedType
) 
VALUES
	('Single'),
	('Double'),
	('Couch')

INSERT INTO Rooms (
	RoomNumber, 
	RoomType, 
	BedType, 
	Rate, 
	RoomStatus
)
VALUES
	(2245, 'Single', 'Single', 30.0, 1),
	(2552, 'Double', 'Double', 45.0, 0),
	(5522, 'Appartment', 'Double', 90.0, 1)

INSERT INTO Payments (
	EmployeeId, 
	PaymentDate, 
	AccountNumber, 
	FirstDateOccupied, 
	LastDateOccupied, 
	AmountCharged, 
	TaxRate
) 
VALUES
	(1, '2011-11-25', 1, '2017-11-30', '2017-12-04', 200.0, 0.1),
	(2, '2014-06-03', 2, '2014-06-06', '2014-06-09', 440.0, 0.2),
	(3, '2016-02-25', 3, '2016-02-27', '2016-03-04', 870.0, 0.5)

INSERT INTO Occupancies (
	EmployeeId, 
	DateOccupied, 
	AccountNumber, 
	RoomNumber, 
	RateApplied, 
	PhoneCharge
) 
VALUES
	(1, '2011-02-04', 1, 2245, 40.0, 12.54),
	(2, '2015-04-09', 2, 2552, 70.0, 11.22),
	(3, '2012-06-08', 3, 5522, 110.0, 10.05)


/* Problem 16.	Create SoftUni Database ---------------------------------------------------------------*/

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY, 
	AddressText NVARCHAR(100) NOT NULL, 
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50), 
	LastName NVARCHAR(50) NOT NULL, 
	JobTitle NVARCHAR(30) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
	HireDate DATE NOT NULL, 
	Salary DECIMAL(7, 2) NOT NULL, 
	AddressId INT FOREIGN KEY REFERENCES AdDresses(Id)
)

/* Problem 17.	Backup Database -----------------------------------------------------------------------*/

USE SoftUni

BACKUP DATABASE SoftUni
TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\SoftUni.bak'
	WITH FORMAT,
		MEDIANAME = 'SQLServerBackups',
		NAME = 'Full Backup of SoftUni'

/* Problem 18.	Basic Insert --------------------------------------------------------------------------*/

INSERT INTO Towns (
	[Name]
)
VALUES (
	'Sofia'
),
	   (
	'Plovdiv'
),
	   (
	'Varna'
),
	   (
	'Burgas'
)

INSERT INTO Departments (
	[Name]
)
VALUES (
	'Engineering'
),
	   (
	'Sales'
),
	   (
	'Marketing'
),
	   (
	'Software Development'
),
	   (
	'Quality Assurance'
)

INSERT INTO Employees (
	FirstName, MiddleName, LastName,
	JobTitle,
	DepartmentID,
	HireDate,
	Salary
)
VALUES (
	'Ivan', 'Ivanov', 'Ivanov',
	'.NET Developer',
	'Software Development',
	'02/01/2013',
	3500.00
),
	  (
	'Petar', 'Petrov', 'Petrov',
	'Senior Engineer',
	'Engineering',
	'03/02/2004',
	4000.00
),
	  (
	'Maria', 'Petrova', 'Ivanova',
	'Intern',
	'Quality Assurance',
	'08/28/2016',
	525.25
),
	  (
	'Georgi', 'Teziev', 'Ivanov',
	'CEO',
	'Sales',
	'12/09/2007',
	3000.00
),
	  (
	'Peter', 'Pan', 'Pan',
	'Intern',
	'Marketing',
	'08/28/2016',
	599.88
)

/* Problem 19.	Basic Select All Fields ---------------------------------------------------------------*/

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

/* Problem 20.	Basic Select All Fields and Order Them ------------------------------------------------*/

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

/* Problem 21.	Basic Select Some Fields --------------------------------------------------------------*/

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

/* Problem 22.	Increase Employees Salary -------------------------------------------------------------*/

UPDATE Employees
SET Salary += (Salary * 0.1)

SELECT Salary FROM Employees

/* Problem 23.	Decrease Tax Rate ---------------------------------------------------------------------*/

USE Hotel

UPDATE Payments
SET TaxRate -= (TaxRate * 0.03)

SELECT TaxRate FROM Payments

/* Problem 24.	Delete All Records --------------------------------------------------------------------*/

USE Hotel

TRUNCATE TABLE Occupancies
