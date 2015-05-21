USE [333_MakerLab];


IF OBJECT_ID('[dbo].[get_Students_WorkingON_projects]') IS not NULL
    DROP PROCEDURE [dbo].get_Students_WorkingON_projects
GO

CREATE PROCEDURE get_Students_WorkingON_projects

(@ProjectID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(ID) FROM Project WHERE ID = @ProjectID) = 0
BEGIN 
	PRINT 'The Project_ID '  + CONVERT(varchar(30), @ProjectID ) + ' does not exist' 
	RETURN 1
END


SELECT s.StudentID, (s.FirstName + ' ' + s.LastName) AS NAME
FROM Student s
WHERE StudentID in (
	SELECT sp.Student_ID
	FROM Student_Project sp
		INNER JOIN Project p ON p.ID = sp.Project_ID
		WHERE p.ID = @ProjectID
	)
	ORDER by s.LastName ASC



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