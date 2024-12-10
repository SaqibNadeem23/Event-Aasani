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
    public partial class HallsTableView : ContentPage
    {
        public HallsTableView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Halls>();
            var asd = con.Table<Halls>();
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
                    Text = x.HallId.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label);

                Label label6 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.HallName.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label6);
                if (x.HallPic != null)
                { 
                    Label label1 = new Label()
                    {
                        WidthRequest = 150,
                        Text = x.HallPic.ToString(),
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                stackLayout.Children.Add(label1);
                }
                else if(x.HallPic == null)
                {
                    Label label1 = new Label()
                    {
                        WidthRequest = 150,
                        Text = "",
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackLayout.Children.Add(label1);
                }
                Label label2 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.Address.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label2);
                Label label3 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.HallPrice.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label3);
                Label label4 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.HallRating.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label4);
                Label label5 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.HallLong.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label5);

                Label label10 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.HallLang.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label10);
                Label label7 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.TotalRatings.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label7);

                Label label8 = new Label()
                {
                    WidthRequest = 150,
                    Text = x.OverallRatings.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
              stackLayout.Children.Add(label8);

            }
            con.Close();
        }
    }
}