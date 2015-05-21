USE [333_MakerLab];

IF OBJECT_ID('[dbo].[get_Student_likeAttr]') IS not NULL
    DROP PROCEDURE [dbo].get_Student_likeAttr
GO

CREATE PROCEDURE get_Student_likeAttr
( @FirstName NVARCHAR(MAX) = NULL,
  @LastName NVARCHAR(MAX) = NULL,
  @Email NVARCHAR(25) = NULL)

AS
SET NOCOUNT ON

IF @FirstName IS NOT NULL
BEGIN 
	SELECT StudentID, Email, FirstName, LastName, ClassYear
	FROM Student
	WHERE FirstName LIKE (@FirstName + '%')
END
ELSE IF @LastName IS NOT NULL
BEGIN 
	SELECT StudentID, Email, FirstName, LastName, ClassYear
	FROM Student
	WHERE LastName LIKE (@LastName + '%')
END
ELSE IF @Email IS NOT NULL
BEGIN 
	SELECT StudentID, Email, FirstName, LastName, ClassYear
	FROM Student
	WHERE Email LIKE (@Email + '%')
END

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