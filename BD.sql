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
Date datetime not null,
Jar tinyint not null check (Jar between 1 and 6)
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
create table Planner --доходы
(
id tinyint identity(0,1) primary key,
Id_user tinyint foreign key references Users(id) not null,
Expense tinyint foreign key references Expense(id) null,
Income tinyint foreign key references Income(id) null,
Date datetime not null,
Period tinyint not null,
)
use Save_My_Money
go
CREATE PROCEDURE UpdatePeriod as
begin
Declare @b int = 0,
@a date,
@c int,
@d int,
@e int,
@f money,
@g int
while @b<=(Select Max(id) from Planner)
begin
set @a = (Select Date from Planner where id=@b)
set @c =  (DATEDIFF(day,@a,GETDATE())/(Select Period from Planner where id=@b))
if (Select Expense from Planner where id=@b) is not null
begin
set @d = (Select Expense from Planner where id=@b)
set @e = (Select Jar from Expense where id = @d)
set @f = (Select Money from Expense where id = @d)
set @g = (Select Id_user from Expense where id = @d)
UPDATE JARS set Money = money - @f*@c where Id_user=@g and Jar = @e;
UPDATE Planner set Date = GETDATE() where id = @b
end;
else
begin
set @d = (Select Income from Planner where id= @b)
set @e = (Select Money from Income where id = @d)
set @g = (Select Id_user from Income where id = @d)
Update Jars set Money = money + ((@e*@c)/100)*55 where Id_user = @g and Jar = 1
Update Jars set Money = money + ((@e*@c)/100)*10 where Id_user = @g and Jar = 2
Update Jars set Money = money + ((@e*@c)/100)*10 where Id_user = @g and Jar = 3
Update Jars set Money = money + ((@e*@c)/100)*10 where Id_user = @g and Jar = 4
Update Jars set Money = money + ((@e*@c)/100)*10 where Id_user = @g and Jar = 5
Update Jars set Money = money + ((@e*@c)/100)*5 where Id_user = @g and Jar = 6
UPDATE Planner set Date = GETDATE() where id = @b
end
set @b = @b+1;
end
end