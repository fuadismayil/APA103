CREATE TABLE [Departments] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Employees] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[DepartmentId] int NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) DEFAULT 'xxx',
	[Email] nvarchar(100) NOT NULL UNIQUE,
	PRIMARY KEY ([Id])
);

CREATE TABLE [EmployeeDetails] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[EmployeeId] int NOT NULL UNIQUE,
	[PhoneNumber] nvarchar(50) NOT NULL,
	[Address] nvarchar(300) NOT NULL,
	[BirthDate] date NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Roles] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL UNIQUE,
	[EmployeeId] int NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [EmployeeRoles] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[EmployeeId] int NOT NULL,
	[RoleId] int NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Projects] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(200) NOT NULL UNIQUE,
	[Description] nvarchar(1000) NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [EmployeeProjects] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[EmployeeId] int NOT NULL,
	[ProjectId] int NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [SalaryHistory] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[EmployeeId] int NOT NULL,
	[Salary] decimal(18,0) NOT NULL,
	[Currency] nvarchar(3) NOT NULL DEFAULT 'AZN',
	PRIMARY KEY ([Id])
);


ALTER TABLE [Employees] ADD CONSTRAINT [Employees_fk1] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]);
ALTER TABLE [EmployeeDetails] ADD CONSTRAINT [EmployeeDetails_fk1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]);

ALTER TABLE [EmployeeRoles] ADD CONSTRAINT [EmployeeRoles_fk1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]);

ALTER TABLE [EmployeeRoles] ADD CONSTRAINT [EmployeeRoles_fk2] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([Id]);

ALTER TABLE [EmployeeProjects] ADD CONSTRAINT [EmployeeProjects_fk1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]);

ALTER TABLE [EmployeeProjects] ADD CONSTRAINT [EmployeeProjects_fk2] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]);
ALTER TABLE [SalaryHistory] ADD CONSTRAINT [SalaryHistory_fk1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]);