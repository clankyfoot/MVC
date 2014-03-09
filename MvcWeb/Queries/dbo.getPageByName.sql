CREATE PROCEDURE [dbo].[getPageByName]
	@name VARCHAR(200)
AS
BEGIN
	SELECT *
	FROM [dbo].PageObject
	WHERE [name] = @name
	FOR XML RAW, ROOT('ROOT'), ELEMENTS
END