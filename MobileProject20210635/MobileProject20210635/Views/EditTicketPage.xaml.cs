using MobileProject20210635.Models;
using MobileProject20210635.ModelsViews;
using MobileProject20210635.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTicketPage : ContentPage
    {
        public EditTicketPage(TicketInfo ticket)
        {
            InitializeComponent();
            if (ticket != null)
            {
                ((TicketEditViewModel)BindingContext).Ticket = ticket;
            }
            if (LabelStatus.Text == "Done")
            {
                checkBox.IsChecked = true;
            }
            else
            {
                checkBox.IsChecked = false;

            }
        }
        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
   

            var newTicket = new TicketInfo
            {
                TicketId = int.Parse(EntryId.Text),
                TicketName = EntryName.Text,
                TicketDescription = EntryDescription.Text,
                TicketComment = EntryComment.Text,
                TicketStatus = LabelStatus.Text,

                StartDate = dateStart.Date,
                FinishDate = dateFinish.Date,
                StartTime = startTime.Time,
                FinishTime = finishTime.Time
            };

            if (!string.IsNullOrEmpty(EntryId.Text))
            {
                TicketServices ticketQuery = new TicketServices();

                await ticketQuery.UpdateTicket(newTicket);

                Console.WriteLine("Client Updated...");
              /*  await this.DisplayAlert($"{newTicket.TicketName}", " is updated...", "", "");*/
                await Navigation.PushModalAsync(new DisplayAllTicket());

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
            await Navigation.PushModalAsync(new DisplayAllTicket());
        }

        private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
           if ((!checkBox.IsChecked)||(LabelStatus.Text=="Pending")|| (LabelStatus.Text == ""))
            {
                LabelStatus.Text = "Pending";
            }
           if (checkBox.IsChecked)
            {
                LabelStatus.Text = "Done";
            }

        }

        private void startTime_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void finishTime_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}