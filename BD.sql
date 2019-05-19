use Save_My_Money;
go
create table Users --пользователи
(
ID tinyint identity(0,1) primary key,
Login nvarchar(20) not null,
Password nvarchar(50) not null,
Name nvarchar(30) not null
)
create table Jars --кувшины
(
Id_user tinyint foreign key references Users(id) not null,
Jar tinyint not null check (Jar between 1 and 6),
Money money not null
)
create table Debts --долги
(
id tinyint identity(0,1) primary key,
Id_user tinyint foreign key references Users(id) not null,
From_who nvarchar(50) not null,
Date datetime not null,
Expence money null,
Income money null,
Return_Date date null,
Jar tinyint not null check (Jar between 1 and 6),
Description nvarchar(300) null,
)

create table Expense --расходы
(
id tinyint identity(0,1) primary key,
Id_user tinyint foreign key references Users(id) not null,
Name nvarchar(50) not null,
Money money not null,
Description nvarchar(300) null,
Period tinyint not null,
Date datetime not null
)
create table Income --доходы
(
id tinyint identity(0,1) primary key,
Id_user tinyint foreign key references Users(id) not null,
Name nvarchar(50) not null,
Money money not null,
Description nvarchar(300) null,
Period tinyint not null,
Date datetime not null
)


