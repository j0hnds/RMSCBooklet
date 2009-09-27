
using System;

namespace RMSCBookletMaker
{
	

	/// <summary>
	/// Value object for an Exhibitor's name, lines (formatted) and room
	/// number.
	/// </summary>
	public class ExhibitorLineRoom
	{
		// A space-delimited list of the lines associated with the
		// exhibitor.
		private string line;
		// The exhibitor's room number
		private string room;
		// The exhibitor's full name.
		private string fullName;
		
		/// <summary>
		/// Constructs a new ExhibitorLineRoom object.
		/// </summary>
		public ExhibitorLineRoom()
		{
		}
		
		/// <value>
		/// The space-delimited list of the lines associated with
		/// the exhibitor.
		/// </value>
		public string Line
		{
			get { return line; }
			set { line = value; }
		}
		
		/// <value>
		/// The exhibitor's room number.
		/// </value>
		public string Room
		{
			get { return room; }
			set { room = value; }
		}
		
		/// <value>
		/// The exhibitor's full name.
		/// </value>
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
	}
}
