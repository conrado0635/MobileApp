using Xamarin.Forms;
using MobileProject20210635.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Text;
using MobileProject20210635.Services;

[assembly: Dependency(typeof(UserServices))]
namespace MobileProject20210635.Services
{
   public class UserServices: IUserServices
    {
        SQLiteAsyncConnection db;
         async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

             db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Users>();

            Console.WriteLine("Table created!");
        }
         public  async Task AddUser(string name,string email,string address,string department,string password)
        {
            await Init();
            var newUser = new Users
            {
                Name = name,
                EmailAddress = email,
                HomeAddress = address,   
                Department = department,
                Password = password
            };
            var id = await db.InsertAsync(newUser);
            Console.WriteLine(newUser.Name + " " + "Added to database", "OK");

        }

        public async Task RemoveUser(int id)
        {
            await Init();
            await db.DeleteAsync<Users>(id);
            Console.WriteLine("UserId deleted...");
        }

        public  async Task <IEnumerable<Users>> GetUser()
        {
            await Init();
            /*   var users = await db.Table<Users>().ToListAsync();*/
      
            var users = await db.Table<Users>().ToListAsync();
            return users;
        }

        public async Task<Users> GetUser(string email, string password)
        {
            await Init();
            Users users =await db.Table<Users>().FirstOrDefaultAsync(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
            return users;
        }

    }
}
