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
 @ACTIVE SMALLINT = 1,
 @StudentID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(StudentID) FROM Student WHERE  StudentID= @StudentID) = 0
BEGIN 
	PRINT 'The student '  + CONVERT(varchar(30), @StudentID ) + '  does not exist '
RETURN 1
END

INSERT INTO [PROJECT] ([Name], [Description], [Image_Gallery], [DateAdded], [LastModified], [ACTIVE])
	VALUES (@Name, @Description, @Image_Gallery, @DateAdded, @LastModified, @ACTIVE)

DECLARE @ProjectID INT;
SELECT TOP 1 @ProjectID = ID FROM Project ORDER BY ID DESC


INSERT INTO Student_Project (Student_ID, Project_ID)
Values (@StudentID, @ProjectID)

SELECT TOP 1 ID FROM Project ORDER BY ID DESC
	

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