USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_user_Skills]') IS not NULL
    DROP PROCEDURE [dbo].get_user_Skills
GO

CREATE PROCEDURE get_user_Skills

(@Student_ID INT)

AS
SET NOCOUNT ON

SELECT Skill.Name, 1 AS [FLAG] 
	FROM Student_Skill 
	JOIN SKILL ON ID = Student_Skill
	WHERE Student_ID = @Student_ID

UNION 

SELECT Skill.Name, 0 AS [FLAG] 
	FROM SKILL
	WHERE ID NOT IN(
		SELECT Student_Skill FROM Student_Skill
		WHERE  Student_ID = @Student_ID)

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

--EXEC get_user_Skills 800983530