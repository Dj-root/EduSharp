create procedure UpdateDepartmentName
@id int,
@name nvarchar(100)
AS
set nocount on

/*
IF (@name = 'test')
BEGIN
	RAISERROR ('invalid department name', 16,1)
	RETURN
END
*/

update HumanResources.Department
set
Name = @name
where
DepartmentID = @id