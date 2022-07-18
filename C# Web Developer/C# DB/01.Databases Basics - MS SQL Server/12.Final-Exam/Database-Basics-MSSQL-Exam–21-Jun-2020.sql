CREATE DATABASE TripService

USE TripService

/* 1. Database design--------------------------------------------------------------------------------- */

CREATE TABLE Cities (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode NVARCHAR(2) CHECK(LEN(CountryCode) = 2) NOT NULL
)

CREATE TABLE Hotels (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15, 2)
)

CREATE TABLE Rooms (
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId	INT REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips (
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE /*CHECK(BookDate < ArrivalDate)*/ NOT NULL,
	ArrivalDate DATE /*CHECK(ArrivalDate < ReturnDate)*/ NOT NULL,
	ReturnDate DATE  NOT NULL,
	CancelDate DATE,
	CHECK(ReturnDate > ArrivalDate AND ArrivalDate > BookDate)
)

CREATE TABLE Accounts (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips (
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	TripId INT REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL,
	PRIMARY KEY(AccountId, TripId)
)

/* 2. Insert ------------------------------------------------------------------------------------------*/

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

/* 3. Update ------------------------------------------------------------------------------------------*/

UPDATE Rooms
	SET Price += Price * 0.14
	WHERE HotelId IN(5, 7, 9)

/* 4. Delete ------------------------------------------------------------------------------------------*/

DELETE  
	FROM AccountsTrips
	WHERE AccountId = 47

DELETE  
	FROM Accounts
	WHERE Id = 47

/* 5. EEE-Mails ---------------------------------------------------------------------------------------*/

SELECT a.FirstName, 
	   a.LastName, 
	   FORMAT(a.BirthDate, 'MM-dd-yyyy'), 
	   c.[Name] AS [Hometown],
	   a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON a.CityId = c.Id
	WHERE a.Email LIKE 'e%'
	ORDER BY c.[Name]


/* 06 */

SELECT c.[Name] AS [City], 
	   COUNT(h.Id) AS [Hotels] 
	FROM Cities AS c
		JOIN Hotels AS h ON c.Id = h.CityId
	GROUP BY c.[Name]
	ORDER BY [Hotels] DESC, 
			 c.[Name]

/* 07 */

SELECT a.Id AS [AccountId],
		CONCAT(a.FirstName, ' ', a.LastName) AS [FullName],
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [LongestTrip], 
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
	FROM Trips AS t
		JOIN AccountsTrips AS [at] ON t.Id = [at].TripId
		JOIN Accounts AS a ON [at].AccountId = a.Id
	GROUP BY a.Id, 
			 a.FirstName, 
			 a.LastName
	ORDER BY [LongestTrip] DESC, 
			 [ShortestTrip]
 		
	
/* 08 */

SELECT TOP(10) c.Id, 
			   c.[Name], 
			   c.CountryCode AS [Country], 
			   COUNT(a.Id) AS [Accounts]
	FROM Cities AS c
		JOIN Accounts AS a ON c.Id = a.CityId
	GROUP BY c.Id, c.[Name], 
			 c.CountryCode  
	ORDER BY [Accounts] DESC

/* 09 */

SELECT a.Id, 
	   a.Email, 
	   c.[Name] AS [City], 
	   COUNT(t.Id) AS [Trips] 
	FROM Accounts AS a
		JOIN Cities AS c ON a.CityId = c.Id
		JOIN AccountsTrips AS [at] ON a.Id = [at].AccountId
		JOIN Trips AS t ON [at].TripId = t.Id
		JOIN Hotels AS h ON c.Id = h.CityId
		JOIN Rooms AS r ON t.RoomId = r.Id
	WHERE a.CityId = h.CityId 
		AND [at].AccountId = a.Id 
		AND r.Id = t.RoomId 
		AND r.HotelId = h.Id
	GROUP BY a.Id, 
			 a.Email, 
			 c.[Name]
	HAVING COUNT(t.Id) >= 1
	ORDER BY [Trips] DESC, 
			 a.Id

/* 10. GDPR Violation ---------------------------------------------------------------------------------*/

SELECT t.Id,
	   CONCAT(a.FirstName, ' ', a.LastName) AS [Full Name],
	   c.[Name] AS [From],
	   (SELECT DISTINCT c.[Name] FROM Hotels AS h
			JOIN Cities AS c ON h.CityId = c.Id
			WHERE h.CityId = c.Id) AS [To]
	FROM Cities AS c
		JOIN Accounts AS a ON c.Id = a.CityId
		JOIN AccountsTrips AS [at] ON a.Id = [at].AccountId
		JOIN Trips AS t ON [at].TripId = t.Id
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
	
/* 11. Available Room ---------------------------------------------------------------------------------*/

GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	
	DECLARE @Hotel INT = (SELECT Id FROM Hotels WHERE Id = @HotelId)

	DECLARE @HotelBaseRate DECIMAL(15, 2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
	DECLARE @RoomPrice DECIMAL(15, 2) = (SELECT Price FROM Rooms AS r
												JOIN Hotels AS h ON r.HotelId = h.Id
												WHERE @HotelId = h.Id)

	DECLARE @totalRoomPrice DECIMAL(15, 2) = (@HotelBaseRate + @RoomPrice) * @People

	IF(@Hotel IS NULL)
		RETURN 'No rooms available'


	
	DECLARE @tArrivalDate DATE = (SELECT t.ArrivalDate 
						FROM Trips AS t
							JOIN Rooms AS r ON t.RoomId = r.Id
							JOIN Hotels AS h ON r.HotelId = h.Id
						WHERE t.CancelDate IS NULL AND @HotelId = h.Id)

	DECLARE @tReturnDate DATE = (SELECT t.ReturnDate 
						FROM Trips AS t
							JOIN Rooms AS r ON t.RoomId = r.Id
							JOIN Hotels AS h ON r.HotelId = h.Id
						WHERE t.CancelDate IS NULL AND @HotelId = h.Id)


	IF(@Date BETWEEN @tArrivalDate AND @tReturnDate)			
		RETURN 'No rooms available'

	DECLARE @roomsBedsCount INT = (SELECT COUNT(Beds) 
								FROM Rooms AS r
									JOIN Hotels AS h ON r.HotelId = h.Id
								WHERE @HotelId = h.Id)

	IF(@roomsBedsCount < @People)
		RETURN 'No rooms available'


	DECLARE @mostExpensiveRoom DECIMAL(15, 2) = MAX((@HotelBaseRate + @RoomPrice) * @People)

	RETURN CONCAT('Room', ' ', (SELECT TOP(1) r.Id FROM Rooms AS r
											JOIN Hotels AS h ON r.HotelId = h.Id
											WHERE @HotelId = h.Id),': ',' ',
								(SELECT [Type] FROM Rooms), ' ', '(', ' ', 
								(SELECT Beds FROM Rooms), ' ',  'beds', ' ', ')', ' ',  - '$', ' ', '{', @totalRoomPrice, '}')
END

/* 12 */

GO

CREATE PROCEDURE named usp_SwitchRoom(@[TripId] INT, @TargetRoomId INT)
AS
	DECLARE @roomToCompare INT = (SELECT Id FROM Rooms AS r
										JOIN Hotels AS h ON r.HotelId = h.Id
										WHERE h.Id = @TargetRoomId)
	IF(@TargetRoomId = ())