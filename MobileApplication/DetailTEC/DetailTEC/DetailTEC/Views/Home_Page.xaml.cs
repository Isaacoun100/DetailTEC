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
    public partial class Home_Page : ContentPage
    {
        public Home_Page()
        {
            InitializeComponent();
        }
        private async void Go_Appointment(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Appointment_Page());
        }
        private async void Go_Points(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Points_Page());
        }
        private async void Go_Profile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile_Page());
        }
        private async void Go_DBSync(object sender, EventArgs e)
        {
            /*
             * 
             */
            await DisplayAlert("Local Database synchronized correctly", "Sync Done!", "OK");
            await Navigation.PushAsync(new Profile_Page());
        }
    }
}