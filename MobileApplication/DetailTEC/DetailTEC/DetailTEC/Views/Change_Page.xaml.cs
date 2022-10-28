using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTEC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Change_Page : ContentPage
    {
        public Change_Page()
        {
            InitializeComponent();
        }
        private async void Go_User(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userEntry.Text))
            {
                Login_Page.CURRENTUSER.Username = userEntry.Text;

                await Navigation.PushAsync(new Views.Profile_Page());
            }
            else
            {
                await DisplayAlert("Warning!","Please fill the blank space to be able to change the value","OK");
            }
            
        }
        private async void Go_Name(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameEntry.Text))
            {
                Login_Page.CURRENTUSER.Name = nameEntry.Text;
                await Navigation.PushAsync(new Views.Profile_Page());
            }
            else
            {
                await DisplayAlert("Warning!", "Please fill the blank space to be able to change the value", "OK");
            }
        }
        private async void Go_Password(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(passEntry.Text))
            {
                Login_Page.CURRENTUSER.Password = passEntry.Text;
                await Navigation.PushAsync(new Views.Profile_Page());
            }
            else
            {
                await DisplayAlert("Warning!", "Please fill the blank space to be able to change the value", "OK");
            }
        }
        private async void Go_Address(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(addressEntry.Text))
            {
                Login_Page.CURRENTUSER.Address = addressEntry.Text;
                await Navigation.PushAsync(new Views.Profile_Page());
            }
            else
            {
                await DisplayAlert("Warning!", "Please fill the blank space to be able to change the value", "OK");
            }
        }
    }
}