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
    public partial class UserOrder : ContentPage
    {
        int sId, evId;
        string evType;
        public UserOrder(string Uid)
        {
            InitializeComponent();
            sId = Convert.ToInt32(Uid);
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            var nms = con.Query<MarriageEvent>("Select * from MarriageEvent where UserId = ?", sId);
            foreach (var s in nms)
            {
                evId = s.EventId;
                evType = s.EventType;
                if (evType == "Marriage")
                {
                    var fs = new StackLayout()
                    { 
                    Orientation = StackOrientation.Horizontal,
                    Margin = 10,
                    };


                    Image image = new Image()
                    {
                        HeightRequest = 35,
                        WidthRequest = 35,
                        Source = "wedding",
                    };

                    Label flb1 = new Label { 
                    Text = evType,
                       FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                        TextColor = Color.FromHex("#3b2c49"),
                    };

                    Label flb2 = new Label
                    {
                        Text = "Date: " + s.Date,
                        TextColor = Color.FromHex("#3b2c49"),
                    };
                    Label flb3 = new Label
                    {
                        Text = "Bill: " + s.TotalBill,
                        TextColor = Color.FromHex("#3b2c49"),
                    };
                    var fs1 = new StackLayout() 
                   { VerticalOptions  = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 20, 0),
                    };
                    var fs2 = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 50, 0),
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
                    fs3.Children.Add(flb2);
                    fs3.Children.Add(flb3);
                    Frame ff = new Frame();
                    ff.Content = fs;

                    OrderStack.Children.Add(ff);
                    bool k = false;
                    StackLayout stackLayout = new StackLayout()
                    {
                        Margin = new Thickness(50, 0, 0, 0),
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
                        Text = "Event Type: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    };
                    Label label2 = new Label()
                    {
                        Text = s.EventType,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s1.Children.Add(label);
                    s1.Children.Add(label2);

                    StackLayout s2 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s2);

                    Label label3 = new Label()
                    {
                        Text = "Date: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label4 = new Label()
                    {
                        Text = s.Date,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

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
                        Text = "Timing: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label6 = new Label()
                    {
                        Text = s.Timing,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s3.Children.Add(label5);
                    s3.Children.Add(label6);

                    StackLayout s4 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s4);

                    Label label7 = new Label()
                    {
                        Text = "Guests: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label8 = new Label()
                    {
                        Text = s.Guests.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s4.Children.Add(label7);
                    s4.Children.Add(label8);




                    SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
                    con1.CreateTable<mHallBook>();
                    var hbs = con1.Query<mHallBook>("Select * from mHallBook where EventId = ?", evId);
                    foreach (var ss1 in hbs)
                    {
                        StackLayout s5 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s5);

                        Label label9 = new Label()
                        {
                            Text = "Hall: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label10 = new Label()
                        {
                            Text = ss1.Hallname,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s5.Children.Add(label9);
                        s5.Children.Add(label10);

                        StackLayout s6 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s6);

                        Label label11 = new Label()
                        {
                            Text = "Hall Rate: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label12 = new Label()
                        {
                            Text = ss1.Hallrate.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s6.Children.Add(label11);
                        s6.Children.Add(label12);

                    }
                    con1.Close();

                    StackLayout sfood = new StackLayout()
                    {

                    };
                    stackLayout.Children.Add(sfood);

                    SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                    con3.CreateTable<FoodOrder>();
                    var obs = con3.Query<FoodOrder>("Select * from FoodOrder where EventId = ?", evId);
                    string hname;
                    int p;
                    int qu;
                    int fp = 0;
                    foreach (var ss4 in obs)
                    {
                        hname = ss4.ItemName;
                        p = ss4.ItemPrice;
                        qu = ss4.ItemQuantity;
                        fp = p * qu;
                        StackLayout st = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        sfood.Children.Add(st);

                        Label flabel = new Label()
                        {
                            Text = "Food Item: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel1 = new Label()
                        {
                            Text = hname,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st.Children.Add(flabel);
                        st.Children.Add(flabel1);

                        StackLayout st1 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };

                        sfood.Children.Add(st1);

                        Label flabel2 = new Label()
                        {
                            Text = "Food Price ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel3 = new Label()
                        {
                            Text = p.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st1.Children.Add(flabel2);
                        st1.Children.Add(flabel3);

                        StackLayout st2 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };

                        sfood.Children.Add(st2);

                        Label flabel4 = new Label()
                        {
                            Text = "Food Quantity: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel5 = new Label()
                        {
                            Text = qu.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st2.Children.Add(flabel4);
                        st2.Children.Add(flabel5);

                    }

                    SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                    con2.CreateTable<mPhotographerBook>();
                    var pbs = con2.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", evId);
                    foreach (var ss2 in pbs)
                    {
                        StackLayout s8 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s8);

                        Label label15 = new Label()
                        {
                            Text = "Photographer: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label16 = new Label()
                        {
                            Text = ss2.PhotographerName,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s8.Children.Add(label15);
                        s8.Children.Add(label16);

                        StackLayout s9 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s9);

                        Label label17 = new Label()
                        {
                            Text = "Photographer Rate: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label18 = new Label()
                        {
                            Text = ss2.PhotographerPrice.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s9.Children.Add(label17);
                        s9.Children.Add(label18);
                    }

                    con2.Close();

                    SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
                    con4.CreateTable<mDecor>();
                    var dbs = con3.Query<mDecor>("Select * from mDecor where EventId = ?", evId);
                    foreach (var ss3 in dbs)
                    {
                        StackLayout s10 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s10);

                        Label label19 = new Label()
                        {
                            Text = "Decorator Name: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label20 = new Label()
                        {
                            Text = ss3.DecoratorName,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s10.Children.Add(label19);
                        s10.Children.Add(label20);

                        StackLayout s12 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s12);

                        Label label23 = new Label()
                        {
                            Text = "Decorator Price: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label24 = new Label()
                        {
                            Text = ss3.DecoratorPrice.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s12.Children.Add(label23);
                        s12.Children.Add(label24);

                    }
                    StackLayout s11 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s11);


                   
                    Label label21 = new Label()
                    {
                        Text = "Total Bill: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

                    };
                    Label label22 = new Label()
                    {
                        Text = s.TotalBill.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

                    };
                    s11.Children.Add(label21);
                    s11.Children.Add(label22);

                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) > Convert.ToDateTime(s.Date))
                    {
                        StackLayout s13 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s13);
                        Button rb = new Button()
                        {
                            Margin = new Thickness(65, 0, 0, 0),
                            Text = "Give Review",
                            TextColor = Color.FromHex("#b68948"),
                            BackgroundColor = Color.FromHex("#1b1b1b"),
                        };
                        s13.Children.Add(rb);

                        rb.Clicked += Button_Clicked;

                        void Button_Clicked(object sender, EventArgs e)
                        {
                            Navigation.PushAsync(new RatingPage(s.EventId));
                        }
                    }

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

                else if(evType == "Birthday")
                {
                    var fs = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Margin = 10,
                    };
                    Image image = new Image()
                    {
                        HeightRequest = 35,
                        WidthRequest = 35,
                      
                        Source = "birthday",
                    };
                    Label flb1 = new Label
                    {
                        Text = evType,
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),

                    };

                    Label flb2 = new Label
                    {
                        Text = "Date: " + s.Date,
                        TextColor = Color.FromHex("#3b2c49"),
                    };
                    Label flb3 = new Label
                    {
                        Text = "Bill: " + s.TotalBill,
                        TextColor = Color.FromHex("#3b2c49"),
                    };
                    var fs1 = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 20, 0),
                    };
                    var fs2 = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 50, 0),
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
                    fs3.Children.Add(flb2);
                    fs3.Children.Add(flb3);
                    Frame ff = new Frame();
                    ff.Content = fs;
                    OrderStack.Children.Add(ff);
                    bool k = false;
                    StackLayout stackLayout = new StackLayout()
                    {
                        Margin = new Thickness(50, 0, 0, 0),
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
                        Text = "Event Type: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    };
                    Label label2 = new Label()
                    {
                        Text = s.EventType,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s1.Children.Add(label);
                    s1.Children.Add(label2);

                    StackLayout s2 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s2);

                    Label label3 = new Label()
                    {
                        Text = "Date: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label4 = new Label()
                    {
                        Text = s.Date,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

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
                        Text = "Timing: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label6 = new Label()
                    {
                        Text = s.Timing,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s3.Children.Add(label5);
                    s3.Children.Add(label6);

                    StackLayout s4 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s4);

                    Label label7 = new Label()
                    {
                        Text = "Guests: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label8 = new Label()
                    {
                        Text = s.Guests.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s4.Children.Add(label7);
                    s4.Children.Add(label8);

                    StackLayout s5 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s5);

                    Label label9 = new Label()
                    {
                        Text = "Cake Name: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label10 = new Label()
                    {
                        Text = s.CakeName,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s5.Children.Add(label9);
                    s5.Children.Add(label10);

                    StackLayout s6 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s6);

                    Label label11 = new Label()
                    {
                        Text = "Cake Quantity: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label12 = new Label()
                    {
                        Text = s.CakeQuantity.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s6.Children.Add(label11);
                    s6.Children.Add(label12);

                    StackLayout s7 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s7);

                    Label label13 = new Label()
                    {
                        Text = "Cake Price: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label14 = new Label()
                    {
                        Text = s.CakeRate.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s7.Children.Add(label13);
                    s7.Children.Add(label14);

                    StackLayout sfood = new StackLayout()
                    {

                    };
                    stackLayout.Children.Add(sfood);

                    SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                    con3.CreateTable<FoodOrder>();
                    var obs = con3.Query<FoodOrder>("Select * from FoodOrder where EventId = ?", evId);
                    string hname;
                    int p;
                    int qu;
                    int fp = 0;
                    foreach (var ss4 in obs)
                    {
                        hname = ss4.ItemName;
                        p = ss4.ItemPrice;
                        qu = ss4.ItemQuantity;
                        fp = p * qu;
                        StackLayout st = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        sfood.Children.Add(st);

                        Label flabel = new Label()
                        {
                            Text = "Food Item: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel1 = new Label()
                        {
                            Text = hname,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st.Children.Add(flabel);
                        st.Children.Add(flabel1);

                        StackLayout st1 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };

                        sfood.Children.Add(st1);

                        Label flabel2 = new Label()
                        {
                            Text = "Food Price ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel3 = new Label()
                        {
                            Text = p.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st1.Children.Add(flabel2);
                        st1.Children.Add(flabel3);

                        StackLayout st2 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };

                        sfood.Children.Add(st2);

                        Label flabel4 = new Label()
                        {
                            Text = "Food Quantity: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel5 = new Label()
                        {
                            Text = qu.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st2.Children.Add(flabel4);
                        st2.Children.Add(flabel5);

                    }

                    SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                    con2.CreateTable<mPhotographerBook>();
                    var pbs = con2.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", evId);
                    foreach (var ss2 in pbs)
                    {
                        StackLayout s8 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s8);

                        Label label15 = new Label()
                        {
                            Text = "Photographer: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label16 = new Label()
                        {
                            Text = ss2.PhotographerName,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s8.Children.Add(label15);
                        s8.Children.Add(label16);

                        StackLayout s9 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s9);

                        Label label17 = new Label()
                        {
                            Text = "Photographer Rate: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label18 = new Label()
                        {
                            Text = ss2.PhotographerPrice.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s9.Children.Add(label17);
                        s9.Children.Add(label18);

                    }

                    con2.Close();

                    SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
                    con4.CreateTable<mDecor>();
                    var dbs = con3.Query<mDecor>("Select * from mDecor where EventId = ?", evId);
                    foreach (var ss3 in dbs)
                    {
                        StackLayout s13 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s13);

                        Label label25 = new Label()
                        {
                            Text = "Decorator Name: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label26 = new Label()
                        {
                            Text = ss3.DecoratorName,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s13.Children.Add(label25);
                        s13.Children.Add(label26);

                        StackLayout s12 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s12);

                        Label label23 = new Label()
                        {
                            Text = "Decorator Price: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label24 = new Label()
                        {
                            Text = ss3.DecoratorPrice.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s12.Children.Add(label23);
                        s12.Children.Add(label24);

                    }

                    StackLayout s10 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s10);

                    Label label19 = new Label()
                    {
                        Text = "Theme Set : ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label20 = new Label()
                    {

                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s10.Children.Add(label19);
                    s10.Children.Add(label20);

                    StackLayout s11 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s11);

                    Label label21 = new Label()
                    {
                        Text = "Total Bill: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

                    };
                    Label label22 = new Label()
                    {
                        Text = s.TotalBill.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

                    };
                    s11.Children.Add(label21);
                    s11.Children.Add(label22);

                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) > Convert.ToDateTime(s.Date))
                    {
                        StackLayout s13 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s13);
                        Button rb = new Button()
                        {
                            Margin = new Thickness(65, 0, 0, 0),
                            Text = "Give Review",
                            TextColor = Color.FromHex("#b68948"),
                            BackgroundColor = Color.FromHex("#1b1b1b"),

                        };
                        s13.Children.Add(rb);

                        rb.Clicked += Button_Clicked;

                        void Button_Clicked(object sender, EventArgs e)
                        {
                            Navigation.PushAsync(new RatingPage(s.EventId));
                        }
                    }

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

                else if(evType == "Dawat")
                {
                    var fs = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Margin = 10,
                    };
                    Image image = new Image()
                    {
                        HeightRequest = 35,
                        WidthRequest = 35,

                        Source = "dawat",
                    };
                    Label flb1 = new Label
                    {
                        Text = evType,
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),

                    };

                    Label flb2 = new Label
                    {
                        Text = "Date: " + s.Date,
                        TextColor = Color.FromHex("#3b2c49"),
                    };
                    Label flb3 = new Label
                    {
                        Text = "Bill: " + s.TotalBill,
                        TextColor = Color.FromHex("#3b2c49"),
                    };
                    var fs1 = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 20, 0),
                    };
                    var fs2 = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 0, 50, 0),
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
                    fs3.Children.Add(flb2);
                    fs3.Children.Add(flb3);
                    Frame ff = new Frame();
                    ff.Content = fs;
                    OrderStack.Children.Add(ff);
                    bool k = false;
                    StackLayout stackLayout = new StackLayout()
                    {
                        Margin = new Thickness(50, 0, 0, 0),
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
                        Text = "Event Type: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label2 = new Label()
                    {
                        Text = s.EventType,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s1.Children.Add(label);
                    s1.Children.Add(label2);

                    StackLayout s2 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s2);

                    Label label3 = new Label()
                    {
                        Text = "Date: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label4 = new Label()
                    {
                        Text = s.Date,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

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
                        Text = "Timing: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label6 = new Label()
                    {
                        Text = s.Timing,
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s3.Children.Add(label5);
                    s3.Children.Add(label6);

                    StackLayout s4 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s4);

                    Label label7 = new Label()
                    {
                        Text = "Guests: ",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    Label label8 = new Label()
                    {
                        Text = s.Guests.ToString(),
                        TextColor = Color.FromHex("#b68948"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                    };
                    s4.Children.Add(label7);
                    s4.Children.Add(label8);

                    StackLayout s5 = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    stackLayout.Children.Add(s5);

                    SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                    con2.CreateTable<mCatBook>();
                    var hbs = con2.Query<mCatBook>("Select * from mCatBook where EventId = ?", evId);
                    foreach (var ss1 in hbs)
                    {
                        StackLayout s6 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s6);

                        Label label9 = new Label()
                        {
                            Text = "Catering: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label10 = new Label()
                        {
                            Text = ss1.Catname,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        s6.Children.Add(label9);
                        s6.Children.Add(label10);

                        StackLayout s7 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s7);

                        Label label11 = new Label()
                        {
                            Text = "Catering Rate: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };
                        Label label12 = new Label()
                        {
                            Text = ss1.Catrate.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                        };
                        s7.Children.Add(label11);
                        s7.Children.Add(label12);

                    }
                    con2.Close();



                    StackLayout sfood = new StackLayout()
                    {

                    };
                    stackLayout.Children.Add(sfood);

                    SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                    con3.CreateTable<FoodOrder>();
                    var obs = con3.Query<FoodOrder>("Select * from FoodOrder where EventId = ?", evId);
                    string hname;
                    int p;
                    int qu;
                    int fp = 0;
                    foreach (var ss4 in obs)
                    {
                        hname = ss4.ItemName;
                        p = ss4.ItemPrice;
                        qu = ss4.ItemQuantity;
                        fp = p * qu;
                        StackLayout st = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        sfood.Children.Add(st);

                        Label flabel = new Label()
                        {
                            Text = "Food Item: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel1 = new Label()
                        {
                            Text = hname,
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st.Children.Add(flabel);
                        st.Children.Add(flabel1);

                        StackLayout st1 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };

                        sfood.Children.Add(st1);

                        Label flabel2 = new Label()
                        {
                            Text = "Food Price ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel3 = new Label()
                        {
                            Text = p.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st1.Children.Add(flabel2);
                        st1.Children.Add(flabel3);

                        StackLayout st2 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };

                        sfood.Children.Add(st2);

                        Label flabel4 = new Label()
                        {
                            Text = "Food Quantity: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        Label flabel5 = new Label()
                        {
                            Text = qu.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

                        };

                        st2.Children.Add(flabel4);
                        st2.Children.Add(flabel5);

                        StackLayout s11 = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        stackLayout.Children.Add(s11);

                        Label label21 = new Label()
                        {
                            Text = "Total Bill: ",
                            TextColor = Color.FromHex("#3b2c49"),
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

                        };
                        Label label22 = new Label()
                        {
                            Text = s.TotalBill.ToString(),
                            TextColor = Color.FromHex("#b68948"),
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

                        };
                        s11.Children.Add(label21);
                        s11.Children.Add(label22);

                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) > Convert.ToDateTime(s.Date))
                        {
                            StackLayout s13 = new StackLayout()
                            {
                                Orientation = StackOrientation.Horizontal,
                            };
                            stackLayout.Children.Add(s13);
                            Button rb = new Button()
                            {
                                Margin = new Thickness(65, 0, 0, 0),
                                Text = "Give Review",
                                TextColor = Color.FromHex("#b68948"),
                                BackgroundColor = Color.FromHex("#1b1b1b"),
                            };
                            s13.Children.Add(rb);

                            rb.Clicked += Button_Clicked;

                            void Button_Clicked(object sender, EventArgs e)
                            {
                                Navigation.PushAsync(new RatingPage(s.EventId));
                            }
                        }

                        
                    }

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
            }



            con.Close();

        }

            
        }
    }
