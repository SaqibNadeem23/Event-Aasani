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
    public partial class CakeSelect : ContentPage
    {
        public CakeSelect()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var imgs = new List<string>
           {
               "ck1.jpg","ck2.jpg","ck3.jpg","ck4.jpg","ck5.jpg","ck6.jpg","ck7.jpg","ck8.jpg","ck9.jpg","ck10.jpg","ck11.jpg","ck12.jpg"
           };

            MainCarouselView.ItemsSource = imgs;
            
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
        }

             bool x = true;
        private void btn1_Clicked(object sender, EventArgs e)
        {
            
            if(x == true)
            {
                btn1.Text = "Unselect";
            MainCarouselView.IsSwipeEnabled = false;
                x = false;
            }
            else
            {
                btn1.Text = "Select";
                MainCarouselView.IsSwipeEnabled = true;
                x = true;
            }
        }
        }
        }
    