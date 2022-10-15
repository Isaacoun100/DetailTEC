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
    public partial class Appointment_Page : ContentPage
    {
        List<Sucursal> sucursales;
        List<Service> services;

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
            services.Add(new Service { Name = "Cambio de aceite" });
            services.Add(new Service { Name = "Alineado" });
            services.Add(new Service { Name = "Tramado" });
            services.Add(new Service { Name = "Revision 5000 km" });
            services.Add(new Service { Name = "Revision 10000 km" });
            services.Add(new Service { Name = "Revision 20000 km" });
            services.Add(new Service { Name = "Reparacion caja de cambio" });
            services.Add(new Service { Name = "Overhaul de motor" });

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
            int position = pickersucursal.SelectedIndex;
            if(position > -1)
            {

            }
        }

        void PickerService_SelectedIndexChanged(Object sender, System.EventArgs e)
        {
            int position = pickerservice.SelectedIndex;
            if (position > -1)
            {

            }
        }
        private async void Make_Appointment(object sender, EventArgs e)
        {
            //todo
            //todo
            //todo
            await Navigation.PushAsync(new Appointment_Confirmation());
        }
    }
}