using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupervisorView : ContentPage
    {
        public SupervisorView()
        {
            InitializeComponent();
        }
        private void BtnAllProductPage_Clicked(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new ProductSettings());
        }

        private void BtnAllUserPage_Clicked(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new DisplayAllUser());
        }


        private void BtnAllClientPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DisplayAllClient());
        }

        private void BtnBackHome_Clicked(object sender, EventArgs e)
        {
            /* await Navigation.PushAsync(new MyAccountPage());*/
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}