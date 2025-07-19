create table emp(
	id int primary key,
	name varchar(255),
	email varchar(255)
)


insert into emp(id,name,email)
values (1,'Ahmed','Ahmed@mail.com'),
(2,'Ali','Ali@mail.com'),
(3,'mai','mai@mail.com'),
(4,'Karim','Karim@mail.com'),
(5,'Omer','Omer@mail.com')



create trigger tr_insertedEmp
on emp
after insert
as 
begin 
	
	print 'Emp inserted!!'
end


insert into emp(id,name,email)
values (6,'Ahmed','Ahmed@mail.com')


create trigger tr_perverntinsertedEmp
on emp
instead of insert
as 
begin 
	
	print 'not allowed, to insert Emp'
end


insert into emp(id,name,email)
values (7,'Ahmed','Ahmed@mail.com')

select * from emp


ALTER TABLE emp DISABLE TRIGGER tr_perverntinsertedEmp


----

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

-- Test the trigger
UPDATE sales.orders
SET order_status = 3 -- Completed
WHERE order_id = 1615;


select * from sales.orders where order_id = 1615

-- Check audit trail
SELECT * FROM sales.order_audit;

-- Enable and Disable Trigger
ALTER TABLE department DISABLE TRIGGER tr_orders_audit
ALTER TABLE department ENABLE TRIGGER tr_orders_audit


-------------

use CO
go

create trigger tr_dataEmp
on emp
after update, delete, insert
as
begin
select * from inserted
    select * from deleted

    end


insert into emp(id,name,email)
values (8,'Ahmed','Ahmed@mail.com')


update emp set name = 'marim' where id = 8


delete emp  where id = 8


----------------------------

Create Table Employees
(
	Id int primary key identity,
	Name nvarchar(50),
	Department nvarchar(50)
)
Go

SET NOCOUNT ON
Declare @counter int = 1

While(@counter <= 1000000)
Begin
	Declare @Name nvarchar(50) = 'ABC ' + RTRIM(@counter)
	Declare @Dept nvarchar(10) = 'Dept ' + RTRIM(@counter)

	Insert into Employees values (@Name, @Dept)

	Set @counter = @counter +1

	If(@Counter%100000 = 0)
		Print RTRIM(@Counter) + ' rows inserted'
End


select * from[dbo].[Employees]

select * from[dbo].[Employees] where id = 500000


select * from[dbo].[Employees] where name = 'ABC 835185'
--6.48 
-- 0.0032

create NONCLUSTERED index indx_name
on [Employees](name)