/* 1. Records� Count ----------------------------------------------------------------------------------*/

USE Gringotts

SELECT w.FirstName, COUNT(w.FirstName) 
	FROM WizzardDeposits AS w
	GROUP BY W.FirstName

/* 2. Longest Magic Wand ------------------------------------------------------------------------------*/



/* 3. Longest Magic Wand Per Deposit Groups -----------------------------------------------------------*/

SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] 
	FROM WizzardDeposits
	GROUP BY DepositGroup

/* 4. * Smallest Deposit Group Per Magic Wand Size ----------------------------------------------------*/

SELECT TOP (2) DepositGroup 
	FROM (
		SELECT DepositGroup, AVG(MagicWandSize) AS [AverageWandSize] 
		FROM WizzardDeposits 
		GROUP BY DepositGroup) AS [AverageWandSize] 
		ORDER BY [AverageWandSize]

/* 5. Deposits Sum ------------------------------------------------------------------------------------*/

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] 
	FROM WizzardDeposits
	GROUP BY DepositGroup

/* 6. Deposits Sum for Ollivander Family --------------------------------------------------------------*/

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] 
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup

/* 7. Deposits Filter ---------------------------------------------------------------------------------*/

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] 
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

/* 8.  Deposit Charge ---------------------------------------------------------------------------------*/



/* 9. Age Groups --------------------------------------------------------------------------------------*/

SELECT CASE
		WHEN Age <= 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS [AgeGroup],
	COUNT(*) AS [WizzardsCount]
	FROM WizzardDeposits
	GROUP BY (CASE
		WHEN Age <= 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END)

/* 10. First Letter -----------------------------------------------------------------------------------*/



/* 11. Average Interest  ------------------------------------------------------------------------------*/

SELECT DepositGroup, IsDepositExpired,
	AVG(DepositInterest) AS [AverageInterst]
	FROM WizzardDeposits
	WHERE DepositStartDate > '01/01/1985'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC

/* 12. * Rich Wizard, Poor Wizard ---------------------------------------------------------------------*/

SELECT SUM([Difference]) AS [SumDifference]
	FROM (
		  SELECT FirstName as [Host Wizzard],
				 DepositAmount AS [Host Wizard Deposit],
				 LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
				 LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
				 DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
			FROM WizzardDeposits
		  ) AS [LeadQuery]
	WHERE [Guest Wizard] IS NOT NULL

/* 13. Departments Total Salaries ---------------------------------------------------------------------*/



/* 14. Employees Maximum Salaries ---------------------------------------------------------------------*/



/* 15. Employees Count Salaries -----------------------------------------------------------------------*/

USE SoftUni

SELECT * INTO EmployeesWithHighSalaries 
	FROM Employees
	WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalaries
	WHERE ManagerID = 42

UPDATE EmployeesWithHighSalaries
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID, 
	AVG(Salary) AS [AverageSalary]
	FROM EmployeesWithHighSalaries
	GROUP BY DepartmentID

/* 16. *3rd Highest Salary ----------------------------------------------------------------------------*/

SELECT DepartmentID, Salary AS [ThirdHighestSalary] 
	FROM (
		SELECT DepartmentID, Salary, 
		DENSE_RANK() OVER(PARTITION BY DepartmentID 
		ORDER BY Salary DESC) 
		AS [SalaryRank]
		FROM Employees
		GROUP BY DepartmentID, Salary)
	AS SalaryRankingsQuery
WHERE SalaryRank = 3

/* 17. **Salary Challenge -----------------------------------------------------------------------------*/

SELECT TOP(10) e1.FirstName, 
			   e1.LastName, 
			   e1.DepartmentID 
	FROM Employees AS e1
	WHERE e1.Salary > (
					   SELECT AVG(Salary) AS [AverageSalary]
					   FROM Employees AS e2
					   WHERE e2.DepartmentID = e1.DepartmentID
					   GROUP BY DepartmentID
					  )
	ORDER BY DepartmentID
