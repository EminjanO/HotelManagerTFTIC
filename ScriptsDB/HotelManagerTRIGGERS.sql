CREATE TRIGGER guest_SoftDelete
ON guest
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE guest
	SET isActive = 0 
	WHERE id IN (SELECT id FROM deleted);
	
	SET NOCOUNT OFF;
END

CREATE TRIGGER room_SoftDelete
ON room
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE room
	SET isActive = 0 
	WHERE id IN (SELECT id FROM deleted);
	
	SET NOCOUNT OFF;
END

CREATE TRIGGER profil_SoftDelete
ON profil
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE profil
	SET isActive = 0 
	WHERE id IN (SELECT id FROM deleted);
	
	SET NOCOUNT OFF;
END


CREATE TRIGGER user_SoftDelete
ON [user]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [user]
	SET isActive = 0 
	WHERE id IN (SELECT id FROM deleted);
	
	SET NOCOUNT OFF;
END

CREATE TRIGGER booking_SoftDelete
ON booking
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE booking
	SET isActive = 0 
	WHERE id IN (SELECT id FROM deleted);
	
	SET NOCOUNT OFF;
END
