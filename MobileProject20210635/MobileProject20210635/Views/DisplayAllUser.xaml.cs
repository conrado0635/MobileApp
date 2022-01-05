using MobileProject20210635.Models;
using MobileProject20210635.ModelsViews;
using MobileProject20210635.Services;
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

    public partial class DisplayAllUser : ContentPage
    {
        public DisplayAllUser()
        {
            InitializeComponent();


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (UserViewModel)BindingContext;
            if (vm.UsersList.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }


        private void TapGestureRecognizer_Delete(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {

            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            Users selectedUser = ((UserViewModel)BindingContext).UsersList.
            Where(user => user.Id == (int)tappedEventArgs.Parameter).FirstOrDefault();
           await Navigation.PushModalAsync(new UserDetailPage(selectedUser));
       

        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SupervisorView());
            /*     Application.Current.MainPage = new NavigationPage(new SettingPage());*/

        }

    }
}