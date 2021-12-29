using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MobileProject20210635.Models;


namespace MobileProject20210635.ModelsViews
{

    public class AddOrEditProductViewModel : INotifyPropertyChanged
    {
        public ProductInfo _product;
        public ProductInfo Product
        {
            get { return _product; }
            set { _product = value;
                OnPropertyChanged();
            }
        }
        public AddOrEditProductViewModel()
        {
            Product = new ProductInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

     }

}

