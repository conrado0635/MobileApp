using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject20210635.Services
{
    public interface IClientServices
    {
        Task AddClient(string name, string email, string address, string phone, DateTime date);
  /*      Task UpdateUser(ClientInfo user);*/
        Task<IEnumerable<ClientInfo>> GetClient();
        Task<ClientInfo> GetClient(int id);
        Task RemoveClient(int id);

  
    }
}
