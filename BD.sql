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
if (Select Period from Planner where id=@b) !=0
begin
set @a = (Select Date from Planner where id=@b)
set @c =  (DATEDIFF(day,@a,GETDATE())/(Select Period from Planner where id=@b))
end;
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
end;
go
Create Procedure GetPlanner @id tinyint as
begin
Select id,'Expense'as Type,Name,Money,Date,Period from Expense where Id_user = @id and Period !=0
union 
Select id,'Income'as Type,Name,Money,Date,Period from Income where Id_user = @id and Period !=0
end
go
Create Procedure AddExpense @id tinyint,@name nvarchar(50),@money money,@desc nvarchar(50),@Period tinyint,@Jar tinyint as
INSERT INTO Expense (Id_user,Name,Money,Description,Period,Date,Jar) values(@id,@name,@money,@desc,@Period,GETDATE(),@Jar);
go
Create Procedure AddIncome @id tinyint,@name nvarchar(50),@money money,@desc nvarchar(50),@Period tinyint as
INSERT INTO Income(Id_user,Name,Money,Description,Period,Date) values(@id,@name,@money,@desc,@Period,GETDATE());
go
Create Procedure UpdateJarsExpense @id tinyint,@Money money,@Jar tinyint as
Update jars set Money = Money-@Money where Id_User = @id and Jar = @Jar
go
Create Procedure UpdateJarsIncome @id tinyint,@Money money,@Jar tinyint as
Update jars set Money = Money+@Money where Id_User = @id and Jar = @Jar
go
Create Procedure GetIncome @id tinyint as
SELECT * FROM Income where Id_user= @id
go
Create Procedure GetExpense @id tinyint as
SELECT * FROM Expense where Id_user= @id
go
Create Procedure GetSelectedJar @id tinyint, @jar int as
Select * from Jars where Id_user=@id and jar=@jar
go
Create Procedure GetLastId as
Select Max(Id) from Expense
go
Create Procedure GetUser @login nvarchar(50), @password nvarchar(50) as
Select id,name from Users where Login = @login and Password = @password
go
Create Procedure CheckLogin @login nvarchar(50) as
Select Login from Users where Login = @login
go
Create Procedure GetId @login nvarchar(50) as
Select ID from Users where Login = @login
go
Create Procedure AddJars @id tinyint, @jar int as
INSERT INTO Jars (Id_user,Jar,Money) VALUES (@id,@jar,'0')
go
Create Procedure AddUser @login nvarchar(50), @password nvarchar(50), @name nvarchar(50) as
INSERT INTO Users (Login,Password,Name) VALUES (@login, @password, @name)