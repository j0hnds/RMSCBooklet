
using System;
using System.Collections.Generic;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RMSCBookletMaker
{
	
	/// <summary>
	/// A PDF Document to construct the 
	/// </summary>
	public class RMSCBookletPDF : Document
	{
		
		/// <summary>
		/// Constructs a new RMSCBookletPDF.
		/// </summary>
		public RMSCBookletPDF() :
			base(iTextSharp.text.PageSize.LETTER)
		{
		}
		
		/// <summary>
		/// Renders the title page of the booklet.
		/// </summary>
		/// <param name="showInfo">
		/// Reference to the Show Information for the booklet.
		/// </param>
		public void TitlePage(ShowInfo showInfo)
		{
			Image img = Image.GetInstance(ConfigurationManager.AppSettings["mountainsImage"]);
			img.Alignment = Image.MIDDLE_ALIGN;
			Console.WriteLine(string.Format("Image = {0}", img));
			Add(img);
			
			Paragraph p = new Paragraph("Rocky Mountain");
			p.Font.Size = 30;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);

			p = new Paragraph("Shoe Show");
			p.Font.Size = 30;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingBefore = 18;
			Add(p);
			
			p = new Paragraph("Denver Market");
			p.Font.Size = 20;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingBefore = 18;
			Add(p);
			
			DateTime startDt = showInfo.StartDate;
			DateTime endDt = showInfo.EndDate;
			
			string nextShow = string.Format("{0} {1}-{2}, {3}",
			                                startDt.ToString("MMMM"),
			                                startDt.Day,
			                                endDt.Day,
			                                startDt.Year);
			p = new Paragraph(nextShow);
			p.Font.Size = 18;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingBefore = 36;
			Add(p);
			
			p = new Paragraph(showInfo.Location);
			p.Font.Size = 18;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			p = new Paragraph(showInfo.LocationAddress);
			p.Font.Size = 18;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			string addr = string.Format("{0}, {1} {2}",
			                            showInfo.LocationCity,
			                            showInfo.LocationState,
			                            showInfo.LocationPostalCode);
			p = new Paragraph(addr);
			p.Font.Size = 18;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 36;
			Add(p);
			
			PdfPTable table = new PdfPTable(2);
			table.WidthPercentage = 40;
			p = new Paragraph("Saturday");
			p.Font.Size = 15;
			PdfPCell cell = new PdfPCell(p);
			cell.Border = PdfPCell.NO_BORDER;
			table.AddCell(cell);
			p = new Paragraph("9am to 5pm");
			p.Font.Size = 15;
			cell = new PdfPCell(p);
			cell.Border = PdfPCell.NO_BORDER;
			table.AddCell(cell);
			p = new Paragraph("Sunday");
			p.Font.Size = 15;
			cell = new PdfPCell(p);
			cell.Border = PdfPCell.NO_BORDER;
			table.AddCell(cell);
			p = new Paragraph("9am to 5pm");
			p.Font.Size = 15;
			cell = new PdfPCell(p);
			cell.Border = PdfPCell.NO_BORDER;
			table.AddCell(cell);
			Add(table);

			p = new Paragraph("Friday & Monday - by Appointment only");
			p.Font.Size = 15;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			NewPage();
		}

		/// <summary>
		/// Renders the Welcome Page for the booklet.
		/// </summary>
		/// <param name="showInfo">
		/// Reference to the show information.
		/// </param>
		public void WelcomePage(ShowInfo showInfo)
		{
			Paragraph p = new Paragraph("Welcome to the Market");
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);
			
			DateTime startDate = showInfo.StartDate;
			
			string txt = string.Format("Members of the Rocky Mountain Shoe Club welcome you to the {0}, {1} Denver Shoe Market.", 
			                           startDate.ToString("MMMM"),
			                           startDate.Year);
			p = new Paragraph(txt);
			p.Font.Size = 16;
			p.SpacingAfter = 20;
			Add(p);

			txt = string.Format("We have over {0} Reps, marketing over {1} lines including shoes, socks, slippers and handbags.",
			                    ConfigurationManager.AppSettings["num_exhibitors"],
			                    ConfigurationManager.AppSettings["num_lines"]);
			p = new Paragraph(txt);
			p.Font.Size = 16;
			p.SpacingAfter = 40;
			Add(p);

			p = new Paragraph("Lunch");
			p.Font.Size = 16;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Lunch will be served Saturday and Sunday from 12:00pm to 1:30pm in the Aspen room and lounge area.");
			p.Font.Size = 16;
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Retailers and exhibitors - We will be having a social hour on Saturday night in the Aspen room starting at 5:00pm.");
			p.Font.Size = 16;
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Snacks and soft drinks will be provided.");
			p.Font.Size = 16;
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Alcoholic beverages will be provided by the exhibitors.");
			p.Font.Size = 16;
			p.SpacingAfter = 36;
			Add(p);

			p = new Paragraph("NEXT SHOE MARKET");
			p.Font.Size = 26;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD);
			Add(p);

			p = new Paragraph(showInfo.NextShow);
			p.Font.Size = 26;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD);
			p.SpacingAfter = 30;
			Add(p);

			p = new Paragraph(string.Format("Show Coordinator: {0}", showInfo.Coordinator));
			p.Font.Size = 16;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);

			p = new Paragraph(string.Format("Phone: {0}", showInfo.CoordinatorPhone));
			p.Font.Size = 16;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);

			p = new Paragraph(showInfo.CoordinatorEmail);
			p.Font.Size = 16;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			NewPage();
		}

		/// <summary>
		/// Renders the Exhibitor name card pages for the booklet.
		/// </summary>
		/// <param name="cards">
		/// The list of exhibitor name cards.
		/// </param>
		public void ExhibitorNameCards(List<ExhibitorNameCard> cards)
		{
			PdfPTable table = new PdfPTable(2);
			table.WidthPercentage = 100;
			int numExhibitors = 0;
			
			foreach (ExhibitorNameCard card in cards)
			{
				numExhibitors++;
				Paragraph p = new Paragraph();
				p.Font.Size = 15;
				string nameSection = string.Format("{0}\nRoom #{1}\n",
				                                   card.FullName,
				                                   card.RoomAssignment);
				Chunk chk = new Chunk(nameSection);
				chk.Font.SetStyle(Font.BOLD);
				p.Add(chk);
				
				string address = string.Format("{0}\n{1}, {2} {3}\n",
				                               card.Address,
				                               card.City,
				                               card.State,
				                               card.PostalCode);
				chk = new Chunk(address);
				p.Add(chk);
				
				if (card.Phone != null)
				{
					chk = new Chunk("Phone: ");
					chk.Font.SetStyle(Font.BOLD);
					p.Add(chk);
					
					chk = new Chunk(string.Format("{0}\n", card.Phone));
					p.Add(chk);
				}

				if (card.Fax != null)
				{
					chk = new Chunk("Fax: ");
					chk.Font.SetStyle(Font.BOLD);
					p.Add(chk);
					
					chk = new Chunk(string.Format("{0}\n", card.Fax));
					p.Add(chk);
				}

				if (card.Cell != null)
				{
					chk = new Chunk("Cell: ");
					chk.Font.SetStyle(Font.BOLD);
					p.Add(chk);
					
					chk = new Chunk(string.Format("{0}\n", card.Cell));
					p.Add(chk);
				}
				
				if (card.Email != null)
				{
					chk = new Chunk(string.Format("{0}\n", card.Email));
					p.Add(chk);
				}
				
				chk = new Chunk("Lines: ");
				chk.Font.SetStyle(Font.BOLD);
				p.Add(chk);
				
				chk = new Chunk(card.Lines);
				p.Add(chk);

				PdfPCell cell = new PdfPCell(p);
				cell.Border = PdfPCell.NO_BORDER;
				cell.NoWrap = false;
				cell.FixedHeight = 180f;
				cell.PaddingRight = 10f;
				table.AddCell(cell);
			}
			
			if (numExhibitors % 2 == 1)
			{
				PdfPCell cell = new PdfPCell(new Paragraph(""));
				cell.Border = PdfPCell.NO_BORDER;
				cell.NoWrap = false;
				cell.FixedHeight = 180f;
				cell.PaddingRight = 10f;
				table.AddCell(cell);
			}
			
			Add(table);
			
			NewPage();
		}

		/// <summary>
		/// Renders the exhibitor line and room table pages of the document.
		/// </summary>
		/// <param name="elrs">
		/// The list of exhibitor line room information objects.
		/// </param>
		public void LineRoomExhibitor(List<ExhibitorLineRoom> elrs)
		{
			PdfPTable table = new PdfPTable(3);
			table.WidthPercentage = 100;
			
			int[] widths = { 60, 10, 30 };
			table.SetWidths(widths);
			Paragraph ph = new Paragraph("LINES");
			ph.Font.Size = 15;
			ph.Font.SetStyle(Font.BOLD);
			PdfPCell cell = new PdfPCell(ph);
			table.AddCell(cell);
			
			ph = new Paragraph("ROOM");
			ph.Font.Size = 15;
			ph.Font.SetStyle(Font.BOLD);
			cell = new PdfPCell(ph);
			table.AddCell(cell);
			
			ph = new Paragraph("EXHIBITOR");
			ph.Font.Size = 15;
			ph.Font.SetStyle(Font.BOLD);
			cell = new PdfPCell(ph);
			table.AddCell(cell);
			
			table.HeaderRows = 1;
			
			int i = 1;

			foreach (ExhibitorLineRoom elr in elrs)
			{
				Paragraph p = new Paragraph(elr.Line);
				p.Font.Size = 15;
				if (i % 2 == 0) 
				{
					p.Font.SetStyle(Font.BOLD);
				}
				cell = new PdfPCell(p);
				table.AddCell(cell);

				string room = (elr.Room != null) ? elr.Room : "";
				p = new Paragraph(room);
				p.Font.Size = 15;
				if (i % 2 == 0) 
				{
					p.Font.SetStyle(Font.BOLD);
				}
				cell = new PdfPCell(p);
				table.AddCell(cell);

				p = new Paragraph(elr.FullName);
				p.Font.Size = 15;
				if (i % 2 == 0) 
				{
					p.Font.SetStyle(Font.BOLD);
				}
				cell = new PdfPCell(p);
				table.AddCell(cell);
				i++;
			}
			
			Add(table);
		}

		/// <summary>
		/// Renders the thank you page for the booklet.
		/// </summary>
		/// <param name="showInfo">
		/// Reference to the Show Information object.
		/// </param>
		public void ThankYou(ShowInfo showInfo)
		{
// The following comments are for the inclusion of notes pages.
// We currently don't want this, but I'm leaving it in for the future.
//
			int currentPage = this.PageNumber;
			Console.WriteLine(string.Format("Current Page: {0}", currentPage));
			int remainder = currentPage % 4;
			int notesPagesToAdd = 0; // (remainder > 0) ? remainder - 1 : 3;
//			Console.WriteLine(string.Format("Notes pages to add: {0}", notesPagesToAdd));
//			
			for (int i=0; i<notesPagesToAdd; i++)
			{
				NewPage();
				Paragraph pNote = new Paragraph("NOTES");
				pNote.Font.Size = 20;
				pNote.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
				pNote.Alignment = Element.ALIGN_CENTER;
				Add(pNote);
			}
			
			NewPage();
			
			Paragraph p = new Paragraph("THANK YOU");
			p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 20;
			Add(p);
			
			p = new Paragraph("FOR COMING TO THE SHOW");
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 100;
			Add(p);
			
			p = new Paragraph("NEXT MARKET");
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 20;
			Add(p);
			
			p = new Paragraph(showInfo.NextShow);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 100;
			Add(p);
			
			p = new Paragraph(showInfo.Location);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			p = new Paragraph(showInfo.LocationAddress);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);

			string addr = string.Format("{0}, {1}  {2}",
			                            showInfo.LocationCity,
			                            showInfo.LocationState,
			                            showInfo.LocationPostalCode);
			p = new Paragraph(addr);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			string phone = string.Format("Phone: {0}",
			                            showInfo.LocationPhone);
			p = new Paragraph(phone);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			string fax = string.Format("Fax: {0}",
			                            showInfo.LocationFax);
			p = new Paragraph(fax);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
		}
	}
}
