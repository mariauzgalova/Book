using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bucher.Model.Models;
using Bucher.Model;

namespace Bucher.Model
{
    internal class BooksTable
    {
        public int IdBook { get; set; }
        public int? Genre { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NameGenre { get; set; }

        public static BooksTable ConvertBooksOnBooksTable(Books book)
        {
            BooksTable booksTable = new BooksTable();
            booksTable.IdBook = book.IdBook;
            booksTable.Genre = book.Genre;
            booksTable.Price= book.Price;
            booksTable.Description = book.Description;
            booksTable.Name = book.Name;
            
            using (ApplicationContext db = new ApplicationContext())
            {
                booksTable.NameGenre = db.Genre.FirstOrDefault(g => g.IdGenre == book.Genre).Name;
            }

            return booksTable;
        }

    }
}
