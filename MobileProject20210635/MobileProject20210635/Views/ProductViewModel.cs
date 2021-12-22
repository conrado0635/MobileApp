using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileProject20210635.Models
{
    public class ProductViewModel : Xamarin.Forms.ContentPage
    {
        public string[] ProductList { get; set; }
        public ProductViewModel()
        {
            ProductList = new string[] { "cake1", "cake2", "cake3", "cake4", "cake5", "cake6" };
        }
    }
}
