
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
        public string Department { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.EmailAddress;
        }

    }
}
