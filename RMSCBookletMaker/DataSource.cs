
using System;
using System.Data;
using Npgsql;
using System.Configuration;

namespace RMSCBookletMaker
{
	
	
	public class DataSource
	{
		private static readonly string HOST = ConfigurationManager.AppSettings["host"];
		private static readonly int PORT = int.Parse(ConfigurationManager.AppSettings["port"]);
		private static readonly string USER = ConfigurationManager.AppSettings["user"];
		private static readonly string PASSWORD = ConfigurationManager.AppSettings["password"];
		private static readonly string DB_NAME = ConfigurationManager.AppSettings["dbname"];
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
