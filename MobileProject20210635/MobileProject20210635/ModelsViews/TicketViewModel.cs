using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileProject20210635.Models;
using MobileProject20210635.Services;
using MobileProject20210635.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace MobileProject20210635.ModelsViews
{
    class TicketViewModel:ViewModelBase
    {
            
      /*  string name, email, address, phone;
        DateTime date;*/
        /*        public string Name { get => name; set => SetProperty(ref name, value); }*/
        public ObservableRangeCollection<TicketInfo> TicketList { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<TicketInfo> RemoveCommand { get; }
        public AsyncCommand RefreshCommand { get; }

        /*      public IClientServices ClientServices { get }*/
        public ITicketServices ticketService { get; set; }

        public TicketViewModel()
        {

            Title = "All Ticket";
            TicketList = new ObservableRangeCollection<TicketInfo>();
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<TicketInfo>(Remove);
            ticketService = DependencyService.Get<ITicketServices>();

        }
        async Task Add()
        {
            /*
                        name = await App.Current.MainPage.DisplayPromptAsync("Client Name", "Name");
                        email = await App.Current.MainPage.DisplayPromptAsync("Email Address", "EmailAddress");
                        address = await App.Current.MainPage.DisplayPromptAsync(" HomeAddress", " HomeAddress");
                        phone = await App.Current.MainPage.DisplayPromptAsync("Phone", "Phone");
                        date = DateTime.Today;
                        TicketServices ticketService = new TicketServices();

                        await ticketService.AddTicket(TicketInfo ticket);*/

            /*            var route = $"{nameof(AddTicketPage)}";*/
            await Shell.Current.GoToAsync($"//{nameof(AddTicketPage)}");


            /* await Refresh();*/
        }
        async Task Refresh()
        {

            IsBusy = true;
            await Task.Delay(500);
            TicketList.Clear();

            TicketServices ticketService = new TicketServices();
            var ticket = await ticketService.GetTicket();

            TicketList.AddRange(ticket);

            IsBusy = false;
        }
        async Task Remove(TicketInfo ticket)
        {

            TicketServices ticketService = new TicketServices();
            await ticketService.RemoveTicket(ticket.TicketId);
            await Refresh();
        }
    }
}

