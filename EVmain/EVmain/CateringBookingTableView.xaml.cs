﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVmain.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CateringBookingTableView : ContentPage
    {
        public CateringBookingTableView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<mCatBook>();
            var asd = con.Table<mCatBook>();
            foreach (var x in asd)
            {
                StackLayout stackLayout = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,

                };

                MS.Children.Add(stackLayout);
                Label label = new Label()
                {
                    WidthRequest = 150,
                    Text = x.EventId.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label);

                Label label6 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.CatId.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label6);

                Label label1 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.Catname.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label1);
                Label label2 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.Catrate.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label2);

            }
            con.Close();
        }
    }
}