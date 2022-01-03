using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MobileProject20210635
{
    public class ProductViewModel
    {
        public ObservableCollection<ProductInfo> ProductList { get; set; }
        public ProductViewModel()
        {
            ProductList = new ObservableCollection<ProductInfo>();


  /*          MessagingCenter.Subscribe<AddProductPage, ProductInfo>(this, "AddOrEditProduct", (page, newProduct) =>
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
*/

        }


    }

}
