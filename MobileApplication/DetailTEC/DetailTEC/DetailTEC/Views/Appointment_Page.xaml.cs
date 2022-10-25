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
    public partial class Appointment_Page : ContentPage
    {
        List<Sucursal> sucursales;
        List<Service> services;
        string branch_g;
        string service_g;

        public Appointment_Page()
        {
            InitializeComponent();
            InitApp();
        }
        public void InitApp()
        {
            sucursales = new List<Sucursal>();
            sucursales.Add(new Sucursal { Name = "Cartago Centro" });
            sucursales.Add(new Sucursal { Name = "Oreamuno de Cartago" });
            sucursales.Add(new Sucursal { Name = "Pinares Curridabat" });
            sucursales.Add(new Sucursal { Name = "Rio Oro Santa Ana" });
            sucursales.Add(new Sucursal { Name = "Ciudad de Panama" });

            services = new List<Service>();
            services.Add(new Service { Name = "Lavado y aspirado" });
            services.Add(new Service { Name = "Lavado encerado" });
            services.Add(new Service { Name = "Lavado premium" });
            services.Add(new Service { Name = "Pulido" });

            foreach (var sucursal in sucursales)
            {
                //picker item {string}
                pickersucursal.Items.Add(sucursal.Name);
            }

            foreach (var service in services)
            {
                //picker item {string}
                pickerservice.Items.Add(service.Name);
            }
        }
        void PickerSucursal_SelectedIndexChanged(Object sender, System.EventArgs e)
        {
            branch_g = pickersucursal.Items[pickersucursal.SelectedIndex];
        }

        void PickerService_SelectedIndexChanged(Object sender, System.EventArgs e)
        {
            service_g = pickerservice.Items[pickerservice.SelectedIndex];
        }
        private async void Make_Appointment(object sender, EventArgs e)
        {
            string cedula = clientEntry.Text;
            //int license = int.Parse(licenseEntry.Text);
            string license = licenseEntry.Text;
            string branch = branch_g;
            string service = service_g;

            /*
             * 
             * API connection
             * 
             */
            await DisplayAlert("Appointment created, awating confirmation", "Appointment Done!", "OK");

            await Navigation.PushAsync(new MainPage());
        }
    }
}