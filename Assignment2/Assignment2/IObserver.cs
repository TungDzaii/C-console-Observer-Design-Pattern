using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IObserver
    {
        int id { get; }
        string name { get; set; }
        string phoneNum { get; set; }
        string address { get; set; }
        string account { get; set; }
        string password { get; set; }

        void Update(Book book);
    }
}
