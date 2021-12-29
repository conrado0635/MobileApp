using System;
using System.Collections.Generic;
using System.Text;

namespace MobileProject20210635.Models
{
    public class ProductInfo
    {

        public int ProductId { get; set; }
        public string price;
        public string ProductName
        { get; set; }


        public string ProductPrice
        {
            get { return price; }

            set{ price = value; } 
        }
        
        public string ProductImage { get; set; }

    }
}
