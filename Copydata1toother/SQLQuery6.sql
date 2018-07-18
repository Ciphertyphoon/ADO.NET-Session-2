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