using MobileProject20210635.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace MobileProject20210635.ModelsViews
{
    public class UserViewModel
    {
        public ObservableCollection<Users>Users { get; set; }
        public UserViewModel()
    {
        Users = new ObservableCollection<Users>();
    }
}

}
