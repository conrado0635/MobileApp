using MobileProject20210635.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void BtnBackHome_Clicked(object sender, EventArgs e)
        {
           /* await Navigation.PushAsync(new MyAccountPage());*/
           Application.Current.MainPage = new NavigationPage(new HomePage());
        }

        private void BtnMerchandiser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DisplayAllTicket());

        }

        private void BtnSupervisor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SupervisorView());
        }
    }
}