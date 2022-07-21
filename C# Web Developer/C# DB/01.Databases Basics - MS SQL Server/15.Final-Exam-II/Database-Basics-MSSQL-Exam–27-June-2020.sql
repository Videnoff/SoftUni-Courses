/* 01 */

CREATE DATABASE WMS

USE WMS


CREATE TABLE Clients (
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone NVARCHAR(12) NOT NULL
)

CREATE TABLE Mechanics (
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(255) NOT NULL
)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs (
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	[Status] NVARCHAR(11) CHECK([Status] = 'Pending' OR [Status] = 'In Progress'  OR [Status] = 'Finished') DEFAULT 'Pending' NOT NULL,
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders (
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors (
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Parts (
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(255),
	Price DECIMAL(15, 2) CHECK(Price >= 0) NOT NULL,
	VendorId INT REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0 NOT NULL
)

CREATE TABLE PartsNeeded (
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity >= 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY(JobId, PartId)
)

CREATE TABLE OrderParts (
	OrderId INT REFERENCES Orders(OrderId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity >= 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY(OrderId, PartId)
)


/* 02 */

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

SELECT * FROM Vendors

/* 03 */

UPDATE Jobs
	SET MechanicId = 3
	WHERE [Status] = 'Pending'

UPDATE Jobs
	SET [Status] = 'In Progress'
	WHERE MechanicId = 3 AND [Status] = 'Pending'

/* 04 */

DELETE FROM OrderParts
	WHERE OrderId = 19

DELETE FROM Orders
	WHERE OrderId = 19

/* 05 */

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], 
	   j.[Status] AS [Status], 
	   j.IssueDate AS [IssueDate] FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	ORDER BY m.MechanicId, 
			 j.IssueDate, 
			 j.JobId

/* 06 */

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Client], 
	   DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going], 
	   j.[Status] AS [Status] 
	FROM Clients AS c
		JOIN Jobs AS j ON c.ClientId = j.ClientId
	WHERE j.[Status] <> 'Finished'
	ORDER BY [Days going] DESC, 
			 c.ClientId

/* 07 */

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], 
	   AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	FROM Mechanics AS m
		LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	WHERE j.[Status] = 'Finished'
	GROUP BY m.FirstName, m.LastName, m.MechanicId
	ORDER BY m.MechanicId

/* 08 */

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Available]
	FROM Mechanics AS m
		LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	WHERE j.[Status] <> 'In Progress' AND j.[Status] <> 'Pending'
	GROUP BY m.FirstName, m.LastName, m.MechanicId, j.[Status]
	ORDER BY m.MechanicId

	

/* 09 */

SELECT */*j.JobId AS [JobId], 
	   SUM(p.Price) AS [Total]*/ FROM Jobs AS j
		 LEFT JOIN Orders AS o ON j.JobId = o.JobId
		 LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
		 LEFT JOIN Parts AS p ON op.PartId = p.PartId
	WHERE j.[Status] = 'Finished'
	GROUP BY j.JobId
	ORDER BY [Total] DESC, 
			 j.JobId



/* 10 */

SELECT p.PartId, p.[Description], pn.Quantity AS [Required], p.StockQty AS [In Stock], CAST(o.Delivered AS INT) AS [Ordered] FROM Parts AS p
		JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
		JOIN Jobs AS j ON pn.JobId = j.JobId
		JOIN OrderParts AS op ON p.PartId = op.PartId
		JOIN Orders AS o ON op.OrderId = op.OrderId
	WHERE j.[Status] <> 'Finished' AND o.Delivered + p.StockQty < pn.Quantity
	GROUP BY p.PartId, p.[Description], pn.Quantity, p.StockQty, o.Delivered
	ORDER BY p.PartId

	SELECT * FROM Orders
/* 11 */

GO

CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @partSerialNumber NVARCHAR(100), @quantity INT)
AS
BEGIN
	
END

/* 12 */

GO

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15, 2)
AS
BEGIN
	DECLARE @job INT = (SELECT JobId FROM Jobs WHERE JobId = @jobId)
	
	

	DECLARE @totalCost DECIMAL(15, 2) = (SELECT SUM(p.Price) FROM Jobs AS j
												JOIN Orders AS o ON j.JobId = o.JobId
												JOIN OrderParts AS op ON o.OrderId = op.OrderId
												JOIN Parts AS p ON op.PartId = p.PartId
											WHERE j.JobId = @job)

	IF(@totalCost IS NULL)
		BEGIN
			RETURN 0
		END
	ELSE
	BEGIN
		RETURN @totalCost
	END
	
END
