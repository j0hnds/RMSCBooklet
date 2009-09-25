
using System;

namespace RMSCBookletMaker
{
	
	
	public class ExhibitorLineRoom
	{
		private string line;
		private string room;
		private string fullName;
		
		public ExhibitorLineRoom()
		{
		}
		
		public string Line
		{
			get { return line; }
			set { line = value; }
		}
		
		public string Room
		{
			get { return room; }
			set { room = value; }
		}
		
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
	}
}
