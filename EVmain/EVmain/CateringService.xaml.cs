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
    public partial class CateringService : ContentPage
    {
        public CateringService()
        {
            InitializeComponent();
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
        }
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
        }

        private bool x1 = true;
        private bool x2 = true;
        private bool x3 = true;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            if (x1 == true)
            {
                s1.IsVisible = true;
                s2.IsVisible = false;
                s3.IsVisible = false;
                x1 = false;
                x2 = true;
                x3 = true;
            }

            else
            {
                s1.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
            }

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (x2 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = true;
                s3.IsVisible = false;
                x2 = false;
                x1 = true;
                x3 = true;
            }

            else
            {
                s2.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (x3 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = false;
                s3.IsVisible = true;
                x3 = false;
                x1 = true;
                x2 = true;

            }

            else
            {
                s3.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
            }
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            btn1.Text = "Selected";
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            sw1.IsEnabled = true;
            sw1.IsVisible = true;
            sw1.IsChecked = true;
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            c11.IsEnabled = false;
            c12.IsEnabled = false;
        }
        private void sw1_CheckedChanged(object sender, ToggledEventArgs e)
        {
            if (sw1.IsChecked == false)
            {
                s1.IsVisible = true;
                sw1.IsEnabled = false;
                sw1.IsVisible = false;
                btn1.Text = "Select";
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                c11.IsEnabled = true;
                c12.IsEnabled = true;
            }
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            btn2.Text = "Selected";
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            sw2.IsEnabled = true;
            sw2.IsVisible = true;
            sw2.IsChecked = true;
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            c21.IsEnabled = false;
            c22.IsEnabled = false;
        }
        private void sw2_CheckedChanged(object sender, ToggledEventArgs e)
        {
            if (sw2.IsChecked == false)
            {
                s2.IsVisible = true;
                sw2.IsEnabled = false;
                sw2.IsVisible = false;
                btn2.Text = "Select";
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                c21.IsEnabled = true;
                c22.IsEnabled = true;
            }
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            btn3.Text = "Selected";
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            sw3.IsVisible = true;
            sw3.IsEnabled = true;
            sw3.IsChecked = true;
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            c31.IsEnabled = false;
            c32.IsEnabled = false;

        }

        private void sw3_CheckedChanged(object sender, ToggledEventArgs e)
        {
            if (sw3.IsChecked == false)
            {
                btn3.Text = "Select";
                s3.IsVisible = true;
                sw3.IsVisible = false;
                sw3.IsEnabled = false;
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                c31.IsEnabled = true;
                c32.IsEnabled = true;
            }
        }


        private void c1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (c11.IsChecked == true || c12.IsChecked == true)
            {
                btn1.IsEnabled = true;
            }
            else
            {
                btn1.IsEnabled = false;
            }
        }

        private void c2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (c21.IsChecked == true || c22.IsChecked == true)
            {
                btn2.IsEnabled = true;
            }
            else
            {
                btn2.IsEnabled = false;
            }
        }

        private void c3_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (c31.IsChecked == true || c32.IsChecked == true)
            {
                btn3.IsEnabled = true;
            }
            else
            {
                btn3.IsEnabled = false;
            }
        }
    }
}