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
    public partial class MarriageEventTableEdit : ContentPage
    {
        string SId, evtype;
        public MarriageEventTableEdit()
        {
            InitializeComponent();

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            var xxx = con.Query<MarriageEvent>("Select EventId from MarriageEvent");
            foreach (var k in xxx)
            {
                pik.Items.Add(k.EventId.ToString());
            }
            con.Close();
        }



        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            con.Delete<MarriageEvent>(SId);

            DisplayAlert("Success", "Deleted Successfully", "Ok");
            pik.SelectedIndex--;
            con.Close();
        }



        private void pik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pik.SelectedItem == null || pik.SelectedItem == "")
            {
                SId = "";
            }
            else
            {
                SId = pik.SelectedItem.ToString();
            }


            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<MarriageEvent>();
            var asd = con.Query<MarriageEvent>("Select * from MarriageEvent where EventId = ?", SId);
            foreach (var k in asd)
            {
                if (SId == null || SId == "")
                {
                    e1.Text = "";
                    e2.Text = "";
                    e3.Text = "";
                    e4.Text = "";
                    e5.Text = "";
                    e6.Text = "";
                    e7.Text = "";
                    e8.Text = "";
                    e9.Text = "";
                    e10.Text = "";
                    e11.Text = "";
                    e12.Text = "";
                    e13.Text = "";
                }
                else
                {
                    evtype = k.EventType;
                    if (k.EventId != null || k.EventId != 0)
                    {
                        if (k.EventType == "Marriage")
                        {

                            e1.Text = k.UserId.ToString();
                            e2.Text = k.Date;
                            e3.Text = k.Guests.ToString();
                            e4.Text = k.Timing;


                            e5.IsVisible = true;
                            e6.IsVisible = true;



                            e7.IsVisible = true;
                            e8.IsVisible = true;


                            e10.IsVisible = true;
                            e11.IsVisible = true;




                            e12.IsVisible = false;
                            e13.IsVisible = false;

                            l1.Text = "Hall";
                            l2.Text = "Hall Price";
                            l3.Text = "Photographer";
                            l4.Text = "Photographer Price";
                            l5.Text = "Decorator";
                            l6.Text = "Decorator Price";


                            l1.IsVisible = true;
                            l2.IsVisible = true;
                            l3.IsVisible = true;
                            l4.IsVisible = true;
                            l5.IsVisible = true;
                            l6.IsVisible = true;

                            l7.IsVisible = false;
                            l8.IsVisible = false;

                            SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
                            con1.CreateTable<mHallBook>();
                            var asdf = con1.Query<mHallBook>("Select * from mHallBook where EventId = ?", SId);
                            foreach (var kk in asdf)
                            {
                                e5.Text = kk.Hallname;
                                e6.Text = kk.Hallrate.ToString();
                            }
                            con1.Close();

                            e9.Text = k.TotalBill.ToString();

                            SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                            con2.CreateTable<mPhotographerBook>();
                            var asdf2 = con2.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", SId);
                            foreach (var kk in asdf2)
                            {

                                e7.Text = kk.PhotographerName;
                                e8.Text = kk.PhotographerPrice.ToString();

                            }
                            con2.Close();

                            SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                            con3.CreateTable<mDecor>();
                            var asdf3 = con3.Query<mDecor>("Select * from mDecor where EventId = ?", SId);
                            foreach (var kk in asdf3)
                            {

                                e10.Text = kk.DecoratorName;
                                e11.Text = kk.DecoratorPrice.ToString();

                            }
                            con3.Close();
                            e9.Text = k.TotalBill.ToString();
                        }

                        else if (k.EventType == "Birthday")
                        {
                            e5.IsVisible = true;
                            e6.IsVisible = true;
                            e7.IsVisible = true;
                            e8.IsVisible = true;
                            e10.IsVisible = true;
                            e11.IsVisible = true;
                            e12.IsVisible = true;
                            e13.IsVisible = true;
                            l1.Text = "Cake Name";
                            l2.Text = "Cake Rate";
                            l3.Text = "Cake Quantity";
                            l4.Text = "Location";
                            l5.Text = "Decorator";
                            l6.Text = "Decorator Price";
                            l1.IsVisible = true;
                            l2.IsVisible = true;
                            l3.IsVisible = true;
                            l4.IsVisible = true;
                            l5.IsVisible = true;
                            l6.IsVisible = true;
                            l7.IsVisible = true;
                            l8.IsVisible = true;

                            e1.Text = k.UserId.ToString();
                            e2.Text = k.Date;
                            e3.Text = k.Guests.ToString();
                            e4.Text = k.Timing;
                            e5.Text = k.CakeName;
                            e6.Text = k.CakeQuantity.ToString();
                            e7.Text = k.CakeRate.ToString();
                            e8.Text = k.Location;
                            e9.Text = k.TotalBill.ToString();

                            SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                            con2.CreateTable<mPhotographerBook>();
                            var asdf2 = con2.Query<mPhotographerBook>("Select * from mPhotographerBook where EventId = ?", SId);
                            foreach (var kk in asdf2)
                            {

                                e12.Text = kk.PhotographerName;
                                e13.Text = kk.PhotographerPrice.ToString();

                            }
                            con2.Close();

                            SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                            con3.CreateTable<mDecor>();
                            var asdf3 = con3.Query<mDecor>("Select * from mDecor where EventId = ?", SId);
                            foreach (var kk in asdf3)
                            {

                                e10.Text = kk.DecoratorName;
                                e11.Text = kk.DecoratorPrice.ToString();

                            }
                            con3.Close();
                        }

                        else if (k.EventType == "Dawat")
                        {
                            e5.IsVisible = true;
                            e6.IsVisible = true;
                            e7.IsVisible = false;
                            e8.IsVisible = true;
                            e10.IsVisible = false;
                            e11.IsVisible = false;
                            e12.IsVisible = false;
                            e13.IsVisible = false;
                            l1.IsVisible = true;
                            l2.IsVisible = true;
                            l3.IsVisible = false;
                            l4.IsVisible = true;
                            l5.IsVisible = false;
                            l6.IsVisible = false;
                            l7.IsVisible = false;
                            l8.IsVisible = false;
                            l1.Text = "Catering";
                            l2.Text = "Catering Rate";
                            l4.Text = "Location";

                            e1.Text = k.UserId.ToString();
                            e2.Text = k.Date;
                            e3.Text = k.Guests.ToString();
                            e4.Text = k.Timing;

                            SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                            con3.CreateTable<mCatBook>();
                            var asdf3 = con3.Query<mCatBook>("Select * from mCatBook where EventId = ?", SId);
                            foreach (var kk in asdf3)
                            {

                                e5.Text = kk.Catname;
                                e6.Text = kk.Catrate.ToString();

                            }
                            con3.Close();

                            e8.Text = k.Location;
                            e9.Text = k.TotalBill.ToString();
                        }
                    }
                }
            }
            con.Close();
        }


        private void btn_Clicked(object sender, EventArgs e)
        {
            if (evtype == "Marriage")
            {
                bool a, b, c, d, f, g, h, i, j, k, l;
                if (e1.Text != null && e4.Text != "")
                {
                    a = true;
                }
                else
                {
                    a = false;
                    DisplayAlert("Error", "UserId is Empty or Incorrect", "Ok");
                }
                if (e2.Text != null && e4.Text != "")
                {
                    b = true;
                }
                else
                {
                    b = false;
                    DisplayAlert("Error", "Date is Empty or Incorrect", "Ok");
                }
                if (e3.Text != null && e4.Text != "")
                {
                    c = true;
                }
                else
                {
                    c = false;
                    DisplayAlert("Error", "Guests is Empty or Incorrect", "Ok");
                }
                if (e4.Text != null && e4.Text != "")
                {
                    d = true;
                }
                else
                {
                    d = false;
                    DisplayAlert("Error", "Timing is Empty or Incorrect", "Ok");
                }
                if (e5.Text != null && e5.Text != "")
                {
                    g = true;
                }
                else
                {
                    g = false;
                    DisplayAlert("Error", "Hall Name is Empty or Incorrect", "Ok");
                }
                if (e6.Text != null && e6.Text != "")
                {
                    h = true;
                }
                else
                {
                    h = false;
                    DisplayAlert("Error", "Hall Rate is Empty or Incorrect", "Ok");
                }

                if (e7.Text != null && e7.Text != "")
                {
                    i = true;
                }
                else
                {
                    i = false;
                    DisplayAlert("Error", "Photogtapher name is Empty or Incorrect", "Ok");
                }

                if (e8.Text != null && e8.Text != "")
                {
                    j = true;
                }
                else
                {
                    j = false;
                    DisplayAlert("Error", "Photographer rate is Empty or Incorrect", "Ok");
                }

                if (e10.Text != null && e10.Text != "")
                {
                    k = true;
                }
                else
                {
                    k = false;
                    DisplayAlert("Error", "decorator name is Empty or Incorrect", "Ok");
                }
                if (e11.Text != null && e11.Text != "")
                {
                    l = true;
                }
                else
                {
                    l = false;
                    DisplayAlert("Error", "decorator rate is Empty or Incorrect", "Ok");
                }
                if (e9.Text != null && e9.Text != "")
                {
                    f = true;
                }
                else
                {
                    f = false;
                    DisplayAlert("Error", "Total Bill is Empty or Incorrect", "Ok");
                }

                if (a == true && b == true && c == true && d == true && f == true && g == true && h == true && i == true && j == true && k == true && l == true)
                {
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<MarriageEvent>();
                    con.Query<MarriageEvent>("Update MarriageEvent SET UserId = ?, Date = ?, Guests = ?, Timing = ?,TotalBill = ? Where EventId = ?", e1.Text, e2.Text, e3.Text, e4.Text, e9.Text, SId);
                    con.Close();
                    SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
                    con1.CreateTable<mHallBook>();
                    con1.Query<mHallBook>("Update mHallBook SET Hallname = ?, Hallrate = ? Where EventId = ?", e5.Text, e6.Text, SId);
                    con1.Close();
                    SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                    con2.CreateTable<mPhotographerBook>();
                    con2.Query<mHallBook>("Update mPhotographerBook SET PhotographerName = ?, PhotographerPrice = ? Where EventId = ?", e7.Text, e8.Text, SId);
                    con2.Close();
                    SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                    con3.CreateTable<mDecor>();
                    con3.Query<mHallBook>("Update mDecor SET DecoratorName = ?, DecoratorPrice = ? Where EventId = ?", e10.Text, e11.Text, SId);
                    con3.Close();
                    DisplayAlert("Successfull", "Updated Successfully", "ok");
                }
            }

            else if (evtype == "Birthday")
            {
                bool a, b, c, d, f, g, h, i, j, k, l,m,n;
                if (e1.Text != null && e4.Text != "")
                {
                    a = true;
                }
                else
                {
                    a = false;
                    DisplayAlert("Error", "UserId is Empty or Incorrect", "Ok");
                }
                if (e2.Text != null && e4.Text != "")
                {
                    b = true;
                }
                else
                {
                    b = false;
                    DisplayAlert("Error", "Date is Empty or Incorrect", "Ok");
                }
                if (e3.Text != null && e4.Text != "")
                {
                    c = true;
                }
                else
                {
                    c = false;
                    DisplayAlert("Error", "Guests is Empty or Incorrect", "Ok");
                }
                if (e4.Text != null && e4.Text != "")
                {
                    d = true;
                }
                else
                {
                    d = false;
                    DisplayAlert("Error", "Timing is Empty or Incorrect", "Ok");
                }

                if (e5.Text != null && e5.Text != "")
                {
                    f = true;
                }
                else
                {
                    f = false;
                    DisplayAlert("Error", "CakeName is Empty or Incorrect", "Ok");
                }
                if (e6.Text != null && e6.Text != "")
                {
                    g = true;
                }
                else
                {
                    g = false;
                    DisplayAlert("Error", "CakeQuantity is Empty or Incorrect", "Ok");
                }
                if (e7.Text != null && e7.Text != "")
                {
                    h = true;
                }
                else
                {
                    h = false;
                    DisplayAlert("Error", "CakeRate is Empty or Incorrect", "Ok");
                }
                if (e8.Text != null && e8.Text != "")
                {
                    i = true;
                }
                else
                {
                    i = false;
                    DisplayAlert("Error", "Location is Empty or Incorrect", "Ok");
                }
                if (e9.Text != null && e9.Text != "")
                {
                    j = true;
                }
                else
                {
                    j = false;
                    DisplayAlert("Error", "Total Bill is Empty or Incorrect", "Ok");
                }

                if (e10.Text != null && e10.Text != "")
                {
                    k = true;
                }
                else
                {
                    k = false;
                    DisplayAlert("Error", "Decorator Name is Empty or Incorrect", "Ok");
                }
                if (e11.Text != null && e11.Text != "")
                {
                    l = true;
                }
                else
                {
                    l = false;
                    DisplayAlert("Error", "Decorator Rate is Empty or Incorrect", "Ok");
                }
                if (e12.Text != null && e12.Text != "")
                {
                    m = true;
                }
                else
                {
                    m = false;
                    DisplayAlert("Error", "Photographer Name is Empty or Incorrect", "Ok");
                }
                if (e13.Text != null && e13.Text != "")
                {
                    n = true;
                }
                else
                {
                    n = false;
                    DisplayAlert("Error", "Photographer Name is Empty or Incorrect", "Ok");
                }


                if (a == true && b == true && c == true && f == true && g == true && h == true && i == true && d == true && j == true && k == true && l == true && m == true && n == true)
                {
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<MarriageEvent>();
                    con.Query<MarriageEvent>("Update Users SET UserId = ?, Date = ?, Guests = ?, Timing = ?,CakeName = ?,CakeQuantity = ?,CakeRate = ?,Location = ?,TotalBill = ?, Where EventId = ?", e1.Text, e2.Text, e3.Text, e4.Text, e5.Text, e6.Text, e7.Text, e8.Text, e9.Text, SId);
                    con.Close();
                    SQLiteConnection con2 = new SQLiteConnection(App.Databaselocation);
                    con2.CreateTable<mPhotographerBook>();
                    con2.Query<mHallBook>("Update mPhotographerBook SET PhotographerName = ?, PhotographerPrice = ?, Where EventId = ?", e12.Text, e13.Text, SId);
                    con2.Close();
                    SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                    con3.CreateTable<mDecor>();
                    con3.Query<mHallBook>("Update mDecor SET DecoratorName = ?, DecoratorPrice = ?, Where EventId = ?", e10.Text, e11.Text, SId);
                    con3.Close();
                    DisplayAlert("Successfull", "Updated Successfully", "ok");
                }
            }

            else if (evtype == "Dawat")
            {


                bool a, b, c, d, i, f,g,h;

                if (e1.Text != null && e1.Text != "")
                {
                    a = true;
                }
                else
                {
                    a = false;
                    DisplayAlert("Error", "UserId is Empty or Incorrect", "Ok");
                }
                if (e2.Text != null && e2.Text != "")
                {
                    b = true;
                }
                else
                {
                    b = false;
                    DisplayAlert("Error", "Date is Empty or Incorrect", "Ok");
                }
                if (e3.Text != null && e3.Text != "")
                {
                    c = true;
                }
                else
                {
                    c = false;
                    DisplayAlert("Error", "Guests is Empty or Incorrect", "Ok");
                }
                if (e4.Text != null && e4.Text != "")
                {
                    d = true;
                }
                else
                {
                    d = false;
                    DisplayAlert("Error", "Timing is Empty or Incorrect", "Ok");
                }

                if (e8.Text != null && e8.Text != "")
                {
                    i = true;
                }
                else
                {
                    i = false;
                    DisplayAlert("Error", "Location is Empty or Incorrect", "Ok");
                }
                if (e9.Text != null && e9.Text != "")
                {
                    g = true;
                }
                else
                {
                    g = false;
                    DisplayAlert("Error", "Total Bill is Empty or Incorrect", "Ok");
                }

                if (e10.Text != null && e10.Text != "")
                {
                    h = true;
                }
                else
                {
                    h = false;
                }

                if (e11.Text != null && e11.Text != "")
                {
                    f = true;
                }
                else
                {
                    f = false;
                }


                if (a == true && b == true && c == true && f == true && i == true && d == true && h == true && h == true)
                {
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<MarriageEvent>();
                    con.Query<MarriageEvent>("Update Users SET UserId = ?, Date = ?, Guests = ?, Timing = ?,Location = ?,TotalBill = ?, Where EventId = ?", e1.Text, e2.Text, e3.Text, e4.Text, e8.Text, e9.Text, SId);
                    con.Close();
                    SQLiteConnection con3 = new SQLiteConnection(App.Databaselocation);
                    con3.CreateTable<mDecor>();
                    con3.Query<mHallBook>("Update mDecor SET DecoratorName = ?, DecoratorPrice = ?, Where EventId = ?", e10.Text, e11.Text, SId);
                    con3.Close();
                    DisplayAlert("Successfull", "Updated Successfully", "ok");
                }
            }
        }
    }
}