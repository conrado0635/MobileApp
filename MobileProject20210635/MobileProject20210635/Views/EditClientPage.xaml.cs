using MobileProject20210635.Models;
using MobileProject20210635.ModelsViews;
using MobileProject20210635.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClientPage : ContentPage
    {

      /*  public DateTime date;*/
        public EditClientPage(ClientInfo client = null)
        {
            InitializeComponent();
            if (client != null)
            {
                ((ClientEditViewModel)BindingContext).Client = client;
            }


        }
        private async void BtnSave_Clicked(object sender, EventArgs e)
        {

            var newClient = new ClientInfo
            {
                ClientId = int.Parse(EntryId.Text),
                ClientName = EntryName.Text,
                ClientEmail = EntryEmail.Text,
                ClientAddress = EntryHome.Text,
                ClientPhone = EntryPhone.Text,
                RegisteredDate = dateRegister.Date
            };

            if (!string.IsNullOrEmpty(EntryId.Text))
            {
                ClientServices userQuery = new ClientServices();

                await userQuery.UpdateClient(newClient);

                Console.WriteLine("Client Updated...");

                await Navigation.PushModalAsync(new DisplayAllClient());

            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Erorr", "No Empty Field", "", "Cancel");
                    if (result)
                    {
                        await Navigation.PopAsync();
                    }
                });

            }
        }
    
        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DisplayAllClient());
        }

 /*       void dateRegister_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
        }
        public void Recalculate()
        {
            DateTime date = dateRegister.Date;
           
        }*/



    }
}