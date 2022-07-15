/* 1.	Database Design -------------------------------------------------------------------------------*/

CREATE DATABASE Airport

USE Airport

CREATE TABLE Planes (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights (
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NVARCHAR(11)
)

CREATE TABLE LuggageTypes (
	Id INT PRIMARY KEY IDENTITY,
	[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages (
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets (
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	FlightId INT REFERENCES Flights(Id) NOT NULL,
	LuggageId INT REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL
)


/* 2.	Insert ----------------------------------------------------------------------------------------*/

INSERT INTO Planes ([Name], Seats, [Range])
VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes ([Type])
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')


/* 3.	Update ----------------------------------------------------------------------------------------*/

SELECT * FROM Tickets

UPDATE Tickets
	SET Price += Price * 0.13
	WHERE FlightId IN (
						SELECT Id 
						FROM Flights
						WHERE Destination = 'Carlsbad'
					  )

/* 4.	Delete ----------------------------------------------------------------------------------------*/



DELETE 
	FROM Tickets
	WHERE FlightId IN (
						SELECT Id  
						FROM Flights
						WHERE Destination = 'Ayn Halagim'
					  )

DELETE 
	FROM Flights
	WHERE Destination = 'Ayn Halagim'

/* 5.	The "Tr" Planes -------------------------------------------------------------------------------*/

SELECT * FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id ASC, [Name] ASC, Seats ASC, [Range] ASC

/* 6.	Flight Profits --------------------------------------------------------------------------------*/

SELECT t.FlightId, 
	SUM(t.Price) AS [PriCE]
	FROM Flights AS f
	JOIN Tickets AS t ON f.Id = t.FlightId
	GROUP BY t.FlightId
	ORDER BY [Price] DESC, FlightId ASC
	

/* 7.	Passenger Trips -------------------------------------------------------------------------------*/

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [FullName], 
	   f.Origin, 
	   f.Destination
	FROM Passengers AS p
	JOIN Tickets AS t ON t.PassengerId = p.Id
	JOIN Flights AS f ON t.FlightId = f.Id
	ORDER BY [FullName], f.Origin, f.Destination


/* 8.	Non Adventures People -------------------------------------------------------------------------*/

SELECT p.FirstName, 
	   p.LastName, 
	   p.Age 
	FROM Passengers AS p
	LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
	WHERE t.PassengerId IS NULL
	ORDER BY p.Age DESC, 
			 p.FirstName, 
			 p.LastName

/* 9.	Full Info -------------------------------------------------------------------------------------*/

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [FullName], 
	   pl.[Name] AS [Plane Name], 
	   CONCAT(f.Origin, ' - ', f.Destination) AS [Trip], 
	   lt.[Type] AS [Luggage Type]
	FROM Passengers AS p
		JOIN Tickets AS t ON t.PassengerId = p.Id
		JOIN Flights AS f ON t.FlightId = f.Id
		JOIN Planes AS pl ON f.PlaneId = pl.Id
		JOIN Luggages AS l ON t.LuggageId = l.Id
		JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
		ORDER BY [FullName], 
				 pl.[Name], 
				 f.Origin, 
				 f.Destination, 
				 lt.[Type]

/* 10.	PSP -------------------------------------------------------------------------------------------*/

SELECT pl.[Name], 
	   pl.Seats,
	   COUNT(t.PassengerId) AS [Passengers Count]
	FROM Planes AS pl
		LEFT JOIN Flights AS f ON pl.Id = f.PlaneId
		LEFT JOIN Tickets AS t ON f.Id = t.FlightId
	GROUP BY pl.[Name], 
			 pl.Seats
	ORDER BY [Passengers Count] DESC, 
			 pl.[Name], 
			 pl.Seats

/* 11.	Vacation --------------------------------------------------------------------------------------*/

GO

CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(70)
AS
BEGIN
	IF (@peopleCount <= 0)
		BEGIN
			RETURN('Invalid people count!')
		END

DECLARE @flightId INT = (
							SELECT TOP(1) Id FROM Flights
								WHERE Origin = @origin AND Destination = @destination
						)
	IF (@flightId IS NULL)
		BEGIN
			RETURN('Invalid flight!')
		END

DECLARE @pricePerTicket DECIMAL(15, 2) =  (
											SELECT TOP(1) Price FROM Tickets
												WHERE FlightId = @flightId
										  )

DECLARE @totalPrice DECIMAL(24, 2) = @pricePerTicket * @peopleCount
	RETURN CONCAT('Total price ', @totalPrice)
END

/* 12.	Wrong Data ------------------------------------------------------------------------------------*/

GO

CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	UPDATE Flights
		SET DepartureTime = NULL, ArrivalTime = NULL
		WHERE DATEDIFF(SECOND, ArrivalTime, DepartureTime) < 0
END

EXEC usp_CancelFlights