USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Project_MLParts]') IS not NULL
    DROP PROCEDURE [dbo].get_Project_MLParts
GO

CREATE PROCEDURE get_Project_MLParts

(@Project_ID INT)

AS
SET NOCOUNT ON

SELECT part.Name, 1 AS [FLAG] 
	FROM Maker_Lab_Part part 
	JOIN Project_MLPart ON ID = MLPart_ID
	WHERE Project_MLPart.Project_ID = @Project_ID

UNION 

SELECT part.Name, 0 AS [FLAG] 
	FROM Maker_Lab_Part part
	WHERE ID NOT IN(
		SELECT MLPart_ID FROM  Project_MLPart
		WHERE Project_MLPart.Project_ID = @Project_ID)

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