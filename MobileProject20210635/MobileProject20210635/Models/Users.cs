
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileProject20210635.Models
{
     public class Users
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string Phone{ get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime SignInDate { get; set; }
        public DateTime SignOutDate { get; set; }
        public string UserType { get; set; }
        public override string ToString()
        {
            return this.Name + " " + this.EmailAddress;
        }

    }
}
