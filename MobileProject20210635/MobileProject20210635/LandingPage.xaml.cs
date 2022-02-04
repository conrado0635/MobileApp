using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileProject20210635
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
            var images = new List<string>()
             {
                 "cake1.png",
                 "cake2.png",
                 "cake3.png",
                 "cake4.png",
                 "cake5.png"
             };
            MainCarousel.ItemsSource = images;
        }

 
        private void TappedItem_Tapped(object sender, EventArgs e)
        {
            var image = sender;
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LogInPage());
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignInPage());
        }
    }
}
