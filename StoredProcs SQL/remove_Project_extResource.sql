USE [333_MakerLab];

--Remove an existing external resource from a project
--Params:Project_ID,Resource_ID

IF OBJECT_ID('[dbo].[remove_Project_extResource]') IS not NULL
    DROP PROCEDURE [dbo].remove_Project_extResource
GO

CREATE PROCEDURE remove_Project_extResource

(@Project_ID INT,
 @Resource_ID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(ID) FROM Project WHERE ID = @Project_ID) = 0
BEGIN 
	PRINT 'The Project_ID '  + CONVERT(varchar(30), @Project_ID ) + ' does not exist' 
	RETURN 1
END

IF (SELECT COUNT(ID) FROM External_Resource WHERE ID = @Resource_ID) = 0
BEGIN 
	PRINT 'The Resource_ID '  + CONVERT(varchar(30), @Resource_ID ) + ' does not exist' 
RETURN 1
END

IF (SELECT COUNT(@Project_ID) FROM Project_Ext_Resource WHERE Resource_ID = @Resource_ID AND Project_ID = @Project_ID) = 0
BEGIN 
	PRINT 'The External Resource '  + CONVERT(varchar(30), @Resource_ID ) + ' is not in the project '   + CONVERT(varchar(30), @Project_ID )
	RETURN 1
END

DELETE FROM dbo.Project_Ext_Resource 
WHERE Resource_ID = @Resource_ID AND Project_ID = @Project_ID


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