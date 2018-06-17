Create Table tblEmployees
(
 EmployeeId int identity primary key,
 Name nvarchar(50),
 Gender nvarchar(10),
 Salary int
) 

--Script to insert sample data. Notice, that in the insert statement we are not providing a value for EmployeeId Column.
Insert into tblEmployees values('Mike','Male',5000)
Insert into tblEmployees values('Pam','Female',3500)
Insert into tblEmployees values('John','Male',2350)
Insert into tblEmployees values('Sara','Female',5700)
Insert into tblEmployees values('Steve','Male',4890)
Insert into tblEmployees values('Sana','Female',4500)

--1. spAddEmployee stored procedure inserts a row into tblEmployees tables. 
--2. @Name, @Gender and @Salary are input parameters.
--3. @EmployeeId is an output parameter
--4. The stored procedure has got only 2 lines of code with in the body. The first line inserts a row into the tblEmployees table. The second line, gets the auto generated identity value of the  EmployeeId column.
--5. This procedure, will later be called by a dot net application.

Create Procedure spAddEmployee
@Name nvarchar(50),  
@Gender nvarchar(20),  
@Salary int,  
@EmployeeId int Out  
as  
Begin  
 Insert into tblEmployees values(@Name, @Gender, @Salary)  
 Select @EmployeeId = SCOPE_IDENTITY()  
End 

DECLARE @EmpID INT
EXECUTE spAddEmployee 'jake','Male','7600',@EmpID out
Print 'Employee ID =' + CAST(@EmpID AS nvarchar(2))

select * from tblEmployees