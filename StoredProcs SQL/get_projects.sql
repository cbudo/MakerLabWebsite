USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_projects]') IS not NULL
    DROP PROCEDURE [dbo].get_projects
GO

CREATE PROCEDURE get_projects

(@ACTIVE SMALLINT = 1,
 @Name NVARCHAR(30) = ' ',
 @DateAdded DATE = NULL,
 @LastModified DATETIME = NULL)

AS
SET NOCOUNT ON

SELECT [ID], [Name], [Description], [Image_Gallery], [DateAdded], [LastModified], [ACTIVE] FROM PROJECT 
	WHERE ACTIVE = @ACTIVE 
		AND (@Name = ' ' OR NAME = @Name) 
		AND (@DateAdded IS NULL OR DateAdded = @DateAdded)
		AND (@LastModified IS NULL OR LastModified = @LastModified)
	

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