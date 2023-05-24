using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicketSalesSystem
{
    public class LoginUser
    {
        public int id;
        public string login;
        public string pass;
        public int type;
        public LoginUser(int id, string login, string pass, int type)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
            this.type = type;
        }
        //public int id;
        //public string FullName;
        //public string PassportNumber;
        //public string Birthdate;
        //public string Telephone;
        //public string Email;
        //public int type;
        //public LoginUser(int id, string fn, string pn, string bd, string t, string e, int type)
        //{
        //    this.id = id;
        //    this.FullName = fn;
        //    this.PassportNumber = pn;
        //    this.Birthdate = bd;
        //    this.Telephone = t;
        //    this.Email = e;
        //    this.type = type;
        //}
        public LoginUser() { }
    }
}
