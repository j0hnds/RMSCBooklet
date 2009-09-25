
using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RMSCBookletMaker
{
	
	
	public class RMSCBookletPDF : Document
	{
		
		public RMSCBookletPDF() :
			base(iTextSharp.text.PageSize.LEGAL)
		{
		}
		
		public void TitlePage(ShowInfo showInfo)
		{
			Image img = Image.GetInstance("file:///home/djs/Projects/RMSCBooklet/RMSCBookletMaker/mountains.jpeg");
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
			p.SpacingBefore = 36;
			Add(p);
			
			p = new Paragraph("Denver Market");
			p.Font.Size = 20;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingBefore = 72;
			Add(p);
			
			DateTime startDt = showInfo.StartDate;
			DateTime endDt = showInfo.EndDate;
			
			string nextShow = string.Format("{0} {1}-{2}, {3}",
			                                startDt.ToString("MMMM"),
			                                startDt.Day,
			                                endDt.Day,
			                                startDt.Year);
			p = new Paragraph(nextShow);
			p.Font.Size = 20;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingBefore = 144;
			Add(p);
			
			p = new Paragraph(showInfo.Location);
			p.Font.Size = 20;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			p = new Paragraph(showInfo.LocationAddress);
			p.Font.Size = 20;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			Add(p);
			
			string addr = string.Format("{0}, {1} {2}",
			                            showInfo.LocationCity,
			                            showInfo.LocationState,
			                            showInfo.LocationPostalCode);
			p = new Paragraph(addr);
			p.Font.Size = 20;
			p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 72;
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
			// p.Font.SetStyle(Font.BOLD);
			p.Alignment = Element.ALIGN_CENTER;
			// p.SpacingAfter = 72;
			Add(p);
			
			NewPage();
		}
		
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
			p.Font.Size = 20;
			// p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("We have over 60 Reps, marketing over 190 lines including shoes, socks, slippers and handbags.");
			p.Font.Size = 20;
			// p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 72;
			Add(p);

			p = new Paragraph("Lunch");
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Lunch will be served Saturday and Sunday from 11:30am to 1:30pm in the Aspen room and lounge area.");
			p.Font.Size = 20;
			// p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Retailers and exhibitors - We will be having a Saturday night social hour that will start @ 5:00pm in the Aspen room.");
			p.Font.Size = 20;
			// p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Snacks and soft drinks will be provided.");
			p.Font.Size = 20;
			// p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 20;
			Add(p);

			p = new Paragraph("Alcoholic beverages will be provided by the exhibitors.");
			p.Font.Size = 20;
			// p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
			p.SpacingAfter = 72;
			Add(p);

			p = new Paragraph("NEXT SHOE MARKET");
			p.Font.Size = 30;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD);
			// p.SpacingAfter = 144;
			Add(p);

			p = new Paragraph(showInfo.NextShow);
			p.Font.Size = 30;
			p.Alignment = Element.ALIGN_CENTER;
			p.Font.SetStyle(Font.BOLD);
			p.SpacingAfter = 80;
			Add(p);

			p = new Paragraph(string.Format("Show Coordinator: {0}", showInfo.Coordinator));
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD);
			// p.SpacingAfter = 144;
			Add(p);

			p = new Paragraph(string.Format("Phone: {0}", showInfo.CoordinatorPhone));
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD);
			// p.SpacingAfter = 144;
			Add(p);

			p = new Paragraph(showInfo.CoordinatorEmail);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.Font.SetStyle(Font.BOLD);
			// p.SpacingAfter = 144;
			Add(p);
			
			NewPage();
		}
		
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
					// chk.Font.SetStyle(Font.UNDERLINE);
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
				// cell.PaddingBottom = 30f;
				cell.FixedHeight = 220f;
				cell.PaddingRight = 10f;
				table.AddCell(cell);
			}
			
			if (numExhibitors % 2 == 1)
			{
				PdfPCell cell = new PdfPCell(new Paragraph(""));
				cell.Border = PdfPCell.NO_BORDER;
				cell.NoWrap = false;
				// cell.PaddingBottom = 30f;
				cell.FixedHeight = 220f;
				cell.PaddingRight = 10f;
				table.AddCell(cell);
			}
			
			Add(table);
			
			NewPage();
		}
		
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
		
		public void ThankYou(ShowInfo showInfo)
		{
//			int currentPage = this.PageNumber;
//			Console.WriteLine(string.Format("Current Page: {0}", currentPage));
//			int remainder = currentPage % 4;
//			int notesPagesToAdd = (remainder > 0) ? remainder - 1 : 3;
//			Console.WriteLine(string.Format("Notes pages to add: {0}", notesPagesToAdd));
//			
//			for (int i=0; i<notesPagesToAdd; i++)
//			{
//				NewPage();
//				Paragraph pNote = new Paragraph("NOTES");
//				pNote.Font.Size = 20;
//				pNote.Font.SetStyle(Font.BOLD | Font.UNDERLINE);
//				pNote.Alignment = Element.ALIGN_CENTER;
//				Add(pNote);
//			}
			
			NewPage();
			
			Paragraph p = new Paragraph("THANK YOU");
			p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 20;
			Add(p);
			
			p = new Paragraph("FOR COMING TO THE SHOW");
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 200;
			Add(p);
			
			p = new Paragraph("NEXT MARKET");
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 20;
			Add(p);
			
			p = new Paragraph(showInfo.NextShow);
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			p.SpacingAfter = 200;
			Add(p);
			
			p = new Paragraph(showInfo.Location);
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.SpacingAfter = 144;
			Add(p);
			
			p = new Paragraph(showInfo.LocationAddress);
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.SpacingAfter = 144;
			Add(p);

			string addr = string.Format("{0}, {1}  {2}",
			                            showInfo.LocationCity,
			                            showInfo.LocationState,
			                            showInfo.LocationPostalCode);
			p = new Paragraph(addr);
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.SpacingAfter = 144;
			Add(p);
			
			string phone = string.Format("Phone: {0}",
			                            showInfo.LocationPhone);
			p = new Paragraph(phone);
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.SpacingAfter = 144;
			Add(p);
			
			string fax = string.Format("Fax: {0}",
			                            showInfo.LocationFax);
			p = new Paragraph(fax);
			// p.Font.SetStyle(Font.BOLD);
			p.Font.Size = 20;
			p.Alignment = Element.ALIGN_CENTER;
			// p.SpacingAfter = 144;
			Add(p);
			
		}
	}
}
