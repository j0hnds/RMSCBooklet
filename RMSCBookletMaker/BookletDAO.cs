
using System;
using System.Data;
using Npgsql;
using System.Collections.Generic;
using log4net;

namespace RMSCBookletMaker
{
	
	
	public class BookletDAO
	{
		private const string GET_SHOWS_SQL = "SELECT SHOW_ID, DESCRIPTION FROM SHOW ORDER BY CREATE_DATE DESC";
		private const string GET_SHOW_INFO_SQL = "SELECT * FROM SHOW WHERE SHOW_ID = {0}";
		private const string GET_EXHIBITOR_CARD_SQL = @"SELECT
		        e.FIRST_NAME || ' ' || e.LAST_NAME AS FULL_NAME,
		        ea.ROOM_ASSIGNMENT,
		        e.ADDRESS_1,
		        e.CITY,
		        e.STATE,
		        e.POSTAL_CODE,
		        e.PHONE,
		        e.FAX,
		        e.CELL,
		        e.EMAIL,
		        attendee_lines('E', e.EXHIBITOR_ID, {0})
		      FROM
		        EXHIBITOR_ATTENDANCE ea,
		        EXHIBITOR e
		      WHERE
		        e.EXHIBITOR_ID = ea.EXHIBITOR_ID
		        AND ea.SHOW_ID = {0}
		      ORDER BY
		        e.LAST_NAME,
		        e.FIRST_NAME";
		private const string EXHIBITOR_LINE_ROOM_SQL = "SELECT LINE, ROOM_ASSIGNMENT, FIRST_NAME || ' ' || LAST_NAME AS FULL_NAME FROM LINE_ROOM_EXHIBITOR WHERE SHOW_ID = {0} ORDER BY LINE, LAST_NAME, FIRST_NAME";
		
		private static ILog log = LogManager.GetLogger(typeof(BookletDAO));
		
		private BookletDAO()
		{
		}
		
		public static List<Show> GetShows()
		{
			List<Show> shows = new List<Show>();
			
			NpgsqlConnection conn = DataSource.Instance.Connection;
			
			NpgsqlCommand cmd = new NpgsqlCommand(GET_SHOWS_SQL, conn);
			
			try
			{
				IDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Show show = new Show();
					
					show.ShowId = reader.GetInt64(0);
					show.Description = reader.GetString(1);
					
					shows.Add(show);
				}
				
				reader.Close();
			}
			finally
			{
				DataSource.Instance.Close();
			}
			
			return shows;
		}
		
		public static ShowInfo GetShowInfo(long showId)
		{
			Console.WriteLine(string.Format("ShowInfo({0})", showId));
			ShowInfo showInfo = null;
			
			NpgsqlConnection conn = DataSource.Instance.Connection;
			
			NpgsqlCommand cmd = new NpgsqlCommand(string.Format(GET_SHOW_INFO_SQL, showId), conn);
			
			try
			{
				IDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					showInfo = new ShowInfo();
					
					showInfo.ShowId = reader.GetInt64(0);
					showInfo.Description = reader.GetString(1);
					showInfo.StartDate = reader.GetDateTime(2);
					showInfo.EndDate = reader.GetDateTime(3);
					showInfo.Location = reader.GetString(4);
					showInfo.Coordinator = reader.GetString(9);
					showInfo.LocationPhone = reader.GetString(10);
					showInfo.LocationFax = reader.GetString(11);
					showInfo.LocationReservation = reader.GetString(12);
					showInfo.NextShow = reader.GetString(13);
					showInfo.CoordinatorPhone = reader.GetString(14);
					showInfo.CoordinatorEmail = reader.GetString(15);
					showInfo.LocationAddress = reader.GetString(16);
					showInfo.LocationCity = reader.GetString(17);
					showInfo.LocationState = reader.GetString(18);
					showInfo.LocationPostalCode = reader.GetString(19);
				}
				
				reader.Close();
			}
			finally
			{
				DataSource.Instance.Close();
			}
			
			return showInfo;
		}
		
		public static List<ExhibitorNameCard> GetExhibitorCards(long showId)
		{
			string sql = string.Format(GET_EXHIBITOR_CARD_SQL, showId);
			List<ExhibitorNameCard> cards = new List<ExhibitorNameCard>();
			
			NpgsqlConnection conn = DataSource.Instance.Connection;
			
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			
			try
			{
				IDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ExhibitorNameCard card = new ExhibitorNameCard();
					
					card.FullName = reader.GetString(0);
					if (! reader.IsDBNull(1))
					{
						card.RoomAssignment = reader.GetString(1);
					}
					else
					{
						card.RoomAssignment = "";
					}
					card.Address = reader.GetString(2);
					card.City = reader.GetString(3);
					card.State = reader.GetString(4);
					card.PostalCode = reader.GetString(5);
					if (! reader.IsDBNull(6))
					{
						card.Phone = reader.GetString(6);
					}
					if (! reader.IsDBNull(7))
					{
						card.Fax = reader.GetString(7);
					}
					if (! reader.IsDBNull(8))
					{
						card.Cell = reader.GetString(8);
					}
					if (! reader.IsDBNull(9))
					{
						card.Email = reader.GetString(9);
					}
					card.Lines = reader.GetString(10);
					
					cards.Add(card);
				}
				
				reader.Close();
			}
			finally
			{
				DataSource.Instance.Close();
			}
			
			return cards;
		}

		public static List<ExhibitorLineRoom> GetExhibitorLineRoom(long showId)
		{
			string sql = string.Format(EXHIBITOR_LINE_ROOM_SQL, showId);
			List<ExhibitorLineRoom> elrs = new List<ExhibitorLineRoom>();
			
			NpgsqlConnection conn = DataSource.Instance.Connection;
			
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			
			try
			{
				IDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ExhibitorLineRoom elr = new ExhibitorLineRoom();
					
					if (! reader.IsDBNull(0))
					{
						elr.Line = reader.GetString(0);
					}
					
					if (! reader.IsDBNull(1))
					{
						elr.Room = reader.GetString(1);
					}
					
					if (! reader.IsDBNull(2))
					{
						elr.FullName = reader.GetString(2);
					}
					
					elrs.Add(elr);
				}
				
				reader.Close();
			}
			finally
			{
				DataSource.Instance.Close();
			}
			
			return elrs;
		}
	}
}
