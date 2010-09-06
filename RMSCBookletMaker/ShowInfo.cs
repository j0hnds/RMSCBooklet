
using System;

namespace RMSCBookletMaker
{
	
	/// <summary>
	/// Value object for show information.
	/// </summary>
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
		
		/// <summary>
		/// Constructs a new ShowInformation object.
		/// </summary>
		public ShowInfo()
		{
		}
		
		/// <value>
		/// The unique identifier of the show.
		/// </value>
		public long ShowId
		{
			get { return showId; }
			set { showId = value; }
		}
		
		/// <value>
		/// The description of the show.
		/// </value>
		public string Description 
		{
			get { return description; }
			set { description = value; }
		}
		
		/// <value>
		/// The start date of the show.
		/// </value>
		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <value>
		/// The end date of the show.
		/// </value>
		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <value>
		/// The location of the show.
		/// </value>
		public string Location {
			get { return location; }
			set { location = value; }
		}
		
		/// <value>
		/// The show coordinator name.
		/// </value>
		public string Coordinator
		{
			get { return coordinator; }
			set { coordinator = value; }
		}
		
		/// <value>
		/// The phone number of the location.
		/// </value>
		public string LocationPhone
		{
			get { return locationPhone; }
			set { locationPhone = value; }
		}
		
		/// <value>
		/// The fax number of the location.
		/// </value>
		public string LocationFax
		{
			get { return locationFax; }
			set { locationFax = value; }
		}
		
		/// <value>
		/// The reservation number of the location.
		/// </value>
		public string LocationReservation
		{
			get { return locationReservation; }
			set { locationReservation = value; }
		}
		
		/// <value>
		/// The date of the next show.
		/// </value>
		public string NextShow
		{
			get { return nextShow; }
			set { nextShow = value; }
		}
		
		/// <value>
		/// The coordinator's phone number.
		/// </value>
		public string CoordinatorPhone
		{
			get { return coordinatorPhone; }
			set { coordinatorPhone = value; }
		}
		
		/// <value>
		/// The coordinator's email address.
		/// </value>
		public string CoordinatorEmail
		{
			get { return coordinatorEmail; }
			set { coordinatorEmail = value; }
		}
		
		/// <value>
		/// The location's street address
		/// </value>
		public string LocationAddress
		{
			get { return locationAddress; }
			set { locationAddress = value; }
		}
		
		/// <value>
		/// The location city.
		/// </value>
		public string LocationCity
		{
			get { return locationCity; }
			set { locationCity = value; }
		}
		
		/// <value>
		/// The location state.
		/// </value>
		public string LocationState
		{
			get { return locationState; }
			set { locationState = value; }
		}
		
		/// <value>
		/// The location postal code.
		/// </value>
		public string LocationPostalCode
		{
			get { return locationPostalCode; }
			set { locationPostalCode = value; }
		}
	}
}
