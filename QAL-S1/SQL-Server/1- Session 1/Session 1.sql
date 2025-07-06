SELECT * 
FROM [production].[products]

SELECT product_name
FROM production.products

SELECT product_name, list_price
FROM production.products

SELECT * 
FROM sales.customers
WHERE state = 'Cairo'

SELECT CONCAT(first_name,' ',last_name)
FROM sales.customers
WHERE state = 'Cairo'

SELECT product_name, list_price
FROM production.products
WHERE list_price < 1000
ORDER BY list_price, product_name


SELECT *
FROM sales.customers
WHERE state = 'CA'
ORDER BY first_name DESC;


SELECT city, COUNT (*)
FROM sales.customers
WHERE state = 'CA'
GROUP BY city 
ORDER BY city;


SELECT city, COUNT (*)
FROM sales.customers
WHERE state = 'CA'
GROUP BY city
HAVING COUNT (*) > 10
ORDER BY city;

-----
SELECT model_year, product_name
FROM production.products
WHERE model_year = 2018
ORDER BY product_name DESC


SELECT model_year, count(*) as product_count
FROM production.products
WHERE category_id = 1
GROUP BY model_year
ORDER BY model_year