/* 1.	Employee Address ------------------------------------------------------------------------------*/

USE SoftUni

SELECT TOP(5) e.EmployeeID,
	   e.JobTitle,
	   e.AddressID,
	   a.AddressText
	FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	ORDER BY e.AddressID

/* 2.	Addresses with Towns --------------------------------------------------------------------------*/

SELECT TOP(50) e.FirstName, 
	   e.LastName,
	   t.[Name] AS [Town],
	   a.AddressText
	FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON a.TownID = t.TownID
	ORDER BY e.FirstName, e.LastName

/* 3.	Sales Employee --------------------------------------------------------------------------------*/



/* 4.	Employee Departments --------------------------------------------------------------------------*/



/* 5.	Employees Without Project ---------------------------------------------------------------------*/

SELECT TOP(3) e.EmployeeID, e.FirstName 
	FROM Employees AS e
	LEFT OUTER JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID

/* 6.	Employees Hired After -------------------------------------------------------------------------*/



/* 7.	Employees with Project ------------------------------------------------------------------------*/

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName]
	FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects AS p
	ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

/* 8.	Employee 24 -----------------------------------------------------------------------------------*/

SELECT e.EmployeeID, e.FirstName,
	CASE
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS [ProjectName]
	FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects AS p
	ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

/* 9.	Employee Manager ------------------------------------------------------------------------------*/



/* 10. Employee Summary -------------------------------------------------------------------------------*/

SELECT TOP(50) e1.EmployeeID, 
	CONCAT(e1.FirstName, ' ', e1.LastName) AS [EmployeeName], 
	CONCAT(e2.FirstName, ' ', e2.LastName) AS [ManagerName],
	d.[Name] AS [DepartmentName]
	FROM Employees AS e1
	LEFT OUTER JOIN Employees AS e2
	ON e1.ManagerID = e2.EmployeeID
	INNER JOIN Departments AS d
	ON e1.DepartmentID = d.DepartmentID
	ORDER BY e1.EmployeeID

/* 11. Min Average Salary -----------------------------------------------------------------------------*/

SELECT MIN([Average Salary]) AS [MinAverageSalary] 
		 FROM (
				SELECT DepartmentID, AVG(Salary) AS [Average Salary] 
				FROM Employees
				GROUP BY DepartmentID
			  ) AS [AverageSalaryQuery]

/* 12. Highest Peaks in Bulgaria ----------------------------------------------------------------------*/

USE Geography

SELECT c.CountryCode,
	   m.MountainRange,
	   p.PeakName,
	   p.Elevation
	FROM Countries AS c
	INNER JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	INNER JOIN Mountains AS m
	ON mc.MountainId = m.Id
	INNER JOIN Peaks AS p
	ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation >= 2835
	ORDER BY p.Elevation DESC

/* 13. Count Mountain Ranges --------------------------------------------------------------------------*/

SELECT CountryCode, COUNT(MountainId) AS [MountainRanges] 
	FROM MountainsCountries
	WHERE CountryCode IN ('US', 'RU', 'BG')
	GROUP BY CountryCode

/* 14. Countries with Rivers --------------------------------------------------------------------------*/



/* 15. *Continents and Currencies ---------------------------------------------------------------------*/

SELECT ContinentCode, CurrencyCode, CurrencyCount AS [CurrencyUsage] 
	FROM (
		 SELECT ContinentCode, CurrencyCode, [CurrencyCount],
			 DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS [CurrencyRank]
			 FROM (
				   SELECT ContinentCode, CurrencyCode, COUNT(*) AS [CurrencyCount]
				   FROM Countries
				   GROUP BY ContinentCode, CurrencyCode
				  ) AS [CurrencyCountQuery]
		WHERE [CurrencyCount] > 1
		) AS [CurrencyRankingQuery]
	WHERE CurrencyRank = 1
	ORDER BY ContinentCode

/* 16. Countries Without Any Mountains ----------------------------------------------------------------*/



/* 17. Highest Peak and Longest River by Country ------------------------------------------------------*/

SELECT TOP(5) CountryName,
	MAX(p.Elevation) AS [Highest Peak Elevation],
	MAX(r.[Length]) AS [Longest River Length]
	FROM Countries AS c
	LEFT OUTER JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT OUTER JOIN Rivers AS r
	ON cr.RiverId = r.Id
	LEFT OUTER JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	LEFT OUTER JOIN Mountains AS m
	ON mc.MountainId = m.Id
	LEFT OUTER JOIN Peaks AS p
	ON p.MountainId = m.Id
	GROUP BY c.CountryName
	ORDER BY [Highest Peak Elevation] DESC,
			 [Longest River Length] DESC,
			 [CountryName] ASC

/* 18. Highest Peak Name and Elevation by Country -----------------------------------------------------*/

SELECT TOP(5) Country,
	   CASE
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
	   END AS [Highest Peak Name],
	   CASE
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
	   END AS [Highest Peak Elevation],
	   CASE
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
	   END AS [Mountain]
		FROM (
			SELECT *,
				DENSE_RANK() OVER(PARTITION BY [Country] ORDER BY [Elevation] DESC) AS [PeakRank]
					FROM (
						SELECT CountryName AS [Country],
							   p.PeakName,
							   p.Elevation,
							   m.MountainRange
								FROM Countries AS c
								LEFT OUTER JOIN MountainsCountries AS mc
								ON c.CountryCode = mc.CountryCode
								LEFT OUTER JOIN Mountains AS m
								ON mc.MountainId = m.Id
								LEFT OUTER JOIN Peaks AS p
								ON p.MountainId = m.Id
						) AS [FullInfoQuery]
			) AS [PeakRankingQuery]
		WHERE [PeakRank] = 1
	ORDER BY Country ASC, [Highest Peak Name] ASC