using MobileProject20210635.ModelsViews;
using MobileProject20210635.Services;
using MobileProject20210635.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject20210635
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        public string email;
        public string password;
        public MyAccountPage()
        {
            InitializeComponent();


        }
        protected override async void OnAppearing()
        {
            email = Preferences.Get("AccessEmailName", "NoEmail");
            password = Preferences.Get("AccessPassword", "NoPassword");
            //base.OnAppearing();

            UserServices userService = new UserServices();

            var userInfo = await userService.GetOneUser(email, password);

            LabelName.Text = userInfo.Name;
            LabelEmail.Text = userInfo.EmailAddress;
            LabelPassword.Text = userInfo.Password;


          //Populate Picker
            string[] rotation = new string[] { "0", "45", "90", "180", "270" };
            int i = 0;
            foreach (string item in rotation)
            {
                PickAngle.Items.Add(item);
                i++;
            }
            



        }

        private async void TapUploadImage_Tapped(object sender, EventArgs e)
        {

            var pickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes=FilePickerFileType.Images,
                PickerTitle= "Pick Image"      
            });

            if (pickImage != null)
            {
                var imgStream = await pickImage.OpenReadAsync();
                ImageProfile.Source = ImageSource.FromStream(() => imgStream);
                labelUpload.Text = pickImage.FileName;
            }

        }

        private async void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            
              await Navigation.PushModalAsync(new PasswordPage());
          
        }

        private void TapChangePhone_Tapped(object sender, EventArgs e)
        {

        }

        private async void TapLogout_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LandingPage());
        }

        private void TapChangeDepartment_Tapped(object sender, EventArgs e)
        {

        }

        private void TapDisplayAllUser_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DisplayAllUser());
        }

        private void LabelLogout_Focused(object sender, FocusEventArgs e)
        {
            LabelLogout.TextColor = Color.DeepSkyBlue;
        }

        private void LabelChangePassword_Focused(object sender, FocusEventArgs e)
        {
            LabelChangePassword.TextColor = Color.DeepSkyBlue;
        }

        private void PickAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
      
            var picker = (Picker)sender;
            int[] rotation = new int[] { 0, 45, 90, 180, 270};

            int pickerIndex = picker.SelectedIndex;
            if (pickerIndex == -1)
            {
                ImageProfile.Rotation = 0;
            }
            else
            {
                ImageProfile.Rotation = rotation[picker.SelectedIndex];
            }
            //picker.SelectedItem = null;

        }
    }
}