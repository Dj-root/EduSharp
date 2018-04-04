using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduSharp.Pluralsight.ADO;
using EduSharp.Pluralsight.ADO.DataLayer;

namespace EduSharp.Pluralsight.ADO.ASPDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //            string connString = DataLayer.DB.ConnectionString;
            DataLayer.DB.ApplicationName = "ASPDemo Application";
            DataLayer.DB.ConnectionTimeout = 30;

            SqlConnection conn = DataLayer.DB.GetSqlConnection();
        }

        protected void LinkButtonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {

                DataLayer.Employees es = new Employees();
                DataLayer.Employee employee = es.GetEmployee(int.Parse(TextBoxEID.Text));

                TextBoxFName.Text = employee.FirstName;
                TextBoxLName.Text = employee.LastName;
                TextBoxDName.Text = employee.DepartmentName;
                LabelDptId.Text = employee.DepartmentId.ToString();

                DataLayer.ApplicationLog.Add4("Searched for user id: " + TextBoxEID.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void LinkButtonUpdateDepartmentName_Click(object sender, EventArgs e)
        {
            try
            {
                //A search must first be persormed
                if (TextBoxEID.Text.Length > 0
                    && TextBoxDName.Text.Length > 0)
                {
                    Employees employees = new Employees();
                    int deptId = int.Parse(LabelDptId.Text);
                    employees.UpdateDepartmentName(deptId, TextBoxDName.Text);
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void LinkButtonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicationLog.DeleteCommentsForApp("ASPDemo Application");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}