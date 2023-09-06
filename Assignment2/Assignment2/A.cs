using Assignment2;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class A
    {
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Staff> staffs = new List<Staff>();
            Customer cus1 = new Customer("Nguyen Van A", "055545454", "Hanoi", "customer1", "123");
            Customer cus2 = new Customer("Tran Thi B", "0123456789", "HCM City", "customer2", "123");
            customers.Add(cus1);
            customers.Add(cus2);
            Staff sta = new Staff("Tran Thi Sta", "0987654321", "Bac Giang", "staff", "123");
            staffs.Add(sta);
            Customer this_customer = new Customer();

            Staff this_staff = new Staff();

            List<Book> books = new List<Book>();
            Book abook = new Book("doraemon", "comic", "Fujiko", new(2001, 01, 05), 10);
            Book abook1 = new Book("Conan", "comic", "Aoyama", new(1997, 11, 11), 0);
            Book abook2 = new Book("Dragon ball", "comic", "Akira", new(1992, 03, 09), 1);
            Book abook3 = new Book("Sherlock holmes", "comic", "Conan Doyle", new(1988, 01, 22), 4);
            

            books.Add(abook);
            books.Add(abook1);
            books.Add(abook2);
            books.Add(abook3);


            List<BorrowTicket> tickets = new List<BorrowTicket>();

        Begin:
            Console.WriteLine("||==============||Welcome to Thanh Tri Library||==============||");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Enter option: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (x) {
                case 1:

                    Console.WriteLine("Enter username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine();


                    bool isCustomer = false;
                    bool isStaff = false;
                    foreach (Customer customer in customers)
                    {
                        if (customer.Login(username, password))
                        {
                            this_customer = customer;
                            isCustomer = true;
                            break;
                        }
                    }

                    if (!isCustomer)
                    {
                        foreach (Staff staff in staffs)
                        {
                            if (staff.Login(username, password))
                            {
                                this_staff = staff;
                                isStaff = true;
                                break;
                            }
                        }
                    }

                    while (!isStaff && !isCustomer)
                    {
                        Console.WriteLine("Invalid username or password.");
                        Console.WriteLine();


                        Console.WriteLine("Enter username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        password = Console.ReadLine();
                        Console.WriteLine();


                        isCustomer = false;
                        isStaff = false;
                        foreach (Customer customer in customers)
                        {
                            if (customer.Login(username, password))
                            {
                                this_customer = customer;
                                isCustomer = true;
                                break;
                            }
                        }

                        if (!isCustomer)
                        {
                            foreach (Staff staff in staffs)
                            {
                                if (staff.Login(username, password))
                                {
                                    this_staff = staff;
                                    isStaff = true;
                                    break;
                                }
                            }
                        }


                    }
                    if (isCustomer)
                    {
                        int option = 1;
                        do
                        {
                        Customer:
                            Console.WriteLine();
                            Console.WriteLine("-----------Book self------------");
                            Console.WriteLine("================================================");
                            Book.viewAllBook(books);
                            Console.WriteLine("================================================");
                            Console.WriteLine();
                            Console.WriteLine("-----------Borrowed book---------");
                            Console.WriteLine("================================================");
                            this_customer.viewBorrowedBook();
                            Console.WriteLine("================================================");
                            Console.WriteLine("1. Borrow book");
                            Console.WriteLine("2. Return book");
                            Console.WriteLine("3. Pay Fee");
                            Console.WriteLine("0. Logout");
                            Console.WriteLine();
                            Console.WriteLine("Enter option: ");
                            option = Int32.Parse(Console.ReadLine());
                            switch (option)
                            {
                                case 0: goto Begin;

                                case 1:
                                    Console.WriteLine("Enter id of the book you want to borrow: ");
                                    int id = Int32.Parse(Console.ReadLine());
                                    //Book aBook = books.Find(book => book.id == id);
                                    Book aBook = new Book();

                                    BorrowTicket ticket = this_customer.createTicket();

                                    bool existed = false;
                                    foreach (Book bookk in books)
                                    {
                                        if (bookk.id == id)
                                        {
                                            aBook = bookk;
                                            existed = true;
                                            break;
                                        }
                                    }

                                    if (existed)
                                    {
                                        ticket.borrowBook(aBook);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Book doesn't exist.");
                                    }

                                    goto Customer;
                                case 2:
                                    Console.WriteLine("Enter id of book you want to return: ");
                                    int idReturn = Int32.Parse(Console.ReadLine());
                                    Book book = new Book();
                                    bool exist = false;
                                    foreach (BorrowTicket borrowTicket in this_customer.Tickets)
                                    {
                                        foreach (Book b in borrowTicket.Books)
                                        {
                                            if (b.id == idReturn)
                                            {
                                                book = b;
                                                exist = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (exist)
                                    {
                                        Console.WriteLine("Enter date of returning: ");
                                        string returndate = Console.ReadLine();
                                        foreach (BorrowTicket borrowTicket in this_customer.Tickets)
                                        {
                                            borrowTicket.returnBook(book, returndate);
                                        }
                                      
                                    }

                                    goto Customer;

                                case 3:
                                    this_customer.viewTicket();
                                    goto Customer;
                            }
                        } while (option < 0 || option > 5);
                    }
                    else if (isStaff)
                    {
                        int option = -1;
                        Staff:
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("-----------Book self------------");
                            Console.WriteLine("================================================");
                            Book.viewAllBook(books);
                            Console.WriteLine("================================================");
                            Console.WriteLine("1. Add a book");
                            Console.WriteLine("2. Delete a book");
                            Console.WriteLine("3. Update a book");
                            Console.WriteLine("0. Logout");
                            Console.WriteLine();
                            Console.WriteLine("Enter option: ");
                            option = Int32.Parse(Console.ReadLine());
                            switch (option)
                            {
                                case 0: goto Begin;
                                case 1:

                                    Console.WriteLine("Enter title: ");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter category: ");
                                    string category = Console.ReadLine();
                                    Console.WriteLine("Enter author: ");
                                    string author = Console.ReadLine();
                                    Console.WriteLine("Enter year of publishing: ");
                                    string pubyear = Console.ReadLine();
                                    DateTime year = stringToDate(pubyear);

                                    Console.WriteLine("Enter quantity: ");
                                    int quanti = Int32.Parse(Console.ReadLine());
                                    this_staff.addBook(books, title, category, author, year, quanti);
                                    goto Staff;


                                case 2:
                                    Console.WriteLine("Enter id of the book to delete: ");
                                    int deleteById = Int32.Parse(Console.ReadLine());
                                    this_staff.deleteBook(books, deleteById);
                                    goto Staff;


                                case 3:
                                    Console.WriteLine("Id of the book to edit: ");
                                    int editId = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter new title: ");
                                    string editTitle = Console.ReadLine();
                                    Console.WriteLine("Enter new category: ");
                                    string editCategory = Console.ReadLine();
                                    Console.WriteLine("Enter new author: ");
                                    string editAuthor = Console.ReadLine();
                                    Console.WriteLine("Enter new year of publishing: ");
                                    string editPubyear = Console.ReadLine();
                                    Console.WriteLine("Enter new quantity:");
                                    int editQuanti = Int32.Parse(Console.ReadLine());
                                    this_staff.editBook(books, editId, editTitle, editCategory, editAuthor, editPubyear, editQuanti);
                                    goto Staff;
                            }
                        } while (option < 0 || option > 3);
                    }
                    break;
                case 0:
                    break;
            }
        }

        public static DateTime stringToDate(string text)
        {
            DateTime year;
            while (!DateTime.TryParseExact(text, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out year))
            {
                Console.WriteLine("Invalid date format. Please re-enter year of publishing in yyyy/MM/dd format:");
                text = Console.ReadLine();
            }
            year = DateTime.Parse(text);
            return year;
        }
    }

}

