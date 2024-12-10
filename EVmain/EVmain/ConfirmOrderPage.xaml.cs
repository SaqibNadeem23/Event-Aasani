using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using EVmain.Model;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmOrderPage : ContentPage
    {
        string sid;
        public ConfirmOrderPage(string userId, int EventId)
        {
            sid = userId;
            InitializeComponent();
            int totalbill = 0;
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            var nms = con.Query<MarriageEvent>("Select * from MarriageEvent where EventId = ?", EventId);
            foreach(var s in nms)
            {
                olb1.Text = s.EventType;
                olb2.Text = s.Date;
                olb3.Text = s.Timing;
                olb4.Text = s.Guests.ToString();
            }
            con.Close();

            SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
            con1.CreateTable<mHallBook>();
            var hbs = con1.Query<mHallBook>("Select * from mHallBook where EventId = ?", EventId);
            foreach (var s in hbs)
            {
                olb5.Text = s.Hallname;
                olb6.Text = s.Hallrate.ToString();
                totalbill += s.Hallrate;
            }
            con1.Close();

            SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
            con2.CreateTable<mPhotographerBook>();
            var pbs = con2.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", EventId);
            foreach (var s in pbs)
            {
                olb7.Text = s.PhotographerName;
                olb8.Text = s.PhotographerPrice.ToString();
                totalbill += s.PhotographerPrice;
            }

            con2.Close();

            SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);

            con3.CreateTable<FoodOrder>();
            var obs = con3.Query<FoodOrder>("Select * from FoodOrder where EventId = ?", EventId);
            string hname;
            int p;
            int qu;
            int fp = 0;
            foreach (var s in obs)
            {
                hname = s.ItemName;
                p = s.ItemPrice;
                qu = s.ItemQuantity;
                fp = p * qu;
                StackLayout st = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                oFoodStack.Children.Add(st);

                Label label = new Label()
                {
                    Text = "Food Item: ",
                };

                 Label label1 = new Label()
                 {
                    Text = hname
                 };

                st.Children.Add(label);
                st.Children.Add(label1);

                StackLayout st1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                oFoodStack.Children.Add(st1);

                Label label2 = new Label()
                {
                    Text = "Food Price ",
                };

                Label label3 = new Label()
                {
                    Text = p.ToString(),
                };

                st1.Children.Add(label2);
                st1.Children.Add(label3);

                StackLayout st2 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                oFoodStack.Children.Add(st2);

                Label label4 = new Label()
                {
                    Text = "Food Quantity: ",
                };

                Label label5 = new Label()
                {
                    Text = qu.ToString(),
                };

                st2.Children.Add(label4);
                st2.Children.Add(label5);


                StackLayout st3 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                oFoodStack.Children.Add(st2);

                Label label6 = new Label()
                {
                    Text = "Food Price: ",
                };

                Label label7 = new Label()
                {
                    Text = fp.ToString(),
                };

                st2.Children.Add(label4);
                st2.Children.Add(label5);


                totalbill += Convert.ToInt32(p) * Convert.ToInt32(s.ItemQuantity);
            }

            olb9.Text = totalbill.ToString();


        }

        string a, d, f, g, h;
        private void oButton_Clicked(object sender, EventArgs e)
        {
           
            SQLiteConnection con5 = new SQLiteConnection(App.Databaselocation);
            con5.CreateTable<Users>();
            var nms = con5.Query<Users>("Select * from Users where UserId = ?", sid);
            foreach (var s in nms)
            {
                a = s.UserId.ToString();
                d = s.UserName;
                f = s.Email;
                g = s.PhoneNumber;
                h = s.Password;
            }
            Navigation.PushAsync(new MasterPage(a, d, f, g, h));
        }

        private void oButton_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}