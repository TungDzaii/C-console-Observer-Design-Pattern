using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface ISubject
    {
        int id { get; }
        Customer Customer { get; set; }
        DateTime dateOfBorrowing { get; set; }
        DateTime actualReturning { get; set; }
        int borrowedDays { get; set; }
        List<Book> Books{ get;set;}
        void RegisterObserver(IObserver custom, Book book);
        void RemoveObserver(IObserver custom, Book book);
        void NotifyWaitinglist(Book book);
    }
}
