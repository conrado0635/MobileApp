using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject20210635.Services
{
   public interface IUserServices
    {

        Task AddUser(string name, string email,string address,string department,string password);
        Task<IEnumerable<Users>> GetUser();
        Task<Users> GetUser(string email,string password);
        Task RemoveUser(int id);
    }
}
