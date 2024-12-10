﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DecoratorMainPage : ContentPage
    {
        string SId, SName, SEmail, SPhone, SPass;
        public DecoratorMainPage(string UId, string UName, string UPhone, string UEmail, string UPass)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            SId = UId;
            SName = UName;
            SEmail = UEmail;
            SPhone = UPhone;
            SPass = UPass;

            lb2.Text = SName;
            lb1.Text = SName.Substring(0, 1);
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
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PartnerGallery(Convert.ToInt32(SId)));

        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PartnerDecoratorOrder(SId));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PartnerDecorator(Convert.ToInt32(SId)));
        }

    }
}