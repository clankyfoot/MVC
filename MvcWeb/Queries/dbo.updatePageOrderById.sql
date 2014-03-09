﻿/*
	RETURNS
		0 IF NO CHANGES WERE MADE BECAUSE THE NAME ALREADY EXISTS
		1 IF THE PROCEDURE WAS SUCCESSFUL
		3 IF THERE WAS AN ERROR
*/
CREATE PROCEDURE [dbo].[updatePageOrderById]
	@id INT,
	@order INT
AS
BEGIN
	DECLARE 
		@RETURN INT
	IF EXISTS(SELECT [name] FROM [dbo].[PageObject] WHERE id = @id)
	BEGIN TRY
		UPDATE [dbo].[PageObject]
		SET [order] = @order
		WHERE [id] = @id
		SET @RETURN = 1
	END TRY
	BEGIN CATCH
		SET @RETURN = 3
	END CATCH

	RETURN @RETURN
END
GO