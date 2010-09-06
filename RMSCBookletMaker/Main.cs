using System;
using Gtk;

namespace RMSCBookletMaker
{
	/// <summary>
	/// The main class for the application.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The main entry point from the command line.
		/// </summary>
		/// <param name="args">
		/// The array of command line arguments.
		/// </param>
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}