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
    public partial class FoodItems : ContentPage
    {
        public FoodItems()
        {
            InitializeComponent();
            s4.IsVisible = false;
            s5.IsVisible = false;
            s6.IsVisible = false;
            s7.IsVisible = false;
            s8.IsVisible = false;
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            sw4.IsVisible = true;
            sw4.IsChecked = true;
            btn4.IsEnabled = false;
            s4.IsVisible = false;
        }
        private void btn5_Clicked(object sender, EventArgs e)
        {
            sw5.IsVisible = true;
            sw5.IsChecked = true;
            btn5.IsEnabled = false;
            s5.IsVisible = false;

        }
        private void btn6_Clicked(object sender, EventArgs e)
        {
            sw6.IsVisible = true;
            sw6.IsChecked = true;
            btn6.IsEnabled = false;
            s6.IsVisible = false;
        }
        private void btn7_Clicked(object sender, EventArgs e)
        {
            sw7.IsVisible = true;
            sw7.IsChecked = true;
            btn7.IsEnabled = false;
            s7.IsVisible = false;
        }
        private void btn8_Clicked(object sender, EventArgs e)
        {
            sw8.IsVisible = true;
            sw8.IsChecked = true;
            btn8.IsEnabled = false;
            s8.IsVisible = false;
        }


        private void sw4_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            sw4.IsVisible = false;
            btn4.IsEnabled = true;
        }
        private void sw5_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            sw5.IsVisible = false;
            btn5.IsEnabled = true;
        }
        private void sw6_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            sw6.IsVisible = false;
            btn6.IsEnabled = true;
        }

        private void sw7_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            sw7.IsVisible = false;
            btn7.IsEnabled = true;
        }

        private void sw8_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            sw8.IsVisible = false;
            btn8.IsEnabled = true;
        }

        private bool f1 = true;
        private bool f2 = true;
        private bool f3 = true;
        private bool f4 = true;
        private bool f5 = true;
        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {

            if (f1 == true)
            {
                s4.IsVisible = true;
                s5.IsVisible = false;
                s6.IsVisible = false;
                s7.IsVisible = false;
                s8.IsVisible = false;
                f1 = false;
                f2 = true;
                f3 = true;
                f4 = true;
                f5 = true;
            }

            else
            {
                s4.IsVisible = false;
                f1 = true;
                f2 = true;
                f3 = true;
                f4 = true;
                f5 = true;

            }
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {

            if (f2 == true)
            {
                s4.IsVisible = false;
                s5.IsVisible = true;
                s6.IsVisible = false;
                s7.IsVisible = false;
                s8.IsVisible = false;
                f2 = false;
                f1 = true;
                f3 = true;
                f4 = true;
                f5 = true;
            }

            else
            {
                s5.IsVisible = false;
                f1 = true;
                f2 = true;
                f3 = true;
                f4 = true;
                f5 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {

            if (f3 == true)
            {
                s4.IsVisible = false;
                s5.IsVisible = false;
                s6.IsVisible = true;
                s7.IsVisible = false;
                s8.IsVisible = false;
                f3 = false;
                f1 = true;
                f2 = true;
                f4 = true;
                f5 = true;
            }

            else
            {
                s6.IsVisible = false;
                f1 = true;
                f2 = true;
                f3 = true;
                f4 = true;
                f5 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {

            if (f4 == true)
            {
                s4.IsVisible = false;
                s5.IsVisible = false;
                s6.IsVisible = false;
                s7.IsVisible = true;
                s8.IsVisible = false;
                f4 = false;
                f2 = true;
                f3 = true;
                f1 = true;
                f5 = true;
            }

            else
            {
                s7.IsVisible = false;
                f1 = true;
                f2 = true;
                f3 = true;
                f4 = true;
                f5 = true;
            }
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {

            if (f5 == true)
            {
                s4.IsVisible = false;
                s5.IsVisible = false;
                s6.IsVisible = false;
                s7.IsVisible = false;
                s8.IsVisible = true;
                f5 = false;
                f2 = true;
                f3 = true;
                f4 = true;
                f1 = true;
            }

            else
            {
                s8.IsVisible = false;
                f1 = true;
                f2 = true;
                f3 = true;
                f4 = true;
                f5 = true;
            }
        }

    

}
}