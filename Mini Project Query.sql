create database Mini_Project
use Mini_Project

create table Train_details(
	Tno int primary key,
	Tclass varchar(20),
	Tname varchar(20),
	TSource varchar(50),
	TDestination varchar(50),
	TotalSeat int,
	AvlSeat int,
	Tstatus varchar(20),
	Fare int
);
--insert into Train_details values (19037,'1A','Awadh Exp','Lucknow','Chennai',100,100,'Active',800);
drop table Train_details
--DROP PROCEDURE insert_train_details

create procedure insert_train_details
    @tno int,
    @tclass varchar(20),
    @tname varchar(20),
    @tsource varchar(50),
    @tdestination varchar(50),
    @totalseat int,
    @avlseat int,
    @tstatus char(1),
    @fare int
as
begin
    insert into train_details (tno, tclass, tname, tsource,TDestination, totalseat, avlseat, tstatus, fare)
    values (@tno, @tclass, @tname, @tsource, @tdestination, @totalseat, @avlseat, @tstatus, @fare);
end;


select * from Train_details
-----------------------------------------------------------------------------------------------------------

create table Booking_status(
	Bid int primary key,
	Tno int,
	class varchar(20),
	date_of_travel date,
	no_of_ticket int,
	Total_amount int,
	FOREIGN KEY (tno) REFERENCES Train_details(tno),

);

drop table Booking_status
--DROP PROCEDURE insert_booking_status

create procedure insert_booking_status
    @bid int,
    @tno int,
    @class varchar(20),
    @date_of_travel date,
    @no_of_ticket int,
    @total_amount int
as
begin
    insert into booking_status (bid, tno, class, date_of_travel, no_of_ticket, total_amount)
    values (@bid, @tno, @class, @date_of_travel, @no_of_ticket, @total_amount);
end

select * from booking_status
------------------------------------------------------------------------------------------------------------------


create table Cancelled_ticket(
	Cid int primary key,
	Tno int,
	date_of_travel date,
	no_of_ticket int,
	refund int,
	bid int
	FOREIGN KEY(bid) REFERENCES Booking_status(bid),
	FOREIGN KEY(tno) REFERENCES Train_details(tno),
);

drop table Cancelled_ticket
--DROP PROCEDURE insert_cancelled_ticket

create procedure insert_cancelled_ticket
    @cid int,
    @tno int,
    @date_of_travel date,
    @no_of_ticket int,
    @refund int
as
begin
    insert into cancelled_ticket (cid, tno, date_of_travel, no_of_ticket, refund)
    values (@cid, @tno, @date_of_travel, @no_of_ticket, @refund);
end;

select * from Cancelled_ticket
--------------------------------------------------------------------------------------------------------------------
select*from Train_details
------------------------------------------------------------------------------------------------------------------

--Creating Admin table.
Create table ADMIN_LOGIN(
	Admin_Id numeric(10) unique, 
	Admin_Name varchar(25),
	Admin_Password varchar(20) not null
	);
	INSERT INTO ADMIN_LOGIN VALUES (101, 'sanjeev', 'sanjeev@123');
--drop table Admin
--drop PROCEDURE insert_admin

create procedure insert_admin
    @admin_id numeric(10),
    @admin_name varchar(25),
    @admin_password varchar(20)
as
begin
    insert into ADMIN_LOGIN (admin_id, admin_name, admin_password)
    values (@admin_id, @admin_name, @admin_password);
end;
 
Select * from ADMIN_LOGIN
--------------------------------------------------------------------------------------------------------------------

Create table User_LogIn(
	[User_id] numeric(10) primary key,
	[User_Name] varchar(25),
	User_Age numeric(2),
	User_Password varchar(20) not null
	);

--drop table User_LogIn
--DROP PROCEDURE insert_user_login

create procedure insert_user_login
    @user_id numeric(10),
    @user_name varchar(25),
    @user_age numeric(2),
    @user_password varchar(20)
as
begin
    insert into user_login (user_id, user_name, user_age, user_password)
    values (@user_id, @user_name, @user_age, @user_password);
end;


--------------------------------------------------------------------------------------------------------------------


CREATE or alter PROCEDURE UpdateAvailableSeats (
    @trainId INT,
    @numberOfSeats INT
)
AS
BEGIN
    DECLARE @availableSeats INT;
    
    -- Retrieve the current available seats for the train
    SELECT @availableSeats = AvlSeat FROM Train_details WHERE Tno = @trainId;
    
    -- Update available seats after booking
    IF @availableSeats >= @numberOfSeats 
    BEGIN
        UPDATE Train_details
        SET AvlSeat = AvlSeat - @numberOfSeats
        WHERE Tno = @trainId;
    END
END;
--------------------------------------------------------------------------------------------------
CREATE or alter PROCEDURE CancelTableAvailableSeats (
	--@cid int,
    @trainId INT,
    @numberOfSeats INT
)
AS
BEGIN
    DECLARE @availableSeats INT;
    
    -- Retrieve the current available seats for the train
    SELECT @availableSeats = AvlSeat FROM Train_details WHERE Tno = @trainId;
    
    -- Update available seats after booking
   
        UPDATE Train_details
        SET AvlSeat = AvlSeat + @numberOfSeats
        WHERE Tno = @trainId;
		--insert into cancelled_ticket(tno,no_of_ticket)
		--values (@trainId,@numberOfSeats);
    
END;
exec CancelTableAvailableSeats @trainId=12531 ,
    @numberOfSeats=5

----------------------------------------------------------------------------------

----------------------------------------------------------------------------------


select*from Train_details
select*from Cancelled_ticket
select*from Booking_status
--drop  UpdateAvailableSeats
