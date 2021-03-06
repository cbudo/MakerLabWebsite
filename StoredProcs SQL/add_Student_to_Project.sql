USE [333_MakerLab];

IF OBJECT_ID('[dbo].[add_Student_to_Project]') IS not NULL
    DROP PROCEDURE [dbo].add_Student_to_Project
GO

CREATE PROCEDURE add_Student_to_Project

(@StudentID INT,
 @ProjectID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(StudentID) FROM Student WHERE StudentID = @StudentID) = 0
BEGIN 
	PRINT 'The StudentID '  + CONVERT(varchar(30), @StudentID ) + ' does not exist' 
RETURN 1
END

IF (SELECT COUNT(ID) FROM Project WHERE ID = @ProjectID) = 0
BEGIN 
	PRINT 'The ProjectID '  + CONVERT(varchar(30), @ProjectID ) + ' does not exist' 
RETURN 1
END

IF (SELECT COUNT(Student_ID) FROM Student_Project WHERE Project_ID = @ProjectID AND Student_ID= @StudentID) <> 0
BEGIN 
	PRINT 'The student '  + CONVERT(varchar(30), @StudentID ) + '  is already working on the project '  + CONVERT(varchar(30), @ProjectID ) 
RETURN 1
END

INSERT INTO Student_Project (Student_ID, Project_ID)
Values (@StudentID, @ProjectID)



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