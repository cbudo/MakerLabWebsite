USE [333_MakerLab];

IF OBJECT_ID('[dbo].[remove_user_Skills]') IS not NULL
    DROP PROCEDURE [dbo].remove_user_Skills
GO

CREATE PROCEDURE remove_user_Skills

(@Student_ID INT,
 @Skill_ID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(StudentID) FROM Student WHERE StudentID = @Student_ID) = 0
BEGIN 
	PRINT 'The Student_ID ' + + CONVERT(varchar(30), @Student_ID ) + ' does not exist' 
	RETURN 1
END
IF (SELECT COUNT(ID) FROM SKILL WHERE ID = @Skill_ID) = 0
BEGIN 
	PRINT 'The Skill_ID ' + + CONVERT(varchar(30), @Skill_ID ) + ' does not exist' 
	RETURN 1
END

DELETE FROM Student_Skill 
WHERE Student_ID = @Student_ID AND Student_Skill = @Skill_ID

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
--EXEC add_user_Skills 800983530, 1
--EXEC remove_user_Skills 800983530, 1