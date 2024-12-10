using EVmain.Model;
using SQLite;
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
    public partial class MarriageEventTableView : ContentPage
    {
        public MarriageEventTableView()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            var asd = con.Table<MarriageEvent>();
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
                    Text = x.UserId.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label6);

                Label label1 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.Date.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label1);
                Label label2 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.Guests.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label2);
                Label label3 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.Timing.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label3);
                Label label4 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.EventType.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label4);
                if (x.CakeName != null)
                { 
                Label label5 = new Label()
                {
                    WidthRequest = 150,                
                    Text = x.CakeName.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label5);
                }
                if (x.CakeName == null)
                {
                    Label label5 = new Label()
                    {
                        WidthRequest = 150,
                        Text = "",
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackLayout.Children.Add(label5);
                }
                if (x.CakeQuantity != null)
                {
                    Label label10 = new Label()
                    {
                        WidthRequest = 150,
                        Text = x.CakeQuantity.ToString(),
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackLayout.Children.Add(label10);
                }
                if (x.CakeRate != null)
                {
                    Label label7 = new Label()
                    {
                        WidthRequest = 150,
                        Text = x.CakeRate.ToString(),
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackLayout.Children.Add(label7);
                }

                if (x.Location != null)
                {
                    Label label8 = new Label()
                    {
                        WidthRequest = 150,
                        Text = x.Location.ToString(),
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackLayout.Children.Add(label8);
                }
                if (x.Location == null)
                {
                    Label label8 = new Label()
                    {
                        WidthRequest = 150,
                        Text = "",
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackLayout.Children.Add(label8);
                }
                Label label9 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.TotalBill.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label9);

            }
            con.Close();
        }
    }
}