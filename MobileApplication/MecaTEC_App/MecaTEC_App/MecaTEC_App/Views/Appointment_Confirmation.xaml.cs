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
    public partial class Appointment_Confirmation : ContentPage
    {
        public Appointment_Confirmation()
        {
            InitializeComponent();
        }
        private async void Go_Back(object sender, EventArgs e)
        {
            //todo
            //todo
            //todo
            await Navigation.PushAsync(new Home_Page());
        }
    }
}