USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Student_ByEmail]') IS not NULL
    DROP PROCEDURE [dbo].get_Student_ByEmail
GO

CREATE PROCEDURE get_Student_ByEmail
( @Email NVARCHAR(25))

AS
SET NOCOUNT ON

IF (SELECT COUNT(StudentID) FROM Student WHERE email = @Email) = 0
BEGIN 
	PRINT 'The Emaiil '  + CONVERT(varchar(30), @Email ) + ' does not exist' 
RETURN 1
END

SELECT StudentID, Email, FirstName, LastName, ClassYear
FROM Student
WHERE Email = @Email


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