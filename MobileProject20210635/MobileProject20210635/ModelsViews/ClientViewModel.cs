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
        public AsyncCommand RefreshCommand { get; }

        /*      public IClientServices ClientServices { get }*/
       IClientServices clientService { get; set; }
        


        public ClientViewModel()
        {
            ClientList = new ObservableRangeCollection<ClientInfo>();
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add); ;
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

/*            var route = $"{nameof(AddMyCoffeePage)}?Name=Motz";
            await Shell.Current.GoToAsync(route);*/

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
            /*
                        DependencyService.Get<IToast>()?.MakeToast("Refreshed!");*/
        }






    }
}
