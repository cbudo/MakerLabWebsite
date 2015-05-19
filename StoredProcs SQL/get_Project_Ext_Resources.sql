USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Project_Ext_Resources]') IS not NULL
    DROP PROCEDURE [dbo].get_Project_Ext_Resources
GO

CREATE PROCEDURE get_Project_Ext_Resources

(@Project_ID INT)

AS
SET NOCOUNT ON

SELECT rsource.Name, 1 AS [FLAG] 
	FROM External_Resource rsource
	JOIN Project_Ext_Resource ON ID = Resource_ID
	WHERE Project_Ext_Resource.Project_ID = @Project_ID

UNION 

SELECT rsource.Name, 0 AS [FLAG] 
	FROM External_Resource rsource
	WHERE ID NOT IN(
		SELECT Resource_ID FROM  Project_Ext_Resource
		WHERE Project_Ext_Resource.Project_ID = @Project_ID)


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