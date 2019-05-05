use Save_My_Money;
go
create table Users
(
ID tinyint identity(0,1) primary key,
Login_text nvarchar(20) not null,
Password_text nvarchar(50) not null,
Name_user nvarchar(30) not null
)

create table Income --доходы
(
Id_user tinyint foreign key references Users(ID),
Sum_money money not null,
From_who nvarchar(40) not null,
When_in date not null
)