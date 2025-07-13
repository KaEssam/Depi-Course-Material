
-- habiba khaled
DECLARE @Order_id int;
DECLARE @CustomerName varchar(255);
DECLARE @TotalOrder decimal(10,2);
Declare @Discounted decimal (10,2);

select top 1 @Order_id =o.order_id
from sales.orders o
join sales.order_items oi on o.order_id = oi.order_id
group by o.order_id
having sum(oi.quantity * oi.list_price) > 500

while @Order_id <10
	BEGIN
		Select @CustomerName = CONCAT(c.first_name,' ',c.last_name),
		@TotalOrder = SUM(OI.quantity * OI.list_price)
		from sales.customers c
		join sales.orders o on o.customer_id = c.customer_id
		join sales.order_items oi on oi.order_id = o.order_id
		where o.order_id = @Order_id
		GROUP BY C.first_name,C.last_name

		SET @Discounted = @TotalOrder * 0.9

		PRINT 'CUSTOMER : '+ @CustomerName;
		PRINT 'ORDER ID: ' + CAST(@Order_id as varchar(10))
		PRINT 'Total before: ' + CAST(@TotalOrder as varchar(200))
		PRINT 'total after: ' + CAST(@Discounted as varchar(200))
		print '================================================='

		select top 1 @Order_id =o.order_id
		from sales.orders o
		join sales.order_items oi on o.order_id = oi.order_id
		where o.order_id > @Order_id
		group by o.order_id
		having sum (oi.quantity * oi.list_price) > 500
	END



-- mohamed nassar
select sc.first_name, sc.last_name, (soi.list_price * soi.quantity * (1 - soi.discount)) as 'price_before_discount',
(soi.list_price * soi.quantity * (1 - soi.discount) * 0.9) as 'price_after_discount' 
from sales.customers as sc 
join sales.orders as so on sc.customer_id = so.customer_id
join sales.order_items as soi on so.order_id = soi.order_id
where (soi.list_price * soi.quantity * (1 - soi.discount)) > 500

--------------------

DECLARE @id INT = 1;
DECLARE @max_id INT;
DECLARE @name NVARCHAR(100);
DECLARE @total_before DECIMAL(10,2);
DECLARE @total_after DECIMAL(10,2);
SELECT @max_id = MAX(customer_id) FROM sales.customers;
WHILE @id <= @max_id
BEGIN
    SELECT @name = first_name + ' ' + last_name
    FROM sales.customers
    WHERE customer_id = @id;
 
    SELECT @total_before = SUM(oi.quantity * oi.list_price * (1 - oi.discount))
    FROM sales.orders o
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE o.customer_id = @id;
 
    IF @total_before IS NOT NULL
    BEGIN
        SET @total_after = IIF(@total_before > 500, @total_before * 0.9, @total_before);
 
        PRINT @name + ' | Before: ' + CAST(@total_before AS VARCHAR(10)) +
              ' | After: ' + CAST(@total_after AS VARCHAR(10));
    END
 
    SET @id += 1;
END


-----------------------

DECLARE @FIRST_NAME VARCHAR(200) = 'Karim'
DECLARE @LAST_NAME VARCHAR(200) ='Last'

DECLARE @FULL_NAME VARCHAR(200) = CONCAT(@FIRST_NAME,' ' ,@LAST_NAME)
select @FULL_NAME

--- 
create function full_name( @FIRST_NAME VARCHAR(200),@LAST_NAME VARCHAR(200))
returns varchar(200)
as
begin 
	return	CONCAT(@FIRST_NAME,' ' ,@LAST_NAME)
end


select dbo.full_name('karim','essam') as fullName


create function HELLO()
RETURNS VARCHAR(255)
AS
BEGIN

	RETURN 'HELLO'
END

SELECT dbo.HELLO()
-----------------------------

-- Function to get products by category

CREATE FUNCTION dbo.GetProductsByCategory(@category_id INT)

RETURNS TABLE
AS
RETURN
(
    SELECT
        p.product_id,
        p.product_name,
        p.list_price,
        b.brand_name,
        c.category_name
    FROM production.products p
    INNER JOIN production.brands b ON p.brand_id = b.brand_id
    INNER JOIN production.categories c ON p.category_id = c.category_id
    WHERE p.category_id = @category_id

);

-- Usage

SELECT * FROM dbo.GetProductsByCategory(3); -- Mountain Bikes


----------------------


--> ORDER YEAR - TOTAL - TOTAL SPENT - AVG - (VIP, REGULAR, PREMIUM)
SELECT YEAR(O.order_date) AS ORDER_YEAR, COUNT(*) AS TOTAL_ORDERS,
SUM(OI.quantity * OI.list_price) AS TOTAL_SPENT,
AVG (OI.quantity * OI.list_price) AS AVG_SPENT,
	CASE 
		WHEN SUM(OI.quantity * OI.list_price) > 5000 THEN 'VIP'
		WHEN SUM(OI.quantity * OI.list_price) > 5000 THEN 'PERMIUM'
		ELSE 'REGULAR'
	END AS CUSTOMER_CAT
FROM sales.orders O
JOIN sales.order_items OI ON O.order_id = OI.order_id
WHERE O.customer_id = 1
GROUP BY YEAR(O.order_date)


CREATE FUNCTION GET_CUSTOMER_SALES_SUMMARY(@CUSTOMER_ID INT)
RETURNS @SALES_SUMMARY TABLE(
ORDER_YEAR INT,
TOTAL_ORDERS INT,
TOTAL_SPENT DECIMAL(10,2),
AVG_SPENT DECIMAL(10,2),
CUSTOMER_CAT VARCHAR(20))
AS
	BEGIN
		INSERT INTO @SALES_SUMMARY
		SELECT YEAR(O.order_date) AS ORDER_YEAR, COUNT(*) AS TOTAL_ORDERS,
		SUM(OI.quantity * OI.list_price) AS TOTAL_SPENT,
		AVG (OI.quantity * OI.list_price) AS AVG_SPENT,
			CASE 
				WHEN SUM(OI.quantity * OI.list_price) > 5000 THEN 'VIP'
				WHEN SUM(OI.quantity * OI.list_price) > 5000 THEN 'PERMIUM'
				ELSE 'REGULAR'
			END AS CUSTOMER_CAT
		FROM sales.orders O
		JOIN sales.order_items OI ON O.order_id = OI.order_id
		WHERE O.customer_id = @CUSTOMER_ID
		GROUP BY YEAR(O.order_date)
		RETURN
	END

SELECT * FROM [dbo].[GET_CUSTOMER_SALES_SUMMARY](10)

-------------------------
--sp



-- Procedure to get customer order history
CREATE PROCEDURE sp_GetCustomerOrders
    @customer_id INT,
    @start_date DATE = NULL,
    @end_date DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT

        o.order_id,

        o.order_date,

        o.order_status,

        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) as order_total

    FROM sales.orders o

    INNER JOIN sales.order_items oi ON o.order_id = oi.order_id

    WHERE o.customer_id = @customer_id

        AND (@start_date IS NULL OR o.order_date >= @start_date)

        AND (@end_date IS NULL OR o.order_date <= @end_date)

    GROUP BY o.order_id, o.order_date, o.order_status

    ORDER BY o.order_date DESC;

END;



-- Usage

EXEC sp_GetCustomerOrders @customer_id = 1;

EXEC sp_GetCustomerOrders @customer_id = 1, @start_date = '2017-01-01';

------------------------------
-- store id = 1 , pid = 1 , 5 , 10,15

-- 1,1,10 => 1,1,10,5,15,done
---

create proc sp_restockProduct(
@StoreId int,
@ProductId int,
@RestockQuntity int,
@OldQuntity int =0 output ,
@NewQuntity int =0 output 
)
as 
begin
	-- validate input
	-- validate product exits in store
	-- current stock 
	-- update
	-- after update

	IF @RestockQuntity <= 0
	begin 
		print 'Error: quntity must be positive'
		return
	end

	if not exists (select 1 from production.stocks where store_id = @StoreId and product_id= @ProductId)
	begin 
		print 'Error: product not in store '
		return
	end

	select @OldQuntity = quantity
	from production.stocks
	where store_id = @StoreId and product_id =  @ProductId

	update production.stocks
	set quantity = quantity + @RestockQuntity
	where store_id = @StoreId and product_id =  @ProductId

	select @NewQuntity = quantity
	from production.stocks
	where store_id = @StoreId and product_id =  @ProductId

	print'stock restocked'
end

exec sp_restockProduct 1,1,20,0,0

select * from production.stocks where store_id = 1 and product_id=1

-- index- trigger 


select sc.first_name, sc.last_name, sum(soi.list_price * soi.quantity * (1 - soi.discount)) as 'price_before_discount',
sum(soi.list_price * soi.quantity * (1 - soi.discount)) * 0.9 as 'price_after_discount'
from sales.customers as sc
join sales.orders as so on sc.customer_id = so.customer_id
join sales.order_items as soi on so.order_id = soi.order_id
group by sc.first_name, sc.last_name
having sum(soi.list_price * soi.quantity * (1 - soi.discount)) > 500