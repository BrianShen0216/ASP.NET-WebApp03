IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'UserDB')
    CREATE DATABASE UserDB
go

use UserDB
IF OBJECT_ID(N'dbo.Users', N'U') IS NOT NULL  
   DROP TABLE [dbo].Users;  
GO

create table Users (
		ID int IDENTITY(1,1) PRIMARY KEY,
        Name varchar(64) not null,
		Email varchar(64) not null,
		Password varchar(64) not null
    )
go

use UserDB

insert into Users(Name, Email, Password)
values('Tom','tom@gmail.com','pwd123')
go

insert into Users(Name, Email, Password)
values('Jerry','jerry@outlook.com','pwd456')
go

insert into Users(Name, Email, Password)
values('Lily','lily@hotmail.com','pwd789')
go