

--CREATE DATABASE MNFS1

--DROP DATABASE MNFS1

USE MNFS1

CREATE TABLE EMPLOYEE(
	SSN INT
)

CREATE SCHEMA HR

CREATE TABLE HR.EMPLOYEE(
	SSN INT
)

DROP SCHEMA HR

DROP TABLE HR.EMPLOYEE

--

USE Depi

SELECT first_name, last_name
FROM sales.customers;

SELECT *
FROM sales.customers;


SELECT first_name, last_name,state
FROM sales.customers
WHERE STATE = 'CAIRO'



SELECT first_name, last_name,state
FROM sales.customers
WHERE STATE = 'CAIRO'
ORDER BY first_name



SELECT first_name, last_name,state
FROM sales.customers
WHERE STATE = 'CAIRO'
ORDER BY first_name DESC

SELECT * 
FROM [production].[products]
ORDER BY list_price,model_year
--


SELECT city,count(*) as city_count
FROM sales.customers
WHERE state = 'CA'
GROUP BY city
ORDER BY city_count;



SELECT city, COUNT (*)
FROM sales.customers
WHERE state = 'CA'
GROUP BY city
HAVING COUNT (*) < 10
ORDER BY city;
