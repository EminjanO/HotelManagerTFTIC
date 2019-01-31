Go
create Procedure AddUser
@firstName varchar(50),
@lastName varchar(50),
@id_profil int,
@Email varchar(384),
@Passwd varchar(20)
As
Begin
	insert into [User] (firstName, lastName, id_profil, Email, HashPassword) values (@firstName, @lastName, @id_profil, @Email, HASHBYTES('MD5', @Passwd));
End
Go

create Procedure CheckUser
@Email varchar(384),
@Passwd varchar(20)
As
Begin
	select Email from [User] where Email = @Email and HashPassword = HASHBYTES('MD5', @Passwd);
End
Go

EXECUTE AddUser 'William', 'Wauters', 1, 'wil.wil@email.com', 'test1234='
EXECUTE AddUser 'Eminjan', 'Obulkasim', 1, 'Eminjan@email.com', 'test1234='

EXECUTE CheckUser 'wil.wil@email.com', 'test1234=' 


GO 
CREATE PROCEDURE InsertBookingGuest
	@user_id int,
	@room_id int,
	@check_in DATETIME,
	@check_out DATETIME,
	@Booking_info VARCHAR(255) = NULL,
	@nb_person int,
	@guest_firstname varchar(60),
	@guest_lastname varchar(60),
	@guest_email varchar(255),
	@guest_phone varchar(50),
	@guest_info varchar(255) = NULL
AS  
    SET NOCOUNT ON;
	
	DECLARE @guestID int;
	DECLARE @bookingID int;

    INSERT INTO guest (firstname, lastname, email, phone, add_info) VALUES (@guest_firstname, @guest_lastname, @guest_email, @guest_phone, @guest_info);
	SET @guestID = SCOPE_IDENTITY();

    INSERT INTO Booking (check_in, check_out, nb_night, nb_person, add_info, id_guest, id_room, id_user) VALUES (@check_in, @check_out, DATEDIFF(day, @check_out, @check_in ), @nb_person, @Booking_info, @guestID, @room_id, @user_id);  
	SET @bookingID = SCOPE_IDENTITY();
	
	SELECT @bookingID;
GO





GO 
CREATE PROCEDURE UpdateBookingGuest
	@booking_id int,
	@user_id int,
	@room_id int,
	@guest_id int,
	@booking_has_payed bit,
	@booking_is_created bit,
	@check_in DATETIME,
	@check_out DATETIME,
	@Booking_info VARCHAR(255),
	@nb_person int,
	@guest_firstname varchar(60),
	@guest_lastname varchar(60),
	@guest_email varchar(255),
	@guest_phone varchar(50),
	@guest_info varchar(255) = NULL
AS  
    SET NOCOUNT OFF;
	UPDATE guest 
	SET firstname = @guest_firstname, 
		lastname = @guest_lastname,
		email = @guest_email,
		phone = @guest_phone,
		add_info = @guest_info,
		last_update = GETDATE()
	WHERE id = @guest_id
	
	UPDATE booking 
	SET hasPayed = @booking_has_payed,
		isCreated = @booking_is_created,
		check_in = @check_in,
		check_out = @check_out,
		add_info = @Booking_info,
		nb_person = @nb_person,
		last_update = GETDATE(),
		id_room = @room_id,
		id_user = @user_id		
	WHERE id = @booking_id
GO

SELECT 


EXECUTE GetAllBookingVM

@booking_id int,
	@user_id int,
	@room_id int,
	@guest_id int,
	@booking_has_payed bit,
	@booking_is_created bit,
	@check_in DATETIME,
	@check_out DATETIME,
	@Booking_info VARCHAR(255),
	@nb_person int,
	@guest_firstname varchar(60),
	@guest_lastname varchar(60),
	@guest_email varchar(255),
	@guest_phone varchar(50),
	@guest_info varchar(255) = NULL



GO 
CREATE PROCEDURE GetBookingGuest
AS   
    SET NOCOUNT ON;
	SELECT b.id, b.id_user, b.id_room, b.id_guest, b.hasPayed, b.isCreated, b.check_in, b.check_out, b.add_info,  
	FROM booking b
	JOIN guest g ON g.id = b.id_guest  
GO


GO 
CREATE PROCEDURE InsertGuest
	@firstname varchar(60),
	@lastname varchar(60),
	@email varchar(255),
	@phone varchar(50),
	@add_info varchar(255) = NULL
AS   
    SET NOCOUNT ON;
	DECLARE @guestID as INT
    INSERT INTO guest (firstname, lastname, email, phone, add_info) VALUES (@firstname, @lastname, @email, @phone, ISNULL(@add_info, NULL));
	SET @guestID = @@IDENTITY;
	SELECT @guestID ;
GO

GO 
CREATE PROCEDURE InsertProfil
	@profil_name varchar(20),
	@description varchar(max)
AS   
    SET NOCOUNT ON;
	DECLARE @profilID as INT
    INSERT INTO profil (profil_name, description) VALUES (@profil_name, @description);
	SET @profilID = @@IDENTITY;
	SELECT @profilID ;
GO

EXECUTE InsertGuest 'Jean-jacques', 'Chocolat', 'jean.jean@Eminjan.com', '05555163854', NULL   

USE HotelManager;  
GO 
CREATE PROCEDURE InsertRoom
	@num varchar(10),
	@add_info varchar(255),
	@id_type_room int,
	@id_state_room int
AS   
    SET NOCOUNT ON;
	DECLARE @roomID as INT
    INSERT INTO room (num, add_info, id_type_room, id_state_room) VALUES (@num, @add_info, @id_type_room, @id_state_room);  
	SET @roomID = @@IDENTITY;
	SELECT @roomID ;
GO

USE HotelManager;  
GO 
CREATE PROCEDURE InsertBooking
	@check_in date,
	@check_out date,
	@nb_person int,
	@add_info varchar(255),
	@id_guest int,
	@id_room int,
	@id_user int
AS   
    SET NOCOUNT ON;
	DECLARE @bookingID as INT
    INSERT INTO Booking (check_in, check_out, nb_night, nb_person, add_info, id_guest, id_room, id_user) VALUES (@check_in, @check_out, DATEDIFF(day, @check_out, @check_in ), @nb_person, @add_info, @id_guest, @id_room, @id_user);  
	SET @bookingID = @@IDENTITY;
	SELECT @bookingID ;
GO

USE HotelManager;  
GO 
CREATE PROCEDURE InsertTypeRoom
	@type_name varchar(20),
	@capacity int,
	@price decimal,
	@add_info varchar(255),
	@id_guest int,
	@id_room int,
	@id_user int
AS   
    SET NOCOUNT ON;
	DECLARE @bookingID as INT
    INSERT INTO Booking (check_in, check_out, nb_night, nb_person, add_info, id_guest, id_room, id_user) VALUES (@check_in, @check_out, DATEDIFF(day, @check_out, @check_in ), @nb_person, @add_info, @id_guest, @id_room, @id_user);  
	SET @bookingID = @@IDENTITY;
	SELECT @bookingID ;
GO

USE HotelManager;  
GO 
CREATE PROCEDURE InsertUser
	@firstname varchar(100),
	@lastname varchar(100),
	@id_profil int
AS   
    SET NOCOUNT ON;
	DECLARE @userID as INT
    INSERT INTO [User] (firstName, lastName, id_profil) VALUES (@firstname, @lastname, @id_profil);  
	SET @userID = @@IDENTITY;
	SELECT @userID ;
GO
























----CRUD GUEST
--USE HotelManager;  
--GO  

--CREATE PROCEDURE GetAllGuest
--AS   
--    SET NOCOUNT ON;  
--    SELECT *
--    FROM guest  
--GO

--USE HotelManager;  
--GO  
--CREATE PROCEDURE GetGuest
--    @id int
--AS   
--    SET NOCOUNT ON;  
--    SELECT *  
--    FROM guest
--	WHERE id = @id;  
--GO


--USE HotelManager;  
--GO 
--CREATE PROCEDURE DeleteGuest
--	@id int
--AS   
--    SET NOCOUNT ON;
--    DELETE guest 
--	WHERE id = @id;
--GO

----CRUD ROOM
--USE HotelManager;  
--GO  

--CREATE PROCEDURE GetAllRoom 
--AS   
--    SET NOCOUNT ON;  
--    SELECT *
--    FROM room  
--GO

--USE HotelManager;  
--GO  
--CREATE PROCEDURE GetRoom
--    @id int
--AS   
--    SET NOCOUNT ON;  
--    SELECT *  
--    FROM room
--	WHERE id = @id;  
--GO

--USE HotelManager;  
--GO 
--CREATE PROCEDURE DeleteRoom
--	@id int
--AS   
--    SET NOCOUNT ON;
--    DELETE room 
--	WHERE id = @id;
--GO

----CRUD BOOKING
--USE HotelManager;  
--GO  

--CREATE PROCEDURE GetAllBooking
--AS   
--    SET NOCOUNT ON;  
--    SELECT *
--    FROM Booking  
--GO

--USE HotelManager;  
--GO  
--CREATE PROCEDURE GetBooking
--    @id int
--AS   
--    SET NOCOUNT ON;  
--    SELECT *  
--    FROM Booking
--	WHERE id = @id;  
--GO

--USE HotelManager;  
--GO 
--CREATE PROCEDURE UpdateGuest
--	@id int,
--	@firstname varchar(60),
--	@lastname varchar(60),
--	@email varchar(255),
--	@phone int,
--	@add_info varchar(255)
--AS   
--    SET NOCOUNT ON;
--    UPDATE guest 
--	SET firstname = @firstname, lastname = @lastname, email = @email, phone = @phone, add_info = @add_info, last_update = CURRENT_TIMESTAMP
--	WHERE id = @id;
--GO

--USE HotelManager;  
--GO 
--CREATE PROCEDURE UpdateRoom
--	@id int,
--	@num varchar(10),
--	@add_info varchar(255),
--	@id_type_room int,
--	@id_state_room int,
--	@isActive bit
--AS   
--    SET NOCOUNT ON;
--    UPDATE room 
--	SET num = @num, add_info = @add_info, id_type_room = @id_type_room, last_update = CURRENT_TIMESTAMP, id_state_room = @id_state_room	
--	WHERE id = @id;
--GO

--USE HotelManager;  
--GO 
--CREATE PROCEDURE UpdateBooking
--	@id int,
--	@check_in date,
--	@check_out date,
--	@nb_person int,
--	@add_info varchar(255),
--	@id_guest int,
--	@id_room int,
--	@id_user int,
--	@isCreated bit,
--	@hasPayed bit
--AS   
--    SET NOCOUNT ON;
--    UPDATE Booking 
--	SET check_in = @check_in, check_out= @check_out, nb_night = DATEDIFF(day, @check_out, @check_in ), nb_person = @nb_person, add_info = @add_info, id_guest = @id_guest, id_room = @id_room, id_user = @id_user, last_update = CURRENT_TIMESTAMP, isCreated = @isCreated, hasPayed = @hasPayed,
--	WHERE id = @id;
--GO

--USE HotelManager;  
--GO 
--CREATE PROCEDURE DeleteBooking
--	@id int
--AS   
--    SET NOCOUNT ON;
--    DELETE Booking 
--	WHERE id = @id;
--GO

