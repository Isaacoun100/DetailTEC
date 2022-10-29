
using DetailTEC.REST_API_LoginModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DetailTEC.REST_API_UserModel;
using DetailTEC.Views;

namespace DetailTEC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// This class allows users to register in Cook Time application
    /// @author Jose A.
    /// </summary>
    public partial class Register_Page : ContentPage
    {
        /// <summary>
        /// This constructor execute Register Page partial class and send data of the new user
        /// @author Jose A.
        /// </summary>
        public Register_Page()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This method create an async request that send data of the new user
        /// @author Jose A.
        /// </summary>
        private async void RegisterRequest()
        {
            User nuevoUsuario = new User();
            nuevoUsuario.ID = idEntry.Text;
            nuevoUsuario.Name = nameEntry.Text;

            List<string> lista_tel = new List<string>();
            lista_tel.Add(phoneEntry1.Text);
            lista_tel.Add(phoneEntry2.Text);

            nuevoUsuario.Telefonos = lista_tel;

            nuevoUsuario.Address = addressEntry1.Text;
            nuevoUsuario.Email = emailEntry.Text;
            nuevoUsuario.Username = usernameEntry.Text;
            nuevoUsuario.Password = passwordEntry.Text;

            HttpClient cliente = new HttpClient();
            string url = DetailTEC.Views.Login_Page.ip + "/api/addClientMobile";

            String jsonNewUser = JsonConvert.SerializeObject(nuevoUsuario);

            var datasent = new StringContent(jsonNewUser);

            datasent.Headers.ContentType.MediaType = "application/json";

            var result = await cliente.PostAsync(url, datasent);

            var json = result.Content.ReadAsStringAsync().Result;

            DetailTEC.Views.Login_Page.CURRENTUSER = DetailTEC.REST_API_UserModel.User.FromJson(json);

            await DisplayAlert("DetailTEC", "Thanks for registering " + DetailTEC.Views.Login_Page.CURRENTUSER.Name, "OK");
           
        }


        /// <summary>
        /// This method verify that not exist blank spaces and send the final request
        /// @author Mauricio C.
        /// </summary>
        private void Button_Clicked(object sender, EventArgs e)
        {
            var nameValidate = nameEntry.Text;
            var idValidate = idEntry.Text;
            var tel1Validate = phoneEntry1.Text;
            var addressValidate = addressEntry1.Text;
            var emailValidate = emailEntry.Text;
            var userValidate = usernameEntry.Text;
            var passValidate = passwordEntry.Text;
            if (!string.IsNullOrEmpty(nameValidate) && !string.IsNullOrEmpty(idValidate) && !string.IsNullOrEmpty(tel1Validate) && !string.IsNullOrEmpty(addressValidate) && !string.IsNullOrEmpty(emailValidate) && !string.IsNullOrEmpty(userValidate) && !string.IsNullOrEmpty(passValidate))
            {
                RegisterRequest();
                DisplayAlert("REGISTRATION COMPLETE", "ENJOY DETAILTEC!", "ACCEPT");
                Navigation.PushAsync(new Login_Page());
            }
            else
            {
                DisplayAlert("ERROR", "YOU MUST FILL ALL THE BLANKS TO CONTINUE", "ACCEPT");
            }
            
        } 
    }
}