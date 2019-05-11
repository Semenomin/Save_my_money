use Save_My_Money;
go
create table Jars 
(
Id_user tinyint not null,
Jar_num tinyint not null check (Jar_num between 1 and 6),
Money_in_jar money not null
)
create table Income --доходы
(
Id_user tinyint not null,
Name_income nvarchar(10) not null,
Money_amount money not null,
Desc_income nvarchar(150) null,
Period_income nvarchar(20) not null,
Date_income datetime not null
)
create table Users
(
ID tinyint identity(0,1) primary key,
Login_text nvarchar(20) not null,
Password_text nvarchar(50) not null,
Name_user nvarchar(30) not null
)

