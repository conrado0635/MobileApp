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
        }

        private async void BtnBegin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignInPage());
        }
    }
}
