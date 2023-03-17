IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'EmployeeDB')
CREATE DATABASE EmployeeDB;
GO
use EmployeeDB;
--creating EmployeeTable schema
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EmployeeTable' and xtype='U')
    CREATE TABLE EmployeeTable (
        EmployeeID int primary key identity(1,1),
		FirstName varchar(30) not null,
		LastName  varchar(30) not null,
		Designation  varchar(30) not null,
		Gender varchar(6),
		Email  varchar(40) not null,
		PhoneNumber varchar(15) not null,
		EmployeeDescription text not null,
		EmployeePicture varchar(max) not null

    )

