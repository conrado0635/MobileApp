using MobileProject20210635.Models;
using MobileProject20210635.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductSettings : ContentPage
    {
      

        public ProductSettings()
        {
            InitializeComponent();

        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {

         /*   lvProductList.ItemsSource = null;*/
            Navigation.PushAsync(new AddProductPage());
        }

        private void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {

            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            ProductInfo productInfo = ((ProductViewClass)BindingContext).ProductList.
                Where(product => product.ProductId == (int)tappedEventArgs.Parameter).FirstOrDefault();
                Navigation.PushAsync(new AddProductPage(productInfo));


        }

        private void TapGestureRecognizer_Tapped_Delete(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            ProductInfo productInfo = ((ProductViewClass)BindingContext).ProductList.
                Where(product => product.ProductId == (int)tappedEventArgs.Parameter).FirstOrDefault();
                ((ProductViewClass)BindingContext).ProductList.Remove(productInfo);

        }
    }
}