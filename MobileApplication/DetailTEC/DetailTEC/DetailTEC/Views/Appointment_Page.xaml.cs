using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailTEC.SQLite_Models;
using DetailTEC.Data;
using SQLite;
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
            if (checkData())
            {
                
                Appointment appoint = new Appointment
                {
                    cliente = clientEntry.Text,
                    placaVehiculo = licenseEntry.Text,
                    sucursal = branch_g,
                    tipoLavado = service_g,
                    responsable = "",
                    factura = "",
                    numeroCita = "",
                };
                await App.SQLiteDB.SaveAppointmentAsync(appoint);
                clientEntry.Text = "";
                licenseEntry.Text = "";
                branch_g = "";
                service_g = "";
                
                await DisplayAlert("Appointment created!", "Waiting for confirmation", "OK");
                var appointmentList = await App.SQLiteDB.GetAppointmentsAsync();
                
                if (appointmentList!=null)
                {
                    listCitas.ItemsSource = appointmentList;
                    
                }
                //await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Warning!", "Please complete all blank spaces", "OK");
            }
        }
        public bool checkData()
        {
            bool response;
            if (string.IsNullOrEmpty(clientEntry.Text))
            {
                response = false;
            }
            else if (string.IsNullOrEmpty(licenseEntry.Text))
            {
                response = false;
            }
            else if (string.IsNullOrEmpty(branch_g))
            {
                response = false;
            }
            else if (string.IsNullOrEmpty(branch_g))
            {
                response = false;
            }
            else
            {
                response = true;
            }
            return response;
        }
    }
}