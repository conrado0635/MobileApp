using MobileProject20210635.Views;
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
    public partial class MyAccountPage : ContentPage
    {
        public MyAccountPage()
        {
            InitializeComponent();
        }

        private void TapUploadImage_Tapped(object sender, EventArgs e)
        {

        }

        private async void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            
              await Navigation.PushModalAsync(new PasswordPage());
           

        }

        private void TapChangePhone_Tapped(object sender, EventArgs e)
        {

        }

        private async void TapLogout_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LogInPage());
        }

        private void TapChangeDepartment_Tapped(object sender, EventArgs e)
        {

        }

        private void TapDisplayAllUser_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DisplayAllUser());
        }
    }
}