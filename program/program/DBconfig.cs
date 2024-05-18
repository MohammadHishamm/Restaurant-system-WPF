﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace program
{
    public class DBconfig  //Singleton design pattern
    {
        private static DBconfig instance;
        private readonly string connectionString;

        // Use a connection string instead of a SqlConnection object
        private readonly SqlConnection conn;

        public DBconfig()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Res.mdf;Integrated Security=True;Connect Timeout=30"; conn = new SqlConnection(connectionString);
        }

        public SqlConnection GetConn()
        {
            return conn;
        }

        public static DBconfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBconfig();
                }
                return instance;
            }
        }

        public void OpenConnection()
        {
            try
            {
                conn.Open();

                // Check if the connection is successfully opened
                if (conn.State == ConnectionState.Open)
                {
                    // Connection opened successfully
                    Debug.WriteLine("Connection opened successfully.");

                    // Perform some operations here if needed
                }
                else
                {
                    // Connection was not opened successfully
                    Debug.WriteLine("Connection was not opened successfully.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while opening connection: {ex.Message}");
            }
        }

        public void InsertData(string insertQuery)
        {
            try
            {
                // Create a new command
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Debug.WriteLine("Data inserted successfully.");
                    }
                    else
                    {
                        Debug.WriteLine("No rows were inserted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while inserting data: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CloseConnection()
        {
            try
            {
                conn.Close();

                // Check if the connection is successfully closed
                if (conn.State == ConnectionState.Closed)
                {
                    // Connection closed successfully
                    Debug.WriteLine("Connection closed successfully.");
                }
                else
                {
                    // Connection was not closed successfully
                    Debug.WriteLine("Connection was not closed successfully.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while closing connection: {ex.Message}");
            }
        }

    }
}