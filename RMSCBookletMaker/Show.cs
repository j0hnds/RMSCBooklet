
using System;

namespace RMSCBookletMaker
{
	
	
	public class Show
	{
		private long showId;
		private string description;
		
		public Show()
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
	}
}
