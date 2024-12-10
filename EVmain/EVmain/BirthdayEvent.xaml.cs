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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class BirthdayEvent : ContentPage
    {
        public int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0;
        public string sn = "lunch.json";
        string sid,fid,pid, evtype;
        List<string> fname = new List<string>();
        List<int> frate = new List<int>();
        List<int> fquan = new List<int>();
        string[] fn = new string[100];
        int[] fr = new int[100];
        int[] fq = new int[100];
        string sphoto = "None", dphoto = "None", cake = "", dId = "";
        int prate = 0, evId = 0, drate = 0;
        double totalbill = 0.0, ckQuan, ckRate;

        int[] Fid = new int[100];
        string[] FoodName = new string[100];
        string[] FoodPic = new string[100];
        int[] FoodPrice = new int[100];

        int[] Pid = new int[100];
        string[] pName = new string[100];
        string[] pPic = new string[100];
        int[] pRating = new int[100];
        int[] pPrice = new int[100];

        int[] Did = new int[100];
        string[] dName = new string[100];
        string[] dPic = new string[100];
        int[] dRating = new int[100];
        int[] dPrice = new int[100];
        byte[] imagearray;


        public BirthdayEvent(string userID, string EventType)
        {
            InitializeComponent();
            sid = userID;
            evtype = EventType;
            d1.MinimumDate = DateTime.Now.AddDays(3);
            sn = "timing.json";
            PopupNavigation.Instance.PushAsync(new Page1(sn)); c1++;

            bl1.IsVisible = true;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            BirthdayInfo.IsVisible = true;
            Cakestack.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;
            cp.BackgroundImageSource = "cbg2";
            ms2.IsVisible = false;

            var imgs = new List<string>
           {
               "ck1.jpg","ck2.jpg","ck3.jpg","ck4.jpg","ck5.jpg","ck6.jpg","ck7.jpg","ck8.jpg","ck9.jpg","ck10.jpg","ck11.jpg","ck12.jpg"
           };
            MainCarouselView.ItemsSource = imgs;


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
            var adp = conn.Query<photogr>("Select * from photogr");
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
                imagearray = s.imgbyte;
                dPic[x] = s.DecoratorPic;
                dPrice[x] = s.DecoratorPrice;
                dRating[x] = Convert.ToInt32(s.DecoratorRating);


                Decorator(Did[x].ToString(), dPic[x], dName[x], imagearray, dRating[x], pPrice[x]);
                x++;
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
            bool cc1, cc2, cc3, cc4, cc5, cc6, cc7,cc8;
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

            if (d2.Time.ToString() == "" || d2.Time == null)
            {
                err += "Please Select the Event Timing\n";
                cc2 = false;

            }
            else
            {
                cc2 = true;
            }

            if (d3.Text == "" || d3.Text == null)
            {

                err += "Please Select the Event Location\n";
                cc3 = false;
            }
            else
            {
                cc3 = true;
            }

            if (d4.Text == "" || d4.Text == null)
            {

                err += "Please Number of expected Guests\n";
                cc7 = false;
            }
            else
            {
                cc7 = true;
            }

            if (cake == "" || cake == null)
            {
                err += "Please Select the Birthday Cake\n";
                cc4 = false;
            }
            else
            {
                cc4 = true;
            }

            if (ck1.Text == "" || ck1.Text == null)
            {
                err += "Please Select Cake Quantity\n";
                cc8 = false;
            }
            else
            {
                cc8 = true;
            }

            if (dphoto == "" || dphoto == null)
            {
                err += "Please Select the Decorator\n";
                cc5 = false;
            }
            else
            {
                cc5 = true;
            }

            if (fname.Count == 0)
            {
                err += "Please Select atleast 1 food item\n";
                cc6 = false;
            }
            else
            {
                cc6 = true;
            }

            if (cc1 == true && cc2 == true && cc3 == true && cc4 == true && cc5 == true && cc6 == true && cc7 == true && cc8 == true)
            {
                ckQuan = Convert.ToDouble(ck1.Text);
                ckRate = ckQuan * 500;
                int x = 0;
                string hname;
                int p;
                int qu = 0;
                int fp = 0;

                totalbill += prate + ckRate + drate;


                olb1.Text = evtype.ToString();
                olb2.Text = d1.Date.ToShortDateString();
                olb3.Text = d2.Time.ToString();
                olb41.Text = d4.Text.ToString();
                olb4.Text = d3.Text.ToString();
                olb5.Text = cake;
                olb51.Text = ck1.Text.ToString();
                olb52.Text = ckRate.ToString();
                olb7.Text = sphoto;
                olb8.Text = prate.ToString();
                olb9.Text = dphoto;
                olb11.Text = drate.ToString();


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

                for (int i = 0; i < ind; i++)
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
                        Text = qu.ToString() + "x",
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
                        Text = "Price: " + fp.ToString(),
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
                ms1.IsVisible = false;
                ms2.IsVisible = true;
                BottomBar.IsVisible = false;
                NavigationPage.SetHasNavigationBar(this, false);
                cp.BackgroundImageSource = "";

            }

            else
            {
                DisplayAlert("Error", err, "ok");
            }
        }

        ////////////////////////Birthday Info/////////////////////////////////

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bl1.IsVisible = true;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            BirthdayInfo.IsVisible = true;
            Cakestack.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;
            cp.BackgroundImageSource = "cbg2";
        }

        ////////////////////////CakeSelect/////////////////////////////////
        
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = true;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#b68948");
            BirthdayInfo.IsVisible = false;
            Cakestack.IsVisible = true;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;
            cp.BackgroundImageSource = "cbg1";

            if (c2 == 0)
            {
                sn = "cake.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c2++;
            }
            else { }
        }


        bool x = true;
        private void btnck_Clicked(object sender, EventArgs e)
        {
         

            if (x == true)
                {
                    btnck.Text = "Unselect";
                    MainCarouselView.IsSwipeEnabled = false;
                    x = false;
                if (MainCarouselView.CurrentItem == "ck1.jpg")
                {
                    cake = "Cake 1";
                }
                else if (MainCarouselView.CurrentItem == "ck2.jpg")
                {
                    cake = "Cake 2";
                }
                else if (MainCarouselView.CurrentItem == "ck3.jpg")
                {
                    cake = "Cake 3";
                }
                else if (MainCarouselView.CurrentItem == "ck4.jpg")
                {
                    cake = "Cake 4";
                }
                else if (MainCarouselView.CurrentItem == "ck5.jpg")
                {
                    cake = "Cake 5";
                }
                else if (MainCarouselView.CurrentItem == "ck6.jpg")
                {
                    cake = "Cake 6";
                }
                else if (MainCarouselView.CurrentItem == "ck7.jpg")
                {
                    cake = "Cake 7";
                }
                else if (MainCarouselView.CurrentItem == "ck8.jpg")
                {
                    cake = "Cake 8";
                }
                else if (MainCarouselView.CurrentItem == "ck9.jpg")
                {
                    cake = "Cake 9";
                }
                else if (MainCarouselView.CurrentItem == "ck10.jpg")
                {
                    cake = "Cake 10";
                }
                else if (MainCarouselView.CurrentItem == "ck11.jpg")
                {
                    cake = "Cake 11";
                }
                else if (MainCarouselView.CurrentItem == "ck12.jpg")
                {
                    cake = "Cake 12";
                }

            }
                else
                {
                    btnck.Text = "Select";
                    MainCarouselView.IsSwipeEnabled = true;
                    x = true;
                    cake = "";
                }
            
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
            BirthdayInfo.IsVisible = false;
            Cakestack.IsVisible = false;
            Foodstack.IsVisible = true;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = false;
            cp.BackgroundImageSource = "abg";
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
            BirthdayInfo.IsVisible = false;
            Cakestack.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = true;
            Decorstack.IsVisible = false;
            cp.BackgroundImageSource = "abg";
            if (c4 == 0)
            {
                sn = "camera.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c4++;
            }
            else { }
        }




        ////////////////////////DecorStack/////////////////////////////////

        string SDecor = "";
        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            bl4.IsVisible = false;
            bl5.IsVisible = true;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            BirthdayInfo.IsVisible = false;
            Cakestack.IsVisible = false;
            Foodstack.IsVisible = false;
            Photostack.IsVisible = false;
            Decorstack.IsVisible = true;
            cp.BackgroundImageSource = "bbg";
            if (c5 == 0)
            {
                sn = "bde.json";
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
                Guests = Convert.ToInt32(d4.Text),
                Timing = d2.Time.ToString(),
                Location = d3.Text.ToString(),
                CakeName = cake,
                CakeQuantity = Convert.ToDouble(ck1.Text),
                CakeRate = (Convert.ToDouble(ck1.Text)) * 500,
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

            mPhotographerBook mp = new mPhotographerBook()
            {
                EventId = evId,
                PId = Convert.ToInt32(pid),
                PhotographerName = sphoto,
                PhotographerPrice = prate,
            };
            SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
            con4.CreateTable<mPhotographerBook>();
            con4.Insert(mp);
            con4.Close();

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
            Navigation.PushAsync(new MasterPage(a, d, f, g, h));




        }

        private void oButton_Clicked_1(object sender, EventArgs e)
        {
            ms1.IsVisible = true;
            ms2.IsVisible = false;
            BottomBar.IsVisible = true;
            NavigationPage.SetHasNavigationBar(this, true);
            cp.BackgroundImageSource = "abg";
        }
    }
}