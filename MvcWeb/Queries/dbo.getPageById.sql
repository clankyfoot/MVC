CREATE PROCEDURE [dbo].[getPageById]
	@id INT
AS
BEGIN
	SELECT *
	FROM [dbo].PageObject
	WHERE [id] = @id
	FOR XML RAW, ROOT('ROOT'), ELEMENTS
END