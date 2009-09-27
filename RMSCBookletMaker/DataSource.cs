
using System;
using System.Data;
using Npgsql;
using System.Configuration;

namespace RMSCBookletMaker
{
	
	/// <summary>
	/// This class is responsible for exposing the functionality of
	/// a database data source.
	/// </summary>
	public class DataSource
	{
		// The host of the data base server
		private static readonly string HOST = ConfigurationManager.AppSettings["host"];
		// The port of the data base server
		private static readonly int PORT = int.Parse(ConfigurationManager.AppSettings["port"]);
		// The user name of the database. Must have read/write access to data in the
		// RMSC schema.
		private static readonly string USER = ConfigurationManager.AppSettings["user"];
		// THe password for the user of the database.
		private static readonly string PASSWORD = ConfigurationManager.AppSettings["password"];
		// The name of the database to acces.
		private static readonly string DB_NAME = ConfigurationManager.AppSettings["dbname"];
		// The string template for the form of the connection string.
		private const string CONNECTION_TEMPLATE= "Server={0};Port={1};User Id={2};Password={3};Database={4}";
		// Constructs the connection string from the template and parameters.
		private static readonly string CONNECTION_STRING = string.Format(CONNECTION_TEMPLATE, HOST, PORT, USER, PASSWORD, DB_NAME);
		
		// The one-and-only datasource instance.
		private static DataSource instance = null;
		
		private NpgsqlConnection connection;
		
		/// <value>
		/// The one-and-only reference to the data source instance.
		/// </value>
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
		
		/// <summary>
		/// Constructs a new DataSource object. Marked as private to
		/// disallow others from instantiating this object.
		/// </summary>
		private DataSource()
		{
		}
		
		/// <value>
		/// The data base connection. If the connection has been closed it
		/// will be reconnected and returned.
		/// </value>
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
		
		/// <summary>
		/// Closes the data base connection.
		/// </summary>
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
