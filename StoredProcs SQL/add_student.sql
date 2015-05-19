USE [333_MakerLab];

--add a new student to student table, add studentID to aspNetUsers table row where email matches email passed into sproc
--Params: StudentID,Email,FirstName,LastName,ClassYear

IF OBJECT_ID('[dbo].[add_student]') IS not NULL
    DROP PROCEDURE [dbo].add_student
GO

CREATE PROCEDURE add_student

(@Student_ID INT,
 @Email NVARCHAR(25),
 @FirstName NVARCHAR(MAX),
 @LastName NVARCHAR(MAX),
 @ClassYear smallint)

AS
SET NOCOUNT ON

INSERT INTO dbo.Student (StudentID, Email, FirstName, LastName, ClassYear)
VALUES (@Student_ID, @Email, @FirstName, @LastName, @ClassYear)

UPDATE dbo.AspNetUsers SET StudentIDFK = @Student_ID
WHERE Email = @Email


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