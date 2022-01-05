using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject20210635.Services
{
    public interface ITicketServices
    {
        Task AddTicket(TicketInfo ticket);
        /*      Task UpdateUser(TicketInfo ticket);*/
        Task<IEnumerable<TicketInfo>> GetTicket();
        Task<TicketInfo> GetTicket(int id);
        Task RemoveTicket(int id);
    }
}
