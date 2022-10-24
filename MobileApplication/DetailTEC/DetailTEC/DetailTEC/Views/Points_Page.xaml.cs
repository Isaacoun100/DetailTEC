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
    public partial class Points_Page : ContentPage
    {
        public Points_Page()
        {
            InitializeComponent();
            updatePoints();
        }

        public void updatePoints()
        {
            Points.Text = Login_Page.CURRENTUSER.Points;
            
        }
    }
}