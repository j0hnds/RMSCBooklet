
using System;

namespace RMSCBookletMaker
{
	

	/// <summary>
	/// Value object holding the exhibitor name, contact information
	/// and lines.
	/// </summary>
	public class ExhibitorNameCard
	{
		// The full name of the exhibitor
		private string fullName;
		// The exhibitor's room number.
		private string roomAssignment;
		// The exhibitor's address
		private string address;
		// The city
		private string city;
		// The state
		private string state;
		// The postal code
		private string postalCode;
		// The exhibitor's work number
		private string phone;
		// The exhibitor's fax number
		private string fax;
		// The exhibitor's cell phone
		private string cell;
		// The exhibitor's email address
		private string email;
		// The exhibitor's lines
		private string lines;
		
		/// <summary>
		/// Constructs a new ExhibitorNameCard object.
		/// </summary>
		public ExhibitorNameCard()
		{
		}
		
		/// <value>
		/// The exhibitor's full name.
		/// </value>
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
		
		/// <value>
		/// The exhibitor's room assignment.
		/// </value>
		public string RoomAssignment
		{
			get { return roomAssignment; }
			set { roomAssignment = value; }
		}
		
		/// <value>
		/// The exhibitor's street address
		/// </value>
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
		
		/// <value>
		/// The exhibitor's city address
		/// </value>
		public string City 
		{
			get { return city; }
			set { city = value; }
		}
		
		/// <value>
		/// The exhibitor's state
		/// </value>
		public string State
		{
			get { return state; }
			set { state = value; }
		}
		
		/// <value>
		/// The exhibitor's postal code.
		/// </value>
		public string PostalCode
		{
			get { return postalCode; }
			set { postalCode = value; }
		}
		
		/// <value>
		/// The exhibitor's work phone number
		/// </value>
		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}
		
		/// <value>
		/// The exhibitor's fax number
		/// </value>
		public string Fax
		{
			get { return fax; }
			set { fax = value; }
		}
		
		/// <value>
		/// The exhibitor's cell phone number.
		/// </value>
		public string Cell
		{
			get { return cell; }
			set { cell = value; }
		}
		
		/// <value>
		/// The exhibitor's email address
		/// </value>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		
		/// <value>
		/// The exhibitor's lines.
		/// </value>
		public string Lines
		{
			get { return lines; }
			set { lines = value; }
		}
	}
}
