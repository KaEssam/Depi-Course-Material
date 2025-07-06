CREATE DATABASE CO
GO
use co
go
CREATE SCHEMA HR
GO 

CREATE TABLE DEPT(
DNum int IDENTITY(10,10) primary key,
DNAME VARCHAR(255) NOT NULL
)

CREATE TABLE EMP(
SSN INT PRIMARY KEY,
NAME NVARCHAR(255) NOT NULL,
SALARY DECIMAL(10,2) CHECK(SALARY > 0),
CITY VARCHAR(255) DEFAULT 'CAIRO',
GENDER CHAR(2) NOT NULL CHECK (GENDER = 'f' or gender = 'm'),
deptID int,
FOREIGN KEY (DeptId) REFERENCES dept(dnum)
on update cascade 
on delete set null

)

alter table emp
add email varchar(255) not null unique


alter table emp
alter column GENDER CHAR NOT NULL CHECK (GENDER = 'f' or gender = 'm'),

alter table emp
drop constraint FK__EMP__deptID__29572725

alter table emp 
add default 10 for deptid

alter table emp
add FOREIGN KEY  (DeptId) REFERENCES dept(dnum)
on update cascade 
on delete set default

-- insert

insert into dept(dname)
values ('CS')

SELECT * FROM DEPT

INSERT INTO EMP(SSN,NAME,GENDER,EMAIL,DEPTID,SALARY)
VALUES (1234567,'KARIM','M','EX1@MAIL.COM',20,100000),
(1234568,'KARIM','M','EX3@MAIL.COM',20,100000)

SELECT *
FROM EMP

UPDATE EMP SET DEPTID = 20 WHERE SSN =24626424 

DELETE EMP WHERE SSN = 24626424

----

use StoreDB

SELECT p.product_name as name, list_price * 1.1 as tax
FROM production.products p ;



SELECT product_name as name, list_price as tax
FROM production.products
order by list_price 
offset 30 rows fetch next 10 rows only;




SELECT top 10 *
FROM production.products
order by list_price 


SELECT DISTINCT state FROM sales.customers;



select *
from [sales].[customers]
where state = 'ny' and city = 'New York'

select *
from [sales].[customers]
where state = 'ny' or state = 'ca'



select *
from [sales].[customers]
where state in ('ny','ma','ca')






