

DECLARE @X INT 
SELECT @X
SET @X = 100
SELECT @X

DECLARE @Y INT = 200
PRINT @Y

DECLARE @Z DECIMAL(10,2)
SELECT @Z  = list_price
FROM production.products
WHERE product_id = 10

SELECT @Z

---- 
--> TOTAL PRODUCT : 1000

DECLARE @PRODUCTCOUNT INT
SELECT @PRODUCTCOUNT = COUNT(product_id) FROM production.products
SELECT 'Total Product: ' + CAST(@PRODUCTCOUNT AS VARCHAR(20))

-----------------------

INSERT INTO PROJECTS(NAME)
VALUES('TT')
SELECT * FROM PROJECTS
SELECT

@@SERVERNAME AS server_name,

@@VERSION AS sql_version,

@@SPID AS session_id,

@@ROWCOUNT AS last_rowcount,

@@ERROR AS last_error,

@@IDENTITY AS last_identity,

@@TRANCOUNT AS transaction_count;

------------------------------------

DECLARE @product_count INT;
SELECT @product_count = COUNT(*) FROM production.products WHERE list_price > 20000;

IF @product_count > 50

	BEGIN

   		PRINT 'High-end product catalog is well-stocked';
	END
ELSE
	BEGIN
   		PRINT 'Limited high-end products available';
	END

--------------------


-- CUSTMOER VALIDATION BASED ON THE ID 

DECLARE @CHECK_ID INT =500000

IF (SELECT 1 FROM sales.customers WHERE customer_id=@CHECK_ID) = 1
	BEGIN 
		PRINT 'CUSTOMER EXIST'
	END
ELSE 
	BEGIN 
		PRINT 'CUSTOMER NOT EXIST'
	END


--
DECLARE @CHECK_ID INT =500000

IF EXISTS (SELECT 1 FROM sales.customers WHERE customer_id=@CHECK_ID)
	BEGIN 
		PRINT 'CUSTOMER EXIST'
	END
ELSE 
	BEGIN 
		PRINT 'CUSTOMER NOT EXIST'
	END

-----------------

-- CHECK IF CUSTOMER EXIST BEFORE SHOWING THEIR ORDERS


DECLARE @CHECK_ID INT =5

IF EXISTS (SELECT 1 FROM sales.customers WHERE customer_id=@CHECK_ID)
	BEGIN 
		SELECT 'CUSTOMER EXIST, ORDERS: '
		SELECT *
		FROM sales.orders 
		WHERE customer_id = @CHECK_ID
	END
ELSE 
	BEGIN 
		PRINT 'CUSTOMER ID ' + CAST(@CHECK_ID AS VARCHAR(20)) +' NOT EXIST IN DATABASE'
	END

--------------------------------
DECLARE @batch_size INT = 100;
DECLARE @rows_updated INT = 1;

WHILE @rows_updated > 0
BEGIN
    UPDATE TOP (100) production.stocks
    SET quantity = quantity + 10
    WHERE quantity < 20;
    SET @rows_updated = @@ROWCOUNT;
    PRINT 'Updated ' + CAST(@rows_updated AS VARCHAR(10)) + ' records';
END


DECLARE @X INT = 1

WHILE @X <= 10
BEGIN 
	PRINT @X
	SET @X = @X +1
	IF @X = 5
	BREAK
END


DECLARE @batch_size INT = 100;
DECLARE @rows_updated INT = 1;

IF @rows_updated > 0
BEGIN
    UPDATE TOP (100) production.stocks
    SET quantity = quantity + 10
    WHERE quantity < 20;
    SET @rows_updated = @@ROWCOUNT;
    PRINT 'Updated ' + CAST(@rows_updated AS VARCHAR(10)) + ' records';
END


------------------
-- DISCOUNT 10% FOR CUSTOMER INVOICE > 500
--------------
-- NAME - BEFORE DISCONUT AFTER DISCOUNT 

 -------------------------------------------

 -- ORDER ID - CUSTMER NAME - ORDER ITEM - DISCOUNTED

DECLARE @OrderId int
DECLARE @CustomerName varchar(255)
DECLARE @OrderTotal Decimal(10,2)
DECLARE @Discounted Decimal(10)