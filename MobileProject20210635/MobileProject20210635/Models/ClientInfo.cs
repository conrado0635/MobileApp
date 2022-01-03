using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileProject20210635.Models
{
     public class ClientInfo
    {
      
            [PrimaryKey,AutoIncrement]
            public int ClientId { get; set; }
            public string ClientName { get; set; }
            public string ClientAddress { get; set; }
            public string ClientPhone { get; set; }
            public string ClientEmail { get; set; }
            public DateTime RegisteredDate{ get; set; }


       
    }
}
