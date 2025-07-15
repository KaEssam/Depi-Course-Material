DECLARE @X INT 
SELECT @X
SET @X = 5

SELECT @X

--- 
DECLARE @ProductCount int 
SELECT @ProductCount=COUNT(*) FROM production.products
SELECT 'Total Product: ' + @ProductCount

SELECT 'Total Product: ' + CAST(@ProductCount AS varchar(20))
PRINT 'Total Product: ' + CAST(@ProductCount AS varchar(20))

SELECT

@@SERVERNAME AS server_name,

@@VERSION AS sql_version,

@@SPID AS session_id,

@@ROWCOUNT AS last_rowcount,

@@ERROR AS last_error,

SELECT @@IDENTITY AS last_identity

INSERT INTO PROJECTS(NAME)
VALUES ('TEST2')

SELECT * FROM PROJECTS

---------------------------------------


DECLARE @product_count INT;
SELECT @product_count = COUNT(*) FROM production.products WHERE list_price > 10000;

IF @product_count > 50

BEGIN
    PRINT 'High-end product catalog is well-stocked';
    PRINT 'Consider running a premium product promotion';

END
ELSE
BEGIN

    PRINT 'Limited high-end products available';
    PRINT 'Consider restocking premium items';

END

-----------------------------

-- GET CUSTOMER WITH HIS ORDERS
--- MAHMOUD 
DECLARE @CutomerID int = 5000

if @CutomerID in (select customer_id from sales.customers)
begin 
	print 'Customer Exist, orders: '
	Select  order_id, order_date
	from sales.orders
	where customer_id =  @CutomerID
end 
else
begin 
	print 'enter valid id'
end


---

-- NOURAN
DECLARE @CutomerID int = 5

if EXISTS (select 1 from sales.customers WHERE customer_id = @CutomerID)
begin 
	print 'Customer Exist, orders: '
	Select  order_id, order_date
	from sales.orders
	where customer_id =  @CutomerID
end 
else
begin 
	print 'enter valid id'
end

-- ESRAA
DECLARE @CutomerID int = 5

if  (select COUNT(*) from sales.customers WHERE customer_id = @CutomerID) > 0
begin 
	print 'Customer Exist, orders: '
	Select  order_id, order_date
	from sales.orders
	where customer_id =  @CutomerID
end 
else
begin 
	print 'enter valid id'
end

DECLARE @CutomerID int = 50000

if  (select 1 from sales.customers WHERE customer_id = @CutomerID) IS NOT NULL
begin 
	print 'Customer Exist, orders: '
	Select  order_id, order_date
	from sales.orders
	where customer_id =  @CutomerID
end 
else
begin 
	print 'enter valid id'
end


-----------------


DECLARE @X INT = 1

WHILE @X <= 10
BEGIN
	PRINT @X
	SET @X = @X+1
END



DECLARE @X INT = 10

WHILE @X <= 20
BEGIN
	SET @X = @X+1
	IF @X = 14
		CONTINUE
	PRINT @X
END

----------------------------------------

-- APPLY 10% RO OREDER ABOVE 1000
-- ORDER_ID , CUSTOMER NAME, TOTAL BEFORE , TOTAL AFTER DISCOUNT 

DECLARE @OrderID int 
DECLARE @CutomerName varchar(200)
DECLARE @TotalOrder DECIMAL (10,2)
DECLARE @DiscountedOrder DECIMAL (10,2)


-- get order id 
SELECT top 1 @OrderID = o.order_id
from sales.orders o
join sales.order_items oi on o.order_id = oi.order_id
group by o.order_id
having sum(oi.quantity * oi.list_price) > 20000

while @OrderID > 10
begin 
    -- order details

    SELECT @CutomerName = C.first_name+' ' +C.last_name,
    @TotalOrder = SUM(OI.quantity * OI.list_price)
    FROM sales.orders O 
    JOIN sales.customers C ON O.customer_id = C.customer_id
    JOIN sales.order_items OI ON O.order_id = OI.order_id
    WHERE O.order_id = @OrderID
    GROUP BY C.first_name , C.last_name


    -- APPLY DISCOUNT
    SET @DiscountedOrder = @TotalOrder * 0.9 

    PRINT 'CUSTOMER NAME: ' + @CutomerName 
    PRINT 'ORDER ID: ' + CAST(@OrderID AS VARCHAR(20))
    PRINT 'TOTAL BEFORE: ' + CAST(@TotalOrder AS VARCHAR(20))
    PRINT 'TOTAL AFTER: ' + CAST(@DiscountedOrder AS VARCHAR(20))


    SELECT top 1 @OrderID = o.order_id
    from sales.orders o
    join sales.order_items oi on o.order_id = oi.order_id
    WHERE O.order_id > @OrderID
    group by o.order_id
    having sum(oi.quantity * oi.list_price) > 20000
end






--Hager atia
DECLARE @order_id INT
DECLARE @total_before DECIMAL(10,2)
DECLARE @total_after DECIMAL(10,2)
DECLARE @customer_name NVARCHAR(100)
DECLARE @current INT = 1
DECLARE @max_id INT

SELECT @max_id = MAX(order_id) FROM sales.orders

WHILE @current <= @max_id
BEGIN
  
    SELECT @total_before = SUM(oi.quantity * oi.list_price * (1 - oi.discount))
    FROM sales.order_items oi
    WHERE oi.order_id = @current

    IF @total_before > 1000
    BEGIN
    
        SET @total_after = @total_before * 0.9

      
        SELECT @customer_name = c.first_name + ' ' + c.last_name
        FROM sales.orders o
        JOIN sales.customers c ON o.customer_id = c.customer_id
        WHERE o.order_id = @current

        PRINT 'Order ID: ' + CAST(@current AS VARCHAR)
        PRINT 'Customer: ' + @customer_name
        PRINT 'Total Before Discount: ' + CAST(@total_before AS VARCHAR)
        PRINT 'Total After Discount: ' + CAST(@total_after AS VARCHAR)
    
    END

    SET @current = @current + 1
END

--sara
SELECT
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,  
    SUM(oi.quantity * (oi.list_price - (oi.list_price * oi.discount))) AS total_before,    
    CASE 
        WHEN SUM(oi.quantity * (oi.list_price - (oi.list_price * oi.discount))) > 1000 
        THEN SUM(oi.quantity * (oi.list_price - (oi.list_price * oi.discount))) * 0.9
        ELSE SUM(oi.quantity * (oi.list_price - (oi.list_price * oi.discount)))
    END AS total_after

FROM 
    sales.orders o
JOIN 
    sales.order_items oi ON o.order_id = oi.order_id
JOIN 
    sales.customers c ON o.customer_id = c.customer_id

GROUP BY 
    o.order_id, c.first_name, c.last_name
ORDER BY 
    total_before DESC;


with my_table as (
SELECT 
c.customer_id,
count(o.order_id) as num_of_count,
SUM(i.list_price) as total_price_before
FROM sales.customers c 
join sales.orders o on c.customer_id = o.customer_id
join sales.order_items i on o.order_id = i.order_id 
group by c.customer_id)

SELECT * ,
(total_price_before - (total_price_before * 0.1)) as price_after
FROM my_table



DECLARE @customer_id INT = 1;
DECLARE @max_id INT;

SELECT @max_id = MAX(customer_id) FROM sales.customers;

WHILE @customer_id <= @max_id
BEGIN
    DECLARE @order_count INT;
    SELECT @order_count = COUNT(*) 
    FROM sales.orders
    WHERE customer_id = @customer_id;

    IF @order_count > 1000
    BEGIN
        SELECT 
            c.first_name + ' ' + c.last_name AS customer_name,
            o.order_id,
            SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS total_before,
            SUM(oi.list_price * oi.quantity * (1 - oi.discount) * 0.9) AS total_after
        FROM sales.orders o
        JOIN sales.order_items oi ON o.order_id = oi.order_id
        JOIN sales.customers c ON o.customer_id = c.customer_id
        WHERE o.customer_id = @customer_id
        GROUP BY c.first_name, c.last_name, o.order_id;
    END

    SET @customer_id = @customer_id + 1;
END;


DECLARE @CustomerID INT = 5;

IF EXISTS (
    SELECT 1
    FROM sales.orders o
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE o.customer_id = @CustomerID
    GROUP BY o.order_id
    HAVING SUM(oi.list_price) > 1000
)
BEGIN
    SELECT 
        c.customer_id,
        o.order_id,
        SUM(oi.list_price) AS total_amount,
        SUM(oi.list_price) * 0.9 AS discounted_total
    FROM sales.customers c
    JOIN sales.orders o ON c.customer_id = o.customer_id
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE c.customer_id = @CustomerID
    GROUP BY c.customer_id, o.order_id
END
ELSE
BEGIN
    SELECT 
        c.customer_id,
        o.order_id,
        SUM(oi.list_price) AS total_amount,
        SUM(oi.list_price) AS discounted_total
    FROM sales.customers c
    JOIN sales.orders o ON c.customer_id = o.customer_id
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE c.customer_id = @CustomerID
    GROUP BY c.customer_id, o.order_id
END



-----------------------------------



CREATE FUNCTION FULLNAME(@FIRSTNAME VARCHAR(255), @LASTNAME VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN 
    RETURN CONCAT(@FIRSTNAME, ' ',@LASTNAME)
END


select [dbo].[full_name]('karim','essam')

select [dbo].[full_name](first_name,last_name)
from sales.customers
where customer_id = 5

-------------------------

create function sales.get_orderID(@orderId int)
returns decimal(10,2)
as 
begin
    declare @total decimal(10,2)
    select @total =sum(oi.list_price*oi.quantity)
    from sales.orders o
    join sales.order_items oi on o.order_id = oi.order_id
    where o.order_id = @orderId
    return @total

end

select get_orderID(5)

-----------------------------------------


CREATE FUNCTION sales.GetProductsByCategory(@category_id INT)

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

select * from sales.GetProductsByCategory(1)
order by list_price


----------------------------
-- order year , total order , total spent, 

create function sales.cSummery(@CID int)
returns @cSummery table(orderYear int, totalOrder int, TotalSpent decimal(10,2),cCategory varchar(255))
as
begin 
    insert into @cSummery
    select year(o.order_date), count(*),sum(oi.quantity * oi.list_price),
    case
        when sum(oi.quantity * oi.list_price) > 5000 then 'vip'
        else 'regular'
    end
    from sales.orders o 
    join sales.order_items oi on o.order_id = oi.order_id
    where o.customer_id = @CID
    group by YEAR(o.order_date)
    return
end

select * from sales.cSummery(3)


----------------------------------------------------


CREATE PROCEDURE sales.sp_GetCustomerOrders
    @customer_id INT,
    @start_date DATE = NULL,
    @end_date DATE = NULL
AS
BEGIN
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


exec sales.sp_GetCustomerOrders 1

-------------------------


create proc sp_fixStock
@storeId int,
@productId int,
@fixStockQuntity int

as

begin
    if @fixStockQuntity <= 0
       begin
       print 'enter valid stock num'
       return
       end

    if not exists (select 1 from production.stocks where store_id = @storeId and product_id = @productId)
    begin 
        print 'product not exist in the store'
        return
    end

    if (select quantity from production.stocks where store_id = @storeId and product_id = @productId) < @fixStockQuntity
    begin
        print 'u cant fix this stock'
        return
    end

    update production.stocks
    set quantity = quantity - @fixStockQuntity
    where store_id = @storeId and product_id = @productId
end

exec sp_fixStock 1, 1, 20

select * from production.stocks where store_id=1 AND product_id = 1


---------
INDEX - TRIGGER

---- 
-- CMU => YT
-- AMR ELHELW => YT 
-- HUSSIEN NASSER => UDEMY


INDEX, ACID 
