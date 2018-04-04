using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EduSharp.Troelsen.Unit21
{
    enum DataProvider
    {
        SqlServer, OleDb, Odbc, None
    }

    class Program
    {
        static void Main(string[] args)
        {
//            //
//            WriteLine("***** Very Simple Connection Factory *****\n");
//            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
//            Console.WriteLine($"Your connection is a {myConnection.GetType().Name}");
//
//            SimpleConnFactory();
            DataProviderFactories();




            ReadLine();
        }

        static void DataProviderFactories()
        {
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
            
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection==null)
                {
                    ShowError("Connection");
                    return;
                }

                Console.WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();
                if (command ==null)
                {
                        ShowError("Command");
                    return;
                }
                Console.WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * FROM Inventory";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"Your datta reader object is a: {dataReader.GetType().Name}");

                    Console.WriteLine("\n***** Current Inventory *****");
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"-> Car #{dataReader["carId"]} is a {dataReader["Make"]}.");
                    }
                }
            }


        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }

        static void SimpleConnFactory()
        {
            WriteLine("***** Very Simple Connection Factory 2 *****\n");

            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            DataProvider dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider),dataProviderString))
            {
                dataProvider = (DataProvider) Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                Console.WriteLine("Sorry, no provider exists!");
                return;
            }

            IDbConnection myConnection = GetConnection(dataProvider);
            Console.WriteLine($"Your connection is a {myConnection.GetType().Name ?? "unrecognized type"}");

        }

        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection=new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }

            return connection;
        }
    }
}




/*
 =====================================================

// ===   Create db
    USE [master]
GO

CREATE DATABASE [AutoLot]
 CONTAINMENT = NONE
GO

 
// ===   Create Inventory Table

   CREATE TABLE [dbo].Inventory
(
	[CarId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Make] NVARCHAR(50) NULL, 
    [Color] NVARCHAR(50) NULL, 
    [PetName] NVARCHAR(50) NULL
);

// ===   Insert data to Inventory Table
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('VW', 'Black', 'Zippy')
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('Ford', 'Rust', 'Rusty')
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('Saab', 'Black', 'Mel')
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('Yugo', 'Wellow', 'Clunker')
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('MBW', 'Black', 'Bimmer')
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('MBW', 'Green', 'Hank')
INSERT INTO [dbo].[Inventory] ([Make], [Color], [PetName]) VALUES ('MBW', 'Pink', 'Pinky')

// ===   Create SP GetPetName
USE [AutoLot]
GO
CREATE procedure GetPetName
@carID int,
@petName char(10) output
AS
select @petName = PetName from Inventory where CarID = @carID

// ===   Create Customers Table
CREATE TABLE [dbo].[Customers]
(
	[CustId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL
)

// ===   Insert data to Customers Table
    INSERT INTO [dbo].[Customers] ( [FirstName], [LastName]) VALUES ('Dave', 'Brenner');
INSERT INTO [dbo].[Customers] ( [FirstName], [LastName]) VALUES ('Matt', 'Walton');
INSERT INTO [dbo].[Customers] ( [FirstName], [LastName]) VALUES ('Steve', 'Hagen');
INSERT INTO [dbo].[Customers] ( [FirstName], [LastName]) VALUES ('Pat', 'Walton');


// ===   Create Orders Table
CREATE TABLE [dbo].Orders
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustId] INT NOT NULL, 
    [CarID] INT NOT NULL, 
    CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY (CarID) REFERENCES Inventory(CarID), 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY (CustId) REFERENCES Customers(CustId)
)


 * 
 * 
 * 
 * 
 */
