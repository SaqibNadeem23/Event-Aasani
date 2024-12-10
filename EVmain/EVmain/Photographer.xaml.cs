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
    public partial class Photographer : ContentPage
    {
        public Photographer()
        {
            InitializeComponent();
            s9.IsVisible = false;
            s10.IsVisible = false;
            s11.IsVisible = false;

        }

        private void TapGestureRecognizer_Tapped_ret(object sender, EventArgs e)
        {
        }

        private bool p1 = true;
        private bool p2 = true;
        private bool p3 = true;
        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            if (p1 == true)
            {
                s9.IsVisible = true;
                s10.IsVisible = false;
                s11.IsVisible = false;
                p1 = false;
                p2 = true;
                p3 = true;
            }

            else
            {
                s9.IsVisible = false;
                p1 = true;
                p2 = true;
                p3 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
            if (p2 == true)
            {
                s9.IsVisible = false;
                s10.IsVisible = true;
                s11.IsVisible = false;
                p2 = false;
                p1 = true;
                p3 = true;
            }

            else
            {
                s10.IsVisible = false;
                p1 = true;
                p2 = true;
                p3 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_15(object sender, EventArgs e)
        {
            if (p3 == true)
            {
                s9.IsVisible = false;
                s10.IsVisible = false;
                s11.IsVisible = true;
                p3 = false;
                p1 = true;
                p2 = true;

            }

            else
            {
                s11.IsVisible = false;
                p1 = true;
                p2 = true;
                p3 = true;
            }
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            sw9.IsVisible = true;
            sw9.IsChecked = true;
            sw9.IsEnabled = true;
            btn9.IsEnabled = false;
            btn10.IsEnabled = false;
            btn11.IsEnabled = false;
            btn9.Text = "Selected";
            s9.IsVisible = false;
        }

        private void btn10_Clicked(object sender, EventArgs e)
        {
            sw10.IsVisible = true;
            sw10.IsChecked = true;
            sw10.IsEnabled = true;
            btn9.IsEnabled = false;
            btn10.IsEnabled = false;
            btn11.IsEnabled = false;
            btn10.Text = "Selected";
            s10.IsVisible = false;
        }

        private void btn11_Clicked(object sender, EventArgs e)
        {
            sw11.IsVisible = true;
            sw11.IsChecked = true;
            sw11.IsEnabled = true;
            btn9.IsEnabled = false;
            btn10.IsEnabled = false;
            btn11.IsEnabled = false;
            btn10.Text = "Selected";
            s11.IsVisible = false;
        }

        private void sw9_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw9.IsChecked == false)
            {
                s9.IsVisible = true;
                sw9.IsEnabled = false;
                sw9.IsVisible = false;
                btn9.Text = "Select";
                btn9.IsEnabled = true;
                btn10.IsEnabled = true;
                btn11.IsEnabled = true;
            }
        }

        private void sw10_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw10.IsChecked == false)
            {
                s10.IsVisible = true;
                sw10.IsEnabled = false;
                sw10.IsVisible = false;
                btn10.Text = "Select";
                btn9.IsEnabled = true;
                btn10.IsEnabled = true;
                btn11.IsEnabled = true;
            }
        }
        private void sw11_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw11.IsChecked == false)
            {
                s11.IsVisible = true;
                sw11.IsEnabled = false;
                sw11.IsVisible = false;
                btn11.Text = "Select";
                btn9.IsEnabled = true;
                btn10.IsEnabled = true;
                btn11.IsEnabled = true;
            }
        }





    }
}