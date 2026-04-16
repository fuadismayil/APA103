--create database Company
--use Company

create table Countries(
    Id int primary key identity,
    Name nvarchar(50) not null
)

create table Cities(
    Id int primary key identity,
    Name nvarchar(50) not null,
    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

create table Employees
(
    Id int primary key identity,
    Name nvarchar(15) not null,
    Surname nvarchar(20) not null,
    Age int not null CHECK (Age >= 18 AND Age <= 65),
    Salary decimal(6, 2) not null,
    Position nvarchar(50) not null,
    IsDeleted bit not null default 0,
    CityId int foreign key references Cities(Id),
)

insert into Countries (Name) values
('Azerbaijan'),
('Turkey'),
('Germany');

insert into Cities (Name, CountryId) values
('Baku', 1),
('Ganja', 1),
('Istanbul', 2),
('Ankara', 2),
('Berlin', 3);

insert into Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId) values
('Ali', 'Mammadov', 25, 1800.00, 'Developer', 0, 1),
('Nigar', 'Aliyeva', 30, 2200.00, 'Designer', 0, 1),
('Emrah', 'Huseynov', 35, 2500.00, 'Manager', 0, 3),
('Leyla', 'Quliyeva', 28, 1900.00, 'Reseption', 0, 2),
('Rashad', 'Ismayilov', 40, 3000.00, 'Developer', 1, 4),
('Arzu', 'Babayeva', 27, 2100.00, 'Reseption', 0, 5),
('Orxan', 'Aliyev', 32, 1700.00, 'Support', 1, 2);

select e.Name, e.Surname, c.Name as City, co.Name as Country from Employees e join Cities c on e.CityId = c.Id join Countries co on c.CountryId = co.Id;

select e.Name, e.Surname, co.Name as Country from Employees e join Cities c on e.CityId = c.Id join Countries co on c.CountryId = co.Id where e.Salary > 2000;

select c.Name as City, co.Name as Country from Cities c join Countries co on c.CountryId = co.Id;

select Name, Surname, Age, Salary, Position, IsDeleted, CityId from Employees where Position = 'Reseption';

select e.Name, e.Surname, c.Name as City, co.Name as Country from Employees e join Cities c on e.CityId = c.Id join Countries co on c.CountryId = co.Id where e.IsDeleted = 1;