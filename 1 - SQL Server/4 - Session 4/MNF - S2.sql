---
--aggregate funcs
---

SELECT COUNT(*) 
FROM production.products

SELECT SUM(list_price) AS PRICE
FROM production.products

SELECT MAX(product_name)
FROM production.products

--(ABDULRHMAN AMR)
SELECT TOP 1 list_price, *
FROM production.products
ORDER BY product_name DESC 

SELECT AVG(list_price)
FROM production.products

-------------------------

SELECT first_name+' ' +last_name AS FULLNAME
FROM sales.customers

SELECT UPPER(LEFT(first_name,1))+LOWER(RIGHT(first_name,LEN(first_name)-1))+ ' ' +
UPPER(LEFT(last_name,1))+LOWER(RIGHT(last_name,LEN(last_name)-1)) as full_name
FROM sales.customers



--212-555-0001
--(3)4-3

SELECT PHONE
FROM sales.customers

--BADR HASSAN,ABDULRAHMAN AMR*2, ALI ESSAM

SELECT '('+LEFT(phone,3)+')'+SUBSTRING(phone,5,5)+'-'+RIGHT(phone,3)
FROM sales.customers

SELECT '('+LEFT(phone,3)+')'+REPLACE(SUBSTRING(phone,5,5),'-','')+'-'+RIGHT(phone,3)
FROM sales.customers


SELECT '('+LEFT(C.phone,3)+')'+'-'+Right(C.phone,Len(C.phone)-4)
FROM sales.customers C

--------------

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

-----------------------------

select *
from sales.orders
where YEAR(order_date) = 2023

select *
from sales.orders
where order_date like '2023%'

-----------------------------

-- add 7 day for order date to be shipped date for null values

select * 
from sales.orders 


update sales.orders set shipped_date = DATEADD(MONTH,7,order_date)

-- get the count days for the shipped items


Select order_date, shipped_date,DATEDIFF(DAY,order_date,shipped_date) AS DAYS
from sales.orders


SELECT COUNT(*) 
FROM sales.orders
WHERE order_date = GETDATE()


------------------------------
--join 

select * 
from production.products

SELECT *
FROM production.categories


SELECT P.product_name, C.category_name, B.brand_name
FROM production.products P
INNER JOIN production.categories C ON P.category_id = C.category_id
JOIN production.brands B ON P.brand_id = B.brand_id
ORDER BY B.brand_name, C.category_name 


SELECT P.product_name, C.category_name, B.brand_name
FROM production.products P, production.categories C, production.brands B
WHERE P.category_id = C.category_id AND P.brand_id = B.brand_id


--- 

-- MOHAMED YASSER
SELECT C.first_name,C.last_name,COUNT(O.order_id)
FROM sales.customers C
JOIN sales.orders O ON C.customer_id = O.customer_id
GROUP BY C.first_name,C.last_name 
ORDER BY COUNT(O.order_id) DESC


---- 
SELECT *
FROM sales.staffs

--------------------------

SELECT CONCAT(S.first_name,' ', S.last_name) AS STAFF_NAME,
CONCAT(M.first_name,' ', M.last_name) AS MANAGER_NAME
FROM sales.staffs S
JOIN sales.staffs M ON S.manager_id = M.staff_id 


SELECT CONCAT(S.first_name,' ', S.last_name) AS STAFF_NAME,
CONCAT(M.first_name,' ', M.last_name) AS MANAGER_NAME
FROM sales.staffs S
LEFT JOIN sales.staffs M ON S.manager_id = M.staff_id


SELECT S.first_name+' '+ S.last_name AS STAFF_NAME,
M.first_name+' '+ M.last_name AS MANAGER_NAME
FROM sales.staffs S
FULL JOIN sales.staffs M ON S.manager_id = M.staff_id

--  Matrix-like pairing of regions and products
SELECT
    b.brand_name,
    c.category_name
FROM production.brands b
CROSS JOIN production.categories c
ORDER BY b.brand_name, c.category_name;


-----------------------------------

-- All staffs with their store information (ABDULALZIZ AHMED)

SELECT S.first_name+' '+S.last_name AS FULL_NAME, S.phone,S.email, SS.store_name,SS.city
FROM sales.staffs S
JOIN sales.stores SS ON S.store_id = SS.store_id


-- Find staff members who work in the same store (YOUSRY - AMR KHALD - MOSTAFA - AHMED MOSTAFA)
 
SELECT S1.first_name+' '+S1.last_name AS STAFF1_NAME,
S2.first_name+' '+S2.last_name AS STAFF1_NAME, SS.store_name
FROM sales.staffs S1
JOIN sales.staffs S2 ON S1.store_id = S2.store_id AND S1.staff_id < S2.staff_id
JOIN sales.stores SS ON S1.store_id = SS.store_id

-- S1 -  S2 - ST
-- KARIM - YOUSRY - S1

select s1.first_name, s2.first_name ,t.store_name
from sales.staffs s1 cross join sales.stores t
 cross join  sales.staffs s2

 -------------------------

 -- Products above average price
SELECT product_name, list_price
FROM production.products
WHERE list_price > (
  SELECT AVG(list_price) FROM production.products
);

-- Customers who placed orders
SELECT *
FROM sales.customers
WHERE customer_id IN (
  SELECT customer_id FROM sales.orders
);

-- Find products more expensive than average
SELECT
    product_name,
    list_price,
    (SELECT AVG(list_price) FROM production.products) as average_price
FROM production.products
WHERE list_price > (SELECT AVG(list_price) FROM production.products)
ORDER BY list_price DESC;



-------------------------

--  Products that have never been ordered (ALAA AHMED )

SELECT *
FROM production.products
WHERE product_id NOT IN (
SELECT DISTINCT product_id
FROM sales.order_items
)

-- Brands that have products in stock (MOHAMED ATEF)

SELECT B.brand_name, COUNT(P.product_id) AS TOTAL_PRODUCTS
FROM production.brands B
JOIN production.products P ON B.brand_id = P.brand_id
WHERE EXISTS(SELECT product_id FROM production.stocks S 
WHERE S.product_id = P.product_id AND S.quantity > 0)
GROUP BY B.brand_name
ORDER BY TOTAL_PRODUCTS DESC

---

CREATE VIEW BRAND_STOCK AS 
SELECT B.brand_name, COUNT(P.product_id) AS TOTAL_PRODUCTS
FROM production.brands B
JOIN production.products P ON B.brand_id = P.brand_id
WHERE EXISTS(SELECT product_id FROM production.stocks S 
WHERE S.product_id = P.product_id AND S.quantity > 0)
GROUP BY B.brand_name


SELECT * FROM BRAND_STOCK
WHERE TOTAL_PRODUCTS > 100

DELETE BRAND_STOCK WHERE brand_name = 'Adidas'


CREATE VIEW PRODUCT_INFO AS
SELECT P.product_name AS 'PRODUCT NAME', C.category_name, B.brand_name
FROM production.products P
INNER JOIN production.categories C ON P.category_id = C.category_id
JOIN production.brands B ON P.brand_id = B.brand_id

SELECT * FROM PRODUCT_INFO
WHERE brand_name = 'Hugo Boss'

DROP VIEW PRODUCT_INFO