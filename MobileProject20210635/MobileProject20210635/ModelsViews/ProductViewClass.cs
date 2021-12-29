using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MobileProject20210635
{
    public class ProductViewClass
    {
        public ObservableCollection<ProductInfo> ProductList { get; set; }
        public ProductViewClass()
        {
            ProductList = new ObservableCollection<ProductInfo>();
            
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 1,
                    ProductName = "Caramel Cake",
                    ProductPrice = "10.0",
                    ProductImage = "cake1.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 2,
                    ProductName = "BlueBChoc",
                    ProductPrice = "20.0",
                    ProductImage = "cake2.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 3,
                    ProductName = "Straw Slice",
                    ProductPrice = "30.0",
                    ProductImage = "cake3.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 4,
                    ProductName = "StrawberryIce",
                    ProductPrice = "11.90",
                    ProductImage = "cake4.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 5,
                    ProductName = "Fresh Berry",
                    ProductPrice = "15.50",
                    ProductImage = "cake5.png"
                });
                ProductList.Add(new ProductInfo()
                {
                    ProductId = 6,
                    ProductName = "Chocolate",
                    ProductPrice = "14.0",
                    ProductImage = "cake6.png"
                });

            MessagingCenter.Subscribe<AddProductPage, ProductInfo>(this, "AddOrEditProduct",(page, newProduct) =>
            {
                if (newProduct.ProductId == 0)
                {
                    newProduct.ProductId = ProductList.Count + 1;
                    ProductList.Add(newProduct);
                }
                else
                {
                    ProductInfo productToEdit = ProductList.Where(p => p.ProductId == newProduct.ProductId).FirstOrDefault();
                    int productToEditIndex = ProductList.IndexOf(productToEdit);
                    ProductList.Remove(productToEdit);
                    ProductList.Add(newProduct);

                    int productIndex = ProductList.IndexOf(newProduct);
                    ProductList.Move(productIndex, productToEditIndex);
                }
            });


        }
  

    }

}
