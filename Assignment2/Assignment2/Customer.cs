using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Formats.Tar;
using Microsoft.VisualBasic;

namespace Assignment2
{
    public class Customer : Person, IObserver
    {
        private List<BorrowTicket> tickets = new List<BorrowTicket>();

        public List<BorrowTicket> Tickets
        {
            get
            {
                return this.tickets;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.tickets = value;
            }
        }

        public Customer(string name, string phoneNum, string address, string account, string password)
            : base(name, phoneNum, address, account, password)
        {
            
        }
        public Customer() { }
        public BorrowTicket createTicket()
        {
            BorrowTicket aTicket = new BorrowTicket(this);
            this.tickets.Add(aTicket);
            return aTicket;
        }

        public void viewBorrowedBook()
        {
            foreach(BorrowTicket ticket in this.tickets){
                foreach(Book book in ticket.Books)
                {
                    Console.WriteLine("Id: {0, -2} | Title: {1, -15} | Category: {2, -7} | Auhthor: {3, -10} | Date of publishing: {4, -4}",
                        book.id, book.title, book.category, book.author, book.yearOfPublishing.ToString("yyyy/MM/dd"));
                }
            }
        }

        public void Update(Book book)
        {
            Console.WriteLine(this.name + " has been informed that the book \"" + book.title + "\" is available.");
        }

        public double payFee(BorrowTicket ticket)
        {
            double fee = 0;
            int count = 0;

            if (ticket.borrowedDays > 7)
            {
                for (int i = 8; i <= ticket.borrowedDays; i++)
                {
                    count++;
                }
                fee = count * 5;
            }
            return fee;
        }
        public void viewTicket()
        {
            foreach (BorrowTicket ticket in this.tickets)
            {
                ticket.borrowedDays = ticket.calculateBorrowedDays(ticket.dateOfBorrowing, ticket.actualReturning);
                if (ticket.borrowedDays >= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("==================================");
                    Console.WriteLine("This ticket id is: " + ticket.id);
                    Console.WriteLine("This borrowing days is: " + ticket.borrowedDays);
                    Console.WriteLine("Your penalty for this ticket is: " + payFee(ticket) + "$");
                    Console.WriteLine("==================================");
                    Console.WriteLine();
                }
            }
        }
    }
}
