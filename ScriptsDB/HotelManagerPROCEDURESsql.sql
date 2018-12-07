USE HotelManager;  
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

