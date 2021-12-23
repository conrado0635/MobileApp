using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
            var db = new SQLiteConnection(_dbpath);
            var userQuery = db.Table<Models.Users>().Where(x => x.EmailAddress.Equals(EntryEmail.Text) && x.Password.Equals(EntryPassword.Text)).FirstOrDefault();
            if (userQuery != null)
            {
                currentUserName = userQuery.Name;
                currentUserEmail = userQuery.EmailAddress;


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

        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}