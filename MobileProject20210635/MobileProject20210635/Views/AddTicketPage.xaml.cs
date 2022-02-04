using MobileProject20210635.Models;
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
    public partial class AddTicketPage : ContentPage
    {
       public string value;
       public TimeSpan start;
       public TimeSpan finish;

       public AddTicketPage()
        {
            InitializeComponent();

        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            var newTicket = new TicketInfo
            {
           /*     TicketId = int.Parse(EntryId.Text),*/
                TicketName = EntryName.Text,
                TicketDescription = EntryDescription.Text,
                TicketComment = EntryComment.Text,
                TicketStatus =value,

                StartDate = dateStart.Date,
                FinishDate = dateFinish.Date,
                StartTime = start,
                FinishTime = finish
            };

            if (!string.IsNullOrEmpty(EntryName.Text))
            {
                TicketServices ticketQuery = new TicketServices();

                await ticketQuery.AddTicket(newTicket);

                Console.WriteLine("Ticket Added...");

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

        //Update database Status.
        public void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                value = "Done";
            }
            else
            {
                value = "Pending";
            }
        }

        private void startTime_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            start = startTime.Time;
        }

        private void finishTime_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            finish = finishTime.Time;
        }
    }
}