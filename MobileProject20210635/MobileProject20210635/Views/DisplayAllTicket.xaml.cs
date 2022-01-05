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
    public partial class DisplayAllTicket : ContentPage
    {
        public DisplayAllTicket()
        {
            InitializeComponent();


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (TicketViewModel)BindingContext;
            if (vm.TicketList.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }

        private async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {

            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            TicketInfo selectedTicket = ((TicketViewModel)BindingContext).TicketList.
            Where(ticket => ticket.TicketId == (int)tappedEventArgs.Parameter).FirstOrDefault();
            await Navigation.PushModalAsync(new EditTicketPage(selectedTicket));

        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            /*Application.Current.MainPage = new NavigationPage(new HomePage());*/
            await Navigation.PushModalAsync(new EmployeePage());
        }



        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTicketPage());
        }
    }
}