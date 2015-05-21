USE [333_MakerLab];

--Updates a student using information passed in, should update AspNetUsers table with email or StudentID if those are different - return true if values can be updated (new values for StudentID or email do not already exist in the tables) false otherwise
--Params: OldStudentID, NewStudentID, NewEmail, NewFirstName, NewLastName, NewClassYear

IF OBJECT_ID('[dbo].[Update_student]') IS not NULL
    DROP PROCEDURE [dbo].Update_student
GO

CREATE PROCEDURE Update_student

(@OldStudentID INT,

 @newStudent_ID INT,
 @newEmail NVARCHAR(25),
 @newFirstName NVARCHAR(MAX),
 @newLastName NVARCHAR(MAX),
 @newClassYear smallint)
 
 

AS
SET NOCOUNT ON
IF (SELECT COUNT(StudentID) FROM Student WHERE StudentID = @OldStudentID) <> 0
BEGIN 
	PRINT 'A student with @Student_ID ' + CONVERT(varchar(30), @OldStudentID ) + ' does not exist' 
	RETURN 1
END

IF (SELECT COUNT(StudentID) FROM Student WHERE StudentID = @newStudent_ID) <> 0
BEGIN 
	PRINT 'A student with @Student_ID ' + CONVERT(varchar(30), @newStudent_ID ) + ' already exists' 
	RETURN 1
END

--Tables that need to be updated
BEGIN TRANSACTION
--Users
DECLARE @oldEmail NVARCHAR(25)
SELECT @oldEmail = Email FROM Student WHERE StudentID = @OldStudentID

UPDATE dbo.AspNetUsers SET StudentIDFK = @newStudent_ID
WHERE Email = @oldEmail

--Leader
UPDATE dbo.Leader SET Student_ID = @newStudent_ID
WHERE Student_ID = @OldStudentID

--Student
UPDATE dbo.Student SET StudentID = @newStudent_ID
WHERE StudentID = @OldStudentID

--Student_Project
UPDATE dbo.Student_Project SET Student_ID = @newStudent_ID
WHERE Student_ID = @OldStudentID

--Student_skill
UPDATE dbo.Student_skill SET Student_ID = @newStudent_ID
WHERE Student_ID = @OldStudentID

--Student_training
UPDATE dbo.Student_training SET Student_ID = @newStudent_ID
WHERE Student_ID = @OldStudentID

COMMIT TRANSACTION

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