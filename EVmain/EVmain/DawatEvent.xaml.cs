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
    public partial class DawatEvent : ContentPage
    {
        public int c1 = 0, c2 = 0, c3 = 0, cpr= 0;
        public string sn = "lunch.json";
        string sid, fid, pid, evtype, cnm = "", cid = "";
        List<string> fname = new List<string>();
        List<int> frate = new List<int>();
        List<int> fquan = new List<int>();
        string[] fn = new string[100];
        int[] fr = new int[100];
        int[] fq = new int[100];
        int evId = 0;
        double totalbill = 0.0;

        int[] Cid = new int[100];
        string[] Cname = new string[100];
        string[] Cpic = new string[100];
        int[] Cprice = new int[100];
        int[] Crating = new int[100];

        int[] Fid = new int[100];
        string[] FoodName = new string[100];
        string[] FoodPic = new string[100];
        int[] FoodPrice = new int[100];
        byte[] imagearray;
        public DawatEvent(string userID, string EventType)
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
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            DawatInfo.IsVisible = true;
            CateringStack.IsVisible = false;
            FoodStack.IsVisible = false;
            ms2.IsVisible = false;


            Label lb = new Label()
            {
                Text = "Select Catering Service",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 30,
                TextColor = Color.WhiteSmoke,
            };

            CateringStack.Children.Add(lb);

            Label l = new Label()
            {
                Text = "Select Food Items",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 30,
                TextColor = Color.WhiteSmoke,
            };

            FoodStack.Children.Add(l);


            int x = 0;

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Catering>();
            var users = con.Table<Catering>().ToList();
            var ad = con.Query<Catering>("Select * from Catering");
            con.Close();
            foreach (var s in ad)
            {
                Cid[x] = s.CatId;
                Cname[x] = s.CatName;
                Cpic[x] = s.CatPic;
                Cprice[x] = s.CatPrice;
                Crating[x] = Convert.ToInt32(s.CatRating);
                imagearray = s.imgbyte;
                CatCreation(Cid[x].ToString(), Cname[x], imagearray, Cpic[x], Cprice[x], Crating[x]);
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
                FoodStack.Children.Add(Food);

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
                FoodStack.Children.Add(Food);

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



        void CatCreation(string Ctid, string CtName, byte[] ppic, string CtPic, int CtPrice, int CtRating)
        {
            byte[] b = ppic;

            if(ppic == null)
            {
                bool x = true;
                StackLayout Catering = new StackLayout();

                CateringStack.Children.Add(Catering);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Catering.Children.Add(S1);
                Label Cname = new Label
                {
                    Text = CtName,
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

                S1.Children.Add(Cname);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };
                Catering.Children.Add(S2);



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
                        Source = CtPic,
                        Aspect = Aspect.AspectFill,
                    }
                };

                S2.Children.Add(ff);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Catering.Children.Add(S3);

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
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(Ctid)));
                }


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
                    InitialValue = CtRating,
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
                    Text = CtPrice.ToString(),
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


                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sende, EventArgs ee)
                {
                    if (cnm == "")
                    {
                        cb.IsVisible = true;
                        cb.IsEnabled = true;
                        cb.IsChecked = true;
                        button.Text = "Selected";
                        button.IsEnabled = false;
                        S3.IsVisible = false;
                        x = false;
                        cnm = CtName;
                        cpr = CtPrice;
                        cid = Ctid;
                    }
                    else
                    {
                        DisplayAlert("Error", "Catering Service Already Selected", "Ok");
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
                        cnm = "";
                        cpr = 0;
                        cid = "";
                    }
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
                bool x = true;
                Stream ms = new MemoryStream(b);
                StackLayout Catering = new StackLayout();

                CateringStack.Children.Add(Catering);

                StackLayout S1 = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Catering.Children.Add(S1);
                Label Cname = new Label
                {
                    Text = CtName,
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

                S1.Children.Add(Cname);
                S1.Children.Add(cb);

                StackLayout S2 = new StackLayout()
                {
                    Padding = new Thickness(20, 0),
                };
                Catering.Children.Add(S2);



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
                        Source = CtPic,
                        Aspect = Aspect.AspectFill,
                    }
                };

                S2.Children.Add(ff);

                StackLayout S3 = new StackLayout()
                {
                    IsVisible = false,
                };

                Catering.Children.Add(S3);

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
                    Navigation.PushAsync(new GalleryView(Convert.ToInt32(Ctid)));
                }

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
                    InitialValue = CtRating,
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
                    Text = CtPrice.ToString(),
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


                cb.CheckedChanged += Cb_CheckedChanged;


                void Button_Clicked(object sende, EventArgs ee)
                {
                    if (cnm == "")
                    {
                        cb.IsVisible = true;
                        cb.IsEnabled = true;
                        cb.IsChecked = true;
                        button.Text = "Selected";
                        button.IsEnabled = false;
                        S3.IsVisible = false;
                        x = false;
                        cnm = CtName;
                        cpr = CtPrice;
                        cid = Ctid;
                    }
                    else
                    {
                        DisplayAlert("Error", "Catering Service Already Selected", "Ok");
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
                        cnm = "";
                        cpr = 0;
                        cid = "";
                    }
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


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool cc1, cc2, cc3, cc4, cc6, cc7;
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

            if (cnm == "" || cnm == null)
            {

                err += "Please Select the catering service\n";
                cc4 = false;
            }
            else
            {
                cc4 = true;
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

            if (fname.Count == 0)
            {
                err += "Please Select atleast 1 food item\n";
                cc6 = false;
            }
            else
            {
                cc6 = true;
            }

            if (cc1 == true && cc2 == true && cc3 == true && cc4 == true && cc6 == true && cc7 == true)
            {

                int x = 0;
                string hname;
                int p;
                int qu = 0;
                int fp = 0;
                totalbill += cpr;


                olb1.Text = evtype.ToString();
                olb2.Text = d1.Date.ToShortDateString();
                olb3.Text = d2.Time.ToString();
                olb41.Text = d4.Text.ToString();
                olb4.Text = d3.Text;
                olb5.Text = cnm;
                olb6.Text = cpr.ToString();

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

        ////////////////////////DawatInfo/////////////////////////////////

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            bl1.IsVisible = true;
            bl2.IsVisible = false;
            bl3.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            DawatInfo.IsVisible = true;
            CateringStack.IsVisible = false;
            FoodStack.IsVisible = false;
        }

        ////////////////////////Catering/////////////////////////////////

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            bl1.IsVisible = false;
            bl2.IsVisible = true;
            bl3.IsVisible = false;
            BottomBar.BackgroundColor = Color.FromHex("#b68948");
            DawatInfo.IsVisible = false;
            CateringStack.IsVisible = true;
            FoodStack.IsVisible = false;

            if (c2 == 0)
            {
                sn = "cater.json";
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
            BottomBar.BackgroundColor = Color.FromHex("#1b1b1b");
            DawatInfo.IsVisible = false;
            CateringStack.IsVisible = false;
            FoodStack.IsVisible = true;

            if (c3 == 0)
            {
                sn = "food2.json";
                PopupNavigation.Instance.PushAsync(new Page1(sn)); c3++;
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


            mCatBook mp = new mCatBook()
            {
                EventId = evId,
                Catname = cnm,
                CatId = Convert.ToInt32(cid),
                Catrate = cpr,
            };
            SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
            con4.CreateTable<mCatBook>();
            con4.Insert(mp);
            con4.Close();


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