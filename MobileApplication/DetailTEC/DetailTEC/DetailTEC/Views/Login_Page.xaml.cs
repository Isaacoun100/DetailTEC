using DetailTEC.REST_API_LoginModel;
using DetailTEC.REST_API_UserModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTEC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// This class allows users to login in Cook Time application, if already have an account created.
    /// @author Jose A.
    /// </summary>
    public partial class Login_Page : ContentPage

    {
        public static DetailTEC.REST_API_UserModel.User CURRENTUSER;
        public static string ip = "https://5314-201-207-239-92.ngrok.io";
        /// <summary>
        /// This constructor execute Login Page partial class
        /// @author Jose A.
        /// </summary>
        public Login_Page()
        {
            InitializeComponent();
            
        }


        /// <summary>
        /// This method is used to change the current page to Register page
        /// @author Mauricio C.
        /// </summary>
        private void Go_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register_Page());
        }

        /// <summary>
        /// This method is used to change the current page to Home page and send a json file to verify the user credentials
        /// @author Mauricio C.
        /// </summary>
        private async void Button_Clicked(object sender, EventArgs e)
        {

            var userValidate = userEntry.Text;
            if (!string.IsNullOrEmpty(userValidate))
            {
                string email = userEntry.Text;
                string password = pasEntry.Text;

                HttpClient cliente = new HttpClient();

                string url = ip + "/api/authMobile";

                LoginUser log = new LoginUser();

                log.Email = email;
                log.Password = password;

                String jsonLogIn = JsonConvert.SerializeObject(log);
                var datasent = new StringContent(jsonLogIn);
                datasent.Headers.ContentType.MediaType = "application/json";
                var result = await cliente.PostAsync(url, datasent);

                var json = result.Content.ReadAsStringAsync().Result;
                DetailTEC.REST_API_UserModel.User InputUser = new DetailTEC.REST_API_UserModel.User();
                InputUser = DetailTEC.REST_API_UserModel.User.FromJson(json);

                if (InputUser.ID == null)
                {
                    await DisplayAlert("DetailTEC", "The data you filled with does not match with any DetailTEC user. Please verify your info and try again!", "OK");
                }
                else
                {
                    CURRENTUSER = DetailTEC.REST_API_UserModel.User.FromJson(json);
                    await DisplayAlert("DetailTEC", "Welcome back " + CURRENTUSER.Name, "OK");
                    await Navigation.PushAsync(new Home_Page());
                }

            }

        }
        /// <summary>
        /// This method is used to change the current page to Info page
        /// @author Mauricio C.
        /// </summary>
        private void Info_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Info_Page());
        }
      
    }
}