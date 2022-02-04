using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileProject20210635.Models;
using MobileProject20210635.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void BtnBuy_Clicked(object sender, EventArgs e)
        {

        }

        private async void productListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var productInfo = e.SelectedItem as ProductInfo;
            var newProductInfoPage = new ProductInfoPage();
            newProductInfoPage.BindingContext = productInfo;
            await Navigation.PushAsync(newProductInfoPage);
        }
             
    }
}