Create table Employee(
ID int primary key identity(1,1),
Employee_Name Varchar(150),
Employee_Email varchar(250),
Employee_Address Varchar(500),
Employee_Number varchar(50)
)
select * from Employee
insert into Employee values('Thomas Hardy','thomashardy@mail.com','89 Chairoscuro Rd,Portland,USA','(171)555-2222')
insert into Employee values('Dominique Perrier','dominiqueperrier@mail.com','obere St.57,Berlin,Germany','(313)555-5735')
insert into Employee values('Maria Anders','mariaanders@mail.com','25, rue Lauristan,Paris,France','(503)555-9931')
insert into Employee values('Fran Wilson','franwilson@mail.com','C/Araquil,67,Madrid,Spain','(204)619-5731')