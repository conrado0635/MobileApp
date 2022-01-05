
using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MobileProject20210635.Models;
using Xamarin.Forms;
using MobileProject20210635.Services;

[assembly: Dependency(typeof(ClientServices))]
namespace MobileProject20210635.Services
{
     public class ClientServices
    {
        SQLiteAsyncConnection db;

        /*  public object ClientList { get; private set; }
  */
        async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData1.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<ClientInfo>();

            Console.WriteLine("Table Client created!");
        }
        public async Task AddClient(string name, string email, string address, string phone,DateTime date)
        { 
            await Init();

            ClientInfo newClient = new ClientInfo()
            {
   
                ClientName = name,
                ClientAddress = email,
                ClientEmail = address,
                ClientPhone = phone,
                RegisteredDate = date
            };
            var newId = await db.InsertAsync(newClient);
            Console.WriteLine(newClient.ClientName + " " + "Added to database", "OK");
        }

        internal static Task GetClient(int v, object id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateClient(ClientInfo newClient)
        {
            await Init();

            await db.UpdateAsync(newClient);

        }
        
        public async Task RemoveClient(int id)
        {
            await Init();
            await db.DeleteAsync<ClientInfo>(id);
            Console.WriteLine("ClientId deleted...");
        }
        public async Task<IEnumerable<ClientInfo>> GetClient()
        {
            await Init();
            var client = await db.Table<ClientInfo>().ToListAsync();
            return client;
        }

        public async Task<ClientInfo> GetClient(int id)
        {
            await Init();

            var client = await db.Table<ClientInfo>()
                .FirstOrDefaultAsync(c => c.ClientId == id);

         return client;
                }

                /*        public async Task<Users> GetOneUser(string email, string password)
                        {
                            await Init();
                            Users user = await db.Table<Users>().FirstOrDefaultAsync(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
                            return user;
                        }*/
    }
}
