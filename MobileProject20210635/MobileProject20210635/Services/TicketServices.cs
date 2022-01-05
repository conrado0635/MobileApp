using Xamarin.Forms;
using MobileProject20210635.Models;
using MobileProject20210635.ModelsViews;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Text;
using MobileProject20210635.Services;

[assembly: Dependency(typeof(TicketServices))]
namespace MobileProject20210635.Services
{
    public class TicketServices : ITicketServices
    {
        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData1.db");

            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<TicketInfo>();
            Console.WriteLine("Table created!");
        }
        public async Task AddTicket(TicketInfo newTicket)
        {
            await Init();
/*            if (newTicket.TicketId == 0)
            {
                newTicket.TicketId = TicketList.Count + 1;
            }*/
            var id = await db.InsertAsync(newTicket);
            Console.WriteLine(newTicket.TicketName + " " + "Added to database", "OK");
        }
        public async Task UpdateTicket(TicketInfo newTicket)
        {
            await Init();

            await db.UpdateAsync(newTicket);

        }
        public async Task RemoveTicket(int id)
        {
            await Init();
            await db.DeleteAsync<TicketInfo>(id);
            Console.WriteLine("TicketId deleted...");
        }
        public async Task<IEnumerable<TicketInfo>> GetTicket()
        {
            await Init();
         var ticket = await db.Table<TicketInfo>().ToListAsync();
            return ticket;
        }
        public async Task<TicketInfo> GetTicket(int id)
        {
            await Init();

            var ticket = await db.Table<TicketInfo>()
                .FirstOrDefaultAsync(c => c.TicketId == id);

            return ticket;
        }
    /*    public async Task<TicketInfo> GetOneticket(string email, string password)
        {
            await Init();
            Users ticket = await db.Table<Users>().FirstOrDefaultAsync(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
            return ticket;
        }*/


    }
}
