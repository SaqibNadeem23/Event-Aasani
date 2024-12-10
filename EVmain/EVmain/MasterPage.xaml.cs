using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
       
        string SId, SName, SEmail, SPhone, SPass;

        
        public MasterPage(string UId, string UName, string UPhone, string UEmail, string UPass)
        {
            
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            
            SId = UId;
            SName = UName;
            SEmail = UEmail;
            SPhone = UPhone;
            SPass = UPass;

            lb2.Text = SName;

            lb1.Text = SName.Substring(0, 1).ToUpper();

            s1.IsVisible = false;
            s2.IsVisible = false;
            s3.IsVisible = false;

                    }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserInfo(SId, SName, SEmail, SPhone, SPass));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserOrder(SId));
        }




        private bool x1 = true;
        private bool x2 = true;
        private bool x3 = true;

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
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

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (x2 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = true;
                s3.IsVisible = false;
                x1 = true;
                x2 = false;
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

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (x3 == true)
            {
                s1.IsVisible = false;
                s2.IsVisible = false;
                s3.IsVisible = true;
                x1 = true;
                x2 = true;
                x3 = false;
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
            string s = "Marriage";
            Navigation.PushAsync(new WeddingPage(SId, s));
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            string s = "Birthday";
            Navigation.PushAsync(new BirthdayEvent(SId, s));
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            string s = "Dawat";
            Navigation.PushAsync(new DawatEvent(SId, s));
        }




    }
}