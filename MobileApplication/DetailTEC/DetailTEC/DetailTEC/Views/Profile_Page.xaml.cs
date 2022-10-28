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
    public partial class Profile_Page : ContentPage
    {
        public Profile_Page()
        {
            InitializeComponent();
    
        }
        private async void Change_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Change_Page());
        }
        
        public void updateLabels()
        {
            Name_Label.Text = Login_Page.CURRENTUSER.Name;
            ID_Label.Text = Login_Page.CURRENTUSER.ID;
            Email_Label.Text = Login_Page.CURRENTUSER.Email;
            Address_Label.Text = Login_Page.CURRENTUSER.Address;
            Username_Label.Text = Login_Page.CURRENTUSER.Username;
        }
    }
}