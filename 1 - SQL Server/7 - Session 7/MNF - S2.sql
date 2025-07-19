select * from emp

create trigger tr_empInsert
on emp
after insert
as 
begin 
	print 'emp inserted '
end

insert into emp(id,name,email)
values (10,'ali','ali@mail.com')



create trigger tr_emp
on emp
instead of update
as
begin
	select 'not allowed'
end


update emp set name= 'amr' where id = 10

--
-- Create audit table
CREATE TABLE sales.order_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    action_type VARCHAR(10), -- INSERT, UPDATE, DELETE
    old_status TINYINT,
    new_status TINYINT,
    changed_by VARCHAR(100),
    change_date DATETIME DEFAULT GETDATE()
);
go
-- Create trigger to audit order status changes
CREATE TRIGGER tr_orders_audit
ON sales.orders
FOR UPDATE
AS
BEGIN
    IF UPDATE(order_status)
    BEGIN
        INSERT INTO sales.order_audit (order_id, action_type, old_status, new_status, changed_by)
        SELECT
            i.order_id,
            'UPDATE',
            d.order_status,
            i.order_status,
            SYSTEM_USER
        FROM INSERTED i
        INNER JOIN DELETED d ON i.order_id = d.order_id
        WHERE i.order_status != d.order_status;
    END
END;

select * from sales.orders


-- Test the trigger
UPDATE sales.orders
SET order_status = 4 -- Completed
WHERE order_id =7 ;

-- Check audit trail
SELECT * FROM sales.order_audit;

-- Enable and Disable Trigger
ALTER TABLE emp DISABLE TRIGGER tr_emp
ALTER TABLE department ENABLE TRIGGER tr_orders_audit




insert into emp(id,name,email)
values (11,'ali','ali@mail.com')

update emp set name = 'ahmed' where id = 11

delete emp  where id = 11

----------------------------------------
+
select * from Employees where id = 555500

select * from Employees where name = 'ABC 20320'
--5.35

CREATE  NONCLUSTERED INDEX IX_EMPNAME
ON [dbo].[Employees](name)