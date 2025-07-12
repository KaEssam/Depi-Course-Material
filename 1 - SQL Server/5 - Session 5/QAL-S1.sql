
-- 19. Find the most expensive product in each category. Show category name, product name, and price.

SELECT TOP 1 MAX(LIST_PRICE) MAX_PRICE, product_name,category_name
FROM production.products P
JOIN production.categories C ON P.category_id = C.category_id
GROUP BY product_name,category_name
ORDER BY MAX_PRICE DESC

SELECT list_price, product_name,category_name
FROM production.products P
JOIN production.categories C ON P.category_id = C.category_id
WHERE P.list_price = (SELECT MAX(list_price) FROM production.products PP WHERE PP.category_id = C.category_id)


SELECT 
  c.category_name,
  p.product_name,
  p.list_price
FROM [production].[products] p
JOIN [production].[categories] c ON p.category_id = c.category_id
WHERE p.list_price = (
  SELECT MAX(p.list_price)
  FROM[production].[products]  p2
  WHERE p2.category_id = p.category_id)

  -- SEIF ALITHY
  select pc.category_name as [Category Name], pp.product_name as [Product Name], pp.list_price as Price
from production.products pp join production.categories pc
on pp.category_id=pc.category_id
where pp.list_price = (select max(pp2.list_price) from production.products pp2 where pp2.category_id =pp.category_id)


SELECT category_id, COUNT(*) AS total_products

FROM [production].[categories]

GROUP BY category_id

HAVING COUNT(*) > 5;


---------------
 -- nyira abdlwahab
SELECT  p.product_name,i.order_id, i.item_id
FROM production.products P
left join sales.order_items i on p.product_id = i.product_id
left join sales.orders o on o.order_id = i.order_id
where i.order_id is null


select * from MEMBERS
select * from PROJECTS


select *
from MEMBERS M 
full join PROJECTS p on m.PROJECT_ID = p.ID

----------------------------------------------

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

-- 1-PENDING 2- PROCESSING 3- REJECTED 4- COMPLETED

-- HABIBIA KHALED
SELECT
    CASE
        WHEN order_status = 4 THEN 'COMPLETED'
        WHEN order_status = 3 THEN 'REJECTED'
        WHEN order_status = 2 THEN 'PROCESSING'
        WHEN order_status = 1 THEN 'PENDING'
    END AS ORDER_CAT,
    COUNT(order_id) ORDER_COUNT
FROM sales.orders
GROUP BY order_status


SELECT
    CASE order_status
        WHEN 4 THEN 'COMPLETED'
        WHEN 3 THEN 'REJECTED'
        WHEN 2 THEN 'PROCESSING'
        WHEN 1 THEN 'PENDING'
    END AS ORDER_CAT,
    COUNT(order_id) ORDER_COUNT
FROM sales.orders
GROUP BY order_status

-- COUNT ORDER STATUS BY CATEGORY

SELECT 
    SUM(CASE WHEN order_status = 1 THEN 1 ELSE 0 END) 'PENDING',
    SUM(CASE WHEN order_status = 2 THEN 1 ELSE 0 END) 'PROCESSING',
    SUM(CASE WHEN order_status = 3 THEN 1 ELSE 0 END) 'REJECTED',
    SUM(CASE WHEN order_status = 4 THEN 1 ELSE 0 END) 'COMPLETED'
FROM sales.orders

-- 
--IIF(CONDITION, TRUE VALUE, FALSE VALUE)



SELECT 
    SUM(IIF(order_status = 1,1,0)) AS 'PENDING',
    SUM(IIF(order_status = 2,1,0)) AS 'PROCESSING',
    SUM(IIF(order_status = 3,1,0)) AS 'REJECTED',
    SUM(IIF(order_status = 4,1,0)) AS 'COMPLETED'
FROM sales.orders


-- CHOOSE
SELECT order_id, order_status,
    CHOOSE(order_status,'PENDING','PROCESSING','REGJECTED','COMPLETED')
FROM sales.orders

----------------------------------------
-- COALESCE(expression1, expression2, default)
SELECT
    customer_id,
    first_name + ' ' + last_name AS customer_name,
    phone,
    email,
    COALESCE(phone, email, 'No Contact Info') AS best_contact_method
FROM sales.customers
ORDER BY customer_id;


SELECT
    customer_id,
    first_name + ' ' + last_name AS customer_name,
    phone,
    email,
    ISNULL(phone, 'No Contact Info') AS best_contact_method
FROM sales.customers
ORDER BY customer_id;

--------------


-- HAS DISCOUNT - YES - NO
-- SOHILA
SELECT product_id,list_price, discount, IIF(discount > 0,'YES','NO') HAS_DISCOUNT
FROM sales.order_items



-----------------------------------
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



SELECT
    ep.product_name,
    b.brand_name,
    ep.list_price
FROM (SELECT
        product_name,
        list_price,
        brand_id
    FROM production.products
    WHERE list_price > 1000) ep
JOIN production.brands b ON ep.brand_id = b.brand_id
ORDER BY ep.list_price DESC;



SELECT
      c.customer_id,
      c.first_name + ' ' + c.last_name AS customer_name,
      c.city,
      customer_stats.total_orders,
      customer_stats.total_spent,
      customer_stats.avg_order_value
    FROM sales.customers c
    INNER JOIN (
      -- Subquery 1:
      SELECT
        o.customer_id,
        COUNT(DISTINCT o.order_id) AS total_orders,
        SUM(order_totals.order_value) AS total_spent,
        AVG(order_totals.order_value) AS avg_order_value
      FROM sales.orders o
      INNER JOIN (
        -- Subquery 2:
        SELECT
          oi.order_id,
          SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS order_value
        FROM sales.order_items oi
        WHERE oi.product_id IN (
          -- Subquery 3:
          SELECT p.product_id
          FROM production.products p
          WHERE p.list_price >= (
            -- Subquery 4:
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




    WITH PremiumProducts AS (
    -- CTE 1:
    SELECT p.product_id, p.product_name, p.list_price
    FROM production.products p
    WHERE p.list_price >= (
      SELECT PERCENTILE_CONT(0.8) WITHIN GROUP (ORDER BY list_price)
      FROM production.products
    )
  ),
  OrderValues AS (
    -- CTE 2:
    SELECT
      oi.order_id,
      SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS order_value
    FROM sales.order_items oi
    INNER JOIN PremiumProducts pp ON oi.product_id = pp.product_id
    GROUP BY oi.order_id
  ),
  CustomerStats AS (
    -- CTE 3:
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
  -- Final SELECT
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


  WITH CTE_NAME AS(
    SELECT * FROM production.products
  )
  SELECT * FROM CTE_NAME


------------------------------------------

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
   ROW_NUMBER() OVER (
    PARTITION BY CITY
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


select * from sales.ntile


SELECT
	v,
	NTILE (2) OVER (
		ORDER BY v
	) buckets
FROM
	sales.ntile

----------------------


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

--------------------

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


----

-- get brand num for each category

SELECT category_name, [Surly],[Trek],[Heller]
FROM (
    SELECT C.category_name,B.brand_name
    FROM production.products P
    JOIN production.categories C ON P.category_id = C.category_id
    JOIN production.brands B ON P.brand_id = B.brand_id
    WHERE B.brand_name IN ('Surly','Trek','Heller')
) T
PIVOT (COUNT(BRAND_NAME) FOR BRAND_NAME IN ([Surly],[Trek],[Heller])) AS PIVOT_TABLE

------------------------------------

-- SET OP

-- FIRST - LAST 

SELECT first_name,last_name --1445
FROM sales.customers
UNION 
SELECT first_name,last_name --10
FROM sales.staffs


SELECT first_name,last_name  --1445
FROM sales.customers
UNION  ALL
SELECT first_name,last_name --10
FROM sales.staffs



SELECT last_name  --1445
FROM sales.customers
intersect  
SELECT last_name --10
FROM sales.staffs

SELECT first_name,last_name --1445
FROM sales.customers
except 
SELECT first_name,last_name --10
FROM sales.staffs

----------------------------------------


-- cat - month - net sales

SELECT C.category_name,MONTH(O.shipped_date) MONTH_REPORT,
    SUM(I.list_price*quantity*discount) NET_SALES
FROM sales.orders O
JOIN sales.order_items I ON I.order_id = O.order_id
JOIN production.products P ON P.product_id = I.product_id
JOIN production.categories C ON P.category_id = C.category_id
WHERE YEAR(shipped_date) = 2017
GROUP BY category_name, MONTH(O.shipped_date)


SELECT C.category_name,MONTH(O.shipped_date) MONTH_REPORT,
    SUM(I.list_price*quantity*(1-discount)) NET_SALES
FROM sales.orders O
JOIN sales.order_items I ON I.order_id = O.order_id
JOIN production.products P ON P.product_id = I.product_id
JOIN production.categories C ON P.category_id = C.category_id
WHERE YEAR(shipped_date) = 2017
GROUP BY category_name, MONTH(O.shipped_date)

