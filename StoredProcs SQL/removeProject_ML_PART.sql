USE [333_MakerLab];

--Remove an existing external resource from a project
--Params:Project_ID,Resource_ID

IF OBJECT_ID('[dbo].[removeProject_ML_PART]') IS not NULL
    DROP PROCEDURE [dbo].removeProject_ML_PART
GO

CREATE PROCEDURE removeProject_ML_PART

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

IF (SELECT COUNT(@Project_ID) FROM Project_MLPart WHERE MLPart_ID = @MLPart_ID AND Project_ID = @Project_ID) = 0
BEGIN 
	PRINT 'The ML Part '  + CONVERT(varchar(30), @MLPart_ID ) + ' is not in the project '   + CONVERT(varchar(30), @Project_ID )
	RETURN 1
END

DELETE FROM dbo.Project_MLPart
WHERE MLPart_ID = @MLPart_ID AND Project_ID = @Project_ID


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