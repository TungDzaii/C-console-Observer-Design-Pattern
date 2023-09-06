using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Book
    {
        public int id { get; }
        public string title { get; set; }
        public string category { get; set; }
        public string author { get; set; }
        public DateTime yearOfPublishing { get; set; }
        public int quantity { get; set; }
        
        private static int COUNT = 1;

        private List<IObserver> waitingList = new List<IObserver>() ;

        public List<IObserver> WaitingList
        {
            get
            {
                return this.waitingList;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.waitingList = value;
            }
        }

        public Book(string title, string category, string author, DateTime yearOfPublishing, int quantity)
        {
            this.id = COUNT ++;
            this.title = title;
            this.category = category;
            this.author = author;
            this.yearOfPublishing = yearOfPublishing;
            this.quantity = quantity;
        }

        public Book() { }

        public void print()
        {
            Console.WriteLine("Id: {0, -3} | Title: {1, -15} | Category: {2, -7} | Auhthor: {3, -10} | Date of publishing: {4, -4} | Quantity: {5, -4}",
                this.id, this.title, this.category, this.author, this.yearOfPublishing.ToString("yyyy/MM/dd"), this.quantity);
        }

        public static void viewAllBook(List<Book> books)
        {
            foreach (Book book in books)
            {
                book.print();
            }
        }

    }


}
