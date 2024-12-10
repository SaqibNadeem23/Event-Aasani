using EVmain.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaavorRatingConception;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPage : ContentPage
    {
        string evtype;
        int evID, userID;

        public RatingPage(int evId)
        {
            InitializeComponent();
            evID = evId;
            Label label = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "Give Ratings on the Following",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.FromHex("1b1b1b"),
                Margin = new Thickness(10, 0, 0, 30)

            };
            rStack.Children.Add(label);


            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            var nms = con.Query<MarriageEvent>("Select * from MarriageEvent where EventId = ?", evID);

            foreach (var x in nms)
            {
                evtype = x.EventType;
                userID = x.UserId;
            }

            if (evtype == "Marriage")
            {
                string hName = "", pName = "", dName = "";
                int HallID = 0, PhotoID = 0, DecorID = 0;
                SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
                con1.CreateTable<mHallBook>();
                var nms1 = con.Query<mHallBook>("Select * from mHallBook where EventId = ?", evID);
                foreach (var x in nms1)
                {
                    hName = x.Hallname;
                    HallID = x.HallId;
                }

                StackLayout stackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                rStack.Children.Add(stackLayout);

                Label label1 = new Label()
                {
                    Text = hName,
                    TextColor = Color.FromHex("b68948"),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    ColorUI = ColorUI.OrangeLight,
                    ImageHeight = 40,
                    ImageWidth = 40,
                    ItemsNumber = 5,
                    DesignType = DesignType.Standard,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 20)
                };

                stackLayout.Children.Add(label1);
                stackLayout.Children.Add(ratingConception);
                con1.Close();

                SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                con2.CreateTable<mPhotographerBook>();
                var nms2 = con.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", evID);
                foreach (var x in nms2)
                {
                    pName = x.PhotographerName;
                    PhotoID = x.PId;
                }


                StackLayout stackLayout1 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                rStack.Children.Add(stackLayout1);

                Label label2 = new Label()
                {
                    TextColor = Color.FromHex("b68948"),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    Text = pName,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                RatingConception ratingConception2 = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    ColorUI = ColorUI.OrangeLight,
                    ImageHeight = 40,
                    ImageWidth = 40,
                    ItemsNumber = 5,
                    DesignType = DesignType.Standard,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 20)
                };

                stackLayout1.Children.Add(label2);
                stackLayout1.Children.Add(ratingConception2);

                if (pName == "None")
                {
                    stackLayout1.IsVisible = false;
                }
                con2.Close();

                SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                con3.CreateTable<mDecor>();
                var nms3 = con.Query<mDecor>("Select * from mDecor where EventId = ?", evID);
                foreach (var x in nms3)
                {
                    dName = x.DecoratorName;
                    DecorID = x.DId;
                }

                StackLayout stackLayout2 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                rStack.Children.Add(stackLayout2);

                Label label3 = new Label()
                {
                    TextColor = Color.FromHex("b68948"),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    Text = dName,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                RatingConception ratingConception3 = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    ColorUI = ColorUI.OrangeLight,
                    ImageHeight = 40,
                    ImageWidth = 40,
                    ItemsNumber = 5,
                    DesignType = DesignType.Standard,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 20)
                };

                stackLayout2.Children.Add(label3);
                stackLayout2.Children.Add(ratingConception3);
                con3.Close();

                StackLayout b = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };


                rStack.Children.Add(b);
                SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
                con4.CreateTable<Ratings>();
                var nms4 = con4.Query<Ratings>("Select Rating from Ratings where EventId = ? and UserId=? and PartnerId = ?", evID, userID, HallID);
                foreach (var x in nms4)
                {
                    ratingConception.InitialValue = x.Rating;
                }

                nms4 = con4.Query<Ratings>("Select Rating from Ratings where EventId = ? and UserId=? and PartnerId = ?", evID, userID, PhotoID);
                foreach (var x in nms4)
                {
                    ratingConception2.InitialValue = x.Rating;
                }

                nms4 = con4.Query<Ratings>("Select Rating from Ratings where EventId = ? and UserId=? and PartnerId = ?", evID, userID, DecorID);
                foreach (var x in nms4)
                {
                    ratingConception3.InitialValue = x.Rating;
                }

                Button button = new Button()
                {
                    Text = "Submit",
                    TextColor = Color.FromHex("b68948"),
                    BackgroundColor = Color.FromHex("1b1b1b"),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };
                b.Children.Add(button);
                button.Clicked += Button_Clicked;

                void Button_Clicked(object sender, EventArgs e)
                {
                    bool aa = true, bb = true, cc = true;
                    string err = "";
                    if (ratingConception.Value == 0 && ratingConception.InitialValue == 0)
                    {
                        aa = false;
                        err += hName + "\n";
                    }
                    if (pName != "None")
                    {
                        if (ratingConception2.Value == 0 && ratingConception2.InitialValue == 0)
                        {
                            bb = false;
                            err += pName + "\n";
                        }
                    }
                    if (ratingConception3.Value == 0 && ratingConception3.InitialValue == 0)
                    {
                        cc = false;
                        err += dName + "\n";
                    }



                    if (aa == true && bb == true && cc == true)
                    {
                        int HTR = 0, PTR = 0, DTR = 0, HOR = 0, POR = 0, DOR = 0;
                        double HR = 0, PR = 0, DR = 0;
                        SQLiteConnection conx = new SQLiteConnection(App.Databaselocation);
                        conx.CreateTable<Halls>();
                        var nmsx = conx.Query<Halls>("Select * from Halls where HallId = ?", HallID);

                        foreach (var x in nmsx)
                        {
                            if (ratingConception.InitialValue == 0)
                            {
                                HTR = x.TotalRatings + 1;
                                HOR = x.OverallRatings + ratingConception.Value;
                                HR = (x.TotalRatings * HOR + ratingConception.Value) / (HTR);
                                HR = Math.Round(HR);
                            }
                            else
                            {
                                HTR = x.TotalRatings;
                                int i;
                                i = ratingConception.Value - ratingConception.InitialValue;
                                HR = ((x.TotalRatings * (HOR + i)) + ratingConception.Value) / (HTR);
                                HR = Math.Round(HR);
                            }
                        }
                        conx.Query<Halls>("Update Halls set TotalRatings = ?,HallRating=?,OverallRatings = ? where HallId = ?", HTR, HR, HOR, HallID);

                        Ratings ratings1 = new Ratings()
                        {
                            UserId = userID,
                            EventId = evID,
                            PartnerId = HallID,
                            Rating = ratingConception.Value,
                        };
                        SQLiteConnection conn1 = new SQLiteConnection(App.Databaselocation);
                        conn1.CreateTable<Ratings>();
                        conn1.Insert(ratings1);
                        conn1.Close();

                        if (pName != "None")
                        {
                            SQLiteConnection conx1 = new SQLiteConnection(App.Databaselocation);
                            conx1.CreateTable<photogr>();
                            var nmsx1 = con.Query<photogr>("Select * from photogr where PhotographerId = ?", PhotoID);
                            foreach (var x in nmsx1)
                            {
                                if (ratingConception2.InitialValue == 0)
                                {
                                    PTR = x.TotalRatings + 1;
                                    POR = x.OverallRatings + ratingConception2.Value;
                                    PR = ((x.TotalRatings * POR) + ratingConception2.Value) / PTR;
                                    PR = Math.Round(PR);
                                }
                                else
                                {
                                    PTR = x.TotalRatings;
                                    int i;
                                    i = ratingConception2.Value - ratingConception2.InitialValue;
                                    PR = ((x.TotalRatings * (POR + i)) + ratingConception2.Value) / PTR;
                                    PR = Math.Round(PR);
                                }

                            }

                            conx1.Query<photogr>("Update photogr set TotalRatings = ?,PhotographerRating=?,OverallRatings = ? where PhotographerId = ?", PTR, PR, PhotoID, POR);

                            Ratings ratings2 = new Ratings()
                            {
                                UserId = userID,
                                EventId = evID,
                                PartnerId = PhotoID,
                                Rating = ratingConception2.Value,
                            };
                            SQLiteConnection conn2 = new SQLiteConnection(App.Databaselocation);
                            conn2.CreateTable<Ratings>();
                            conn2.Insert(ratings2);
                            conn2.Close();
                        }
                        SQLiteConnection conx2 = new SQLiteConnection(App.Databaselocation);
                        conx2.CreateTable<Decorator>();
                        var nmsx2 = con.Query<Decorator>("Select * from Decorator where DecoratorId = ?", DecorID);
                        foreach (var x in nmsx2)
                        {
                            if (ratingConception3.InitialValue == 0)
                            {
                                DTR = x.TotalRatings + 1;
                                DOR = x.OverallRatings + ratingConception3.Value;
                                DR = ((x.TotalRatings * DOR) + ratingConception3.Value) / DTR;
                                DR = Math.Round(DR);
                            }
                            else
                            {
                                DTR = x.TotalRatings;
                                int i;
                                i = ratingConception3.Value - ratingConception3.InitialValue;
                                DR = ((x.TotalRatings * (DOR + i)) + ratingConception3.Value) / DTR;
                                DR = Math.Round(DR);
                            }
                            conx2.Query<Decorator>("Update Decorator set TotalRatings = ?,DecoratorRating=?,OverallRatings = ? where DecoratorId = ?", DTR, DR, DecorID, DOR);

                            Ratings ratings3 = new Ratings()
                            {
                                UserId = userID,
                                EventId = evID,
                                PartnerId = DecorID,
                                Rating = ratingConception3.Value,
                            };
                            SQLiteConnection conn3 = new SQLiteConnection(App.Databaselocation);
                            conn3.CreateTable<Ratings>();
                            conn3.Insert(ratings3);
                            conn3.Close();

                            DisplayAlert("Success!", "Event Reviewed Successfully", "Ok");
                            Navigation.PopAsync();

                        }
                    }

                    else
                    {
                        DisplayAlert("Please Rate the following", err, "Ok");
                    }

                }

            }

            else if (evtype == "Birthday")
            {
                int PhotoID = 0, DecorID = 0;
                string pName = "", dName = "";
                SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                con2.CreateTable<mPhotographerBook>();
                var nms2 = con.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", evID);
                foreach (var x in nms2)
                {
                    pName = x.PhotographerName;
                    PhotoID = x.PId;
                }

                StackLayout stackLayout1 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                rStack.Children.Add(stackLayout1);

                Label label2 = new Label()
                {
                    Text = pName,
                    TextColor = Color.FromHex("b68948"),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                RatingConception ratingConception2 = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    ColorUI = ColorUI.OrangeLight,
                    ImageHeight = 40,
                    ImageWidth = 40,
                    ItemsNumber = 5,
                    DesignType = DesignType.Standard,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 20)
                };

                stackLayout1.Children.Add(label2);
                stackLayout1.Children.Add(ratingConception2);

                if (pName == "None")
                {
                    stackLayout1.IsVisible = false;
                }
                con2.Close();

                SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                con3.CreateTable<mDecor>();
                var nms3 = con.Query<mDecor>("Select * from mDecor where EventId = ?", evID);
                foreach (var x in nms3)
                {
                    dName = x.DecoratorName;
                    DecorID = x.DId;
                }

                StackLayout stackLayout2 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                rStack.Children.Add(stackLayout2);

                Label label3 = new Label()
                {
                    Text = dName,
                    TextColor = Color.FromHex("b68948"),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                RatingConception ratingConception3 = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    ColorUI = ColorUI.OrangeLight,
                    ImageHeight = 40,
                    ImageWidth = 40,
                    ItemsNumber = 5,
                    DesignType = DesignType.Standard,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 20)
                };

                stackLayout2.Children.Add(label3);
                stackLayout2.Children.Add(ratingConception3);
                con3.Close();

                StackLayout b = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };


                rStack.Children.Add(b);

                Button button = new Button()
                {
                    Text = "Submit",
                    TextColor = Color.FromHex("b68948"),
                    BackgroundColor = Color.FromHex("1b1b1b"),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                b.Children.Add(button);
                button.Clicked += Button_Clicked;

                void Button_Clicked(object sender, EventArgs e)
                {
                    bool bb = true, cc = true;
                    string err = "";

                    if (pName != "None")
                    {
                        if (ratingConception2.Value == 0 && ratingConception2.InitialValue == 0)
                        {
                            bb = false;
                            err += pName + "\n";
                        }
                    }
                    if (ratingConception3.Value == 0 && ratingConception3.InitialValue == 0)
                    {
                        cc = false;
                        err += dName + "\n";
                    }

                    if (bb == true && cc == true)
                    {
                        int  PTR = 0, DTR = 0, POR = 0, DOR = 0;
                        double PR = 0, DR = 0;
                        if (pName != "None")
                        {
                            SQLiteConnection conx1 = new SQLiteConnection(App.Databaselocation);
                            conx1.CreateTable<photogr>();
                            var nmsx1 = con.Query<photogr>("Select * from photogr where PhotographerId = ?", PhotoID);
                            foreach (var x in nmsx1)
                            {
                                if (ratingConception2.InitialValue == 0)
                                {
                                    PTR = x.TotalRatings + 1;
                                    POR = x.OverallRatings + ratingConception2.Value;
                                    PR = ((x.TotalRatings * POR) + ratingConception2.Value) / PTR;
                                    PR = Math.Round(PR);
                                }
                                else
                                {
                                    PTR = x.TotalRatings;
                                    int i;
                                    i = ratingConception2.Value - ratingConception2.InitialValue;
                                    PR = ((x.TotalRatings * (POR + i)) + ratingConception2.Value) / PTR;
                                    PR = Math.Round(PR);
                                }

                            }

                            conx1.Query<photogr>("Update photogr set TotalRatings = ?,PhotographerRating=?,OverallRatings = ? where PhotographerId = ?", PTR, PR, PhotoID, POR);

                            Ratings ratings2 = new Ratings()
                            {
                                UserId = userID,
                                EventId = evID,
                                PartnerId = PhotoID,
                                Rating = ratingConception2.Value,
                            };
                            SQLiteConnection conn2 = new SQLiteConnection(App.Databaselocation);
                            conn2.CreateTable<Ratings>();
                            conn2.Insert(ratings2);
                            conn2.Close();
                        }
                        SQLiteConnection conx2 = new SQLiteConnection(App.Databaselocation);
                        conx2.CreateTable<Decorator>();
                        var nmsx2 = con.Query<Decorator>("Select * from Decorator where DecoratorId = ?", DecorID);
                        foreach (var x in nmsx2)
                        {
                            if (ratingConception3.InitialValue == 0)
                            {
                                DTR = x.TotalRatings + 1;
                                DOR = x.OverallRatings + ratingConception3.Value;
                                DR = ((x.TotalRatings * DOR) + ratingConception3.Value) / DTR;
                                DR = Math.Round(DR);
                            }
                            else
                            {
                                DTR = x.TotalRatings;
                                int i;
                                i = ratingConception3.Value - ratingConception3.InitialValue;
                                DR = ((x.TotalRatings * (DOR + i)) + ratingConception3.Value) / DTR;
                                DR = Math.Round(DR);
                            }
                            conx2.Query<Decorator>("Update Decorator set TotalRatings = ?,DecoratorRating=?,OverallRatings = ? where DecoratorId = ?", DTR, DR, DecorID, DOR);

                            Ratings ratings3 = new Ratings()
                            {
                                UserId = userID,
                                EventId = evID,
                                PartnerId = DecorID,
                                Rating = ratingConception3.Value,
                            };
                            SQLiteConnection conn3 = new SQLiteConnection(App.Databaselocation);
                            conn3.CreateTable<Ratings>();
                            conn3.Insert(ratings3);
                            conn3.Close();

                            DisplayAlert("Success!", "Event Reviewed Successfully", "Ok");
                            Navigation.PopAsync();
                        }
                    }

                    else
                    {
                        DisplayAlert("Please Rate the following", err, "Ok");
                    }
                }
            }

            else if (evtype == "Dawat")
            {
                string cName = "";
                int CId = 0;
                SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                con3.CreateTable<mCatBook>();
                var nms3 = con.Query<mCatBook>("Select * from mCatBook where EventId = ?", evID);
                foreach (var x in nms3)
                {
                    cName = x.Catname;
                    CId = x.CatId;
                }

                StackLayout stackLayout2 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };
                rStack.Children.Add(stackLayout2);

                Label label3 = new Label()
                {
                    Text = cName,
                    TextColor = Color.FromHex("b68948"),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                RatingConception ratingConception3 = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    ColorUI = ColorUI.OrangeLight,
                    ImageHeight = 40,
                    ImageWidth = 40,
                    ItemsNumber = 5,
                    DesignType = DesignType.Standard,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 20)
                };

                stackLayout2.Children.Add(label3);
                stackLayout2.Children.Add(ratingConception3);
                con3.Close();

                StackLayout b = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };


                rStack.Children.Add(b);

                Button button = new Button()
                {
                    Text = "Submit",
                    TextColor = Color.FromHex("b68948"),
                    BackgroundColor = Color.FromHex("1b1b1b"),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,

                };

                b.Children.Add(button);

                button.Clicked += Button_Clicked;

                void Button_Clicked(object sender, EventArgs e)
                {
                    bool cc = true;
                    string err = "";


                    if (ratingConception3.Value == 0 && ratingConception3.InitialValue == 0)
                    {
                        cc = false;
                        err += cName + "\n";
                    }

                    if (cc == true)
                    {
                        int DTR = 0, DOR = 0; double DR = 0;
                        SQLiteConnection conx2 = new SQLiteConnection(App.Databaselocation);
                        conx2.CreateTable<Catering>();
                        var nmsx2 = con.Query<Catering>("Select * from Catering where CatId = ?", CId);
                        foreach (var x in nmsx2)
                        {
                            if (ratingConception3.InitialValue == 0)
                            {
                                DTR = x.TotalRatings + 1;
                                DOR = x.OverallRatings + ratingConception3.Value;
                                DR = ((x.TotalRatings * DOR) + ratingConception3.Value) / DTR;
                                DR = Math.Round(DR);
                            }
                            else
                            {
                                DTR = x.TotalRatings;
                                int i;
                                i = ratingConception3.Value - ratingConception3.InitialValue;
                                DR = ((x.TotalRatings * (DOR + i)) + ratingConception3.Value) / DTR;
                                DR = Math.Round(DR);
                            }
                            conx2.Query<Decorator>("Update Catering set TotalRatings = ?,CatRating=?,OverallRatings = ? where CatId = ?", DTR, DR, CId, DOR);

                            Ratings ratings3 = new Ratings()
                            {
                                UserId = userID,
                                EventId = evID,
                                PartnerId = CId,
                                Rating = ratingConception3.Value,
                            };
                            SQLiteConnection conn3 = new SQLiteConnection(App.Databaselocation);
                            conn3.CreateTable<Ratings>();
                            conn3.Insert(ratings3);
                            conn3.Close();

                            DisplayAlert("Success!", "Event Reviewed Successfully", "Ok");
                            Navigation.PopAsync();
                        }
                    }
                    else
                    {
                        DisplayAlert("Please Rate the following", err, "Ok");
                    }


                }
            }
        }


    }
}















    /* 
  

    */
