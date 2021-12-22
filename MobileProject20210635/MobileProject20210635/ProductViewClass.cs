using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileProject20210635
{
    public class ProductViewClass
    {
            public ObservableCollection<ProductInfo> ProductList { get; set; }
        public ProductViewClass()
        {
            ProductList = new ObservableCollection<ProductInfo>();
            {
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 1,
                    ProductName = "Cake1",
                    ProductPrice = "$10.0",
                    ProductImage = "cake1.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 2,
                    ProductName = "Cake2",
                    ProductPrice = "$18.0",
                    ProductImage = "cake2.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 3,
                    ProductName = "Cake3",
                    ProductPrice = "$8.50",
                    ProductImage = "cake3.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 4,
                    ProductName = "Cake4",
                    ProductPrice = "$13.80.0",
                    ProductImage = "cake4.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 5,
                    ProductName = "Cake5",
                    ProductPrice = "$12.0",
                    ProductImage = "cake5.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 6,
                    ProductName = "Cake6",
                    ProductPrice = "$15.0",
                    ProductImage = "cake6.png"
                });
            }
        }
      
    }

}
