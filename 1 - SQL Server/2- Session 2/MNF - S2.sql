--CREATE DATABASE CO


--DROP DATABASE CO


USE CO


CREATE TABLE Department(
DNum INT IDENTITY(1,1) PRIMARY KEY,
DName VARCHAR(50),
Loction NVARCHAR(255)
)

CREATE SCHEMA HR

CREATE TABLE HR.Department(
DNum INT IDENTITY(1,1) PRIMARY KEY,
DName VARCHAR(50),
Loction NVARCHAR(255)
)

DROP SCHEMA HR

DROP TABLE HR.Department

DROP SCHEMA HR


---------------------------
USE Depi


SELECT *
FROM [sales].[customers]



SELECT first_name, last_name
FROM sales.customers;


SELECT *
FROM [sales].[customers]
WHERE city = 'GIZA'


SELECT *
FROM [sales].[customers]
WHERE city = 'GIZA'
ORDER BY first_name DESC


SELECT product_name, list_price
FROM production.products
ORDER BY list_price DESC


SELECT *
FROM sales.customers
WHERE phone IS NULL
ORDER BY first_name;


SELECT phone,email,street, COUNT(*) AS CITY_COUNT
FROM sales.customers
WHERE PHONE IS NOT NULL
GROUP BY PHONE,email,street
--HAVING COUNT(*) < 10
ORDER BY CITY_COUNT DESC

-- task 2 - 1
select *
from sales.customers
where email = 'ahmed.hassan@email.com'
