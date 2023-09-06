using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Person
    {
        public int id { get;}
        public string name { get; set; }
        public string phoneNum { get; set; }
        public string address { get; set; }
        public string account { get; set; }
        public string password { get; set; }

        private static int count = 1;

        public Person(string name, string phoneNum, string address, string account, string password)
        {
            this.id = count++;
            this.name = name;
            this.phoneNum = phoneNum;
            this.address = address;
            this.account = account;
            this.password = password;
        }

        public Person()
        {

        }

        public bool Login(string account, string password)
        {
            if (this.password.Equals(password) && this.account.Equals(account))
            {
                return true;
            }
            return false;
        }
    }
}
