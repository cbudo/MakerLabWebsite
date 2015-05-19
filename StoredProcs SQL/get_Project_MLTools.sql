USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Project_MLTools]') IS not NULL
    DROP PROCEDURE [dbo].get_Project_MLTools
GO

CREATE PROCEDURE get_Project_MLTools

(@Project_ID INT)

AS
SET NOCOUNT ON

SELECT tool.Name, tool.ID, 1 AS [FLAG] 
	FROM Maker_Lab_Tool tool 
	JOIN Project_MLTool ON ID = MLTool_ID
	WHERE Project_MLTool.Project_ID = @Project_ID

UNION 

SELECT tool.Name, tool.ID, 0 AS [FLAG] 
	FROM Maker_Lab_Tool tool
	WHERE ID NOT IN(
		SELECT MLTool_ID FROM Project_MLTool
		WHERE Project_MLTool.Project_ID = @Project_ID)

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