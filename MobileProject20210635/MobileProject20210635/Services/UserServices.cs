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
    public class UserServices : IUserServices
    {
        public SQLiteAsyncConnection db;

/*        public UserServices(){
            if (db != null)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData1.db");
                db = new SQLiteAsyncConnection(dbPath);
                db.CreateTableAsync<Users>();
            }

        }*/

       public async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData1.db");
            Console.WriteLine(databasePath);
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Users>();

            Console.WriteLine("Table created!");
            
          

        }

        public async Task AddUser(string name,string email,string address,string phone,string password,DateTime signIn,DateTime signOut, string userType="User")
        {
           await Init();
            var newUser = new Users
            {
                Name = name,
                EmailAddress = email.ToLower(),
                HomeAddress = address.ToLower(),   
                Phone = phone,
                Password = password,
                SignInDate=signIn,
                SignOutDate=signOut,
                UserType=userType
            };
            var id = await db.InsertAsync(newUser);
            Console.WriteLine(newUser.Name + " " + "Added to database", "OK");
        }
        public async Task UpdateUser(Users newUser)
        {
            await Init();

            await db.UpdateAsync(newUser);
 
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
        public async Task<Users> GetUser(int id)
        {
            await Init();

            var user = await db.Table<Users>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return user;
        }
        public async Task<Users> GetOneUser(string email, string password)
        {
            await Init();
            Users user =await db.Table<Users>().FirstOrDefaultAsync(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
            return user;
        }


    }
}
