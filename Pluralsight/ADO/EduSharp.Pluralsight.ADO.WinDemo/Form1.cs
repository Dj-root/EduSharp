using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EduSharp.Pluralsight.ADO;
using EduSharp.Pluralsight.ADO.DataLayer;

namespace EduSharp.Pluralsight.ADO.WinDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //            string connString = DataLayer.DB.ConnectionString;
                DataLayer.DB.ApplicationName = "WinDemo Application";
                DataLayer.DB.ConnectionTimeout = 5;

                SqlConnection conn = DataLayer.DB.GetSqlConnection();

                DataTable tableLog = DataLayer.ApplicationLog.GetLog(DataLayer.DB.ApplicationName);
                dataGridViewAppLog.DataSource = tableLog;
            }
            catch (SqlException sqlex)
            {
                //Connection Error
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(sqlex);
                throw;
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataLayer.Employees es = new Employees();
                DataLayer.Employee employee = es.GetEmployee(int.Parse(textBoxEID.Text));

                textBoxFName.Text = employee.FirstName;
                textBoxLName.Text = employee.LastName;
                textBoxDName.Text = employee.DepartmentName;
                labelDeptId.Text = employee.DepartmentId.ToString();

                DataLayer.ApplicationLog.Add4("Searched for user id: "+ textBoxEID.Text);
            }
            catch (Exception sqlex)
            {
                //Connection Error
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(sqlex);
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicationLog.DeleteCommentsForApp("WinDemo Application");
                DataLayer.ApplicationLog.Add4("Deleted all data for: " + DataLayer.DB.ApplicationName);
            }
            catch (Exception sqlex)
            {
                //Connection Error
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(sqlex);
                throw;
            }
        }

        private void linkLabelUpdateDepartmentName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //A search must first be persormed
                if (textBoxEID.Text.Length >0
                    && textBoxDName.Text.Length >0)
                {
                    Employees employees = new Employees();
                    int deptId = int.Parse(labelDeptId.Text);
                    employees.UpdateDepartmentName(deptId, textBoxDName.Text);

                    DataLayer.ApplicationLog.Add4("Updated Department with id: " + textBoxEID.Text + " to name: " + textBoxDName.Text);
                }

            }
            catch (Exception sqlex)
            {
                //Connection Error
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(sqlex);
                throw;
            }
        }

        private void dataGridViewAppLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonUpdateLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable) dataGridViewAppLog.DataSource;
                DataTable tableRes = DataLayer.ApplicationLog.UpdateLogChanges(table);
                dataGridViewAppLog.DataSource = tableRes;
            }
            catch (Exception sqlex)
            {
                //Connection Error
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(sqlex);
                throw;
            }
        }
    }
}
