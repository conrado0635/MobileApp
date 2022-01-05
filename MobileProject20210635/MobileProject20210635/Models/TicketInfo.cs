using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileProject20210635.Models
{
     public class TicketInfo
    {
        [PrimaryKey,AutoIncrement]
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; set; }
        public string TicketComment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }


    }
}
