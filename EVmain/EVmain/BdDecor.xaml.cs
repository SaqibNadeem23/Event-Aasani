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
    public partial class BdDecor : ContentPage
    {
        public BdDecor()
        {
            InitializeComponent();
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_ret(object sender, EventArgs e)
        {

        }

        private bool x1 = true;
        private bool x2 = true;
        private bool x3 = true;
        private bool x4 = true;
        private bool x5 = true;
        private bool x6 = true;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            if (x1 == true)
            {
                s1.IsVisible = true;
                s2.IsVisible = false;
                s3.IsVisible = false;
                s4.IsVisible = false;
                s5.IsVisible = false;
                s6.IsVisible = false;
                x1 = false;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true; 
                x6 = true;
            }

            else
            {
                s1.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (x2 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = true;
                s3.IsVisible = false;
                s4.IsVisible = false;
                s5.IsVisible = false;
                s6.IsVisible = false;
                x1 = false;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }

            else
            {
                s2.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (x3 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = false;
                s3.IsVisible = true;
                s4.IsVisible = false;
                s5.IsVisible = false;
                s6.IsVisible = false;
                x1 = false;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;

            }

            else
            {
                s3.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }
        }
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (x4 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = false;
                s3.IsVisible = false;
                s4.IsVisible = true;
                s5.IsVisible = false;
                s6.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = false;
                x5 = true;
                x6 = true;

            }

            else
            {
                s4.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }
        }
        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (x5 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = false;
                s3.IsVisible = false;
                s5.IsVisible = true;
                s4.IsVisible = false;
                s6.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x5 = false;
                x4 = true;
                x6 = true;

            }

            else
            {
                s5.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (x6 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = false;
                s3.IsVisible = false;
                s6.IsVisible = true;
                s4.IsVisible = false;
                s5.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x6 = false;
                x4 = true;
                x5 = true;

            }

            else
            {
                s6.IsVisible = false;
                x1 = true;
                x2 = true;
                x3 = true;
                x4 = true;
                x5 = true;
                x6 = true;
            }
        }
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            btn1.Text = "Selected"; 
            sw1.IsEnabled = true;
            sw1.IsVisible = true;
            sw1.IsChecked = true;
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            btn2.Text = "Selected";
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            sw2.IsEnabled = true;
            sw2.IsVisible = true;
            sw2.IsChecked = true;
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            btn3.Text = "Selected";
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            sw3.IsVisible = true;
            sw3.IsEnabled = true;
            sw3.IsChecked = true;
            

        }
        private void btn4_Clicked(object sender, EventArgs e)
        {
            btn4.Text = "Selected";
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            sw4.IsVisible = true;
            sw4.IsEnabled = true;
            sw4.IsChecked = true;
        }
        private void btn5_Clicked(object sender, EventArgs e)
        {
            btn5.Text = "Selected";
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            sw5.IsVisible = true;
            sw5.IsEnabled = true;
            sw5.IsChecked = true;
        }
        private void btn6_Clicked(object sender, EventArgs e)
        {
            btn6.Text = "Selected";
            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            sw6.IsVisible = true;
            sw6.IsEnabled = true;
            sw6.IsChecked = true;
        }
        private void sw1_CheckedChanged(object sender, CheckedChangedEventArgs e)
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
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
            }

        }

        private void sw2_CheckedChanged(object sender, CheckedChangedEventArgs e)
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
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
            }
        }

        private void sw3_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw3.IsChecked == false)
            {
                s3.IsVisible = true;
                sw3.IsVisible = false;
                sw3.IsEnabled = false;
                btn3.Text = "Select";
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
            }
        }
        

        
        private void sw4_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw4.IsChecked == false)
            {
                s4.IsVisible = true;
                sw4.IsVisible = false;
                sw4.IsEnabled = false;
                btn4.Text = "Select";
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
            }
        }

        
        private void sw5_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw5.IsChecked == false)
            {
                s5.IsVisible = true;
                sw5.IsVisible = false;
                sw5.IsEnabled = false;
                btn5.Text = "Select";
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
            }
        }

        private void sw6_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sw6.IsChecked == false)
            {
                s6.IsVisible = true;
                sw6.IsVisible = false;
                sw6.IsEnabled = false;
                btn3.Text = "Select";
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
            }
        } 
    }
}