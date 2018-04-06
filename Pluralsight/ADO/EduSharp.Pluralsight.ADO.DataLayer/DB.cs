using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Pluralsight.ADO.DataLayer
{
    /// <summary>
    /// Connection Statistics
    /// </summary>
    public class ConnectionStatistics
    {
        public long ExecutionTime { get; set; }
        public long BytesReceived { get; set; }

        public ConnectionStatistics(System.Collections.IDictionary stats)
        {
            if (stats.Contains("ExecutionTime"))
            {
                ExecutionTime = long.Parse(stats["ExecutionTime"].ToString());
            }
            if (stats.Contains("BytesReceived"))
            {
                ExecutionTime = long.Parse(stats["BytesReceived"].ToString());
            }
        }
    }

    public class DB
    {
        /// <summary>
        /// Last connection statistics gathered
        /// </summary>
        public ConnectionStatistics LastStatistics { get; set; }

        /// <summary>
        /// Set to true to enable gathering statistics
        /// </summary>
        public bool EnableStatistics { get; set; }

        public static string ConnectionString
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["AWConnection"].ToString();
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;

                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns an openned connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            conn.StatisticsEnabled = EnableStatistics;
            conn.StateChange += conn_StateChange;
            return conn;
        }

        private static void conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if (e.CurrentState == System.Data.ConnectionState.Closed)
            {
                if (((SqlConnection)sender).StatisticsEnabled)
                {
                    LastStatistics=new ConnectionStatistics(((SqlConnection)sender).RetrieveStatistics());
                }
            }
        }

        public static int ConnectionTimeout { get; set; }

        /// <summary>
        /// Property used to override the name of the application
        /// </summary>
        public static string ApplicationName { get; set; }

    }
}
