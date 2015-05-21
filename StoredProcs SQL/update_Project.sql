USE [333_MakerLab];

IF OBJECT_ID('[dbo].[update_Project]') IS not NULL
    DROP PROCEDURE [dbo].update_Project
GO

CREATE PROCEDURE update_Project
(@ProjectID INT,
 @Name NVARCHAR(MAX),
 @Description NVARCHAR(MAX),
 @Image_Gallery NVARCHAR(MAX),
 @DateAdded Date,
 @LastModified DATETIME,
 @Active SMALLINT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(ID) FROM Project WHERE ID = @ProjectID) = 0
BEGIN 
	PRINT 'The ProjectID '  + CONVERT(varchar(30), @ProjectID ) + ' does not exist' 
RETURN 1
END

UPDATE PROJECT 
SET Name = @Name, [Description] = @Description, Image_Gallery = @Image_Gallery,
	DateAdded = @DateAdded, LastModified = @LastModified, @Active = Active
WHERE ID = @ProjectID


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