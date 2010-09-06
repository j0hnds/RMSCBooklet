
using System;

namespace RMSCBookletMaker
{
	
	/// <summary>
	/// Value object for show information.
	/// </summary>
	public class Show
	{
		// Unique identifier for the show
		private long showId;
		// The description of the show.
		private string description;
		
		/// <summary>
		/// Constructs a new show.
		/// </summary>
		public Show()
		{
		}
		
		/// <value>
		/// The unique identifier for the show.
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
	}
}
