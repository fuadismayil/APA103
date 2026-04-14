CREATE DATABASE Company
use Company

create table Employees(
EmployeeID int,
FirstName nvarchar(25),
LastName nvarchar(25),
Email nvarchar(50),
PhoneNumber nvarchar(15),
HireDate date,
JobTitle nvarchar(50),
Salary money,
Department nvarchar(50)
)

INSERT INTO Employees VALUES (1, N'Tərlan', N'Ağayev', N'tarlan@company.az', N'050-123-4567', '2019-02-15', N'Proqramçı', 2200.00, N'IT');
INSERT INTO Employees VALUES (2, N'Leyla', N'Həsənova', N'leyla@company.az', N'055-987-6543', '2021-06-10', N'IT Mütəxəssis', 1800.00, N'HR');
INSERT INTO Employees VALUES (3, N'Samir', N'Məmmədov', N'samir@gmail.com', N'070-555-4433', '2022-03-20', N'Sistem Administratoru', 2400.00, N'IT');
INSERT INTO Employees VALUES (4, N'Günel', N'Rəsulova', N'gunel@company.az', N'051-222-3344', '2018-11-25', N'Mühasib', 1200.00, N'Maliyyə');
INSERT INTO Employees VALUES (5, N'Rəşad', N'Əliyev', N'reshad@yahoo.com', N'077-888-9900', '2020-08-14', N'Marketinq Meneceri', 2600.00, N'Marketinq');

select * from Employees

select * from Employees where Salary>2000

select * from Employees where Department = N'IT'

select * from Employees order by Salary desc

select FirstName, Salary from Employees

select * from Employees where year(HireDate)>2020

select * from Employees where Email like '%company.az'

select Max(Salary) as EnYuksekMaas from Employees

select Min(Salary) as EnAsaqiMaas from Employees

select Avg(Salary) as OrtalamaMaas from Employees

select Count(*) as UmumiIsciSayi from Employees

select Sum(Salary) as ButunMaasCemi from Employees

select Department, count(*) as IsciSayi from Employees Group by Department

select Department, avg(Salary) as OrtalamaMaas from Employees Group By Department

select Department, max(Salary) as EnYuksekMaas from Employees Group by Department

select Salary from Employees where EmployeeID=1
update Employees set Salary=2800 where EmployeeID=1
select Salary from Employees where EmployeeID=1

select Salary from Employees where Department=N'IT'
update Employees set Salary=Salary*1.10 where Department=N'IT'
select Salary from Employees where Department=N'IT'

select JobTitle from Employees where Concat(FirstName,' ',LastName)=N'Leyla Həsənova'
update Employees set JobTitle=N'HR Meneceri' where Concat(FirstName,' ',LastName)=N'Leyla Həsənova'
--burda ID ya gore filterlemeliyik cunki Leyla Hesenova adinda birden cox isci ola biler
update Employees set JobTitle=N'HR Meneceri' where EmployeeID=2

delete from Employees where EmployeeID=5

delete from Employees where Salary<1500

select * from Employees where FirstName like '%a%' or FirstName like 'A%'

select * from Employees where Salary between 2000 and 2500

select * from Employees where Department in (N'Maliyyə',N'IT')


