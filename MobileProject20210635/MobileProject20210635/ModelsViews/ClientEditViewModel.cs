using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Text;

namespace MobileProject20210635.ModelsViews
{
    class ClientEditViewModel: INotifyPropertyChanged
    {
       public ClientInfo _client;
       public ClientInfo Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged();
            }
        }
        public ClientEditViewModel()
        {
            Client = new ClientInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
