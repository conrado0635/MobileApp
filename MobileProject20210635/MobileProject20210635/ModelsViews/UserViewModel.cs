using MobileProject20210635.Models;
using System;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using MobileProject20210635.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using MobileProject20210635.Views;

namespace MobileProject20210635.ModelsViews
{
    public class UserViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Users>UsersList { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Users> RemoveCommand { get; }
        public AsyncCommand<Users> SelectedCommand { get; }
        public IUserServices UserServices { get; }

        IUserServices  userService;
        public UserViewModel()
        {
  
       /*     Title = "All User Detail";*/

            UsersList = new ObservableRangeCollection<Users>();
            SelectedCommand = new AsyncCommand<Users>(Selected);
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Users>(Remove);
            userService = DependencyService.Get<IUserServices>();
        }

        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name");
            var email = await App.Current.MainPage.DisplayPromptAsync("EmailAddress", "EmailAddress");
            var address = await App.Current.MainPage.DisplayPromptAsync(" HomeAddress", " HomeAddress");
            var phone = await App.Current.MainPage.DisplayPromptAsync("Phone", "Phone");
            var password = await App.Current.MainPage.DisplayPromptAsync("Password", "Password");
            var signIn = DateTime.UtcNow;
            var signOut = DateTime.UtcNow;
            var userType = "User";
            await userService.AddUser(name, email,address,phone,password,signIn,signOut,userType);
            await Refresh();

 /*           var route = $"{nameof(AddUserPage)}?Name=Conz";
            await Shell.Current.GoToAsync(route);*/

        }

        async Task Selected(Users user)
        {
            if (user == null)
                return;

            var route = $"{nameof(UserDetailPage)}?Id={user.Id}";
            await Shell.Current.GoToAsync(route);
        }



        async Task Remove(Users user)
        {
            await userService.RemoveUser(user.Id);
            await Refresh();
        }
       async Task Refresh()
            {
                IsBusy = true;

    #if DEBUG
                await Task.Delay(5000);
    #endif

                UsersList.Clear();

                var user = await userService.GetUser();

                UsersList.AddRange(user);

                IsBusy = false;
    /*
                DependencyService.Get<IToast>()?.MakeToast("Refreshed!");*/
            }

    }

}
