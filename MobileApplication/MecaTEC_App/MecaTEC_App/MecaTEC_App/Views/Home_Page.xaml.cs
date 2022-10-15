using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MecaTEC_App.Views
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
        private async void Go_Bills(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bills_Page());
        }
    }
}