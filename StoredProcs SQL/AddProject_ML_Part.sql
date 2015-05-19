USE [333_MakerLab];

--add an external resource to the project
--Params: Project_ID,Resource_ID
--db.project_ext_resource.insertonsubmit(new project_ext_resource(){Resource_ID = model.Resource_id,Project_ID = model.Project_Id})

IF OBJECT_ID('[dbo].[AddProject_ML_Part]') IS not NULL
    DROP PROCEDURE [dbo].AddProject_ML_Part
GO

CREATE PROCEDURE AddProject_ML_Part

(@Project_ID INT,
 @MLPart_ID INT)

AS
SET NOCOUNT ON

IF (SELECT COUNT(ID) FROM Project WHERE ID = @Project_ID) = 0
BEGIN 
	PRINT 'The Project_ID '  + CONVERT(varchar(30), @Project_ID ) + ' does not exist' 
	RETURN 1
END

IF (SELECT COUNT(ID) FROM Maker_Lab_Part WHERE ID = @MLPart_ID) = 0
BEGIN 
	PRINT 'The MLPart_ID '  + CONVERT(varchar(30), @MLPart_ID ) + ' does not exist' 
	RETURN 1
END

IF (SELECT COUNT(@Project_ID) FROM Project_MLPart WHERE MLPart_ID = @MLPart_ID AND Project_ID = @Project_ID) <> 0
BEGIN 
	PRINT 'The External Resource '  + CONVERT(varchar(30), MLPart_ID ) + ' is already in the project '   + CONVERT(varchar(30), @Project_ID )
	RETURN 1
END

INSERT INTO dbo.Project_MLPart (MLPart_ID, Project_ID)
VALUES (@MLPart_ID, @Project_ID)


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