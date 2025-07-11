-- INNER JOIN 
-- RAMEZ
SELECT B.brand_name, C.category_name, P.product_name,P.list_price
FROM production.brands B 
JOIN production.products P ON B.brand_id = P.brand_id
JOIN production.categories  C ON P.category_id = C.category_id 

--- OUTER JOIN (LEFT, RIGHT, FULL)

SELECT O.order_id, P.product_name
FROM production.products P
LEFT JOIN sales.order_items O ON P.product_id = O.product_id
WHERE order_id IS NULL


--FULL JOIN 

SELECT *
FROM MEMBERS

SELECT * FROM PROJECTS

SELECT *
FROM MEMBERS M
FULL JOIN PROJECTS P ON M.PROJECT_ID = P.ID

------------------------------------------------------
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

------------------


SELECT *
FROM sales.orders

--1 2 3 4 
-- ORDER ID - PENDING, PROCESSING, REJECTED,COMPLETED (ALI RAFAT,AMR KHALED)
SELECT order_status,
    CASE
        WHEN order_status = 1 THEN 'PENDING'
        WHEN order_status = 2 THEN 'PROCESSING'
        WHEN order_status = 3 THEN 'REJECTED'
        WHEN order_status = 4 THEN 'COMPLETED'
    END AS ORDER_STATUS,
    COUNT(order_status) ORDER_COUNT
FROM sales.orders
GROUP BY order_status


SELECT order_status,
    CASE order_status
        WHEN  1 THEN 'PENDING'
        WHEN  2 THEN 'PROCESSING'
        WHEN  3 THEN 'REJECTED'
        WHEN  4 THEN 'COMPLETED'
    END AS ORDER_STATUS,
    COUNT(order_status) ORDER_COUNT
FROM sales.orders
GROUP BY order_status

---

SELECT
    SUM(CASE WHEN order_status = 1 THEN 1 ELSE 0 END) AS 'PENDING',
    SUM(CASE WHEN order_status = 2 THEN 1 ELSE 0 END) AS 'PROCESSING',
    SUM(CASE WHEN order_status = 3 THEN 1 ELSE 0 END) AS 'REJECTED',
    SUM(CASE WHEN order_status = 4 THEN 1 ELSE 0 END) AS 'COMPLETED'
FROM sales.orders


-- IIF(CONDITION, TRUE RESULT, FALSE RESULT)

SELECT
    SUM(IIF(order_status=1,1,0)) AS 'PENDING',
    SUM(IIF(order_status=2,1,0)) AS 'PROCESSING',
    SUM(IIF(order_status=3,1,0)) AS 'REJECTED',
    SUM(IIF(order_status=4,1,0)) AS 'COMPLETED'
FROM sales.orders


SELECT order_status,
   choose(order_status,'PENDING','PROCESSING','REJECTED','COMPLETED')
FROM sales.orders
GROUP BY order_status

-------------
SELECT *,
    CASE 
        WHEN discount > 0 THEN 'YES'
        ELSE 'NO'
    END AS HAS_DISCOUNT
FROM sales.order_items

SELECT *,
  IIF(discount>0,'YES','NO') HAS_DISCOUNT
FROM sales.order_items

-------------------------------------------------------------
-- NULL
------------------------------------------------------------

-- COALESCE(expression1, expression2, default)
SELECT
    customer_id,
    first_name + ' ' + last_name AS customer_name,
    phone,
    email,
    COALESCE(phone,email, 'No Contact Info') AS best_contact_method
FROM sales.customers
ORDER BY customer_id;


SELECT
    customer_id,
    first_name + ' ' + last_name AS customer_name,
    phone,
    email,
    ISNULL(phone,email) AS best_contact_method
FROM sales.customers
ORDER BY customer_id;

--------------------------------------------
--CTE
--------------------------------------------


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


---

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
  ---------------------------------------------------


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
  category_id,
  RANK () OVER (
    PARTITION BY category_id
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


SELECT *
FROM sales.ntile


SELECT
	v,
	NTILE (4) OVER (
		ORDER BY v DESC
	) buckets
FROM
	sales.ntile


--------------------------------

-- get top 5 customer based on the orders they order 
-- full name - order count - rank 


-- mohamed abdullhamid
WITH order_counts AS (
    SELECT 
        CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
        c.customer_id,
        COUNT(o.order_id) AS to_orders,
        RANK() 
        OVER (
        ORDER BY COUNT(o.order_id) DESC) AS rank_num
    FROM sales.customers c
    JOIN sales.orders o  ON c.customer_id = o.customer_id  
    GROUP BY c.customer_id, c.first_name, c.last_name
)
SELECT *
FROM order_counts
WHERE rank_num <= 5;

----
-- ali essam
SELECT TOP 5
    full_name,
    order_count,
    customer_rank
	from(Select  C.first_name + ' ' + C.last_name AS full_name,COUNT(O.order_id) AS order_count,
    RANK() OVER (ORDER BY COUNT(O.order_id) DESC) AS customer_rank
FROM sales.customers C , sales.orders O
where C.customer_id = O.customer_id
GROUP BY C.first_name, C.last_name) As T
ORDER BY customer_rank



--- ahmed mostafa
SELECT TOP 5
    CONCAT(c.first_name, ' ', c.last_name) AS full_name,
    COUNT(o.order_id) AS order_count,
    RANK() OVER (ORDER BY COUNT(o.order_id) DESC) AS customer_rank
FROM sales.orders o
JOIN sales.customers c ON o.customer_id = c.customer_id
GROUP BY c.first_name, c.last_name
ORDER BY customer_rank;



---ramez
SELECT TOP 5
    CONCAT(c.first_name, ' ', c.last_name) AS full_name,
    COUNT(o.order_id) AS order_count,
    RANK() OVER (ORDER BY COUNT(o.order_id) DESC) AS rank
FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name
ORDER BY order_count DESC;

---

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


---------------

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



SELECT
        category_name, count(product_id)
    FROM
        production.products p
        INNER JOIN production.categories c
            ON c.category_id = p.category_id

group by category_name


---- brand - categroy - count 

select *
from (select category_name, brand_name
      from production.products P 
      join production.categories C on p.category_id = C.category_id
      join production.brands b on p.brand_id = b.brand_id
      where b.brand_name in('Trek', 'Haro', 'Electra')
) tdd
pivot(count(brand_name) for brand_name in ([Trek], [Haro], [Electra])) as pivot_table
order by category_name

------
select category_name,brand_name, count(brand_name)
      from production.products P 
      join production.categories C on p.category_id = C.category_id
      join production.brands b on p.brand_id = b.brand_id
      where b.brand_name in('Trek', 'Haro', 'Electra')
      group by category_name, brand_name

-----------------------------

SELECT first_name, last_name FROM sales.staffs --10
UNION
SELECT first_name, last_name FROM sales.customers; --1445


SELECT first_name, last_name FROM sales.staffs --10
UNION all
SELECT first_name, last_name FROM sales.customers; --1445


SELECT last_name FROM sales.staffs --10
intersect
SELECT  last_name FROM sales.customers; --1445


SELECT last_name FROM sales.staffs --10
except
SELECT  last_name FROM sales.customers; --1445