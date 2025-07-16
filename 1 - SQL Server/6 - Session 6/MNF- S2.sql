DECLARE @X INT 
SET @X = 5
SELECT @X
PRINT @X


SELECT @X=COUNT(*) FROM production.products

SELECT @X
------------------------------
SELECT @@ROWCOUNT

SELECT
@@ROWCOUNT AS last_rowcount,
@@SERVERNAME AS server_name,

@@VERSION AS sql_version,

@@SPID AS session_id,
@@ERROR AS last_error,
@@IDENTITY AS last_identity


INSERT INTO PROJECTS(NAME)
VALUES ('MNF')

SELECT * FROM PROJECTS

SELECT @@IDENTITY AS last_identity

-----------------------------------------------------
DECLARE @X INT 
SELECT @X = COUNT(*) FROM production.products 
--321
IF @X < 320
BEGIN 
	PRINT 'U HAVE ALOT OF PRODUCTS :' + CAST(@X AS VARCHAR(20))
END
ELSE
BEGIN 
	PRINT 'U NEED TO RESTOCK UR PRODUCT: ' + CAST(@X AS VARCHAR(20))
END

---- 1 
-- GET CUSTOMER ORDERS 

DECLARE @CID INT = 5000

IF EXISTS (SELECT 1 FROM sales.customers WHERE customer_id = @CID)
	BEGIN 
		PRINT 'CUSTOMER EXIST, ORDERS :'
		SELECT O.order_id, O.order_date,O.order_status
 		FROM sales.orders O
		WHERE O.customer_id = @CID
	END
ELSE 
	BEGIN
		PRINT 'CUSTOMER NOT EXIST, ENTER VALID ID'
	END

----


DECLARE @CID INT = 50

IF @CID IN (SELECT customer_id FROM sales.customers)
	BEGIN 
		PRINT 'CUSTOMER EXIST, ORDERS :'
		SELECT O.order_id, O.order_date,O.order_status
 		FROM sales.orders O
		WHERE O.customer_id = @CID
	END
ELSE 
	BEGIN
		PRINT 'CUSTOMER NOT EXIST, ENTER VALID ID'
	END


----

DECLARE @CID INT = 50

IF (SELECT COUNT(*) FROM sales.customers WHERE customer_id = @CID) > 0
	BEGIN 
		PRINT 'CUSTOMER EXIST, ORDERS :'
		SELECT O.order_id, O.order_date,O.order_status
 		FROM sales.orders O
		WHERE O.customer_id = @CID
	END
ELSE 
	BEGIN
		PRINT 'CUSTOMER NOT EXIST, ENTER VALID ID'
	END

-----------------------

-- WHILE 

DECLARE @X INT = 10

WHILE @X <= 20
BEGIN
	PRINT @X
	SET @X = @X +1
END


DECLARE @X INT = 10

WHILE @X <= 20
BEGIN
	PRINT @X
	SET @X = @X +1
	IF @X = 14
		BREAK
END


DECLARE @X INT = 10

WHILE @X <= 20
BEGIN
	SET @X = @X +1
	IF @X = 14
		CONTINUE
	PRINT @X
END


-- Apply 10% discount to orders over $1000
-- OUTPUT=> ORDER ID :  , CUSTOMER NAME:  ,  TOTAL BEFORE: , TOTAL AFTER: 


-- DECLARE
DECLARE @OrderId int 
DECLARE @CustomerName varchar(255)
DECLARE @TotalBefore DECIMAL(10,2)
DECLARE @TotalAfter DECIMAL(10,2)
-- GET ORDER ID > TOTAL 1000
SELECT TOP 1  @OrderId= O.order_id 
FROM sales.orders O
JOIN sales.order_items OI ON O.order_id = OI.order_id
GROUP BY O.order_id
HAVING SUM(OI.quantity * OI.list_price) >1000


---LOOP
while @OrderId < 10
begin
-- CUSTOMER INFO
SELECT
@CustomerName =c.first_name +' '+ c.last_name,
@TotalBefore = SUM(OI.quantity * OI.list_price)
FROM sales.orders o 
join sales.customers c on o.customer_id = c.customer_id
join sales.order_items oi on o.order_id =  oi.order_id
where o.order_id = @OrderId
group by c.first_name,c.last_name

-- DISCOUNT 
set @TotalAfter = @TotalBefore * 0.9

-- print the report

print 'Order id: ' + cast(@OrderId as varchar(10))
print 'Customer Name: ' + @CustomerName
print 'Total before: ' + cast(@TotalBefore as varchar(10))
print 'Total after: ' + cast(@TotalAfter as varchar(10))
print '===================================================='

-- ORDER ID + 1

SELECT TOP 1 @OrderId = O.order_id 
FROM sales.orders O
JOIN sales.order_items OI ON O.order_id = OI.order_id
where o.order_id > @OrderId
GROUP BY O.order_id
HAVING SUM(OI.quantity * OI.list_price) >1000
end


---------------------
-- ali essam
DECLARE @Id INT = 1
DECLARE @maxx INT = (SELECT MAX(order_id) FROM [sales].[orders])
DECLARE @total_before DECIMAL(10, 2)
DECLARE @total_after DECIMAL(10, 2)
DECLARE @customer_id INT
DECLARE @customer_name VARCHAR(50)

WHILE @Id <= @maxx
BEGIN
    SELECT @customer_id = customer_id
    FROM [sales].[orders]
    WHERE order_id = @Id
    IF @customer_id IS NULL
    Begin
        SET @Id += 1
        Continue
    END
    SELECT @total_before = SUM(quantity * list_price)
    FROM [sales].[order_items]
    WHERE order_id = @Id
    IF @total_before IS NULL OR @total_before <= 10000
    BEGIN
        SET @Id += 1
        Continue
    END
    SELECT @customer_name = first_name
    FROM [sales].[customers]
    WHERE customer_id = @customer_id
    SET @total_after = @total_before * 0.9
    PRINT 'OrderID: ' + CAST(@Id AS VARCHAR(10)) +
          ', Customer: ' + @customer_name +
          ', Total Before: ' + CAST(@total_before AS VARCHAR(20)) +
          ', Total After: ' + CAST(@total_after AS VARCHAR(20))
    SET @Id += 1
END


---

-- ramez
declare @id int = 0;
declare @name varchar(200);
declare @before decimal(10,2);
declare @after decimal(10,2);

select top 1 @id = order_id from sales.orders order by order_id;

while @id is not null
begin
    select 
        @name = c.first_name + ' ' + c.last_name,
        @before = sum(oi.quantity * p.list_price)
    from sales.orders o
    join sales.customers c on o.customer_id = c.customer_id
    join sales.order_items oi on o.order_id = oi.order_id
    join production.products p on oi.product_id = p.product_id
    where o.order_id = @id
    group by c.first_name, c.last_name;

    if @before > 1000
    begin
        set @after = @before * 0.9;

        print 'order id: ' + cast(@id as varchar);
        print 'customer name: ' + @name;
        print 'total before: ' + cast(@before as varchar);
        print 'total after: ' + cast(@after as varchar);
        print '--------------------------';
    end

    select top 1 @id = order_id 
    from sales.orders 
    where order_id > @id
    order by order_id;
end

----
CREATE FUNCTION GET_FULLNAME(@FNAME VARCHAR(255), @LNAME VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN 
    RETURN @FNAME + ' ' + @LNAME
END


SELECT dbo.GET_FULLNAME('ALI','ESSAM')


select dbo.GET_FULLNAME(first_name, last_name) 
from sales.staffs
where staff_id = 1

-------------------
--> 500 , output => stander shipping 

create function shipping_info(@totalOrder decimal(10,2))
returns varchar(255)
as
begin 
    if @totalOrder > 1000
        return 'free shipping'

    return 'stander shipping'
end


create function shipping_calc(@totalOrder decimal(10,2))
returns decimal(10,2)
as
begin 
    if @totalOrder > 1000
        return 0.00

    return 70.00
end


select dbo.shipping_calc(200)
select dbo.shipping_info(200)

--> 


CREATE FUNCTION production.GetProductsByCategory(@category_id INT)

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


select * from production.GetProductsByCategory(1000)

----------------------------------
CREATE FUNCTION YEAR_SUMMERY(@YEAR INT)
RETURNS @YEAR_SUMMERY TABLE(MONTH_NUM INT, tOTAL DECIMaL(18,2)) 
AS
BEGIN 
    INSERT INTO @YEAR_SUMMERY
    SELECT MONTH(O.order_date), SUM(OI.quantity * OI.list_price)
    FROM sales.orders O
    JOIN sales.order_items OI ON O.order_id = O.order_id
    WHERE YEAR(O.order_date) = @YEAR
    GROUP BY MONTH(O.order_date)

    RETURN
END

SELECT * FROM dbo.YEAR_SUMMERY(2016)

--------------------------------------------

CREATE PROC HELLO_MNF_S1
AS
BEGIN
    PRINT 'HELLO MNF S1'
END

EXEC dbo.HELLO_MNF_S1

CREATE PROC FULLn  @FNAME VARCHAR(50), @LNAME VARCHAR(50)
AS
BEGIN
    PRINT @FNAME + ' ' + @LNAME
END

exec dbo.FULLn 'ali','essam'

--------------------------------

-- ali essam (bouns)
create proc updatePrice @discount decimal(10,2), @catID int = null, @bId int = null
as
begin 

    update production.products
    set list_price = list_price * @discount
    where category_id = @catID or category_id = null and brand_id = @bId or brand_id = null --- null

    select @@ROWCOUNT as product_updated
end


exec dbo.updatePrice 0.2

select * from production.products


--- index - trigger 
