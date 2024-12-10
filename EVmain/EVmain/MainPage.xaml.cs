using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using EVmain.Model;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.IO;

namespace EVmain
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }



        protected override void OnAppearing()
        {
           
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Users>();
            var nms = con.Query<Users>("Select UserId from Users");

            int x = nms.Count;


            if (x > 0)
            {

            }

            else
            {
                Users uh1 = new Users()
                {
                    UserId = 1,
                    UserName = "h1",
                    FullName = "Hall 1",
                    Email = "h1@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Hall",
                };

                Users uh2 = new Users()
                {
                    UserId = 2,
                    UserName = "h2",
                    FullName = "Hall 2",
                    Email = "h2@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Hall",
                };

                Users uh3 = new Users()
                {
                    UserId = 3,
                    UserName = "h3",
                    FullName = "Hall 3",
                    Email = "h3@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Hall",
                };

                Users ph1 = new Users()
                {
                    UserId = 4,
                    UserName = "p1",
                    FullName = "Photographer 1",
                    Email = "p1@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Photographer",
                };
                Users ph2 = new Users()
                {
                    UserId = 5,
                    UserName = "p2",
                    FullName = "Photographer 2",
                    Email = "p2@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Photographer",
                };
                Users ph3 = new Users()
                {
                    UserId = 6,
                    UserName = "p3",
                    FullName = "Photographer 3",
                    Email = "p3@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Photographer",
                };
               
                Users ch1 = new Users()
                {
                    UserId = 7,
                    UserName = "c1",
                    FullName = "Cateringr 1",
                    Email = "c1@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Catering",
                };
                Users ch2 = new Users()
                {
                    UserId = 8,
                    UserName = "c2",
                    FullName = "Catering 2",
                    Email = "c2@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Catering",
                };
                Users ch3 = new Users()
                {
                    UserId = 9,
                    UserName = "c3",
                    FullName = "Catering 3",
                    Email = "c3@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Catering",
                };

                Users dh1 = new Users()
                {
                    UserId = 10,
                    UserName = "d1",
                    FullName = "Decorator 1",
                    Email = "d1@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Decorator",
                };
                Users dh2 = new Users()
                {
                    UserId = 11,
                    UserName = "d2",
                    FullName = "Decorator 2",
                    Email = "d2@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Decorator",
                };
                Users dh3 = new Users()
                {
                    UserId = 12,
                    UserName = "d3",
                    FullName = "Decorator 3",
                    Email = "d3@yahoo.com",
                    PhoneNumber = "1234",
                    Password = "12345678",
                    UserType = "Decorator",
                };


                con.Insert(uh1);
                con.Insert(uh2);
                con.Insert(uh3);
                con.Insert(ph1);
                con.Insert(ph2);
                con.Insert(ph3);
                con.Insert(ch1);
                con.Insert(ch2);
                con.Insert(ch3);
                con.Insert(dh1);
                con.Insert(dh2);
                con.Insert(dh3);
                con.Close();
            }

            

            SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
            con1.CreateTable<Halls>();
            var nms1 = con1.Query<Halls>("Select HallId from Halls");

            int x1 = nms1.Count;


            if (x1 > 0)
            {

            }

            else
            {
                SQLiteConnection cong = new SQLiteConnection(App.Databaselocation);
                cong.CreateTable<Gallery>();

                Halls h1 = new Halls()
                {
                    HallId = 1,
                    HallName = "Milan Hall",
                    HallPic = "b1.jpg",
                    HallRating = 4,
                    HallPrice = 35000,
                    HallLang = 30.176738,
                    HallLong = 66.993873,
                    Address = "Milan Marriage Garden, Sariab Rd, Gulistan St,Quetta",
                    TotalRatings = 1,
                    OverallRatings = 4,
                };

                Gallery h1g1 = new Gallery()
                {
                    Id = 1,
                    PicNum = 1,
                    imgsource = "hall2",
                };

                Gallery h1g2 = new Gallery()
                {
                    Id = 1,
                    PicNum = 2,
                    imgsource = "hall1",
                };
                Gallery h1g3 = new Gallery()
                {
                    Id = 1,
                    PicNum = 3,
                    imgsource = "hall3",
                };
                Gallery h1g4 = new Gallery()
                {
                    Id = 1,
                    PicNum = 4,
                    imgsource = "hall4",
                };
                Gallery h1g5 = new Gallery()
                {
                    Id = 1,
                    PicNum = 5,
                    imgsource = "hall5",
                };
                Halls h2 = new Halls()
                {
                    HallId = 2,
                    HallName = "Milak Hall",
                    HallPic = "b2.jpg",
                    HallRating = 5,
                    HallPrice = 50000,
                    HallLang = 30.198418,
                    HallLong = 67.024906,
                    Address = "Milak Banquet Hall, Shara Gulistan Road,Quetta",
                    TotalRatings = 1,
                    OverallRatings = 5,
                };
                Gallery h2g1 = new Gallery()
                {
                    Id = 2,
                    PicNum = 1,
                    imgsource = "hall2",
                };

                Gallery h2g2 = new Gallery()
                {
                    Id = 2,
                    PicNum = 2,
                    imgsource = "hall1",
                };
                Gallery h2g3 = new Gallery()
                {
                    Id = 2,
                    PicNum = 3,
                    imgsource = "hall3",
                };
                Gallery h2g4 = new Gallery()
                {
                    Id = 2,
                    PicNum = 4,
                    imgsource = "hall4",
                };
                Gallery h2g5 = new Gallery()
                {
                    Id = 2,
                    PicNum = 5,
                    imgsource = "hall5",
                };
                Halls h3 = new Halls()
                {
                    HallId = 3,
                    HallName = "Imran Hall",
                    HallPic = "b3.jpg",
                    HallRating = 2,
                    HallPrice = 20000,
                    HallLang = 30.188146,
                    HallLong = 67.017023,
                    Address = "Imran Marriage Hall, Khudiadad Road, Quetta",
                    TotalRatings = 1,
                    OverallRatings = 2,
                };
                Gallery h3g1 = new Gallery()
                {
                    Id = 3,
                    PicNum = 1,
                    imgsource = "hall2",
                };

                Gallery h3g2 = new Gallery()
                {
                    Id = 3,
                    PicNum = 2,
                    imgsource = "hall1",
                };
                Gallery h3g3 = new Gallery()
                {
                    Id = 3,
                    PicNum = 3,
                    imgsource = "hall3",
                };
                Gallery h3g4 = new Gallery()
                {
                    Id = 3,
                    PicNum = 4,
                    imgsource = "hall4",
                };
                Gallery h3g5 = new Gallery()
                {
                    Id = 3,
                    PicNum = 5,
                    imgsource = "hall5",
                };

                cong.Insert(h1g1);
                cong.Insert(h1g2);
                cong.Insert(h1g3);
                cong.Insert(h1g4);
                cong.Insert(h1g5);
                cong.Insert(h2g1);
                cong.Insert(h2g2);
                cong.Insert(h2g3);
                cong.Insert(h2g4);
                cong.Insert(h2g5);
                cong.Insert(h3g1);
                cong.Insert(h3g2);
                cong.Insert(h3g3);
                cong.Insert(h3g4);
                cong.Insert(h3g5);
                cong.Close();


                con1.Insert(h1);
                con1.Insert(h2);
                con1.Insert(h3);
                con1.Close();

                

            }


            SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
            con2.CreateTable<photogr>();
            var nms2 = con2.Query<photogr>("Select PhotographerId from photogr");

            int x2 = nms2.Count;


            if (x2 > 0)
            {

            }

            else
            {
                photogr p1 = new photogr()
                {
                    PhotographerId = 4,
                    PhotographerName = "Photographer 1",
                    PhotographerPic = "p1",
                    PhotographerRating = 4,
                    PhotographerPrice = 15000,
                    TotalRatings = 1,
                    OverallRatings = 4,
                };

                photogr p2 = new photogr()
                {
                    PhotographerId = 5,
                    PhotographerName = "Photographer 2",
                    PhotographerPic = "p2",
                    PhotographerRating = 5,
                    PhotographerPrice = 25000,
                    TotalRatings = 1,
                    OverallRatings = 5,
                };

                photogr p3 = new photogr()
                {
                    PhotographerId = 6,
                    PhotographerName = "Photographer 3",
                    PhotographerPic = "p3",
                    PhotographerRating = 2,
                    PhotographerPrice = 12000,
                    TotalRatings = 1,
                    OverallRatings = 2,
                };
                con2.Insert(p1);
                con2.Insert(p2);
                con2.Insert(p3);
                con2.Close();

                SQLiteConnection cong = new SQLiteConnection(App.Databaselocation);
                cong.CreateTable<Gallery>();

                Gallery p1g1 = new Gallery()
                {
                    Id = 4,
                    PicNum = 1,
                    imgsource = "photographer1",
                };

                Gallery p1g2 = new Gallery()
                {
                    Id = 4,
                    PicNum = 2,
                    imgsource = "photographer2",
                };
                Gallery p1g3 = new Gallery()
                {
                    Id = 4,
                    PicNum = 3,
                    imgsource = "photographer3",
                };
                Gallery p1g4 = new Gallery()
                {
                    Id = 4,
                    PicNum = 4,
                    imgsource = "photographer4",
                };
                Gallery p1g5 = new Gallery()
                {
                    Id = 4,
                    PicNum = 5,
                    imgsource = "photographer5",
                };

                Gallery p2g1 = new Gallery()
                {
                    Id = 5,
                    PicNum = 1,
                    imgsource = "photographer1",
                };

                Gallery p2g2 = new Gallery()
                {
                    Id =5,
                    PicNum = 2,
                    imgsource = "photographer2",
                };
                Gallery p2g3 = new Gallery()
                {
                    Id =5,
                    PicNum = 3,
                    imgsource = "photographer3",
                };
                Gallery p2g4 = new Gallery()
                {
                    Id = 5,
                    PicNum = 4,
                    imgsource = "photographer4",
                };
                Gallery p2g5 = new Gallery()
                {
                    Id = 6,
                    PicNum = 5,
                    imgsource = "photographer5",
                };

                Gallery p3g1 = new Gallery()
                {
                    Id = 6,
                    PicNum = 1,
                    imgsource = "photographer1",
                };

                Gallery p3g2 = new Gallery()
                {
                    Id = 6,
                    PicNum = 2,
                    imgsource = "photographer2",
                };
                Gallery p3g3 = new Gallery()
                {
                    Id = 6,
                    PicNum = 3,
                    imgsource = "photographer3",
                };
                Gallery p3g4 = new Gallery()
                {
                    Id = 6,
                    PicNum = 4,
                    imgsource = "photographer4",
                };
                Gallery p3g5 = new Gallery()
                {
                    Id = 6,
                    PicNum = 5,
                    imgsource = "photographer5",
                };

                cong.Insert(p1g1);
                cong.Insert(p1g2);
                cong.Insert(p1g3);
                cong.Insert(p1g4);
                cong.Insert(p1g5);
                cong.Insert(p2g1);
                cong.Insert(p2g2);
                cong.Insert(p2g3);
                cong.Insert(p2g4);
                cong.Insert(p2g5);
                cong.Insert(p3g1);
                cong.Insert(p3g2);
                cong.Insert(p3g3);
                cong.Insert(p3g4);
                cong.Insert(p3g5);
                cong.Close();
            }

            SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
            con3.CreateTable<Catering>();
            var nms3 = con3.Query<Catering>("Select CatId from Catering");

            int x3 = nms3.Count;


            if (x3 > 0)
            {

            }

            else
            {
                Catering c1 = new Catering()
                {
                    CatId = 7,
                    CatName = "Imran Tent",
                    CatPic = "itent",
                    CatPrice = 15000,
                    CatRating = 4,
                    TotalRatings = 1,
                    OverallRatings = 4,
                };

                Catering c2 = new Catering()
                {
                    CatId = 8,
                    CatName = "Madina Tent",
                    CatPic = "mtent",
                    CatPrice = 25000,
                    CatRating = 5,
                    TotalRatings = 1,
                    OverallRatings = 5,
                };

                Catering c3 = new Catering()
                {
                    CatId = 9,
                    CatName = "Dubai Tent",
                    CatPic = "dubaitent",
                    CatPrice = 12000,
                    CatRating = 2,
                    TotalRatings = 1,
                    OverallRatings = 2,
                };

                con3.Insert(c1);
                con3.Insert(c2);
                con3.Insert(c3);
                con3.Close();

                SQLiteConnection cong = new SQLiteConnection(App.Databaselocation);
                cong.CreateTable<Gallery>();

                Gallery p1g1 = new Gallery()
                {
                    Id = 7,
                    PicNum = 1,
                    imgsource = "catering1",
                };

                Gallery p1g2 = new Gallery()
                {
                    Id = 7,
                    PicNum = 2,
                    imgsource = "catering2",
                };
                Gallery p1g3 = new Gallery()
                {
                    Id = 7,
                    PicNum = 3,
                    imgsource = "catering3",
                };
                Gallery p1g4 = new Gallery()
                {
                    Id = 7,
                    PicNum = 4,
                    imgsource = "catering4",
                };
                Gallery p1g5 = new Gallery()
                {
                    Id = 7,
                    PicNum = 5,
                    imgsource = "catering5",
                };

                Gallery p2g1 = new Gallery()
                {
                    Id = 8,
                    PicNum = 1,
                    imgsource = "catering1",
                };

                Gallery p2g2 = new Gallery()
                {
                    Id = 8,
                    PicNum = 2,
                    imgsource = "catering2",
                };
                Gallery p2g3 = new Gallery()
                {
                    Id = 8,
                    PicNum = 3,
                    imgsource = "catering3",
                };
                Gallery p2g4 = new Gallery()
                {
                    Id = 8,
                    PicNum = 4,
                    imgsource = "catering4",
                };
                Gallery p2g5 = new Gallery()
                {
                    Id = 8,
                    PicNum = 5,
                    imgsource = "catering5",
                };

                Gallery p3g1 = new Gallery()
                {
                    Id = 8,
                    PicNum = 1,
                    imgsource = "catering1",
                };

                Gallery p3g2 = new Gallery()
                {
                    Id = 9,
                    PicNum = 2,
                    imgsource = "catering2",
                };
                Gallery p3g3 = new Gallery()
                {
                    Id = 9,
                    PicNum = 3,
                    imgsource = "catering3",
                };
                Gallery p3g4 = new Gallery()
                {
                    Id = 9,
                    PicNum = 4,
                    imgsource = "catering4",
                };
                Gallery p3g5 = new Gallery()
                {
                    Id = 9,
                    PicNum = 5,
                    imgsource = "catering5",
                };

                cong.Insert(p1g1);
                cong.Insert(p1g2);
                cong.Insert(p1g3);
                cong.Insert(p1g4);
                cong.Insert(p1g5);
                cong.Insert(p2g1);
                cong.Insert(p2g2);
                cong.Insert(p2g3);
                cong.Insert(p2g4);
                cong.Insert(p2g5);
                cong.Insert(p3g1);
                cong.Insert(p3g2);
                cong.Insert(p3g3);
                cong.Insert(p3g4);
                cong.Insert(p3g5);
                cong.Close();

            }

            SQLiteConnection con5 = new SQLiteConnection(App.Databaselocation);
            con5.CreateTable<Decorator>();
            var nms5 = con5.Query<Decorator>("Select DecoratorId from Decorator");

            int x5 = nms5.Count;


            if (x5 > 0)
            {

            }

            else
            {
                Decorator d1 = new Decorator()
                {
                    DecoratorId = 10,
                    DecoratorName = "Decorator 1",
                    DecoratorPic = "d1",
                    DecoratorPrice = 15000,
                    DecoratorRating = 4,
                    TotalRatings = 1,
                    OverallRatings = 4,
                };

                Decorator d2 = new Decorator()
                {
                    DecoratorId = 11,
                    DecoratorName = "Decorator 2",
                    DecoratorPic = "d2",
                    DecoratorPrice = 25000,
                    DecoratorRating = 5,
                    TotalRatings = 1,
                };

                Decorator d3 = new Decorator()
                {
                    DecoratorId = 12,
                    DecoratorName = "Decorator 3",
                    DecoratorPic = "d3",
                    DecoratorPrice = 12000,
                    DecoratorRating = 2,
                    TotalRatings = 1,
                    OverallRatings = 2,
                };

                con5.Insert(d1);
                con5.Insert(d2);
                con5.Insert(d3);
                con5.Close();

                SQLiteConnection cong = new SQLiteConnection(App.Databaselocation);
                cong.CreateTable<Gallery>();

                Gallery p1g1 = new Gallery()
                {
                    Id = 10,
                    PicNum = 1,
                    imgsource = "decoration1",
                };

                Gallery p1g2 = new Gallery()
                {
                    Id = 10,
                    PicNum = 2,
                    imgsource = "decoration2",
                };
                Gallery p1g3 = new Gallery()
                {
                    Id = 10,
                    PicNum = 3,
                    imgsource = "decoration3",
                };
                Gallery p1g4 = new Gallery()
                {
                    Id = 10,
                    PicNum = 4,
                    imgsource = "decoration4",
                };
                Gallery p1g5 = new Gallery()
                {
                    Id = 10,
                    PicNum = 5,
                    imgsource = "decoration5",
                };

                Gallery p2g1 = new Gallery()
                {
                    Id = 11,
                    PicNum = 1,
                    imgsource = "decoration1",
                };

                Gallery p2g2 = new Gallery()
                {
                    Id = 11,
                    PicNum = 2,
                    imgsource = "decoration2",
                };
                Gallery p2g3 = new Gallery()
                {
                    Id = 11,
                    PicNum = 3,
                    imgsource = "decoration3",
                };
                Gallery p2g4 = new Gallery()
                {
                    Id = 11,
                    PicNum = 4,
                    imgsource = "decoration4",
                };
                Gallery p2g5 = new Gallery()
                {
                    Id = 11,
                    PicNum = 5,
                    imgsource = "decoration5",
                };

                Gallery p3g1 = new Gallery()
                {
                    Id = 12,
                    PicNum = 1,
                    imgsource = "decoration1",
                };

                Gallery p3g2 = new Gallery()
                {
                    Id = 12,
                    PicNum = 2,
                    imgsource = "decoration2",
                };
                Gallery p3g3 = new Gallery()
                {
                    Id = 12,
                    PicNum = 3,
                    imgsource = "decoration3",
                };
                Gallery p3g4 = new Gallery()
                {
                    Id = 12,
                    PicNum = 4,
                    imgsource = "decoration4",
                };
                Gallery p3g5 = new Gallery()
                {
                    Id = 12,
                    PicNum = 5,
                    imgsource = "decoration5",
                };

                cong.Insert(p1g1);
                cong.Insert(p1g2);
                cong.Insert(p1g3);
                cong.Insert(p1g4);
                cong.Insert(p1g5);
                cong.Insert(p2g1);
                cong.Insert(p2g2);
                cong.Insert(p2g3);
                cong.Insert(p2g4);
                cong.Insert(p2g5);
                cong.Insert(p3g1);
                cong.Insert(p3g2);
                cong.Insert(p3g3);
                cong.Insert(p3g4);
                cong.Insert(p3g5);
                cong.Close();
            }


            SQLiteConnection con4 = new SQLiteConnection(App.Databaselocation);
            con4.CreateTable<FoodIt>();
            var nms4 = con4.Query<FoodIt>("Select FoodId from FoodIt");

            int x4 = nms4.Count;


            if (x4 > 0)
            {

            }

            else
            {
                FoodIt f1 = new FoodIt()
                {
                    FoodName = "Biryani",
                    FoodId = 1,
                    FoodPic = "biryani",
                    FoodPrice = 500,
                };

                FoodIt f2 = new FoodIt()
                {
                    FoodName = "Kabab",
                    FoodId = 2,
                    FoodPic = "kabab",
                    FoodPrice = 800,
                };

                FoodIt f3 = new FoodIt()
                {
                    FoodName = "Korma",
                    FoodId = 3,
                    FoodPic = "korma",
                    FoodPrice = 400,
                };

                FoodIt f4 = new FoodIt()
                {
                    FoodName = "Palak Gosht",
                    FoodId = 4,
                    FoodPic = "pg",
                    FoodPrice = 200,
                };

                FoodIt f5 = new FoodIt()
                {
                    FoodName = "Roast",
                    FoodId = 5,
                    FoodPic = "roast",
                    FoodPrice = 300,
                };

                con4.Insert(f1);
                con4.Insert(f2);
                con4.Insert(f3);
                con4.Insert(f4);
                con4.Insert(f5);
                con4.Close();
            }

        }

            private void Login_Clicked(object sender, EventArgs e)
        {

              SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
              con.CreateTable<Users>();
              var nms = con.Query<Users>("Select UserId from Users where UserName = ? and Password = ?", name.Text, ps1.Text);



            string[] arr = new string[1];
            foreach (var s in nms)
            {
                arr[0] = s.UserId.ToString();
            }

            string idd = "";
            idd = arr[0];
            var data = con.Query<Users>("Select * from Users where UserId = ?", idd);

            string[] dat = new string[6];
            foreach (var s in data)
            {
                dat[0] = s.UserId.ToString();
                dat[1] = s.FullName;
                dat[2] = s.PhoneNumber;
                dat[3] = s.Email;
                dat[4] = s.Password;
                dat[5] = s.UserType;
            }

            con.Close();

            int x = nms.Count;


              if (name.Text == "admin" && ps1.Text == "admin")
              {
                  Navigation.PushAsync(new Admin_View());
              }

              else if(x > 0 && dat[5] == "Customer")
              {
                Navigation.PushAsync(new MasterPage(dat[0], dat[1], dat[2], dat[3], dat[4]));
              }
            else if (x > 0 && dat[5] == "Hall")
            {
               Navigation.PushAsync(new HallMainPage(dat[0], dat[1], dat[2], dat[3], dat[4], dat[5]));

            }
            else if (x > 0 && dat[5] == "Photographer")
              {
                Navigation.PushAsync(new PhotographerMainPage(dat[0], dat[1], dat[2], dat[3], dat[4]));
            }
              else if (x > 0 && dat[5] == "Catering")
              {
                Navigation.PushAsync(new CateringMainPage(dat[0], dat[1], dat[2], dat[3], dat[4]));

            }

            else if (x > 0 && dat[5] == "Decorator")
            {
                Navigation.PushAsync(new DecoratorMainPage(dat[0], dat[1], dat[2], dat[3], dat[4]));

            }


            else
              {
                  DisplayAlert("", "UserName or Password is incorrect", "ok");
              } 

            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {         
            Navigation.PushAsync(new SignUp());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PartnerSignUp());
        }
    }
}
