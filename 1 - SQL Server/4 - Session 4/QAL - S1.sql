QAL - S1
--- aggregate func


select * from production.products

-- Count all products
SELECT COUNT(*) as total_products
FROM production.products;

Select sum(list_price) as total_money
from production.products

select max(list_price)
from production.products

select min(list_price)
from production.products

select avg(list_price)
from production.products

select sum(product_name)
from production.products

select first_name+ ' ' + last_name as full_name
from sales.customers 

select CONCAT(first_name, ' ' , last_name) as full_name
from sales.customers 


-- Average quantity per order item
SELECT AVG(quantity) as avg_quantity
FROM sales.order_items;


select * from production.products

select model_year, count(*) from production.products
where list_price >= 2000
group by model_year
 
-- get all products model year  = 2024
select count(*), model_year
from production.products
where list_price >= 2000
group by model_year
having model_year >= 2022


-- Most expensive and cheapest products
SELECT
    MAX(list_price) as highest_price,
    MIN(list_price) as lowest_price,
    MAX(list_price) - MIN(list_price) as price_range,
    avg(list_price) as avg_price
FROM production.products;

--------------------------------

-- built-in 

SELECT
    first_name,
    last_name,
    LEN(first_name) as name_length,
    UPPER(first_name) as name_upper,
    LOWER(last_name) as last_name_lower,
    LEFT(first_name, 1) as first_initial,
    first_name + ' ' + last_name as full_name
FROM sales.customers

-- bouns: upper middle letter & -- Phone number formatting (baraa, ismail, ahmed)
select first_name, phone,
left(phone,3) as country_code,
upper(left(first_name,1))+ lower(right(first_name,len(first_name)-1)) as name,
'('+left(phone,3)+') '+ SUBSTRING(phone,5,3)+ '-' + right(phone,4) as new_phone
from sales.customers
where phone is not null 
-------------------------
SELECT
    product_name,
    list_price,
    ROUND(list_price, 2) as rounded_price,
    CEILING(list_price) as price_ceiling,
    FLOOR(list_price) as price_floor,
    ABS(list_price - 100) as difference_from_100
FROM production.products

-----


select COUNT(order_date), year(order_date), order_date from sales.orders
where store_id = 1 and year(order_date) = 2022
group by order_date,year(order_date),order_date
order by order_date

select COUNT(order_date)
from sales.orders
where order_date = '2022' and store_id = 1
group by order_date 


select order_date
from sales.orders
where order_date = '2022' and store_id = 1
-- Basic date operations
SELECT
    order_id,
    order_date,
    YEAR(order_date) as order_year,
    MONTH(order_date) as order_month,
    DATENAME(MONTH, order_date) as month_name,
    DATENAME(WEEKDAY, order_date) as weekday_name
FROM sales.orders
WHERE order_id <= 10;

----

-------------------------------

--join

-- inner join (join)

SELECT p.product_name , category_name, brand_name
FROM production.products p
inner join production.categories c on p.category_id = c.category_id
join production.brands b on p.brand_id = b.brand_id


SELECT * FROM production.products
where brand_id is null or category_id is null

DELETE production.brands WHERE brand_id = 37

DELETE production.categories WHERE category_id=37

select * from sales.staffs


select CONCAT(s.first_name, ' ',s.last_name) as emp_name, m.first_name+ ' ' +m.last_name as manager_name
from sales.staffs s
left join sales.staffs m on s.staff_id = m.manager_id


SELECT customer_id,phone,
       COALESCE( phone, 'No contact info') AS contact
FROM sales.customers;

SELECT *
FROM sales.customers
where phone is null or email is null



select CONCAT(s.first_name, ' ',s.last_name) as emp_name, 
COALESCE(m.first_name + ' ' +m.last_name,'No Manager') as manager_name
from sales.staffs s
left join sales.staffs m on s.staff_id = m.manager_id
order by m.staff_id

---

SELECT
    b.brand_name,
    c.category_name
FROM production.categories c
CROSS JOIN production.brands b
WHERE b.brand_id <= 5 AND c.category_id <= 5
ORDER BY b.brand_name, c.category_name;


----

-- Products above average price
SELECT product_name, list_price
FROM production.products
WHERE list_price > (
  SELECT AVG(list_price) FROM production.products
);

---

SELECT *
FROM sales.customers
WHERE customer_id IN (
  SELECT customer_id FROM sales.orders
);

-- customer + order count
SELECT first_name, last_name,count(order_id) as 'order count'
FROM sales.customers c
join sales.orders o on c.customer_id = o.customer_id
group by first_name, last_name


--get sum for count orders 
SELECT count(order_id) as 'order count'
FROM sales.customers c
join sales.orders o on c.customer_id = o.customer_id


SELECT
    product_name,
    list_price,
    (SELECT AVG(list_price) FROM production.products) as average_price
FROM production.products
WHERE list_price > (SELECT AVG(list_price) FROM production.products)
ORDER BY list_price DESC;




SELECT
    c.first_name + ' ' + c.last_name as customer_name,
    (SELECT COUNT(*) FROM sales.orders o WHERE o.customer_id = c.customer_id) as order_count
FROM sales.customers c
ORDER BY order_count DESC;

-----------

-- Simple view for customer summary
CREATE VIEW customer_summary AS
SELECT
    c.first_name + ' ' + c.last_name as 'customer name',
    c.city,
    c.state
FROM sales.customers c
WHERE state = 'CA'

select * from sales.customers

-- Use the view
SELECT * FROM customer_summary
WHERE state = 'CA'
ORDER BY 'customer name';


Delete customer_summary WHERE state = 'CA'


CREATE VIEW product_summary AS
SELECT
    c.category_name,
    COUNT(p.product_id) AS total_products,
    AVG(p.list_price) as avg_price,
    MIN(p.list_price) as min_price,
    MAX(p.list_price) as max_price
FROM production.products p
INNER JOIN production.categories c ON p.category_id = c.category_id
GROUP BY c.category_id, c.category_name;

-- Use the view
SELECT * FROM product_summary
WHERE avg_price > 100
ORDER BY avg_price DESC;

Delete from product_summary where category_name = 'Handbags & Purses'

-----------------------

-- Round prices and calculate discounts (seif allithy)
Select p.product_name,p.list_price,
ROUND(p.list_price,0) AS Rounded_price,
p.list_price -  (p.list_price * oi.discount) as price_after_discount
from production.products p
join sales.order_items oi on p.product_id = oi.product_id 

-- get staff data + store data + manager (alyaa gamal)
SELECT s.first_name + ' ' + s.last_name as staff_name,ss.store_name,
m.first_name + ' ' + m.last_name as manager_name,
s.phone,s.email
from sales.staffs s
join sales.stores ss on s.store_id = ss.store_id
join sales.staffs m on s.manager_id = m.staff_id



