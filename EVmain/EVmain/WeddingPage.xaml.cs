using EVmain.Model;
using LaavorRatingConception;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeddingPage : ContentPage
    {

        public int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0;
        public string sn = "lunch.json";
        double totalbill = 0.0;
        string Hnm = "", Hpr = "";
        string hid = "", pid = "", fid, dId= "";
        string sid, evtype;
        List<string> fname = new List<string>();
        List<int> frate = new List<int>();
        List<int> fquan = new List<int>();
        string[] fn = new string[100];
        int[] fr = new int[100];
        int[] fq = new int[100];
        string sphoto = "None", dphoto = "";
        int prate = 0;
        int drate = 0, evId = 0;

        int[] Hid = new int[100];
        string[] Hname = new string[100];
        string[] Hpic = new string[100];
        string[] Haddress = new string[100];
        int[] Hprice = new int[100];
        int[] Hrating = new int[100];
        double[] Hlong = new double[100];
        double[] Hlang = new double[100];

        int[] Fid = new int[100];
        string[] FoodName = new string[100];
        string[] FoodPic = new string[100];
        int[] FoodPrice = new int[100];

        int[] Pid = new int[100];
        string[] pName = new string[100];
        string[] pPic = new string[100];
        int[] pRating = new int[100];
        int[] pPrice = new int[100];
        byte[] imagearray;

        int[] Did = new int[100];
        string[] dName = new string[100];
        string[] dPic = new string[100];
        int[] dRating = new int[100];
        int[] dPrice = new int[100];
        byte[] imgarray;

        public WeddingPage(string userID, string EventType)
        {
            InitializeComponent();
            evtype = EventType;
            sid = userID;
            d1.MinimumDate = DateTime.Now.AddDays(3);

            bl1.IsVisible = true;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            WeddingInfo.IsVisible = true;
            HallBooking.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;



            sn = "timing.json";
            PopupNavigation.Instance.PushAsync(new Page1(sn)); c1++;

            Label lab = new Label()
            {
                Text = "Select Hall",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 30,
                TextColor = Color.WhiteSmoke,
            };
            HallBooking.Children.Add(lab);

            Label lb = new Label()
            {
                Text = "Select a Photograher(Optional)",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 30,
                TextColor = Color.WhiteSmoke,
            };

            Photostack.Children.Add(lb);

            Label l = new Label()
            {
                Text = "Select Food Items",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 30,
                TextColor = Color.WhiteSmoke,
            };

            Foodstack.Children.Add(l);

            Label l2 = new Label()
            {
                Text = "Select Decorator",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 30,
                TextColor = Color.WhiteSmoke,
            };

            Decorstack.Children.Add(l2);


            int x = 0;
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Halls>();
            var users = con.Table<Halls>().ToList();
            var ad = con.Query<Halls>("Select * from Halls Order by HallRating Desc");
            con.Close();


            foreach (var s in ad)
            {
                Hid[x] = s.HallId;
                Hname[x] = s.HallName;
                imagearray = s.imgbyte;
                Hpic[x] = s.HallPic;
                Haddress[x] = s.Address;
                Hprice[x] = Convert.ToInt32(s.HallPrice);
                Hrating[x] = Convert.ToInt32(s.HallRating);
                Hlong[x] = Convert.ToDouble(s.HallLong);
                Hlang[x] = Convert.ToDouble(s.HallLang);
                HallCreation(Hid[x].ToString(), Hname[x], imagearray, Hpic[x], Haddress[x], Hprice[x], Hrating[x], Hlong[x], Hlang[x]);
                x++;
            }
            x = 0;
            SQLiteConnection conf = new SQLiteConnection(App.Databaselocation);
            conf.CreateTable<FoodIt>();
            var usersf = conf.Table<FoodIt>().ToList();
            var adf = conf.Query<FoodIt>("Select * From FoodIt");
            conf.Close();
            foreach (var s in adf)
            {
                Fid[x] = Convert.ToInt32(s.FoodId);
                FoodName[x] = s.FoodName;
                imagearray = s.imgbyte;
                FoodPic[x] = s.FoodPic;
                FoodPrice[x] = Convert.ToInt32(s.FoodPrice);
                FoodItem(Fid[x].ToString(), FoodName[x], imagearray, FoodPic[x], FoodPrice[x]);
                x++;
            }

            x = 0;
            SQLiteConnection conn = new SQLiteConnection(App.Databaselocation);
            conn.CreateTable<photogr>();
            var usersp = conn.Table<photogr>().ToList();
            var adp = conn.Query<photogr>("Select * from photogr Order by PhotographerRating Desc");
            conn.Close();
            foreach (var s in adp)
            {
                Pid[x] = s.PhotographerId;
                pName[x] = s.PhotographerName;
                imagearray = s.imgbyte;
                pPic[x] = s.PhotographerPic;
                pPrice[x] = s.PhotographerPrice;
                pRating[x] = Convert.ToInt32(s.PhotographerRating);


                Photo(Pid[x].ToString(), pPic[x], pName[x], imagearray, pRating[x], pPrice[x]);
                x++;
            }



            x = 0;
            SQLiteConnection cond = new SQLiteConnection(App.Databaselocation);
            cond.CreateTable<Decorator>();
            var userdp = cond.Table<Decorator>().ToList();
            var ddp = cond.Query<Decorator>("Select * from Decorator Order by DecoratorRating Desc");
            cond.Close();
            foreach (var s in ddp)
            {

                Did[x] = s.DecoratorId;
                dName[x] = s.DecoratorName;
                imgarray = s.imgbyte;
                dPic[x] = s.DecoratorPic;
                dPrice[x] = s.DecoratorPrice;
                dRating[x] = Convert.ToInt32(s.DecoratorRating);


                Decorator(Did[x].ToString(), dPic[x], dName[x], imgarray, dRating[x], pPrice[x]);
                x++;
            }
        }

        void HallCreation(string Hallid, string HallName, byte[] ppic, string HallPic, string Address, int HallPrice, int HallRating, double HallLong, double HallLang)
        {
            
            bool x = true;
            byte[] b = ppic;

            if (ppic == null)
            {

                StackLayout Hall = new StackLayout();

                HallBooking.Children.Add(Hall);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Hall.Children.Add(S1);
                Label Hname = new Label
                {
                    Text = HallName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(Hname);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };
                Hall.Children.Add(S2);


                Frame ff = new Frame()
                {
                    CornerRadius = 100,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Padding = new Thickness(0),
                    IsClippedToBounds = true,
                    HorizontalOptions = LayoutOptions.Center,

                    Content = new Image
                    {
                        Aspect = Aspect.AspectFill,
                        Source = HallPic,

                    }

                };




                S2.Children.Add(ff);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Hall.Children.Add(S3);

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.Center,
                };
                S3.Children.Add(s31);

                Image img1 = new Image()
                {
                    Source = "world.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label = new Label()
                {
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    Text = "Address: " + Address,
                };
                s31.Children.Add(img1);
                s31.Children.Add(label);

                StackLayout s32 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s32);

                Image img2 = new Image()
                {
                    Source = "pin.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label1 = new Label()
                {
                    Text = "Tap to view Location",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s32.Children.Add(img2);
                s32.Children.Add(label1);

                
                StackLayout s33 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s33);

                Image img3 = new Image()
                {
                    Source = "time.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label2 = new Label()
                {
                    Text = "Open 24/7",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s33.Children.Add(img3);
                s33.Children.Add(label2);

                StackLayout s322 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s322);

                Image img22 = new Image()
                {
                    Source = "galleryg.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label11 = new Label()
                {
                    Text = "Tap to view Gallery",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s322.Children.Add(img22);
                s322.Children.Add(label11);

                StackLayout s34 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s34);

                Image img4 = new Image()
                {
                    Source = "star.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label3 = new Label()
                {
                    Text = " Rating: ",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    IsReadOnly = true,
                    ImageHeight = 20,
                    ImageWidth = 20,
                    ColorUI = ColorUI.OrangeLight,
                    ItemsNumber = 5,
                    InitialValue = HallRating,
                };

                Label label4 = new Label()
                {
                    Text = ratingConception.InitialValue.ToString(),
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s34.Children.Add(img4);
                s34.Children.Add(label3);
                s34.Children.Add(ratingConception);
                s34.Children.Add(label4);

                StackLayout s35 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s35);

                Image img5 = new Image()
                {
                    Source = "coin.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label6 = new Label()
                {
                    Text = HallPrice.ToString(),
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,

                };

                Button button = new Button()
                {
                    Text = "Select",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,                    
                    Margin = new Thickness(40, 0),

                };

                s35.Children.Add(img5);
                s35.Children.Add(label6);
                S3.Children.Add(button);

                button.Clicked += Button_Clicked;
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped1;
                ff.GestureRecognizers.Add(tapGestureRecognizer);

                var tapGestureRecognizer1 = new TapGestureRecognizer();
                tapGestureRecognizer1.Tapped += TapGestureRecognizer1_Tapped;
                label1.GestureRecognizers.Add(tapGestureRecognizer1);

                var tapGestureRecognizer11 = new TapGestureRecognizer();
                tapGestureRecognizer11.Tapped += TapGestureRecognizer11_Tapped;
                label11.GestureRecognizers.Add(tapGestureRecognizer11);

                void TapGestureRecognizer11_Tapped(object sende, EventArgs ee)
                {
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(Hallid)));
                }

                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sende, EventArgs ee)
                {
                    if (Hnm == "")
                    {
                        cb.IsVisible = true;
                        cb.IsEnabled = true;
                        cb.IsChecked = true;
                        button.Text = "Selected";
                        button.IsEnabled = false;
                        S3.IsVisible = false;
                        x = false;
                        Hnm = HallName;
                        Hpr = HallPrice.ToString();
                        hid = Hallid;
                    }
                    else
                    {
                        DisplayAlert("Error", "Hall Already Selected", "Ok");
                    }
                }

                void Cb_CheckedChanged(object sende, EventArgs ee)
                {
                    if (cb.IsChecked == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                        cb.IsEnabled = false;
                        cb.IsVisible = false;
                        button.Text = "Select";
                        button.IsEnabled = true;
                        Hnm = "";
                        Hpr = "";
                        hid = "";
                    }
                }

                void TapGestureRecognizer1_Tapped(object sende, EventArgs ee)
                {
                    Map.OpenAsync(HallLang, HallLong);
                }

                

                void TapGestureRecognizer_Tapped1(object sende, EventArgs ee)
                {
                    if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }

                    else if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }
                }
            }

            else
            {
                Stream ms = new MemoryStream(b);
                StackLayout Hall = new StackLayout();

                HallBooking.Children.Add(Hall);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Hall.Children.Add(S1);
                Label Hname = new Label
                {
                    Text = HallName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(Hname);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };
                Hall.Children.Add(S2);


                Frame ff = new Frame()
                {
                    CornerRadius = 100,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Padding = new Thickness(0),
                    IsClippedToBounds = true,
                    HorizontalOptions = LayoutOptions.Center,

                    Content = new Image
                    {
                        Aspect = Aspect.AspectFill,
                        Source = ImageSource.FromStream(() => ms),

                    }

                };




                S2.Children.Add(ff);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Hall.Children.Add(S3);

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.Center,
                };
                S3.Children.Add(s31);

                Image img1 = new Image()
                {
                    Source = "world.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label = new Label()
                {
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    Text = "Address: " + Address,
                };
                s31.Children.Add(img1);
                s31.Children.Add(label);

                StackLayout s32 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s32);

                Image img2 = new Image()
                {
                    Source = "pin.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label1 = new Label()
                {
                    Text = "Tap to view Location",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s32.Children.Add(img2);
                s32.Children.Add(label1);

                StackLayout s33 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s33);

                Image img3 = new Image()
                {
                    Source = "time.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label2 = new Label()
                {
                    Text = "Open 24/7",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s33.Children.Add(img3);
                s33.Children.Add(label2);

                StackLayout s322 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s322);

                Image img22 = new Image()
                {
                    Source = "galleryg.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label11 = new Label()
                {
                    Text = "Tap to view Gallery",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s322.Children.Add(img22);
                s322.Children.Add(label11);

                StackLayout s34 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s34);

                Image img4 = new Image()
                {
                    Source = "star.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label3 = new Label()
                {
                    Text = " Rating: ",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    IsReadOnly = true,
                    ImageHeight = 20,
                    ImageWidth = 20,
                    ColorUI = ColorUI.OrangeLight,
                    ItemsNumber = 5,
                   
                    InitialValue = HallRating,
                };

                Label label4 = new Label()
                {
                    Text = ratingConception.InitialValue.ToString(),
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s34.Children.Add(img4);
                s34.Children.Add(label3);
                s34.Children.Add(ratingConception);
                s34.Children.Add(label4);

                StackLayout s35 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s35);

                Image img5 = new Image()
                {
                    Source = "coin.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label6 = new Label()
                {
                    Text = HallPrice.ToString(),
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,

                };

                Button button = new Button()
                {
                    Text = "Select",
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    Margin = new Thickness(40, 0),

                };

                s35.Children.Add(img5);
                s35.Children.Add(label6);
                S3.Children.Add(button);

                button.Clicked += Button_Clicked;
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped1;
                ff.GestureRecognizers.Add(tapGestureRecognizer);

                var tapGestureRecognizer1 = new TapGestureRecognizer();
                tapGestureRecognizer1.Tapped += TapGestureRecognizer1_Tapped;
                label1.GestureRecognizers.Add(tapGestureRecognizer1);

                var tapGestureRecognizer11 = new TapGestureRecognizer();
                tapGestureRecognizer11.Tapped += TapGestureRecognizer11_Tapped;
                label11.GestureRecognizers.Add(tapGestureRecognizer11);

                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sende, EventArgs ee)
                {
                    if (Hnm == "")
                    {
                        cb.IsVisible = true;
                        cb.IsEnabled = true;
                        cb.IsChecked = true;
                        button.Text = "Selected";
                        button.IsEnabled = false;
                        S3.IsVisible = false;
                        x = false;
                        Hnm = HallName;
                        Hpr = HallPrice.ToString();
                        hid = Hallid;
                    }
                    else
                    {
                        DisplayAlert("Error", "Hall Already Selected", "Ok");
                    }
                }

                void Cb_CheckedChanged(object sende, EventArgs ee)
                {
                    if (cb.IsChecked == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                        cb.IsEnabled = false;
                        cb.IsVisible = false;
                        button.Text = "Select";
                        button.IsEnabled = true;
                        Hnm = "";
                        Hpr = "";
                        hid = "";
                    }
                }

                void TapGestureRecognizer1_Tapped(object sende, EventArgs ee)
                {
                    Map.OpenAsync(HallLang, HallLong);
                }

                void TapGestureRecognizer11_Tapped(object sende, EventArgs ee)
                {
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(Hallid)));
                }

                void TapGestureRecognizer_Tapped1(object sende, EventArgs ee)
                {
                    if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }

                    else if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }
                }
            }
        }

        void FoodItem(string foodid, string fName, byte[] ppic, string foodpic, int fprice)
        {
            byte[] b = ppic;

            if (ppic == null)
            {
                fid = foodid;
                bool x = false;
                int quan = 0;

                StackLayout Food = new StackLayout();
                Foodstack.Children.Add(Food);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Food.Children.Add(S1);


                Label FoodName = new Label
                {
                    Text = fName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(FoodName);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };

                Food.Children.Add(S2);

                Frame ff = new Frame()
                {
                    CornerRadius = 100,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Padding = new Thickness(0),
                    IsClippedToBounds = true,
                    HorizontalOptions = LayoutOptions.Center,

                    Content = new Image
                    {
                        Source = foodpic,
                        Aspect = Aspect.AspectFill,
                    }

                };
                S2.Children.Add(ff);


                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Food.Children.Add(S3);

                var Quantity = new List<Int32>();
                Quantity.Add(5);
                Quantity.Add(10);
                Quantity.Add(15);
                Quantity.Add(20);

                Picker picker = new Picker()
                {
                    Title = "Select Quantity in Kg's",
                    Margin = new Thickness(80, 0),
                    TextColor = Color.WhiteSmoke,
                    TitleColor = Color.WhiteSmoke,
                    ItemsSource = Quantity,
                };
                S3.Children.Add(picker);

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                S3.Children.Add(s31);

                Image image = new Image()
                {
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Source = "coin.png"
                };

                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    Text = "Price Per Kg: " + fprice.ToString(),
                };

                s31.Children.Add(image);
                s31.Children.Add(label);

                Button button = new Button()
                {
                    Text = "Add",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(40, 0),
                };
                S3.Children.Add(button);


                button.Clicked += Button_Clicked;
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);
                cb.CheckedChanged += Cb_CheckedChanged;

                void Button_Clicked(object sender, EventArgs e)
                {

                    if (picker.SelectedIndex == 1 || picker.SelectedIndex == 0 || picker.SelectedIndex == 2 || picker.SelectedIndex == 3 || picker.SelectedIndex == 4)
                    {
                        {
                            if (picker.SelectedIndex == 1)
                                quan = 5;
                            if (picker.SelectedIndex == 2)
                                quan = 10;
                            if (picker.SelectedIndex == 3)
                                quan = 15;
                            if (picker.SelectedIndex == 4)
                                quan = 20;
                        }
                        cb.IsVisible = true;
                        cb.IsEnabled = true;
                        cb.IsChecked = true;
                        S3.IsVisible = false;
                        button.Text = "Selected";
                        button.IsEnabled = false;
                        x = false;
                        fname.Add(fName);
                        frate.Add(fprice);
                        fquan.Add(quan);
                    }

                    else
                    {
                        DisplayAlert("Error", "Please Select Quantity First", "Ok");
                    }
                }

                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }

                    else if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }
                }



                void Cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
                {
                    if (cb.IsChecked == false)
                    {
                        cb.IsVisible = false;
                        cb.IsEnabled = false;
                        S3.IsVisible = true;
                        x = true;
                        button.Text = "Add";
                        button.IsEnabled = true;
                        fname.Remove(fname.ToString());
                        frate.Remove(fprice);
                        fquan.Remove(quan);

                    }
                }
            }


            else
            {
                Stream ms = new MemoryStream(b);
                fid = foodid;
                bool x = false;
                int quan = 0;

                StackLayout Food = new StackLayout();
                Foodstack.Children.Add(Food);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Food.Children.Add(S1);


                Label FoodName = new Label
                {
                    Text = fName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(FoodName);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };

                Food.Children.Add(S2);

                Frame ff = new Frame()
                {
                    CornerRadius = 100,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Padding = new Thickness(0),
                    IsClippedToBounds = true,
                    HorizontalOptions = LayoutOptions.Center,

                    Content = new Image
                    {
                        Source = ImageSource.FromStream(() => ms),
                        Aspect = Aspect.AspectFill,
                    }

                };
                S2.Children.Add(ff);


                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Food.Children.Add(S3);

                var Quantity = new List<Int32>();
                Quantity.Add(5);
                Quantity.Add(10);
                Quantity.Add(15);
                Quantity.Add(20);

                Picker picker = new Picker()
                {
                    Title = "Select Quantity in Kg's",
                    Margin = new Thickness(80, 0),
                    TextColor = Color.WhiteSmoke,
                    TitleColor = Color.WhiteSmoke,
                    ItemsSource = Quantity,
                };
                S3.Children.Add(picker);

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                S3.Children.Add(s31);

                Image image = new Image()
                {
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Source = "coin.png"
                };

                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    Text = "Price Per Kg: " + fprice.ToString(),
                };

                s31.Children.Add(image);
                s31.Children.Add(label);

                Button button = new Button()
                {
                    Text = "Add",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(40, 0),
                };
                S3.Children.Add(button);


                button.Clicked += Button_Clicked;
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);
                cb.CheckedChanged += Cb_CheckedChanged;

                void Button_Clicked(object sender, EventArgs e)
                {

                    if (picker.SelectedIndex == 1 || picker.SelectedIndex == 0 || picker.SelectedIndex == 2 || picker.SelectedIndex == 3 || picker.SelectedIndex == 4)
                    {
                        {
                            if (picker.SelectedIndex == 1)
                                quan = 5;
                            if (picker.SelectedIndex == 2)
                                quan = 10;
                            if (picker.SelectedIndex == 3)
                                quan = 15;
                            if (picker.SelectedIndex == 4)
                                quan = 20;
                        }
                        cb.IsVisible = true;
                        cb.IsEnabled = true;
                        cb.IsChecked = true;
                        S3.IsVisible = false;
                        button.Text = "Selected";
                        button.IsEnabled = false;
                        x = false;
                        fname.Add(fName);
                        frate.Add(fprice);
                        fquan.Add(quan);
                    }

                    else
                    {
                        DisplayAlert("Error", "Please Select Quantity First", "Ok");
                    }
                }

                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }

                    else if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }
                }



                void Cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
                {
                    if (cb.IsChecked == false)
                    {
                        cb.IsVisible = false;
                        cb.IsEnabled = false;
                        S3.IsVisible = true;
                        x = true;
                        button.Text = "Add";
                        button.IsEnabled = true;
                        fname.Remove(fname.ToString());
                        frate.Remove(fprice);
                        fquan.Remove(quan);

                    }
                }
            }
        }
       
        void Photo(string phid, string p, string pName, byte[] ppic, int prating, int pprice)
        {
            bool x = false;
            byte[] b = ppic;

            if (ppic == null)
            {
                
            StackLayout Ph = new StackLayout();
            Photostack.Children.Add(Ph);

            StackLayout S1 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };
            Ph.Children.Add(S1);

            Label PhotographerName = new Label
            {
                Text = pName,
                TextColor = Color.WhiteSmoke,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            CheckBox cb = new CheckBox()
            {
                IsVisible = false,
                IsEnabled = false,
                IsChecked = false,
                Color = Color.WhiteSmoke,
            };

            S1.Children.Add(PhotographerName);
            S1.Children.Add(cb);

            StackLayout S2 = new StackLayout()
            {
                Padding = new Thickness(20, 0),
            };

            Ph.Children.Add(S2);

            StackLayout S3 = new StackLayout()
            {
                IsVisible = false,
            };

            Ph.Children.Add(S3);

            
                Frame ff = new Frame()
            {
                CornerRadius = 100,
                HeightRequest = 200,
                WidthRequest = 200,
                Padding = new Thickness(0),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.Center,

                Content = new Image
                {      
                    Aspect = Aspect.AspectFill,
                    Source = p,

                }

            };
            S2.Children.Add(ff);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);
                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }

                    else if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }
                }

                StackLayout s322 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s322);

                Image img22 = new Image()
                {
                    Source = "galleryg.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label11 = new Label()
                {
                    Text = "Tap to view Gallery",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s322.Children.Add(img22);
                s322.Children.Add(label11);
                var tapGestureRecognizer11 = new TapGestureRecognizer();
                tapGestureRecognizer11.Tapped += TapGestureRecognizer11_Tapped;
                label11.GestureRecognizers.Add(tapGestureRecognizer11);

                void TapGestureRecognizer11_Tapped(object sende, EventArgs ee)
                {
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(phid)));
                }


                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                S3.Children.Add(s31);

                Image image = new Image()
                {
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Source = "coin.png"
                };

                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    Text = pprice.ToString(),
                };
                s31.Children.Add(image);
                s31.Children.Add(label);

                
                StackLayout s32 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s32);

                Image img4 = new Image()
                {
                    Source = "star.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label3 = new Label()
                {
                    Text = " Rating: ",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    IsReadOnly = true,
                    ImageHeight = 20,
                    ImageWidth = 20,
                    ColorUI = ColorUI.OrangeLight,
                    ItemsNumber = 5,
                    InitialValue = prating,
                };

                Label label4 = new Label()
                {
                    Text = ratingConception.InitialValue.ToString(),
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s32.Children.Add(img4);
                s32.Children.Add(label3);
                s32.Children.Add(ratingConception);
                s32.Children.Add(label4);


                Button button = new Button()
                {
                    Text = "Select",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(80, 0),
                };
                S3.Children.Add(button);


                button.Clicked += Button_Clicked;

                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sender, EventArgs e)
                {
                    cb.IsVisible = true;
                    cb.IsEnabled = true;
                    cb.IsChecked = true;
                    S3.IsVisible = false;
                    button.Text = "Selected";
                    button.IsEnabled = false;
                    x = false;
                    sphoto = pName;
                    prate = pprice;
                    pid = phid;
                }



                void Cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
                {
                    if (cb.IsChecked == false)
                    {
                        cb.IsVisible = false;
                        cb.IsEnabled = false;
                        S3.IsVisible = true;
                        x = true;
                        button.Text = "Select";
                        button.IsEnabled = true;
                        sphoto = "";
                        prate = 0;
                    }
                }
            }


            else
            {
                Stream ms = new MemoryStream(b);
                StackLayout Ph = new StackLayout();
                Photostack.Children.Add(Ph);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                Ph.Children.Add(S1);

                Label PhotographerName = new Label
                {
                    Text = pName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                

                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(PhotographerName);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };

                Ph.Children.Add(S2);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Ph.Children.Add(S3);
                Frame ff = new Frame()
                {
                CornerRadius = 100,
                HeightRequest = 200,
                WidthRequest = 200,
                Padding = new Thickness(0),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.Center,

                Content = new Image
                {      
                    Aspect = Aspect.AspectFill,
                    Source = ImageSource.FromStream(() => ms),
                }

            };
            S2.Children.Add(ff);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);

                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }

                    else if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }
                }

                StackLayout s322 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s322);

                Image img22 = new Image()
                {
                    Source = "galleryg.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label11 = new Label()
                {
                    Text = "Tap to view Gallery",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s322.Children.Add(img22);
                s322.Children.Add(label11);
                var tapGestureRecognizer11 = new TapGestureRecognizer();
                tapGestureRecognizer11.Tapped += TapGestureRecognizer11_Tapped;
                label11.GestureRecognizers.Add(tapGestureRecognizer11);

                void TapGestureRecognizer11_Tapped(object sende, EventArgs ee)
                {
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(phid)));
                }

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                S3.Children.Add(s31);

                Image image = new Image()
                {
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Source = "coin.png"
                };

                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    Text = pprice.ToString(),
                };
                s31.Children.Add(image);
                s31.Children.Add(label);

                StackLayout s32 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s32);

                Image img4 = new Image()
                {
                    Source = "star.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label3 = new Label()
                {
                    Text = " Rating: ",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    IsReadOnly = true,
                    ImageHeight = 20,
                    ImageWidth = 20,
                    ColorUI = ColorUI.OrangeLight,
                    ItemsNumber = 5,
                    InitialValue = prating,
                };

                Label label4 = new Label()
                {
                    Text = ratingConception.InitialValue.ToString(),
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s32.Children.Add(img4);
                s32.Children.Add(label3);
                s32.Children.Add(ratingConception);
                s32.Children.Add(label4);


                Button button = new Button()
                {
                    Text = "Select",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(80, 0),
                };
                S3.Children.Add(button);


                button.Clicked += Button_Clicked;

                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sender, EventArgs e)
                {
                    cb.IsVisible = true;
                    cb.IsEnabled = true;
                    cb.IsChecked = true;
                    S3.IsVisible = false;
                    button.Text = "Selected";
                    button.IsEnabled = false;
                    x = false;
                    sphoto = pName;
                    prate = pprice;
                    pid = phid;
                }



                void Cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
                {
                    if (cb.IsChecked == false)
                    {
                        cb.IsVisible = false;
                        cb.IsEnabled = false;
                        S3.IsVisible = true;
                        x = true;
                        button.Text = "Select";
                        button.IsEnabled = true;
                        sphoto = "";
                        prate = 0;
                    }
                }
            }
            
            

            

            

        }

        void Decorator(string did, string d, string dName, byte[] dpic, int drating, int dprice)
        {
            bool x = false;
            byte[] b = dpic;

            if (dpic == null)
            {

                StackLayout Dh = new StackLayout();
                Decorstack.Children.Add(Dh);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                Dh.Children.Add(S1);

                Label DecoratorName = new Label
                {
                    Text = dName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    Margin = new Thickness(70, 0, 70, 0),
                };

                

                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(DecoratorName);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };

                Dh.Children.Add(S2);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Dh.Children.Add(S3);


                Frame ff = new Frame()
                {
                    CornerRadius = 100,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Padding = new Thickness(0),
                    IsClippedToBounds = true,
                    HorizontalOptions = LayoutOptions.Center,

                    Content = new Image
                    {
                        Aspect = Aspect.AspectFill,
                        Source = d,

                    }

                };
                S2.Children.Add(ff);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);
                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }

                    else if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }
                }

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                StackLayout s322 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s322);

                Image img22 = new Image()
                {
                    Source = "galleryg.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label11 = new Label()
                {
                    Text = "Tap to view Gallery",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s322.Children.Add(img22);
                s322.Children.Add(label11);
                var tapGestureRecognizer11 = new TapGestureRecognizer();
                tapGestureRecognizer11.Tapped += TapGestureRecognizer11_Tapped;
                label11.GestureRecognizers.Add(tapGestureRecognizer11);

                void TapGestureRecognizer11_Tapped(object sende, EventArgs ee)
                {
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(did)));
                }

                S3.Children.Add(s31);

                Image image = new Image()
                {
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Source = "coin.png"
                };

                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    Text = dprice.ToString(),
                };
                s31.Children.Add(image);
                s31.Children.Add(label);

                StackLayout s32 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s32);

                Image img4 = new Image()
                {
                    Source = "star.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label3 = new Label()
                {
                    Text = " Rating: ",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    IsReadOnly = true,
                    ImageHeight = 20,
                    ImageWidth = 20,
                    ColorUI = ColorUI.OrangeLight,
                    ItemsNumber = 5,
                    InitialValue = drating,
                };

                Label label4 = new Label()
                {
                    Text = ratingConception.InitialValue.ToString(),
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s32.Children.Add(img4);
                s32.Children.Add(label3);
                s32.Children.Add(ratingConception);
                s32.Children.Add(label4);


                Button button = new Button()
                {
                    Text = "Select",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(40, 0),
                };
                S3.Children.Add(button);


                button.Clicked += Button_Clicked;

                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sender, EventArgs e)
                {
                    cb.IsVisible = true;
                    cb.IsEnabled = true;
                    cb.IsChecked = true;
                    S3.IsVisible = false;
                    button.Text = "Selected";
                    button.IsEnabled = false;
                    x = false;
                    dphoto = dName;
                    drate = dprice;
                    dId = did;
                }



                void Cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
                {
                    if (cb.IsChecked == false)
                    {
                        cb.IsVisible = false;
                        cb.IsEnabled = false;
                        S3.IsVisible = true;
                        x = true;
                        button.Text = "Select";
                        button.IsEnabled = true;
                        dphoto = "";
                        drate = 0;
                    }
                }
            }


            else
            {
                Stream ms = new MemoryStream(b);
                StackLayout Ph = new StackLayout();
                Photostack.Children.Add(Ph);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                Ph.Children.Add(S1);

                Label DecoratorName = new Label
                {
                    Text = dName,
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    Margin = new Thickness(70, 0, 70, 0),
                };


                CheckBox cb = new CheckBox()
                {
                    IsVisible = false,
                    IsEnabled = false,
                    IsChecked = false,
                    Color = Color.WhiteSmoke,
                };

                S1.Children.Add(DecoratorName);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };

                Ph.Children.Add(S2);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Ph.Children.Add(S3);
                Frame ff = new Frame()
                {
                    CornerRadius = 100,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Padding = new Thickness(0),
                    IsClippedToBounds = true,
                    HorizontalOptions = LayoutOptions.Center,

                    Content = new Image
                    {
                        Aspect = Aspect.AspectFill,
                        Source = ImageSource.FromStream(() => ms),
                    }

                };
                S2.Children.Add(ff);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ff.GestureRecognizers.Add(tapGestureRecognizer);

                void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
                    if (x == false)
                    {
                        S3.IsVisible = true;
                        x = true;
                    }

                    else if (x == true)
                    {
                        S3.IsVisible = false;
                        x = false;
                    }
                }

                StackLayout s322 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s322);

                Image img22 = new Image()
                {
                    Source = "galleryg.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label11 = new Label()
                {
                    Text = "Tap to view Gallery",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                    TextDecorations = TextDecorations.Underline,
                };

                s322.Children.Add(img22);
                s322.Children.Add(label11);
                var tapGestureRecognizer11 = new TapGestureRecognizer();
                tapGestureRecognizer11.Tapped += TapGestureRecognizer11_Tapped;
                label11.GestureRecognizers.Add(tapGestureRecognizer11);

                void TapGestureRecognizer11_Tapped(object sende, EventArgs ee)
                {
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(did)));
                }

                StackLayout s31 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                S3.Children.Add(s31);

                Image image = new Image()
                {
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Source = "coin.png"
                };

                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#797c01"),
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    Text = dprice.ToString(),
                };
                s31.Children.Add(image);
                s31.Children.Add(label);

                StackLayout s32 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };
                S3.Children.Add(s32);

                Image img4 = new Image()
                {
                    Source = "star.png",
                    Margin = new Thickness(20, 0, 0, 5),
                    HeightRequest = 30,
                    WidthRequest = 30,
                };

                Label label3 = new Label()
                {
                    Text = " Rating: ",
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                RatingConception ratingConception = new RatingConception()
                {
                    DrawType = DrawType.Heart,
                    IsReadOnly = true,
                    ImageHeight = 20,
                    ImageWidth = 20,
                    ColorUI = ColorUI.OrangeLight,
                    ItemsNumber = 5,
                    InitialValue = drating,
                };

                Label label4 = new Label()
                {
                    Text = ratingConception.InitialValue.ToString(),
                    TextColor = Color.WhiteSmoke,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Center,
                };

                s32.Children.Add(img4);
                s32.Children.Add(label3);
                s32.Children.Add(ratingConception);
                s32.Children.Add(label4);


                Button button = new Button()
                {
                    Text = "Select",
                    BackgroundColor = Color.FromHex("b68948"),
                    TextColor = Color.FromHex("1b1b1b"),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(40, 0),
                };
                S3.Children.Add(button);


                button.Clicked += Button_Clicked;

                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sender, EventArgs e)
                {
                    cb.IsVisible = true;
                    cb.IsEnabled = true;
                    cb.IsChecked = true;
                    S3.IsVisible = false;
                    button.Text = "Selected";
                    button.IsEnabled = false;
                    x = false;
                    dphoto = dName;
                    drate = dprice;
                    dId = did;
                }



                void Cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
                {
                    if (cb.IsChecked == false)
                    {
                        cb.IsVisible = false;
                        cb.IsEnabled = false;
                        S3.IsVisible = true;
                        x = true;
                        button.Text = "Select";
                        button.IsEnabled = true;
                        dphoto = "";
                        drate = 0;
                    }
                }
            }







        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool cc1, cc2, cc3, cc4,cc5,cc6,cc7,cc8 = true;

            String err = "Following Errors Occured:\n";

            if (d1.Date.ToString() == "" || d1.Date == null)
            {
                err += "Please Select the Event Date\n";
                cc1 = false;
                
            }
             else
            {
                cc1 = true;
            }

             if(d2.Text == "" || d2.Text == null)
            {

                err += "Please Select Number of Guests\n";
                cc2 = false;
            }
            else
            {
                cc2 = true;
            }

            if (s == "" || s == null)
            {

                err += "Please Select Event Timing\n";
                cc3 = false;
            }
            else
            {
                cc3 = true;
            }

            if (Hnm == "" || Hnm == null)
            {
                err += "Please Select Hall for Event\n";
                cc4 = false;
            }
            else
            {
                cc4 = true;
            }

            if(fname.Count == 0)
            {
                err += "Please Select atleast 1 food item\n";
                cc5 = false;
            }
            else
            {
                cc5 = true;
            }

            if (dphoto == "" || dphoto == null)
            {
                err += "Select the Decorator\n";
                cc6 = false;
            }
            else
            {
                cc6 = true;
            }

            if (sphoto == "" || sphoto == null)
            {
                err += "Select the Photographer\n";
                cc7 = false;
            }
            else
            {
                cc7 = true;
            }

            if(cc1 == true && cc4 == true)
            {
                int z = 0;
                string dx, dt;
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<MarriageEvent>();
                var nm = con.Query<MarriageEvent>("Select EventId from MarriageEvent where Date= ? and EventType = ?  and timing = ?", d1.Date.ToShortDateString().ToString(), evtype, s);

                foreach (var s in nm)
                {
                    int hx = s.EventId;
                    dx = s.Date;
                    dt = s.Timing;
                    var hxm = con.Query<mHallBook>("Select EventId from mHallBook where Hallname =?", Hnm);
                    foreach (var aff in hxm)
                    {
                        if (aff.EventId == hx)
                        {
                            z++;
                        }
                    }
                }
                con.Close();

                if (z > 0)
                {
                    err += Hnm + " is already Booked at " + d1.Date.ToShortDateString() + " at " + s + " timing\n";
                    cc8 = false;
                }

                else
                {
                    cc8 = true;
                }
            }


            if (cc1 == true && cc2 == true && cc3 == true && cc4 == true && cc5 == true && cc6 == true && cc7 == true && cc8 == true)
            {

                olb1.Text = evtype.ToString();
                olb2.Text = d1.Date.ToShortDateString();
                olb3.Text = s;
                olb4.Text = d2.Text;
                olb5.Text = Hnm;
                olb6.Text = "Price: " + Hpr.ToString();
                olb7.Text = sphoto;
                olb8.Text = "Price: " + prate.ToString();
                olb9.Text = dphoto;
                olb11.Text = "Price: " + drate.ToString();

                int x = 0;               
                string hname;
                int p;
                int qu = 0;
                int fp = 0;
                totalbill += Convert.ToInt32(Hpr) + prate + drate;


                foreach (var m in fname)
                {

                    fn[x] = m;
                    x++;
                }
                int ind = x;
                x = 0;
                foreach (var m in frate)
                {

                    fr[x] = m;
                    x++;
                }
                x = 0;
                foreach (var m in fquan)
                {
                    fq[x] = m;
                    x++;
                }
                
                for (int i = 0; i<ind; i++)
                {
                    hname = fn[i];
                    p = fr[i];
                    qu = fq[i];
                    fp = p * qu;
                    StackLayout st = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Margin = 10,
                    };
                   

                    Label label1 = new Label()
                    {
                        Text = qu.ToString() +"x",
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        Margin = new Thickness(0, 0, 20, 0),
                    };


                    Label label2 = new Label()
                    {
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        Text = hname,
                        Margin = new Thickness(0, 0, 60, 0),

                    };
           

                    Label label3 = new Label()
                    {
                        Text = "Price: "+fp.ToString(),
                        TextColor = Color.FromHex("#3b2c49"),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    };
                    st.Children.Add(label1);
                    st.Children.Add(label2);
                    st.Children.Add(label3);
                    Frame ff = new Frame();
                    ff.Content = st;
                    oFoodStack.Children.Add(ff);

                    totalbill += fp;

                }
                olb10.Text = totalbill.ToString();
                s1.IsVisible = false;
                s2.IsVisible = true;
                BottomBar.IsVisible = false;
                NavigationPage.SetHasNavigationBar(this, false);
                WedPage.BackgroundImageSource = "";
            }


            else
            {
                DisplayAlert("Error", err, "ok");
            }
             
        }




        ////////////////////////Wedding Info/////////////////////////////////

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bl1.IsVisible = true;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            WeddingInfo.IsVisible = true;
            HallBooking.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;
        }


        private void animV_OnPlay(object sender, EventArgs e)
        {
            anim.IsVisible = true;
        }

        private void animV_OnFinish(object sender, EventArgs e)
        {
            anim.IsVisible = false;
        }


        public string s = "";
        private void pik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pik.SelectedIndex == 0)
            {
                s = "Day";
                animV.Animation = "day.json";
                animV.PlayAnimation();
            }

            else if(pik.SelectedIndex == 1)
            {
                s = "Night";
                animV.Animation = "night.json";
                animV.PlayAnimation();
            }
        }

        ////////////////////////Hall Booking/////////////////////////////////

        

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = true;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#b68948");
            WeddingInfo.IsVisible = false;
            HallBooking.IsVisible = true;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;
            if (c2 == 0)
            {
                sn = "hall.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c2++;
            }
            else { }
        }






        ////////////////////////Food Items/////////////////////////////////

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = false;
            bl3.IsVisible = true;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            WeddingInfo.IsVisible = false;
            HallBooking.IsVisible = false;
            Foodstack.IsVisible = true;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;

            if (c3 == 0)
            {
                sn = "food2.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c3++;
            }
            else { }
        }


        ////////////////////////Photographer/////////////////////////////////
        
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = true;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#b68948");
            WeddingInfo.IsVisible = false;
            HallBooking.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = true;
            Decorstack.IsVisible = false;

            if (c4 == 0)
            {
                sn = "camera.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c4++;
            }
            else { }
        }



       

        ////////////////////////SetDecor/////////////////////////////////

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = true;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            WeddingInfo.IsVisible = false;
            HallBooking.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = true;

            if (c5 == 0)
            {
                sn = "decoration.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c5++;
            }
            else { }


        }

       
   


        ////////////////////////OrderInterface/////////////////////////////////


        string a, d, f, g, h;
        private void oButton_Clicked(object sender, EventArgs e)
        {
             
                  MarriageEvent mar = new MarriageEvent()
                  {
                      UserId = Convert.ToInt32(sid),
                      Date = d1.Date.ToShortDateString(),
                      Guests = Convert.ToInt32(d2.Text),
                      Timing = s,
                      EventType = evtype,
                      TotalBill = totalbill,
                  };
                  SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                  con.CreateTable<MarriageEvent>();
                  con.Insert(mar);
                  var nm = con.Query<MarriageEvent>("Select EventId from MarriageEvent where Date= ? and EventType = ?  and UserId = ?", d1.Date.ToShortDateString().ToString(), evtype, sid);

                  foreach (var s in nm)
                  {
                      evId = s.EventId;
                  }
                  con.Close();


                  int x = 0;
                  foreach (var m in fname)
                  {

                      fn[x] = m;
                      x++;
                  }
                  int ind = x;
                  x = 0;
                  foreach (var m in frate)
                  {

                      fr[x] = m;
                      x++;
                  }
                  x = 0;
                  foreach (var m in fquan)
                  {
                      fq[x] = m;
                      x++;
                  }
                  x = 0;

                  for (int i = 0; i < ind; i++)
                  {
                      FoodOrder fo = new FoodOrder()
                      {
                          EventId = evId,
                          ItemName = fn[i],
                          ItemQuantity = fq[i],
                          ItemPrice = fr[i],                     
                      };
                      SQLiteConnection conn = new SQLiteConnection(App.Databaselocation);
                      conn.CreateTable<FoodOrder>();
                      conn.Insert(fo);
                      conn.Close();
                  }


                  mHallBook mh = new mHallBook()
                  {
                      EventId = Convert.ToInt32(evId),
                      HallId = Convert.ToInt32(hid),
                      Hallname = Hnm,
                      Hallrate = Convert.ToInt32(Hpr),
                  };
                  SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                  con3.CreateTable<mHallBook>();
                  con3.Insert(mh);
                  con3.Close();

            
            


            if (sphoto != "None")
            { 
            mPhotographerBook mp = new mPhotographerBook()
            {
                      PId = Convert.ToInt32(pid),
                      EventId = Convert.ToInt32(evId),
                      PhotographerName = sphoto,
                      PhotographerPrice = prate,
                  };
                SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
                con4.CreateTable<mPhotographerBook>();
                con4.Insert(mp);
                con4.Close();

                Ratings ratings2 = new Ratings()
                {
                    UserId = Convert.ToInt32(sid),
                    EventId = evId,
                    PartnerId = Convert.ToInt32(pid),
                    Rating = 0,
                };

                SQLiteConnection connn = new SQLiteConnection(App.Databaselocation);
                connn.CreateTable<Ratings>();
                connn.Insert(ratings2);
                connn.Close();
            }

            if (sphoto == "None")
            {
                mPhotographerBook mp = new mPhotographerBook()
                {
                    EventId = Convert.ToInt32(evId),
                    PhotographerName = sphoto,
                    PhotographerPrice = prate,
                };
                SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
                con4.CreateTable<mPhotographerBook>();
                con4.Insert(mp);
                con4.Close();
            }


            mDecor dp = new mDecor()
            {
                DId = Convert.ToInt32(dId),
                EventId = Convert.ToInt32(evId),
                DecoratorName = dphoto,
                DecoratorPrice = drate,
            };
            SQLiteConnection con6 = new SQLiteConnection(App.Databaselocation);
            con6.CreateTable<mDecor>();
            con6.Insert(dp);
            con6.Close();


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

            Ratings ratings1 = new Ratings()
            {
                UserId = Convert.ToInt32(sid),
                EventId = evId,
                PartnerId = Convert.ToInt32(hid),
                Rating = 0,
            };
           
            Ratings ratings3 = new Ratings()
            {
                UserId = Convert.ToInt32(sid),
                EventId = evId,
                PartnerId = Convert.ToInt32(dId),
                Rating = 0,
            };
            SQLiteConnection conn1 = new SQLiteConnection(App.Databaselocation);
            conn1.CreateTable<Ratings>();
            conn1.Insert(ratings1);
            conn1.Insert(ratings3);
            conn1.Close();

            Navigation.PushAsync(new MasterPage(a, d, f, g, h));
            DisplayAlert("Order Placed", "Dear Customer your order is placed.We will contact you shortly, 50% of the Total Bill will be taken in advaced. Thank You!", "Ok");
        }

        private void oButton_Clicked_1(object sender, EventArgs e)
        {
            s1.IsVisible = true;
            s2.IsVisible = false;
            BottomBar.IsVisible = true;
            NavigationPage.SetHasNavigationBar(this, true);
            WedPage.BackgroundImageSource = "abg";
        }
    }
}