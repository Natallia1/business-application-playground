using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using BookStore.BackOffice.WebApi.Models;
using System.Collections.Generic;
using System.IO;
using System;

namespace BookStore.BackOffice.WebApi.FileFactory.Word
{
    public class BookListToWord
    {
        public MemoryStream GetWord(List<Book> books)
        {
            var word = new WordDocument();
            IWSection section = word.AddSection();
            IWTextRange title = section.AddParagraph().AppendText("Filtered Books");
            title.CharacterFormat.Bold = true;
            section.AddParagraph();

            IWTable table = section.AddTable();
            table.Title = "Filtered books";
            table.Description = "Books found based on applied filters";
           
            var headers = new List<string>()
            { "Title", "Author", "Price", "Bestseller", "Availability" };

            table.ResetCells(books.Count + 1, headers.Count);

            //Add table row with headers
            for (int i = 0; i < headers.Count; i++)
            {
                table[0, i].AddParagraph().AppendText(headers[i]);
            }

            //Add table rows with book values
            for (int i = 0; i < books.Count; i++)
            {
                table[i + 1, 0].AddParagraph().AppendText(books[i].Title);
                table[i + 1, 1].AddParagraph().AppendText(GetAuthorString(books[i].Author)); ;
                table[i + 1, 2].AddParagraph().AppendText(GetPriceString(books[i].Price));
                table[i + 1, 3].AddParagraph().AppendText(GetBestsellerString(books[i].IsBestSeller));
                table[i + 1, 4].AddParagraph().AppendText(GetStockString(books[i].AvailableStock));
            }

            MemoryStream stream = new MemoryStream();
            word.Save(stream, FormatType.Docx);

            return stream;
        }

        private string GetAuthorString(Author author)
        {
            return author.Firstname + " " + author.Lastname;
        }

        private string GetPriceString(decimal price)
        {
            return String.Format("€{0:N2}", price);
        }

        private string GetBestsellerString(bool bestseller)
        {
            if (bestseller)
            {
                return "Bestseller";
            }
            return "Not Bestseller";
        }

        private string GetStockString(int stock)
        {
            if (stock > 0)
            {
                return $"Available in stock({stock})";
            }
            else if (stock == 0)
            {
                return "Not available in stock";
            }
            throw new System.Exception($"{stock} is below zero, which is invalid for stock number.");
        }
    }

    
}
