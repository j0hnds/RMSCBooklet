
using System;

namespace RMSCBookletMaker
{
	
	
	public class ShowInfo
	{
		private long showId;
		private string description;
		private DateTime startDate;
		private DateTime endDate;
		private string location;
		private string coordinator;
		private string locationPhone;
		private string locationFax;
		private string locationReservation;
		private string nextShow;
		private string coordinatorPhone;
		private string coordinatorEmail;
		private string locationAddress;
		private string locationCity;
		private string locationState;
		private string locationPostalCode;
		
		public ShowInfo()
		{
		}
		
		public long ShowId
		{
			get { return showId; }
			set { showId = value; }
		}
		
		public string Description 
		{
			get { return description; }
			set { description = value; }
		}
		
		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}
		
		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
		
		public string Location {
			get { return location; }
			set { location = value; }
		}
		
		public string Coordinator
		{
			get { return coordinator; }
			set { coordinator = value; }
		}
		
		public string LocationPhone
		{
			get { return locationPhone; }
			set { locationPhone = value; }
		}
		
		public string LocationFax
		{
			get { return locationFax; }
			set { locationFax = value; }
		}
		
		public string LocationReservation
		{
			get { return locationReservation; }
			set { locationReservation = value; }
		}
		
		public string NextShow
		{
			get { return nextShow; }
			set { nextShow = value; }
		}
		
		public string CoordinatorPhone
		{
			get { return coordinatorPhone; }
			set { coordinatorPhone = value; }
		}
		
		public string CoordinatorEmail
		{
			get { return coordinatorEmail; }
			set { coordinatorEmail = value; }
		}
		
		public string LocationAddress
		{
			get { return locationAddress; }
			set { locationAddress = value; }
		}
		
		public string LocationCity
		{
			get { return locationCity; }
			set { locationCity = value; }
		}
		
		public string LocationState
		{
			get { return locationState; }
			set { locationState = value; }
		}
		
		public string LocationPostalCode
		{
			get { return locationPostalCode; }
			set { locationPostalCode = value; }
		}
	}
}
