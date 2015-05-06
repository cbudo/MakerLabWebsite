USE [333_MakerLab];

IF OBJECT_ID('[dbo].[new_project]') IS not NULL
    DROP PROCEDURE [dbo].new_project
GO

CREATE PROCEDURE new_project

(@Name NVARCHAR(30),
 @Description NVARCHAR(MAX),
 @Image_Gallery NVARCHAR(MAX) = NULL,
 @DateAdded DATE = NULL,
 @LastModified DATETIME = NULL,
 @ACTIVE SMALLINT = 1)

AS
SET NOCOUNT ON

INSERT INTO [PROJECT] ([Name], [Description], [Image_Gallery], [DateAdded], [LastModified], [ACTIVE])
	VALUES (@Name, @Description, @Image_Gallery, @DateAdded, @LastModified, @ACTIVE)
	

--ERROR Stuff
DECLARE @Status1 SMALLINT
SET @Status1 = @@ERROR
IF @Status1 <> 0 
	BEGIN
	-- Return error code to the calling program to indicate failure. 
	PRINT 'An error occurred creating the project'
	RETURN(@Status1)
END
ELSE 
	BEGIN
	RETURN 0
END
GO