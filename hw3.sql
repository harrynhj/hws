-- HW3

USE Northwind
GO

-- List all cities that have both Employees and Customers.

SELECT DISTINCT c.City FROM Employees as e JOIN Customers c ON e.City = c.City
GO

-- List all cities that have Customers but no Employee.

--- Use sub-query

SELECT DISTINCT c.City FROM Customers c WHERE c.City NOT IN (
    SELECT DISTINCT e.City FROM Employees e
)
GO

--- Do not use sub-query

SELECT DISTINCT c.City FROM Customers c LEFT JOIN Employees e
ON c.City = e.City
WHERE e.EmployeeID IS NULL
GO

--  List all products and their total order quantities throughout all orders.

SELECT p.ProductName, SUM(od.Quantity) as [Total Sell] FROM 
[Order Details] od JOIN Products p  ON od.ProductID = p.ProductID
GROUP BY p.ProductName
GO

--  List all Customer Cities and total products ordered by that city.

SELECT c.City, SUM(od.Quantity) as [Total Sell] FROM 
(Customers c JOIN Orders o ON c.CustomerID = o.CustomerID)
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
GO

-- List all Customer Cities that have at least two customers.

SELECT c.City FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) >= 2
GO

-- List all Customer Cities that have ordered at least two different kinds of products.

SELECT c.City FROM 
(Customers c JOIN Orders o ON c.CustomerID = o.CustomerID)
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2
GO

-- List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT c.CustomerID FROM Customers c JOIN Orders o 
ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity
GO

-- List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

WITH ProductCity AS(
    SELECT od.ProductID, c.City, SUM(od.Quantity) AS CityQuantity FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID 
    GROUP BY od.ProductID,  c.City
),
RankedCities AS (
    SELECT ProductID, City, CityQuantity,
        ROW_NUMBER() OVER (PARTITION BY ProductID ORDER BY CityQuantity DESC) as RankNum 
    FROM ProductCity
),
MostQuantity AS (
    SELECT ProductID, City, CityQuantity
    FROM RankedCities
    WHERE RankNum = 1
)

SELECT TOP 5 
    od.ProductID, 
    p.ProductName, 
    SUM(od.Quantity) AS [Total Sell],  
    AVG(od.UnitPrice) AS [avg price],
    mq.City
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID 
JOIN Products p ON od.ProductID = p.ProductID
JOIN MostQuantity mq ON mq.ProductID = p.ProductID
GROUP BY od.ProductID, p.ProductName, mq.City
ORDER BY [Total Sell] DESC
GO

-- List all cities that have never ordered something but we have employees there.

--- Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (
    SELECT DISTINCT c.City
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
)
GO

--- Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN (Customers c JOIN Orders o ON c.CustomerID = o.CustomerID)
ON e.City = c.City
WHERE c.City IS NULL
GO

-- List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is

SELECT e.City FROM Employees e
WHERE e.EmployeeID = (
    SELECT TOP 1 e.EmployeeID FROM Employees e JOIN Orders o
    ON e.EmployeeID = o.EmployeeID
    GROUP BY e.EmployeeID
    ORDER BY COUNT(o.OrderID) DESC
) 



-- and also the city of most total quantity of products ordered from. (tip: join  sub-query)

SELECT TOP 1 c.City, SUM(od.Quantity) as [Total Sell] FROM 
(Customers c JOIN Orders o ON c.CustomerID = o.CustomerID)
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY [Total Sell] DESC 
GO

-- How do you remove the duplicates record of a table?

-- You can use keyword DISTINCT to remove duplicates rows in the result
-- You can also use selfjoin to find duplicate rows
-- ex:
-- DELETE t1
-- FROM extable t1 JOIN extable t2
-- ON t1.dup1 = t2.dup1 AND t1.dup2 = t2.dup2
-- WHERE t1.pk > t2.pk

