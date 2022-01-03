using MobileProject20210635.Models;
using MobileProject20210635.ModelsViews;
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
    public partial class DisplayAllClient : ContentPage
    {
        public DisplayAllClient()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (ClientViewModel)BindingContext;
            if (vm.ClientList.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }
        private async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            ClientInfo selectedUser = ((ClientViewModel)BindingContext).ClientList.
            Where(client => client.ClientId == (int)tappedEventArgs.Parameter).FirstOrDefault();
            await Navigation.PushModalAsync(new EditClientPage(selectedUser));

        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            /*Application.Current.MainPage = new NavigationPage(new HomePage());*/
            await Navigation.PushModalAsync(new SettingPage());
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {

        }

/*        private async void TapGestureRecognizer_Tapped_Add(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddClientView());
        }*/


    }
}