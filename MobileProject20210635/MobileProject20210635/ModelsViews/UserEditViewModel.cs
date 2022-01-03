
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MobileProject20210635.Models;


namespace MobileProject20210635.ModelsViews
{

    public class UserEditViewModel : INotifyPropertyChanged
    {
        public Users _user;
        public Users User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public UserEditViewModel()
        {
            User = new Users();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
