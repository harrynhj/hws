-- HW2

USE AdventureWorks2022
GO

-- How many products can you find in the Production.Product table?

SELECT COUNT(ProductID) as ProductCnt FROM Production.Product
GO

-- Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
-- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT DISTINCT COUNT(ProductID) as ProductCnt FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GO

-- How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts

SELECT ProductSubcategoryID, COUNT(ProductSubcategoryID) as CountedProducts FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID
GO

-- How many products that do not have a product subcategory.

SELECT DISTINCT COUNT(ProductID) as ProductCnt FROM Production.Product
WHERE ProductSubcategoryID IS NULL
GO

-- Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT SUM(Quantity) FROM Production.ProductInventory
GO

-- Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
-- ProductID    TheSum

SELECT ProductID, SUM(Quantity) as TheSum FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100
GO

-- Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
-- Shelf      ProductID    TheSum

SELECT Shelf, ProductID, SUM(Quantity) as TheSum FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100
GO

-- Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT ProductID, AVG(Quantity) as AVGQ FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID
GO
-- Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
-- ProductID   Shelf      TheAvg

SELECT ProductID, Shelf, AVG(Quantity) as TheAvg FROM Production.ProductInventory
GROUP BY ProductID, Shelf
GO

-- Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
-- ProductID   Shelf      TheAvg

SELECT ProductID, Shelf, AVG(Quantity) as TheAvg FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf
GO

-- List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
-- Color                        Class              TheCount          AvgPrice

SELECT Color, Class, COUNT(ProductID) as TheCount, AVG(ListPrice) as AvgPrice FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class
GO

-- Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
-- Country                        Province

SELECT pc.Name as Country, ps.Name as Province FROM Person.CountryRegion pc
JOIN Person.StateProvince ps
ON pc.CountryRegionCode = ps.CountryRegionCode
GO

-- Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. 
-- Join them and produce a result set similar to the following.
-- Country                        Province

SELECT pc.Name as Country, ps.Name as Province FROM Person.CountryRegion pc
JOIN Person.StateProvince ps
ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name = 'Germany' OR pc.Name = 'Canada'
GO

-- Northwnd

USE Northwind
GO

-- List all Products that has been sold at least once in last 27 years.

SELECT DISTINCT ProductID FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
WHERE od.Quantity != 0
AND o.OrderDate >= DATEADD(year, -27, GETDATE())
GO

-- List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 o.ShipPostalCode, COUNT(od.Quantity) as Quantity FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY COUNT(od.Quantity) DESC
GO

-- List top 5 locations (Zip Code) where the products sold most in last 27 years.

SELECT TOP 5 o.ShipPostalCode, COUNT(od.Quantity) as Quantity FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
AND o.OrderDate >= DATEADD(year, -27, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY COUNT(od.Quantity) DESC
GO

-- List all city names and number of customers in that city.  

WITH CityCTE
AS (
SELECT DISTINCT City FROM [Employees]
UNION
SELECT DISTINCT City FROM [Customers]
UNION
SELECT DISTINCT City FROM [Customer and Suppliers by City]
)
SELECT CityCTE.City, COUNT(c.CustomerID) as CSTCNT FROM CityCTE LEFT JOIN Customers as c
ON CityCTE.City = c.City
GROUP BY CityCTE.City
ORDER BY COUNT(c.CustomerID) DESC
GO

-- List city names which have more than 2 customers, and number of customers in that city

WITH CityCTE
AS (
SELECT DISTINCT City FROM [Employees]
UNION
SELECT DISTINCT City FROM [Customers]
UNION
SELECT DISTINCT City FROM [Customer and Suppliers by City]
)
SELECT CityCTE.City, COUNT(c.CustomerID) as CSTCNT FROM CityCTE LEFT JOIN Customers as c
ON CityCTE.City = c.City
GROUP BY CityCTE.City
HAVING COUNT(c.CustomerID) >= 2
ORDER BY COUNT(c.CustomerID) DESC
GO

-- List the names of customers who placed orders after 1/1/98 with order date.

SELECT DISTINCT o.ShipName FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
WHERE o.OrderDate >= '1998-01-01'
GO

-- List the names of all customers with most recent order dates

SELECT DISTINCT o.ShipName FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
WHERE o.OrderDate = (SELECT MAX(sub_o.OrderDate) FROM [Orders] as sub_o)
GO

--  Display the names of all customers  along with the  count of products they bought

SELECT o.ShipName, SUM(od.Quantity) as QCNT  FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
GROUP BY o.ShipName
GO

-- Display the customer ids who bought more than 100 Products with count of products.

SELECT o.CustomerID, SUM(od.Quantity) as QCNT  FROM [Orders] as o JOIN [Order Details] as od
ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
HAVING SUM(od.Quantity) > 100
GO

-- List all of the possible ways that suppliers can ship their products. Display the results as below
-- Supplier Company Name                Shipping Company Name

SELECT su.CompanyName as [Supplier Company Name], sp.CompanyName as [Shipping Company Name] 
FROM Suppliers su CROSS JOIN Shippers sp
ORDER BY su.CompanyName
GO

-- Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName FROM (
    Orders as o JOIN [Order Details] as od
    ON o.OrderID = od.OrderID
    ) JOIN Products as p
ON od.ProductID = p.ProductID
GO

-- Displays pairs of employees who have the same job title.

SELECT e1.FirstName + ' ' + e1.LastName as name1, e2.FirstName + ' ' + e2.LastName as name2, e1.Title
FROM Employees as e1 JOIN Employees as e2
ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID
GO

-- Display all the Managers who have more than 2 employees reporting to them.

SELECT e.FirstName + ' ' + e.LastName FROM Employees as e JOIN (
SELECT ReportsTo FROM Employees
GROUP BY ReportsTo
HAVING COUNT(ReportsTo) > 2) as e1 
ON e1.ReportsTo = e.EmployeeID
GO

-- Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)

SELECT cs.City, cs.CompanyName, cs.ContactName, cs.Relationship 
FROM [Customer and Suppliers by City] as cs
GO