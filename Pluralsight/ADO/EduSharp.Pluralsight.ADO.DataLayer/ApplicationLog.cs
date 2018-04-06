using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Pluralsight.ADO.DataLayer
{
    public class ApplicationLog
    {


        /// <summary>
        /// Add a comment to the application log in the DB
        /// </summary>
        /// <param name="comment"></param>
        public static void Add(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;
                    cmd.Parameters.Add(p1);

                    int res = cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add a comment and return the last ID generated
        /// </summary>
        /// <param name="comment"></param>
        public static void Add2(string comment)
        {

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog2";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;
                    cmd.Parameters.Add(p1);

                    object res = cmd.ExecuteScalar();
                }
            }

        }

        /// <summary>
        /// Add a comment and use an output parameter
        /// </summary>
        /// <param name="comment"></param>
        public static void Add3(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog3";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;
                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("outid", System.Data.SqlDbType.Int);
                    p2.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(p2);
                    cmd.ExecuteNonQuery();

                    object res = p2.Value;
                }
            }
        }


        /// <summary>
        /// Add a comment and use the Return value
        /// </summary>
        /// <param name="comment"></param>
        public static void Add4(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog4";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = comment;
                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                    p2.Direction = System.Data.ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(p2);
                    cmd.ExecuteNonQuery();

                    object res = p2.Value;
                }
            }
        }
        /// <summary>
        /// Delete all comments for a specific application
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentsForApp(string appName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DeleteAppLog";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("appName", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = appName;
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves application log details for a given application
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static DataTable GetLog(string appName)
        {
            DataTable table = new DataTable("ApplicationLog");
            SqlDataAdapter da = null;

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ApplicationLog WHERE application_name = @appname",conn);
                cmd.Parameters.Add(new SqlParameter("appname", System.Data.SqlDbType.NVarChar,100));
                cmd.Parameters["appname"].Value = appName;

                da = new SqlDataAdapter(cmd);

                int res = da.Fill(table);
            }

            return table;
        }
        /// <summary>
        /// Applies the INSERT, UPDATE, DELETE operations from the disconnected data table
        /// </summary>
        /// <param name="tableLog"></param>
        /// <returns></returns>
        public static DataTable UpdateLogChanges(DataTable tableLog)
        {
            SqlDataAdapter da = new SqlDataAdapter();

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                da.SelectCommand = new SqlCommand("SELECT * FROM ApplicationLog",conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                int res = da.Update(tableLog);

                return tableLog;
            }
        }
    }
}


/*
 *
 ====================================================
CREATE TABLE ApplicationLog(
id	int	IDENTITY(1,1) primary key,
date_added datetime not null default(getutcdate()),
comment ntext not null,
application_name nvarchar(100));
 * 
 *
 *
====================================================

 create procedure AddAppLog
@comment ntext
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))
====================================================

alter procedure AddAppLog
@comment ntext
AS
--SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

====================================================

create procedure AddAppLog2
@comment ntext
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

select scope_identity()

====================================================

create procedure AddAppLog3
@comment ntext
@outid int output
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

set @outid = scope_identity()

====================================================

declare @out int
EXEC AddAppLog3 'sample data', @out output
select @out

====================================================

create procedure AddAppLog4
@comment ntext
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

    RETURN scope_identity()

====================================================

create procedure DeleteAppLog
@appname nvarchar(100)
AS
set nocount on

delete from ApplicationLog where application_name = @appname

GO


 */
