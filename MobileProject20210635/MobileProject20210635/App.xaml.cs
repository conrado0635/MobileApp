using MobileProject20210635.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new LandingPage());
            //UserServices();
      
           
        }

        private async void UserServices()
        {
            UserServices openUserServices = new UserServices();
            await openUserServices.Init();
        }

        /*        protected override async void OnAppearing()
       {
           UserServices.Init();
       }
*/



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
