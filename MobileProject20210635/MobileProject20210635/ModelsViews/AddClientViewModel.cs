using MobileProject20210635.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileProject20210635.ModelsViews
{
    [QueryProperty(nameof(Name), nameof(Name))]
    class AddClientViewModel:ViewModelBase
    {
        string name, email,address,phone;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Address { get => address; set => SetProperty(ref address, value); }
        public string Phone { get => phone; set => SetProperty(ref phone, value); }


        public AsyncCommand SaveCommand { get; }
        IClientServices clientService;
        public AddClientViewModel()
        {
            Title = "Add Client";
       /*     SaveCommand = new AsyncCommand(Save);*/
            clientService = DependencyService.Get<IClientServices>();
        }

/*        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email))
            {
                return;
            }

            await clientService.AddClient(name, email,address,phone,date);

            await Shell.Current.GoToAsync("..");
        }*/
    }
}
