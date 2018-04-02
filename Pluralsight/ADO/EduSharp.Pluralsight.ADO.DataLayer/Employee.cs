using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Pluralsight.ADO.DataLayer
{
    public class Employees
    {
        public List<Employee> EmployeeList { get; set; }

        public Employee GetEmployee(int employeeId)
        {
            Employee e = new Employee();
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"GetEmployeeDetails";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("businessEntityId", System.Data.SqlDbType.Int);
                    p1.Value = employeeId;
                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (reader.Read())
                    {
                        e.Load(reader);
                    }
                }
            }

            return e;
        }

        /// <summary>
        /// Update the name of department given its ID
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="newName"></param>
        public void UpdateDepartmentName(int departmentId, string newName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UpdateDepartmentName";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("id", System.Data.SqlDbType.Int);
                    p1.Value = departmentId;
                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("name", System.Data.SqlDbType.NVarChar, 100);
                    p2.Value = newName;
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Returns an employee using Inline SQL
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>

        public Employee GetEmployeeDoNotCall(int employeeId)
        {
            Employee e = new Employee();
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from HumanResources.Employee e
                        join Person.Person p on e.BusinessEntityID=p.BusinessEntityID AND p.PersonType = 'EM'
                        join HumanResources.EmployeeDepartmentHistory EH ON e.BusinessEntityID = EH.BusinessEntityID
                        join HumanResources.Department D ON D.DepartmentID = EH.DepartmentID
                    where
	                    e.BusinessEntityID = {0}";

                    cmd.CommandText = string.Format(cmd.CommandText, employeeId.ToString());
                   SqlDataReader reader =  cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (reader.Read())
                    {
                        e.Load(reader);
                    }
                }
            }

            return e;
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public void Load(SqlDataReader reader)
        {
            EmployeeId = Int32.Parse(reader["BusinessEntityId"].ToString());
            FirstName = reader["FirstName"].ToString();
            LastName = reader["LastName"].ToString();
            DepartmentId = Int32.Parse(reader["DepartmentId"].ToString());
            DepartmentName = reader["Name"].ToString();
        }

    }
}




/*
 =========================================================
 ==== SQL Code ====

    create procedure GetEmployeeDetails
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
 *
 *
 
=========================================================
create procedure UpdateDepartmentName
@id int,
@name nvarchar(100)
AS
set nocount on

update HumanResources.Department
set
Name = @name
where
DepartmentID = @id

 
=========================================================    
    select * from HumanResources.Department
     *
 *
 * *
 */
