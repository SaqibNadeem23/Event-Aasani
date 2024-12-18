﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EVmain
{
    public partial class App : Application
    {


        public static string Databaselocation = string.Empty;
        public App(string databaselocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            Databaselocation = databaselocation;
        }

        public App()
        {
            InitializeComponent();

           MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
