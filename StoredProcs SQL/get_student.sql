USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_student]') IS not NULL
    DROP PROCEDURE [dbo].get_student
GO

CREATE PROCEDURE get_student

(@StudentID INT)

AS
SET NOCOUNT ON

SELECT StudentID, Email, FirstName, LastName, ClassYear
FROM Student 
	WHERE StudentID = @StudentID
	

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

--SELECT * FROM STUDENT
--EXEC get_Student 800983530