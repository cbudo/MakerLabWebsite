USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Active_projects]') IS not NULL
    DROP PROCEDURE [dbo].get_Active_projects
GO

CREATE PROCEDURE get_Active_projects

AS
SET NOCOUNT ON

DECLARE @ACTIVE SMALLINT = 1

SELECT [ID], [Name], [Description], [Image_Gallery], [DateAdded], [LastModified], [ACTIVE]  FROM PROJECT 
	WHERE ACTIVE = @ACTIVE

--ERROR Stuff
DECLARE @Status1 SMALLINT
SET @Status1 = @@ERROR
IF @Status1 <> 0 
	BEGIN
	-- Return error code to the calling program to indicate failure. 
	PRINT 'An error occurred updating the project'
	RETURN(@Status1)
END
ELSE 
	BEGIN
	RETURN 0
END
GO