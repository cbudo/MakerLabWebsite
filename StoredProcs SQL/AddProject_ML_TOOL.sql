USE [333_MakerLab];

--add an external resource to the project
--Params: Project_ID,Resource_ID
--db.project_ext_resource.insertonsubmit(new project_ext_resource(){Resource_ID = model.Resource_id,Project_ID = model.Project_Id})

IF OBJECT_ID('[dbo].[AddProject_ML_TOOL]') IS not NULL
    DROP PROCEDURE [dbo].AddProject_ML_TOOL
GO

CREATE PROCEDURE AddProject_ML_TOOL

(@Project_ID INT,
 @MLTool_ID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(ID) FROM Project WHERE ID = @Project_ID) = 0
BEGIN 
	PRINT 'The Project_ID '  + CONVERT(varchar(30), @Project_ID ) + ' does not exist' 
	RETURN 1
END

IF (SELECT COUNT(ID) FROM Maker_Lab_Tool WHERE ID = @MLTool_ID) = 0
BEGIN 
	PRINT 'The MLTool_ID '  + CONVERT(varchar(30), @MLTool_ID ) + ' does not exist' 
	RETURN 1
END

IF (SELECT COUNT(@Project_ID) FROM Project_MLTool WHERE MLTool_ID = @MLTool_ID AND Project_ID = @Project_ID) <> 0
BEGIN 
	PRINT 'The ML Tool '  + CONVERT(varchar(30), @MLTool_ID ) + ' is already in the project '   + CONVERT(varchar(30), @Project_ID )
	RETURN 1
END

INSERT INTO dbo.Project_MLTool (MLTool_ID, Project_ID)
VALUES (@MLTool_ID, @Project_ID)


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