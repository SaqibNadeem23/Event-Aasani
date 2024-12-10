using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetDecor : ContentPage
    {
        public SetDecor()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped_ret(object sender, EventArgs e)
        {

        }

        private bool sd1 = true;
        private bool sd2 = true;
        private bool sd3 = true;
        private void TapGestureRecognizer_Tapped_16(object sender, EventArgs e)
        {

            if (sd1 == true)
            {
                s12.IsVisible = true;
                s13.IsVisible = false;
                s14.IsVisible = false;
                sd1 = false;
                sd2 = true;
                sd3 = true;
            }

            else
            {
                s12.IsVisible = false;
                sd1 = true;
                sd2 = true;
                sd3 = true;
            }

        }

        private void TapGestureRecognizer_Tapped_17(object sender, EventArgs e)
        {
            if (sd2 == true)
            {
                s12.IsVisible = false;
                s13.IsVisible = true;
                s14.IsVisible = false;
                sd2 = false;
                sd1 = true;
                sd3 = true;
            }

            else
            {
                s13.IsVisible = false;
                sd1 = true;
                sd2 = true;
                sd3 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_18(object sender, EventArgs e)
        {
            if (sd3 == true)
            {
                s12.IsVisible = false;
                s13.IsVisible = false;
                s14.IsVisible = true;
                sd3 = false;
                sd1 = true;
                sd2 = true;

            }

            else
            {
                s14.IsVisible = false;
                sd1 = true;
                sd2 = true;
                sd3 = true;
            }
        }

        private void btn12_Clicked(object sender, EventArgs e)
        {
            btn12.Text = "Selected";
            btn12.IsEnabled = false;
            btn13.IsEnabled = false;
            btn14.IsEnabled = false;
            sw12.IsEnabled = true;
            sw12.IsVisible = true;
            sw12.IsChecked = true;
            s12.IsVisible = false;
            s13.IsVisible = false;
            s14.IsVisible = false;
        }
       
        private void btn13_Clicked(object sender, EventArgs e)
        {
            btn13.Text = "Selected";
            btn12.IsEnabled = false;
            btn13.IsEnabled = false;
            btn14.IsEnabled = false;
            sw13.IsEnabled = true;
            sw13.IsVisible = true;
            sw13.IsChecked = true;
            s12.IsVisible = false;
            s13.IsVisible = false;
            s14.IsVisible = false;
        }
       
        private void btn14_Clicked(object sender, EventArgs e)
        {
            btn14.Text = "Selected";
            btn12.IsEnabled = false;
            btn13.IsEnabled = false;
            btn14.IsEnabled = false;
            sw14.IsVisible = true;
            sw14.IsEnabled = true;
            sw14.IsChecked = true;
            s12.IsVisible = false;
            s13.IsVisible = false;
            s14.IsVisible = false;

        }

        private void sw12_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw12.IsChecked == false)
            {
                s12.IsVisible = true;
                sw12.IsEnabled = false;
                sw12.IsVisible = false;
                btn12.Text = "Select";
                btn12.IsEnabled = true;
                btn13.IsEnabled = true;
                btn14.IsEnabled = true;
            }

        }

        private void sw13_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw13.IsChecked == false)
            {
                s13.IsVisible = true;
                sw13.IsEnabled = false;
                sw13.IsVisible = false;
                btn13.Text = "Select";
                btn12.IsEnabled = true;
                btn13.IsEnabled = true;
                btn14.IsEnabled = true;
            }
        }

        private void sw14_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw14.IsChecked == false)
            {
                s14.IsVisible = true;
                sw14.IsVisible = false;
                sw14.IsEnabled = false;
                btn14.Text = "Select";
                btn12.IsEnabled = true;
                btn13.IsEnabled = true;
                btn14.IsEnabled = true;
            }
        }

        
         



    }
}
 
 