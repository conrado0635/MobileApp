using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileProject20210635.ModelsViews
{
    class TicketEditViewModel: INotifyPropertyChanged
    {
        public TicketInfo _ticket;
        public TicketInfo Ticket
        {
            get { return _ticket; }
            set
            {
                _ticket = value;
                OnPropertyChanged();
            }
        }
        public TicketEditViewModel()
        {
            Ticket = new TicketInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
