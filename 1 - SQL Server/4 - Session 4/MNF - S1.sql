USE StoreDB


---------
-- Aggragate func

-- COUNT

SELECT COUNT(*) AS PRODUCT_COUNT
FROM production.products


SELECT SUM(list_price) AS TOTAL_PRICE
FROM production.products

SELECT SUM(list_price) AS TOTAL_PRICE
FROM sales.order_items

SELECT COUNT(*) AS PRODUCT_COUNT
FROM sales.order_items


SELECT AVG(list_price) AS TOTAL_PRICE
FROM sales.order_items

SELECT MAX(product_name),MAX(list_price) 
FROM production.products

SELECT list_price
FROM production.products
WHERE product_name = 'Zara Regular Fit Chambray Shirt - Indigo'

SELECT MIN(list_price) ,MAX(list_price) 
FROM production.products


SELECT *
FROM production.products
ORDER BY list_price


SELECT *
FROM production.products
ORDER BY list_price
OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY


-----------------------
--BUILT-IN FUNC


-- STRING FUNCS

----- FORMAT (FNAME,LASTNAME )FOR CUSTOMER TO BE (FULL NAME) START WITH UPPER


SELECT first_name +' ' + last_name as full_name
FROM sales.customers

-- (Ahmed ali, mahmoud, rawan yasser)
select upper(left(first_name,1)) + LOWER(RIGHT(first_name,len(first_name)-1)) + ' ' +
upper(left(last_name,1)) + LOWER(RIGHT(last_name,len(last_name)-1)) as full_name
from sales.customers

-- (hager atia)
select upper(left(first_name,1)) + lower(SUBSTRING(first_name,2,len(first_name)-1))
from sales.customers

-- format (000) 4 - 3 (abdullah mahmoud, ahmed ibrahim, hager atia,ahmed hanea)
select phone
from sales.customers

select phone, '('+left(phone,3)+')' + SUBSTRING(phone,5,3) + '-' + RIGHT(phone,4) as phone
from sales.customers

select '('+ SUBSTRING(phone,1,3)+')'+SUBSTRING(phone,5,3)+'-'+SUBSTRING(phone,9,4)
from sales.customers

-----
-- Basic numeric operations
SELECT
    product_name,
    list_price,
    ROUND(list_price, 2) as rounded_price,
    CEILING(list_price) as price_ceiling,
    FLOOR(list_price) as price_floor,
    ABS(list_price - 100) as difference_from_100
FROM production.products
WHERE product_id <= 10;


---
--12900
Select *
from sales.orders
where YEAR(order_date) = 2023


--50
Select *
from sales.orders
where order_date = '2023'

---
-------------------------------------------------------

-- JOIN

SELECT * FROM production.products

-- inner join 
SELECT p.product_name, c.category_name,b.brand_name
FROM production.products p
inner join  production.categories c on p.category_id = c.category_id
join production.brands b on p.brand_id = b.brand_id

-- left join

--161
select * from sales.staffs
where manager_id is not null

SELECT s.first_name+' ' + s.last_name as Emp_name , 
m.first_name+' ' + m.last_name as manager_name
FROM sales.staffs s
full JOIN sales.staffs m on s.manager_id = m.staff_id

---

-- men - child - women
-- puma - nike

--  Matrix-like pairing of regions and products
SELECT
    b.brand_name,
    c.category_name
FROM production.brands b
CROSS JOIN production.categories c
WHERE b.brand_id <= 5 AND c.category_id <= 5
ORDER BY b.brand_name, c.category_name;

-- get brand with the cat


-----------------------------------------

-- Products above average price
SELECT product_name, list_price
FROM production.products
WHERE list_price > (
  SELECT AVG(list_price) FROM production.products -- 265
);


-- Customers who placed orders
SELECT *
FROM sales.customers
WHERE customer_id IN (
  SELECT customer_id FROM sales.orders
);


SELECT
    first_name + ' ' + last_name as customer_name,
    email
FROM sales.customers
WHERE customer_id IN (
    SELECT customer_id FROM sales.orders WHERE order_status = 4
)
ORDER BY customer_name;


SELECT
    c.first_name + ' ' + c.last_name as customer_name,
    (SELECT COUNT(*) FROM sales.orders o WHERE o.customer_id = c.customer_id) as order_count
FROM sales.customers c
WHERE c.customer_id <= 10
ORDER BY order_count DESC;

-----------------------

-- get product name + category name (subquery) (hager atia)

SELECT p.product_name, (
    SELECT category_name FROM production.categories C WHERE C.category_id=p.category_id) as cat
FROM production.products P


SELECT p.product_name, c.category_name
FROM production.products p
inner join  production.categories c on p.category_id = c.category_id

------------------------


-- PROUDCT NAME, CATEGORY, BRAND, PRICE, PRICE WITH TAX (2976)
CREATE VIEW PRODUCTS AS
    SELECT P.product_name AS 'PRODUCT NAME',C.category_name AS CATEGORY,B.brand_name AS BRAND,
    list_price AS PRICE, list_price * 1.15 AS 'PRICE WITH TAX'
    FROM production.products P
    JOIN production.categories C ON P.category_id = C.category_id
    JOIN production.brands B ON P.brand_id = B.brand_id


SELECT * FROM PRODUCTS
WHERE BRAND = 'Ralph Lauren'

DELETE FROM PRODUCTS WHERE BRAND = 'Ralph Lauren'

----------------------

--LEFT - RIGHT JOIN


SELECT customer_id,phone,email
FROM sales.customers;


SELECT customer_id,
       COALESCE( phone,email, 'No contact info') AS contact
FROM sales.customers;

SELECT s.first_name+' ' + s.last_name as Emp_name , 
coalesce(m.first_name+' ' + m.last_name 
,'No Manager') as manager_name
FROM sales.staffs s
left JOIN sales.staffs m on s.manager_id = m.staff_id