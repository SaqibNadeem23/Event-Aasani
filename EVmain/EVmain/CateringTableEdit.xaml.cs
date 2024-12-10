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
    public partial class CateringTableEdit : ContentPage
    {
        string SId;
        public CateringTableEdit()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Catering>();
            var xxx = con.Query<Catering>("Select CatId from Catering");
            foreach (var k in xxx)
            {
                pik.Items.Add(k.CatId.ToString());
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
            con.CreateTable<Catering>();
            var asd = con.Query<Catering>("Select * from Catering where CatId = ?", SId);
            foreach (var k in asd)
            {
                if (SId == null || SId == "")
                {
                    e1.Text = "";
                    e3.Text = "";
                }
                else
                {
                    e1.Text = k.CatName;
                    e3.Text = k.CatPrice.ToString();
                }
                
            }
            con.Close();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (SId == null || SId == "")
            {
                DisplayAlert("Error", "Select Catering Id first to Delete Catering", "Ok");
            }

            else
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<Catering>();
                con.Delete<Catering>(Convert.ToInt32(SId));
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
                err += "Catering Name is Empty or Incorrect\n";
            }

            if (e3.Text != null && e3.Text != "")
            {
                u3 = true;
            }
            else
            {
                u3 = false;
                err += "Catering rate is Empty or Incorrect\n";
            }


            if (u1 == true && u3 == true)
            {

                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<Catering>();
                con.Query<Catering>("Update Catering Set CatName = ?, CatPrice = ? where CatId = ?", e1.Text.ToString(), Convert.ToInt32(e3.Text), SId);
                DisplayAlert("Success", "Catering Edited Successfully", "Ok");
            }

            else
            {
                DisplayAlert("Error", err, "Ok");
            }











        }
    }
}