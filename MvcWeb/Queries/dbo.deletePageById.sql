CREATE PROCEDURE [dbo].[deletePageById]
	@id INT
AS
BEGIN
	DELETE FROM [dbo].PageObject
	WHERE [id] = @id
END
GO
