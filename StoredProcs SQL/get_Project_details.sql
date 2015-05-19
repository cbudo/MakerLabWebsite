USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Project_details]') IS not NULL
    DROP PROCEDURE [dbo].get_Project_details
GO

CREATE PROCEDURE get_Project_details

(@Project_ID INT)

AS
SET NOCOUNT ON

SELECT ID, Name, [Description], Image_Gallery, DateAdded, LastModified, Active
FROM Project 
WHERE ID = @Project_ID


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