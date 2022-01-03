using MobileProject20210635.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage(Models.ProductInfo productInfo = null)


        {
            InitializeComponent();
            if (productInfo != null)
            {
                ((AddOrEditProductViewModel)BindingContext).Product = productInfo;
            }
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
           Models.ProductInfo newProduct = ((AddOrEditProductViewModel)BindingContext).Product;
           if (newProduct.ProductId == 0)
            {
                newProduct.ProductImage = "cake5.png";
            }
           MessagingCenter.Send(this, "AddOrEditProduct", newProduct);
           
            await Navigation.PopAsync();
        }
    }
}     