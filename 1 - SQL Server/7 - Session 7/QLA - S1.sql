select * from emp

create trigger tr_empInserted
on emp
after insert 
as
begin 
	print 'emp inserted success'
end

insert into emp (id,name)
values (12,'ahmed')


create trigger tr_perverntEmpAction
on emp
instead of update,delete
as
begin
	select 'not allowed'
end

update emp set name = 'mai' where id = 12


select * from inserted
select * from deleted

create trigger tr_EmpAction
on emp
after update,delete
as
begin
	select 'not allowed'
end

ALTER TABLE emp DISABLE TRIGGER tr_perverntEmpAction


create trigger tr_Empinfo
on emp
after update,delete,insert
as
begin
	select * from inserted
	select * from deleted
end


insert into emp (id,name)
values (20,'karim')

update emp set name = 'ay 7aga' where id = 20

delete emp where id = 20


--------------------
use StoreDB
go 
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

-- Test the trigger

UPDATE sales.orders
SET order_status = 4 -- Completed
WHERE order_id = 1615;

-- Check audit trail
SELECT * FROM sales.order_audit;

--------------------------
use CO
go

select * from Employees


select * from Employees where id = 550000


select * from Employees where name = 'ABC 50000'
 --6.48


 CREATE CLUSTERED  INDEX IX_EMP
 on Employees(name)


