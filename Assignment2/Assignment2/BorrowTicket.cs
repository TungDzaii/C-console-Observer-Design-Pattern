using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class BorrowTicket : ISubject
    {
        public int id { get; }

        private Customer customer = new Customer();


        private List<Book> books = new List<Book>();
        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.customer = value;
            }
        }

        public List<Book> Books {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.books = value;
            }
            get { return this.books; }
        }

        public DateTime dateOfBorrowing { get; set; }

        public DateTime actualReturning { get; set; }

        public int borrowedDays { get; set; }

        private static int idx = 1;

        public BorrowTicket(Customer customer)
        {
            this.id = idx++;
            this.customer = customer;
            this.dateOfBorrowing = DateTime.Now;
        }

        public BorrowTicket() { }

        public bool borrowBook(Book aBook)
        {

            if (aBook.quantity >= 1)
            {
                Console.WriteLine("Borrow successfull the book has id: {0}", aBook.id);
                this.Books.Add(aBook);
                aBook.quantity--;
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine("This book is not available to borrow");
                Console.WriteLine("======================================");
                Console.WriteLine();
                Console.WriteLine("Do you want to join the waiting list? : y/n");
                string choice = Console.ReadLine();

                if (choice == "y")
                {
                    if (!aBook.WaitingList.Contains(this.customer))
                    {
                        RegisterObserver(this.customer, aBook);
                        Console.WriteLine("Customer " + this.customer.name + " added to waiting list.");
                    }
                    else
                    {
                        Console.WriteLine("Customer " + this.customer.name + " is already in the waiting list.");
                    }


                }
                return false;
            }
        }

        public bool returnBook(Book book, string returnDate)
        {
            book.quantity++;
            this.Books.Remove(book);
            this.actualReturning = DateTime.ParseExact(returnDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            Console.WriteLine();
            NotifyWaitinglist(book);
            Console.WriteLine();
            Console.WriteLine("Return successful for book has id {0}", book.id);
            return true;
        }

        public void NotifyWaitinglist(Book book)
        {
            foreach (IObserver customer in book.WaitingList)
            {
                customer.Update(book);
            }
            if(book.WaitingList.Count > 0)
            {
                IObserver nextCustomer = book.WaitingList[0];
                RemoveObserver(nextCustomer, book);
            }
        }

        public void RegisterObserver(IObserver customer, Book book)
        {
            book.WaitingList.Add(customer);
        }

        public void RemoveObserver(IObserver customer, Book book)
        {
            book.WaitingList.Remove(customer);
        }


        public int calculateBorrowedDays(DateTime dateOfBorrowing, DateTime actualReturning)
        {
            TimeSpan days = actualReturning - dateOfBorrowing;
            int borrowedDays = (int)days.TotalDays;
            borrowedDays += 1;
            return borrowedDays;
        }

        public void printBorrowedBook()
        {
            foreach (Book book in this.books)
            {
                book.print();
            }
        }
    }
}
