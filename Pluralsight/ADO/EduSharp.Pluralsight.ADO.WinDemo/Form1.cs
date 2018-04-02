﻿using System;
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
            //            string connString = DataLayer.DB.ConnectionString;
            DataLayer.DB.ApplicationName = "WinDemo Application";
            DataLayer.DB.ConnectionTimeout = 30;

            SqlConnection conn = DataLayer.DB.GetSqlConnection();
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
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicationLog.DeleteCommentsForApp("WinDemo Application");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
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
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
