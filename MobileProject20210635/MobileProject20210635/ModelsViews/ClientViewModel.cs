using MobileProject20210635.Models;
using MobileProject20210635.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileProject20210635.ModelsViews
{
    public class ClientViewModel:ViewModelBase
    {
        string name, email,address,phone;
        DateTime date;
/*        public string Name { get => name; set => SetProperty(ref name, value); }*/
        public ObservableRangeCollection<ClientInfo> ClientList { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<ClientInfo> RemoveCommand { get; }
        public AsyncCommand RefreshCommand { get; }

        /*      public IClientServices ClientServices { get }*/
        public IClientServices clientService { get; set; }

        public ClientViewModel()
        {
            ClientList = new ObservableRangeCollection<ClientInfo>();
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<ClientInfo>(Remove);
            clientService = DependencyService.Get<IClientServices>();

        }
        async Task Add()
        {

            name = await App.Current.MainPage.DisplayPromptAsync("Client Name", "Name");
            email = await App.Current.MainPage.DisplayPromptAsync("Email Address", "EmailAddress");
            address = await App.Current.MainPage.DisplayPromptAsync(" HomeAddress", " HomeAddress");
            phone = await App.Current.MainPage.DisplayPromptAsync("Phone", "Phone");
            date = DateTime.Today;
            ClientServices clientService = new ClientServices();

            await clientService.AddClient(name, email, address, phone,date);
            await Refresh();
        }
        async Task Refresh()
        {

            IsBusy = true;
            await Task.Delay(500);
            ClientList.Clear();

            ClientServices clientService = new ClientServices();
            var client = await clientService.GetClient();
       
            ClientList.AddRange(client);

            IsBusy = false;
        }
        async Task Remove(ClientInfo client)
        {

            ClientServices clientService = new ClientServices();
            await clientService.RemoveClient(client.ClientId);
            await Refresh();
        }
    }
}
