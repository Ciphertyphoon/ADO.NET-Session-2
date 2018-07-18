Create table Departments
(
     ID int primary key identity,
     Name nvarchar(50),
     Location nvarchar(50)
)
GO

Create table Employees
(
     ID int primary key identity,
     Name nvarchar(50),
     Gender nvarchar(50),
     DepartmentId int foreign key references Departments(Id)
)
GO

Insert into Departments values ('IT', 'New York')
Insert into Departments values ('HR', 'London')
Insert into Departments values ('Payroll', 'Muumbai')
GO

Insert into Employees values ('Mark', 'Male', 1)
Insert into Employees values ('John', 'Male', 1)
Insert into Employees values ('Mary', 'Female', 2)
Insert into Employees values ('Steve', 'Male', 2)
Insert into Employees values ('Ben', 'Male', 3)
GO