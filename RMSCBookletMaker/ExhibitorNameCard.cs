
using System;

namespace RMSCBookletMaker
{
	
	
	public class ExhibitorNameCard
	{
		private string fullName;
		private string roomAssignment;
		private string address;
		private string city;
		private string state;
		private string postalCode;
		private string phone;
		private string fax;
		private string cell;
		private string email;
		private string lines;
		
		public ExhibitorNameCard()
		{
		}
		
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
		
		public string RoomAssignment
		{
			get { return roomAssignment; }
			set { roomAssignment = value; }
		}
		
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
		
		public string City 
		{
			get { return city; }
			set { city = value; }
		}
		
		public string State
		{
			get { return state; }
			set { state = value; }
		}
		
		public string PostalCode
		{
			get { return postalCode; }
			set { postalCode = value; }
		}
		
		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}
		
		public string Fax
		{
			get { return fax; }
			set { fax = value; }
		}
		
		public string Cell
		{
			get { return cell; }
			set { cell = value; }
		}
		
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		
		public string Lines
		{
			get { return lines; }
			set { lines = value; }
		}
	}
}
