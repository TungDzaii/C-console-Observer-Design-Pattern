using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment2
{
    public class Staff : Person
    {
        public Staff(string name, string phonenum, string address, string account, string password)
            : base(name, phonenum, address, account, password) { }

        public Staff()
        {

        }
        public void addBook(List<Book> books, string title, string category, string author, DateTime pubyear, int quantity)
        {
            if(quantity >= 0)
            {
                Book aBook = new Book(title, category, author, pubyear, quantity);
                books.Add(aBook);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("///////////////////////////////////////////");
                Console.WriteLine("Error: Quantity of book can not be below 0");
                Console.WriteLine("///////////////////////////////////////////");
                Console.WriteLine();
            }
            
        }

        public bool deleteBook(List<Book> books, int id)
        {
            Book bookToDelete = books.Find(book => book.id == id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                Console.WriteLine("Book with id {0} has been deleted.", id);
                return true;
            }
            else
            {
                Console.WriteLine("Book with id {0} not found.", id);
                return false;
            }
        }

        public void editBook(List<Book> books, int id, string title, string category, string author, string yearOfPublishing, int quantity)
        {
            // Tìm kiếm sách theo id và cập nhật thông tin nếu tìm thấy
            Book aBook = books.Find(book => book.id == id);
            if (aBook != null)
            {
                if (quantity >= 0)
                {
                    aBook.title = title;
                    aBook.category = category;
                    aBook.author = author;
                    aBook.yearOfPublishing = DateTime.ParseExact(yearOfPublishing, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    aBook.quantity = quantity;
                    Console.WriteLine("Book with id {0} has been updated.", id);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("///////////////////////////////////////////");
                    Console.WriteLine("Error: Quantity of book can not be below 0");
                    Console.WriteLine("///////////////////////////////////////////");
                    Console.WriteLine();
                } 
            }
            else
            {
                Console.WriteLine("Book with id {0} not found.", id);
            }
        }
    }
}
