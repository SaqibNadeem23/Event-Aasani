using EVmain.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HallTableEdit : ContentPage
    {
        string SId;
        public HallTableEdit()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Halls>();
            var xxx = con.Query<Halls>("Select HallId from Halls");
            foreach (var k in xxx)
            {
                pik.Items.Add(k.HallId.ToString());
            }
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
            con.CreateTable<Halls>();
            var asd = con.Query<Halls>("Select * from Halls where HallId = ?", SId);
            foreach (var k in asd)
            {
                if (SId == null || SId == "")
                {
                    e1.Text = "";
                    e3.Text = "";
                    e4.Text = "";
                    e5.Text = "";
                    e6.Text = "";
                }
                else
                {
                    e1.Text = k.HallName;
                    e3.Text = k.Address;
                    e4.Text = k.HallPrice.ToString();
                    e5.Text = k.HallLong.ToString();
                    e6.Text = k.HallLang.ToString();
                }
            }
            con.Close();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (SId == null || SId == "")
            {
                DisplayAlert("Error", "Select a Hall Id first to Delete Hall", "Ok");
            }

            else
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<Halls>();
                con.Delete<Halls>(Convert.ToInt32(SId));
                DisplayAlert("Success", "Deleted Successfully", "Ok");
                con.Close();
                pik.Items.Remove(pik.SelectedItem.ToString());
            }
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            bool u1,u3, u4, u5, u6;
            String err = "Following Errors Occured:\n";

            if (e1.Text != null && e1.Text != "" && Regex.IsMatch(e1.Text, "^(([A-za-z]+[ ]{1}[A-za-z]+)|([A-Za-z]+|[A-za-z]+[ ]{1}[A-za-z]+[ ]{1}[A-za-z]+))$"))
            {
                u1 = true;
            }
            else
            {
                u1 = false;
                err += "Hall Name is Empty or Incorrect\n";
            }

            if (e3.Text != null && e3.Text != "")
            {
                u3 = true;
            }
            else
            {
                u3 = false;
                err += "Hall Address is Empty or Does not Match\n";
            }
            if (e4.Text != null && e4.Text != "")
            {
                u4 = true;
            }
            else
            {
                u4 = false;
                err += "Hall Price is Empty or Does not Match\n";
            }
            if (e5.Text != null && e5.Text != "")
            {
                u5 = true;
            }
            else
            {
                u5 = false;
                err += "Hall Longitude is Empty or Does not Match\n";
            }
            if (e6.Text != null && e6.Text != "")
            {
                u6 = true;
            }
            else
            {
                u6 = false;
                err += "Hall Langitude is Empty or Does not Match\n";
            }

            if (u1 == true && u3 == true && u4 == true && u5 == true && u6 == true)
            {
                
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Halls>();
                    con.Query<Halls>("Update Halls Set HallName = ?, Address = ?,  HallPrice = ?, HallLong= ?,  HallLang= ? where HallId = ?", e1.Text.ToString(), e3.Text.ToString(), Convert.ToInt32(e4.Text), Convert.ToDouble(e5.Text), Convert.ToDouble(e6.Text), SId);
                    DisplayAlert("Success", "Hall Edited Successfully", "Ok");           
            }

            else
            {
                DisplayAlert("Error", err, "Ok");
            }











        }
    }
}