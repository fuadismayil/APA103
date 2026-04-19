create database CompanyMM;

use CompanyMM;

create table Employees (
    EmployeeID int identity(1,1) primary key,
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    BirthDate date,
    Email nvarchar(100) unique,
    constraint CHK_BirthDate check (BirthDate <= getdate())
);

create table Projects (
    ProjectID int identity(1,1) primary key,
    ProjectName nvarchar(100) not null,
    StartDate date,
    EndDate date,
    constraint CHK_ProjectDates check (EndDate > StartDate)
);

create table EmployeeProjects (
    EmployeeID int,
    ProjectID int,
    AssignedDate date default getdate(),
    primary key (EmployeeID, ProjectID),
    foreign key (EmployeeID) references Employees(EmployeeID) on delete cascade,
    foreign key (ProjectID) references Projects(ProjectID) on delete cascade
);

insert into Employees (FirstName, LastName, BirthDate, Email) values
('Ali', 'Mammadov', '1990-05-15', 'ali.m@company.az'),
('Veli', 'Aliyev', '1992-08-20', 'veli.e@company.az'),
('Aysel', 'Hasanova', '1988-11-10', 'aysel.h@company.az'),
('Gunel', 'Huseynova', '1995-02-25', 'gunel.h@company.az'),
('Tariq', 'Qasimov', '1991-07-30', 'tariq.q@company.az');

insert into Projects (ProjectName, StartDate, EndDate) values
('Vebsayt Yenilenmesi', '2023-01-01', '2023-06-30'),
('Mobil Tetbiq', '2023-03-15', '2024-03-15'),
('Verilenler Bazasi Miqrasiyasi', '2023-05-01', '2023-12-31');

insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate) values
(1, 1, '2023-01-10'),
(1, 2, '2023-03-20'),
(1, 3, '2023-05-05'), 
(2, 1, '2023-01-15'),
(3, 2, '2023-03-25'),
(4, 3, '2023-05-10'),
(5, 1, '2023-01-20'),
(5, 2, '2023-03-25');

select * from Employees;

select * from Projects;

select e.FirstName, e.LastName, p.ProjectName, ep.AssignedDate from Employees e 
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID;

select p.ProjectName, count(ep.EmployeeID) as EmployeeCount from Projects p
left join EmployeeProjects ep on p.ProjectID = ep.ProjectID
group by p.ProjectName;

select e.FirstName, e.LastName, count(ep.ProjectID) as AssignedProjectsCount from Employees e
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
group by e.EmployeeID, e.FirstName, e.LastName
having count(ep.ProjectID) > 2;

create view EmployeeProjectView as
select e.EmployeeID, e.FirstName + ' ' + e.LastName as FullName, p.ProjectID, p.ProjectName, ep.AssignedDate from Employees e
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID;

select * from EmployeeProjectView where EmployeeID = 2;

create procedure sp_AssignEmployeeToProject @empId int, @projId int
as begin if not exists (select 1 from EmployeeProjects where EmployeeID = @empId and ProjectID = @projId)
    begin
        insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
        values (@empId, @projId, getdate());
    end
end;


create function fn_GetProjectCount(@empId int) returns int as begin
    declare @projCount int;
    select @projCount = count(*) 
    from EmployeeProjects 
    where EmployeeID = @empId;
    return @projCount;
end;


select FirstName, LastName, dbo.fn_GetProjectCount(EmployeeID) as TotalProjects 
from Employees;

exec sp_AssignEmployeeToProject @empId = 2, @projId = 3;

select * from EmployeeProjectView where EmployeeID = 2;

delete from EmployeeProjects where EmployeeID = 5;

select * from EmployeeProjects where EmployeeID = 5;