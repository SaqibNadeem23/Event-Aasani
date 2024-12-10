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
    public partial class PartnerCateringOrder : ContentPage
    {
        int pid;
        int evid, userid;
        string evdate, username, evtiming, usernum, evlocation;
        public PartnerCateringOrder(string SId)
        {
            InitializeComponent();

            pid = Convert.ToInt32(SId);


            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<mCatBook>();
            var nms = con.Query<mCatBook>("Select * from mCatBook where CatId = ?", pid);
            foreach (var s in nms)
            {
                evid = s.EventId;

                SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
                con1.CreateTable<MarriageEvent>();
                var nms1 = con1.Query<MarriageEvent>("Select * from MarriageEvent where EventId = ?", evid);
                foreach (var ss in nms1)
                {
                    userid = ss.UserId;
                    evdate = ss.Date;
                    evtiming = ss.Timing;
                    evlocation = ss.Location;
                }
                con1.Close();
                SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                con2.CreateTable<Users>();
                var nms2 = con.Query<Users>("Select * from Users where UserId = ?", userid);
                foreach (var sss in nms2)
                {
                    username = sss.UserName;
                    usernum = sss.PhoneNumber;
                }


                var fs = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = 10,
                };
                Image image = new Image()
                {
                    HeightRequest = 35,
                    WidthRequest = 35,

                    Source = "user",
                };
                Label flb1 = new Label
                {
                    Text = username,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.FromHex("#3b2c49"),

                };
                Label flb2 = new Label
                {
                    TextColor = Color.FromHex("#3b2c49"),
                    Text = "Date: " + evdate,
                };

                Label flb3 = new Label
                {
                    Text = "Rate: " + s.Catrate,
                    TextColor = Color.FromHex("#3b2c49"),
                };
                var fs1 = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 0, 15, 0),
                };
                var fs2 = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 0, 30, 0),
                };
                var fs3 = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                };
                fs.Children.Add(fs1);
                fs.Children.Add(fs2);
                fs.Children.Add(fs3);
                fs1.Children.Add(image);
                fs2.Children.Add(flb1);
                fs2.Children.Add(flb2);
                fs3.Children.Add(flb3);
                Frame ff = new Frame();
                ff.Content = fs;


                OrderStack.Children.Add(ff);
                bool k = false;
                StackLayout stackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    IsVisible = false,
                };
                OrderStack.Children.Add(stackLayout);



                StackLayout s1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayout.Children.Add(s1);

                Label label = new Label()
                {
                    Text = "Username: ",
                    TextColor = Color.FromHex("#3b2c49"),
                };
                Label label2 = new Label()
                {
                    Text = username,
                    TextColor = Color.FromHex("#b68948"),
                };
                s1.Children.Add(label);
                s1.Children.Add(label2);

                StackLayout s5 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayout.Children.Add(s5);

                Label label9 = new Label()
                {
                    Text = "User Phone Number: ",
                    TextColor = Color.FromHex("#3b2c49"),
                };
                Label label10 = new Label()
                {
                    Text = usernum,
                    TextColor = Color.FromHex("#b68948"),
                };
                s5.Children.Add(label9);
                s5.Children.Add(label10);


                StackLayout s2 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayout.Children.Add(s2);

                Label label3 = new Label()
                {
                    Text = "Date: ",
                    TextColor = Color.FromHex("#3b2c49"),
                };
                Label label4 = new Label()
                {
                    Text = evdate,
                    TextColor = Color.FromHex("#b68948"),
                };
                s2.Children.Add(label3);
                s2.Children.Add(label4);


                StackLayout s3 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayout.Children.Add(s3);

                Label label5 = new Label()
                {
                    Text = "Timing ",
                    TextColor = Color.FromHex("#3b2c49"),
                };
                Label label6 = new Label()
                {
                    Text = evtiming,
                    TextColor = Color.FromHex("#b68948"),
                };
                s3.Children.Add(label5);
                s3.Children.Add(label6);

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayout.Children.Add(s31);

                Label label51 = new Label()
                {
                    Text = "Location: ",
                    TextColor = Color.FromHex("#3b2c49"),
                };
                Label label61 = new Label()
                {
                    Text = evlocation,
                    TextColor = Color.FromHex("#b68948"),
                };
                s31.Children.Add(label51);
                s31.Children.Add(label61);

                StackLayout s4 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayout.Children.Add(s4);

                Label label7 = new Label()
                {
                    Text = "Rate ",
                    TextColor = Color.FromHex("#3b2c49"),
                };
                Label label8 = new Label()
                {
                    Text = s.Catrate.ToString(),
                    TextColor = Color.FromHex("#b68948"),
                };
                s4.Children.Add(label7);
                s4.Children.Add(label8);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);

                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (k == false)
                    {
                        stackLayout.IsVisible = true;
                        k = true;
                    }
                    else if (k == true)
                    {
                        stackLayout.IsVisible = false;
                        k = false;
                    }
                }
            }
            con.Close();

        }
    }
}