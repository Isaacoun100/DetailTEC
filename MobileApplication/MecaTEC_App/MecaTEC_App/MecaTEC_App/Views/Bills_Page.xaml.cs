using MecaTEC_App.REST_API_BillListModel;
using MecaTEC_App.REST_API_BillModel;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MecaTEC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bills_Page : ContentPage
    {
        MecaTEC_App.REST_API_UserModel.User myprofile = Login_Page.CURRENTUSER;

        public Bills_Page()
        {
            InitializeComponent();
            Pull_Bill_Request();

            

        }
        private void Pull_Bill_Request()
        {
           

        }
    }
}