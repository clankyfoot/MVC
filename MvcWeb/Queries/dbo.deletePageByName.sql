CREATE PROCEDURE [dbo].[deletePageByName]
	@name VARCHAR(200)
AS
BEGIN
	DELETE FROM [dbo].PageObject
	WHERE [name] = @name
END
GO
