using EVmain.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeddingInfo : ContentPage
    {

        public WeddingInfo()
        {
            InitializeComponent();

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
        }

        private void animV_OnPlay(object sender, EventArgs e)
        {
            anim.IsVisible = true;
        }

        private void animV_OnFinish(object sender, EventArgs e)
        {
            anim.IsVisible = false;
        }

        string s;
        private void sw_Toggled(object sender, ToggledEventArgs e)
        {
            
            if (d3.IsToggled == true)
            {
                s = "night";
                animV.Animation = "night.json";
                animV.PlayAnimation();
            }
            else if (d3.IsToggled == false)
            {
                s = "day";
                animV.Animation = "day.json";
                animV.PlayAnimation();
            }
        }
   
    }

}
