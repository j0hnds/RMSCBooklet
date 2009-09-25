
using System;
using System.Data;
using Npgsql;

namespace RMSCBookletMaker
{
	
	
	public class DataSource
	{
		private const string HOST = "hagrid";
		private const int PORT = 5432;
		private const string USER = "postgres";
		private const string PASSWORD = "jordan123";
		private const string DB_NAME = "RMSC";
		private const string CONNECTION_TEMPLATE= "Server={0};Port={1};User Id={2};Password={3};Database={4}";
		private static readonly string CONNECTION_STRING = string.Format(CONNECTION_TEMPLATE, HOST, PORT, USER, PASSWORD, DB_NAME);
		
		private static DataSource instance = null;
		
		private NpgsqlConnection connection;
		
		public static DataSource Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new DataSource();
				}
				
				return instance;
			}
		}
		
		private DataSource()
		{
		}
		
		public NpgsqlConnection Connection
		{
			get 
			{
				if (connection == null)
				{
					connection = new NpgsqlConnection(CONNECTION_STRING);
					connection.Open();
				}
				
				return connection;
			}
		}
		
		public void Close()
		{
			if (connection != null)
			{
				connection.Close();
				connection = null;
			}
		}
	}
}
