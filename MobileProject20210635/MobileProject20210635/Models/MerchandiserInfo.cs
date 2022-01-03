using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileProject20210635.Models
{
   public class MerchandiserInfo
    {
        [PrimaryKey]
        public int MerchatId { get; set; }
        public string MerchantName { get; set; }
        public string MerchantEmail { get; set; }
        public string MerchantPhone { get; set; }
        public DateTime SignInDate { get; set; }
        public DateTime SignOutDate { get; set; }


    }
}
