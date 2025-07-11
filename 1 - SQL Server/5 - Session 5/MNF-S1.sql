
-- INNER JOIN

SELECT P.product_name, P.list_price, C.category_name, B.brand_name
FROM production.products P
INNER JOIN production.categories C ON P.category_id = C.category_id
JOIN production.brands B ON P.brand_id = B.brand_id


-- OUTER JOIN (LEFT, RIGHT, FULL)

SELECT P.product_name,S.order_id
FROM production.products P
LEFT JOIN sales.order_items S ON P.product_id = S.product_id
ORDER BY S.order_id


-- RIGHT JOIN

SELECT P.product_name,S.order_id
FROM sales.order_items S
RIGHT JOIN production.products P ON P.product_id = S.product_id
ORDER BY S.order_id

-- FULL JOIN

CREATE TABLE PROJECTS(
ID INT PRIMARY KEY IDENTITY,
NAME VARCHAR(255) NOT NULL,
)

CREATE TABLE MEMBERS(
ID INT PRIMARY KEY IDENTITY,
NAME VARCHAR(255) NOT NULL,
PROJECT_ID INT,
FOREIGN KEY(PROJECT_ID) REFERENCES PROJECTS(ID)
)


INSERT INTO PROJECTS(NAME)
VALUES('CRM'),('ERP'),('BACKEND')

INSERT INTO MEMBERS(NAME,PROJECT_ID)
VALUES('Karim Essam',3),('Ahmed amr',null),('marim karim',2)


SELECT M.NAME AS MEMBER_NAME,P.NAME AS PROJECT_NAME
FROM MEMBERS M
FULL JOIN PROJECTS P ON M.PROJECT_ID = P.ID

-- SELF 

SELECT *
FROM sales.staffs


SELECT S.first_name + ' ' +  S.last_name, m.first_name + ' ' +  m.last_name
FROM sales.staffs S
JOIN sales.staffs M ON S.manager_id = M.staff_id
------------------------------------------------------------

--CASE 

SELECT
    product_name,
    list_price,
    CASE
        WHEN list_price < 500 THEN 'Budget'
        WHEN list_price BETWEEN 500 AND 1500 THEN 'Mid-Range'
        ELSE 'Premium'
    END AS price_category
FROM production.products
ORDER BY list_price;


SELECT *
FROM sales.orders

-- mahamoud abdulkarim
SELECT order_status as status,
    CASE order_status
        WHEN 1 THEN 'PENDING'
        WHEN 2 then 'processing'
        WHEN 3 then 'Rejected'
        WHEN 4 then 'Completed'
    END as order_status,
    count(order_id) order_count
FROM sales.orders
group by order_status
order by order_status

-- Hager atia
SELECT
    sum(case when order_status = 1 then 1 else 0 end) as 'pending',
    sum(case when order_status = 2 then 1 else 0 end) as 'processing', 
    sum(case when order_status = 3 then 1 else 0 end) as 'Rejected',
    sum(case when order_status = 4 then 1 else 0 end) as 'Completed'
FROM sales.orders


-- IIF

SELECT 
SUM (IIF(order_status = 1,1,0)) AS 'pending',
SUM (IIF(order_status = 2,1,0)) AS 'processing',
SUM (IIF(order_status = 3,1,0)) AS 'Rejected',
SUM (IIF(order_status = 4,1,0)) AS 'Completed'
FROM SALES.ORDERS


SELECT order_id,discount, IIF(discount>0,'YES','NO') HAS_DISCOUNT
FROM sales.order_items

----------------------
-- null

SELECT *
FROM sales.customers

SELECT
    customer_id,
    first_name + ' ' + last_name AS customer_name,
    phone,
    email,
    COALESCE(phone, email, 'No Contact Info') AS best_contact_method
FROM sales.customers
ORDER BY customer_id;


-- ISNULL
SELECT
    customer_id,
    first_name,
    last_name,
    ISNULL(phone,email) AS contact_phone
FROM sales.customers
ORDER BY customer_id;

--- 
WITH expensive_products AS (
    SELECT
        product_name,
        list_price,
        brand_id
    FROM production.products
    WHERE list_price > 1000
)

SELECT
    ep.product_name,
    b.brand_name,
    ep.list_price
FROM expensive_products ep
JOIN production.brands b ON ep.brand_id = b.brand_id
ORDER BY ep.list_price DESC;

--------------------

SELECT
    c.customer_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    c.city,
    customer_stats.total_orders,
    customer_stats.total_spent,
    customer_stats.avg_order_value
  FROM sales.customers c
  INNER JOIN (
    -- Subquery
    SELECT
      o.customer_id,
      COUNT(DISTINCT o.order_id) AS total_orders,
      SUM(order_totals.order_value) AS total_spent,
      AVG(order_totals.order_value) AS avg_order_value
    FROM sales.orders o
    INNER JOIN (
      -- Subquery
      SELECT
        oi.order_id,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS order_value
      FROM sales.order_items oi
      WHERE oi.product_id IN (
        -- Subquery
        SELECT p.product_id
        FROM production.products p
        WHERE p.list_price >= (
          -- Subquery
          SELECT PERCENTILE_CONT(0.8) WITHIN GROUP (ORDER BY list_price)
          FROM production.products
        )
      )
      GROUP BY oi.order_id
    ) AS order_totals ON o.order_id = order_totals.order_id
    WHERE o.order_status = 4 
    GROUP BY o.customer_id
    HAVING COUNT(DISTINCT o.order_id) >= 3
  ) AS customer_stats ON c.customer_id = customer_stats.customer_id
  ORDER BY customer_stats.total_spent DESC;

  ---

   WITH PremiumProducts AS (
    -- CTE 1
    SELECT p.product_id, p.product_name, p.list_price
    FROM production.products p
    WHERE p.list_price >= (
      SELECT PERCENTILE_CONT(0.8) WITHIN GROUP (ORDER BY list_price)
      FROM production.products
    )
  ),
  OrderValues AS (
    -- CTE 2
    SELECT
      oi.order_id,
      SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS order_value
    FROM sales.order_items oi
    INNER JOIN PremiumProducts pp ON oi.product_id = pp.product_id
    GROUP BY oi.order_id
  ),
  CustomerStats AS (
    -- CTE 3
    SELECT
      o.customer_id,
      COUNT(DISTINCT o.order_id) AS total_orders,
      SUM(ov.order_value) AS total_spent,
      AVG(ov.order_value) AS avg_order_value
    FROM sales.orders o
    INNER JOIN OrderValues ov ON o.order_id = ov.order_id
    WHERE o.order_status = 4 
    GROUP BY o.customer_id
    HAVING COUNT(DISTINCT o.order_id) >= 3 
  )
  -- SELECT
  SELECT
    c.customer_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    c.city,
    cs.total_orders,
    cs.total_spent,
    cs.avg_order_value
  FROM sales.customers c
  INNER JOIN CustomerStats cs ON c.customer_id = cs.customer_id
  ORDER BY cs.total_spent DESC;


  ---------------------


  SELECT
   ROW_NUMBER() OVER (
  ORDER BY first_name
   ) row_num,
   first_name,
   last_name,
   city
FROM
   sales.customers;



SELECT
  product_id,
  product_name,
  list_price
FROM
  production.products
ORDER BY List_Price desc


SELECT
  product_id,
  product_name,
  list_price,
  RANK () OVER (
    ORDER BY list_price DESC
  ) price_rank
FROM
  production.products;

SELECT
  product_id,
  product_name,
  list_price,
  DENSE_RANK () OVER (
    ORDER BY list_price DESC
  ) price_rank

FROM
  production.products;


--- top 5 rank custmers based on order count (BOUNS)

SELECT  TOP 5 S.customer_id,
    S.first_name + ' ' + S.last_name AS customer_name,
rank() over(order by count(o.customer_id)) as custmor_rank
FROM sales.customers S
join sales.orders O on s.customer_id = o.customer_id
group by s.customer_id
ORDER BY custmor_rank DESC


SELECT TOP 5
    c.customer_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    COUNT(o.order_id) AS total_orders,
    RANK() OVER (ORDER BY COUNT(o.order_id) DESC) AS rank_position
FROM sales.customers c
JOIN sales.orders o ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name
ORDER BY total_orders DESC;

-----
----

CREATE TABLE sales.ntile (
  v INT NOT NULL

);


INSERT INTO sales.ntile(v)
VALUES(1),(2),(3),(4),(5),(6),(7),(8),(9),(10);

SELECT * FROM sales.ntile;

--

SELECT
	v,
	NTILE (3) OVER (
		ORDER BY v
	) buckets
FROM
	sales.ntile;


SELECT first_name,last_name,city,
ROW_NUMBER() OVER(
PARTITION BY CITY
ORDER BY FIRST_NAME) ROW_NUM
FROM sales.customers
ORDER BY city




SELECT
    p.product_name,
    c.category_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_revenue,
    ROW_NUMBER() OVER (ORDER BY SUM(oi.quantity * oi.list_price * (1 - oi.discount)) DESC) AS row_num,
    RANK() OVER (ORDER BY SUM(oi.quantity * oi.list_price * (1 - oi.discount)) DESC) AS rank_pos,
    DENSE_RANK() OVER (ORDER BY SUM(oi.quantity * oi.list_price * (1 - oi.discount)) DESC) AS dense_rank_pos,
    NTILE(4) OVER (ORDER BY SUM(oi.quantity * oi.list_price * (1 - oi.discount)) DESC) AS quartile
FROM production.products p
JOIN sales.order_items oi ON p.product_id = oi.product_id
JOIN production.categories c ON p.category_id = c.category_id
GROUP BY p.product_id, p.product_name, c.category_name
ORDER BY total_revenue DESC;


----------------

SELECT * FROM

(
    SELECT
        category_name,
        product_id
    FROM
        production.products p
        INNER JOIN production.categories c
            ON c.category_id = p.category_id
) t
PIVOT(
    COUNT(product_id)
    FOR category_name IN (
        [Children Bicycles],
        [Comfort Bicycles],
        [Cruisers Bicycles],
        [Cyclocross Bicycles],
        [Electric Bikes],
        [Mountain Bikes],
        [Road Bikes])
) AS pivot_table;


-------
SELECT *
FROM (SELECT B.brand_name,C.category_name FROM production.products P 
JOIN production.categories C ON P.category_id = C.category_id
JOIN production.brands B ON P.brand_id = B.brand_id
WHERE B.brand_name IN ('Electra','Surly','Trek')
) B
PIVOT (COUNT (brand_name) for brand_name in ([Electra],[Surly],[Trek])) as piovt_table


----
SELECT first_name, last_name FROM sales.staffs --10
UNION
SELECT first_name, last_name FROM sales.customers; --1445



SELECT first_name, last_name FROM sales.staffs --10
UNION ALL
SELECT first_name, last_name FROM sales.customers; --1445


SELECT first_name, last_name FROM sales.staffs 
EXCEPT
SELECT first_name, last_name FROM sales.customers;

SELECT  last_name FROM sales.staffs 
INTERSECT
SELECT  last_name FROM sales.customers; 


----------
-- martina
SELECT *
FROM (
    SELECT 
        s.first_name + ' ' + s.last_name AS full_name,
        COUNT(o.order_id) AS order_count,
        RANK() OVER (ORDER BY COUNT(o.order_id) DESC) AS customer_rank
    FROM sales.customers s
    JOIN sales.orders o ON s.customer_id = o.customer_id
    GROUP BY s.customer_id, s.first_name, s.last_name
) ranked_customers
WHERE customer_rank <= 5;


-- Ahmed ali
SELECT TOP 5 s.first_name + ' ' + s.last_name as cus_name , COUNT(o.customer_id) cus_orders ,
RANK() OVER(ORDER BY COUNT(o.customer_id) DESC) as cus_rank
FROM sales.customers s
join sales.orders o on s.customer_id = o.customer_id
group by s.first_name + ' ' + s.last_name

--Esraa soliman 
SELECT 
    s.first_name + ' ' + s.last_name AS full_name,
    RANK() OVER (ORDER BY COUNT(o.order_id) DESC) AS rank
FROM sales.customers s
JOIN sales.orders o ON s.customer_id = o.customer_id
GROUP BY s.first_name, s.last_name, s.customer_id
ORDER BY COUNT(o.order_id) DESC
OFFSET 0 ROWS FETCH FIRST 5 ROWS ONLY;


-- hager atia
WITH ranked_customers AS (
    SELECT 
        c.customer_id,
        c.first_name + ' ' + c.last_name AS customer_name,
        COUNT(o.order_id) AS total_orders,
        RANK() OVER (ORDER BY COUNT(o.order_id) DESC) AS rank_position
    FROM sales.customers c
    JOIN sales.orders o ON c.customer_id = o.customer_id
    GROUP BY c.customer_id, c.first_name, c.last_name
)
SELECT *
FROM ranked_customers
WHERE rank_position <= 5;


-- karim 100 , mo 50