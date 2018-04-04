
CREATE procedure GetEmployeeDetails
@businessEntityId int
AS

SET NOCOUNT ON

select * from HumanResources.Employee e
join Person.Person p on e.BusinessEntityID=p.BusinessEntityID AND p.PersonType = 'EM'
join HumanResources.EmployeeDepartmentHistory EH ON e.BusinessEntityID = EH.BusinessEntityID
join HumanResources.Department D ON D.DepartmentID = EH.DepartmentID
where
	e.BusinessEntityID = @businessEntityId
;