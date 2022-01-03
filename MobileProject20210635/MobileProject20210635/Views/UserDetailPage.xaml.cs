using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileProject20210635.ModelsViews;
using MobileProject20210635.Models;
using MobileProject20210635.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class UserDetailPage : ContentPage
    {

        public UserDetailPage(Users user = null)
        {
            InitializeComponent();
            if (user != null)
            {
                ((UserEditViewModel)BindingContext).User = user;
            }


        }
        private async void BtnSave_Clicked(object sender, EventArgs e)
        {

            var newUser = new Users
            {
                Id = int.Parse(EntryId.Text),
                Name = EntryName.Text,
                EmailAddress = EntryEmail.Text,
                HomeAddress = EntryHome.Text,
                Phone = EntryPhone.Text,
                Password = EntryPassword.Text
            };

            if (!string.IsNullOrEmpty(EntryId.Text))
            {
                UserServices userQuery = new UserServices();

                await userQuery.UpdateUser(newUser);        
                
                Console.WriteLine("User Updated...");

                await Navigation.PushModalAsync(new DisplayAllUser());
         
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Erorr", "No Empty Field", "", "Cancel");
                    if (result)
                    {
                        await Navigation.PopAsync();
                    }
                });

            }
        }


    }
}    


