
using System;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileProject20210635.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
       /* string _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");*/
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {

            /*            var db = new SQLiteConnection(_dbpath);
                        db.CreateTable<Models.Users>();

                        var maxpk = db.Table<Models.Users>().OrderByDescending(c => c.Id).FirstOrDefault();*/
            /*            if (typeof(EntryCell) == null)
                        {
                            DisplayAlert(null, "Please provide value.", "cancel");
                        }*/

            /*            Models.Users user = new Models.Users()
                        {
                            Id = maxpk == null ? 1 : maxpk.Id + 1,
                            Name = EntryName.Text,

                            EmailAddress = EntryEmail.Text,
                            Password=EntryPassword.Text,
                            HomeAddress = EntryAddress.Text,
                            Department=EntryDepartment.Text
                        };
                        db.Insert(user);
                        await DisplayAlert(null, user.Name + " " + "saved", "OK");*/
            UserServices userQuery = new UserServices();
            await userQuery.AddUser(EntryName.Text,
                EntryEmail.Text,
                EntryAddress.Text,
                EntryDepartment.Text,
                EntryPassword.Text);
            

            await Navigation.PushModalAsync(new LogInPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LogInPage());
        }
    }
}