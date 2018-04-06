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
            if (!Page.IsPostBack)
            {
                LabelError.Text = "";
                try
                {
                    //            string connString = DataLayer.DB.ConnectionString;
                    DataLayer.DB.ApplicationName = "ASPDemo Application";
                    DataLayer.DB.ConnectionTimeout = 5;

                    SqlConnection conn = DataLayer.DB.GetSqlConnection();

                    GridViewAppLog.DataSource = DataLayer.ApplicationLog.GetLog(DataLayer.DB.ApplicationName);
                    GridViewAppLog.DataBind();
                }
                catch (SqlException sqlex)
                {
                    LabelError.Text = sqlex.Message;
                    //                Console.WriteLine(exception);
                    //                throw;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
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

                GridViewAppLog.DataSource = DataLayer.ApplicationLog.GetLog(DataLayer.DB.ApplicationName);
                GridViewAppLog.DataBind();
            }
            catch (SqlException sqlex)
            {
                LabelError.Text = sqlex.Message;
                //                Console.WriteLine(exception);
                //                throw;
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

                    DataLayer.ApplicationLog.Add4("Updated Department with id: " + TextBoxEID.Text + " to name: " + TextBoxDName.Text);

                    GridViewAppLog.DataSource = DataLayer.ApplicationLog.GetLog(DataLayer.DB.ApplicationName);
                    GridViewAppLog.DataBind();
                }

            }
            catch (SqlException sqlex)
            {
                //                Console.WriteLine(exception);
                LabelError.Text = sqlex.Message;
                //                throw;
            }
        }

        protected void LinkButtonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicationLog.DeleteCommentsForApp("ASPDemo Application");
                DataLayer.ApplicationLog.Add4("Deleted all data for: " + DataLayer.DB.ApplicationName);

                GridViewAppLog.DataSource = DataLayer.ApplicationLog.GetLog(DataLayer.DB.ApplicationName);
                GridViewAppLog.DataBind();
            }
            catch (SqlException sqlex)
            {
                LabelError.Text = sqlex.Message;
                //                Console.WriteLine(exception);
                //                throw;
            }
        }

        protected void GridViewAppLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}