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
    public partial class PhotographerTableEdit : ContentPage
    {
        string SId;
        public PhotographerTableEdit()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<photogr>();
            var xxx = con.Query<photogr>("Select PhotographerId from photogr");
            foreach (var k in xxx)
            {
                pik.Items.Add(k.PhotographerId.ToString());
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
            con.CreateTable<photogr>();
            var asd = con.Query<photogr>("Select * from photogr where PhotographerId = ?", SId);
            foreach (var k in asd)
            {
                if (SId == null || SId == "")
                {
                    e1.Text = "";
                    e3.Text = "";
                }
                else
                {
                    e1.Text = k.PhotographerName;
                    e3.Text = k.PhotographerPrice.ToString();
                }
            }
            con.Close();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (SId == null || SId == "")
            {
                DisplayAlert("Error", "Select Photographer Id first to Delete Photographer", "Ok");
            }

            else
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<photogr>();
                con.Delete<photogr>(Convert.ToInt32(SId));
                DisplayAlert("Success", "Deleted Successfully", "Ok");
                con.Close();
                pik.Items.Remove(pik.SelectedItem.ToString());
            }
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            bool u1, u3;
            String err = "Following Errors Occured:\n";

            if (e1.Text != null && e1.Text != "")
            {
                u1 = true;
            }
            else
            {
                u1 = false;
                err += "Photographer Name is Empty or Incorrect\n";
            }

            if (e3.Text != null && e3.Text != "")
            {
                u3 = true;
            }
            else
            {
                u3 = false;
                err += "Photographer rate is Empty or Incorrect\n";
            }
           

            if (u1 == true && u3 == true)
            {

                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<photogr>();
                con.Query<photogr>("Update photogr Set PhotographerName = ?, PhotographerPrice = ? where PhotographerId = ?", e1.Text.ToString(), e3.Text.ToString(), SId);
                DisplayAlert("Success", "Photographer Edited Successfully", "Ok");
            }

            else
            {
                DisplayAlert("Error", err, "Ok");
            }











        }
    }
}