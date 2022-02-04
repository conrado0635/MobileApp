using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileProject20210635.Services;
using Xamarin.Essentials;

namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public string currentUserName;
        public string currentUserEmail;
        public LogInPage()
        {
            InitializeComponent();
            currentUserName = "";
            currentUserEmail = "";


        }

/*        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }*/

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            /*            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
                        var db = new SQLiteConnection(_dbpath);
                        var userQuery = db.Table<Models.Users>().Where(x => x.EmailAddress.Equals(EntryEmail.Text) && x.Password.Equals(EntryPassword.Text)).FirstOrDefault();*/
            UserServices userQuery = new UserServices();
            var query = await userQuery.GetOneUser(EntryEmail.Text, EntryPassword.Text);
            if (query!= null)
            {
               
                {
                    currentUserName = query.Name;
                    currentUserEmail = query.EmailAddress;
                }
                Preferences.Set("AccessEmailName", EntryEmail.Text);
                Preferences.Set("AccessPassword", EntryPassword.Text);
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Wrong Email or Password..","","Cancel");
                    if (result)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                });

            }      
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignInPage());
        }

    }
}