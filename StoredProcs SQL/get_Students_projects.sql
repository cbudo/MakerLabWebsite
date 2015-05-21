USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Students_projects]') IS not NULL
    DROP PROCEDURE [dbo].get_Students_projects
GO

CREATE PROCEDURE get_Students_projects

(@StudentID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(StudentID) FROM Student WHERE StudentID = @StudentID) = 0
BEGIN 
	PRINT 'The StudentID'  + CONVERT(varchar(30), @StudentID ) + ' does not exist' 
RETURN 1
END

SELECT p.ID, p.Name, p.Active 
FROM Student_Project sp
INNER JOIN Project p ON p.ID = sp.Project_ID
WHERE Student_ID = @StudentID
ORDER BY ACTIVE DESC, LASTMODIFIED DESC



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