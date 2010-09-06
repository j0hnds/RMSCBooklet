using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Gtk;
using RMSCBookletMaker;
using iTextSharp.text.pdf;

/// <summary>
/// The main window of the application.
/// </summary>
public partial class MainWindow: Gtk.Window
{	
	// The name of the PDF file to construct.
	private string pdfFileName;
	// The selected show
	private long selectedShowId;
	
	/// <summary>
	/// Constructs a new MainWindow object.
	/// </summary>
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		SetUpStoreCombo();
	}
	
	/// <summary>
	/// Loads the store combo box with the stores available in the
	/// data base. Got to give the user something to choose from.
	/// </summary>
	private void SetUpStoreCombo()
	{
		ListStore ls = new ListStore(GLib.GType.String, GLib.GType.Int64);
		List<Show> shows = BookletDAO.GetShows();
		foreach (Show show in shows)
		{
			ls.AppendValues(show.Description, show.ShowId);
		}
		cbShows.Model = ls;
	}
	
	/// <summary>
	/// Event handler for the application Delete event. Actually
	/// exits the application.
	/// </summary>
	/// <param name="sender">
	/// The control which generated the event.
	/// </param>
	/// <param name="a">
	/// The arguments for the event.
	/// </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	/// <summary>
	/// Helper method to display a message box to ask the user if 
	/// the selected file name should be overwritten.
	/// </summary>
	/// <param name="fileName">
	/// The name of the file to be overwritten.
	/// </param>
	/// <returns>
	/// True if the file should be overwritten.
	/// </returns>
	private bool OverwriteFile(string fileName)
	{
		MessageDialog mdlg = new MessageDialog(this,
		                                       DialogFlags.DestroyWithParent,
		                                       MessageType.Question,	
		                                       ButtonsType.YesNo,
		                                       "Are you sure you want overwrite file: {0}?",
		                                       fileName);
		mdlg.Title = "Overwrite File";
		bool overwrite = mdlg.Run() == (int) ResponseType.Yes;
		mdlg.Destroy();
		
		return overwrite;
	}

	/// <summary>
	/// Event handler for when the Save button is clicked.
	/// </summary>
	/// <param name="sender">
	/// The save button.
	/// </param>
	/// <param name="e">
	/// The arguments associated with the event.
	/// </param>
	protected virtual void SaveButtonClicked (object sender, System.EventArgs e)
	{
		FileChooserDialog dlg = new FileChooserDialog("Choose the name of the PDF File",
		                                              this,
		                                              FileChooserAction.Save,
		                                              "Cancel", ResponseType.Cancel,
		                                              "Save", ResponseType.Accept);
		
		if (dlg.Run() == (int) ResponseType.Accept)
		{
			pdfFileName = dlg.Filename;
			dlg.Destroy();
			
			// Check to see if the file already exists...
			if (File.Exists(pdfFileName))
			{
				if (OverwriteFile(pdfFileName))
				{
					File.Delete(pdfFileName);
				}
				else
				{
					// Fine; they have to pick another name...
					return;
				}
			}
			Console.WriteLine(string.Format("PDF Name: {0}", pdfFileName));
			
			Thread th = new Thread(CreatePDF);
			
			th.Start();
		}
		else
		{
			dlg.Destroy();
		}
	}

	/// <summary>
	/// Handles the event when the exit button is clicked.
	/// </summary>
	/// <param name="sender">
	/// The exit button.
	/// </param>
	/// <param name="e">
	/// The event arguments.
	/// </param>
	protected virtual void ExitButtonClicked (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	/// <summary>
	/// Helper method to actually construct the PDF file for the show.
	/// </summary>
	private void CreatePDF()
	{
		pbProgress.Visible = true;
		
		RMSCBookletPDF doc = new RMSCBookletPDF();
		PdfWriter.GetInstance(doc, new FileStream(pdfFileName, FileMode.CreateNew));
		
		doc.Open();
		
		ShowInfo showInfo = BookletDAO.GetShowInfo(selectedShowId);
		
		doc.TitlePage(showInfo);
		
		pbProgress.Fraction = 0.1;
		
		doc.WelcomePage(showInfo);

		pbProgress.Fraction = 0.2;
		
		List<ExhibitorNameCard> cards = BookletDAO.GetExhibitorCards(selectedShowId);
		
		doc.ExhibitorNameCards(cards);
		
		pbProgress.Fraction = 0.5;
		
		List<ExhibitorLineRoom> elrs = BookletDAO.GetExhibitorLineRoom(selectedShowId);
		
		doc.LineRoomExhibitor(elrs);
		
		pbProgress.Fraction = 0.8;
		
		doc.ThankYou(showInfo);
		
		pbProgress.Fraction = 1;
		
		pbProgress.Visible = false;
		doc.Close();
	}

	/// <summary>
	/// Event handler for the show cursor changing.
	/// </summary>
	/// <param name="sender">
	/// The object that sent the event.
	/// </param>
	/// <param name="e">
	/// The event arguments.
	/// </param>
	protected virtual void ShowCursorChanged (object sender, System.EventArgs e)
	{
		TreeIter iter = TreeIter.Zero;
		if (cbShows.GetActiveIter(out iter))
		{
			selectedShowId = (long) cbShows.Model.GetValue(iter, 1);
			btnGenerate.Sensitive = true;
		}
		else
		{
			btnGenerate.Sensitive = false;
		}
	}
}