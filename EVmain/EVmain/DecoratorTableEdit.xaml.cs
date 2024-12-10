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
    public partial class DecoratorTableEdit : ContentPage
    {
        string SId;
        public DecoratorTableEdit()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Decorator>();
            var xxx = con.Query<Decorator>("Select DecoratorId from Decorator");
            foreach (var k in xxx)
            {
                pik.Items.Add(k.DecoratorId.ToString());
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
            con.CreateTable<Decorator>();
            var asd = con.Query<Decorator>("Select * from Decorator where DecoratorId = ?", SId);
            foreach (var k in asd)
            {
                if (SId == null || SId == "")
                {
                    e1.Text = "";
                    e3.Text = "";
                }
                else
                {
                    e1.Text = k.DecoratorName;
                    e3.Text = k.DecoratorPrice.ToString();
                }
                
            }
            con.Close();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (SId == null || SId == "")
            {
                DisplayAlert("Error", "Select Decorator Id first to Delete Decorator", "Ok");
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
                err += "Decorator Name is Empty or Incorrect\n";
            }

            if (e3.Text != null && e3.Text != "")
            {
                u3 = true;
            }
            else
            {
                u3 = false;
                err += "Decorator rate is Empty or Incorrect\n";
            }


            if (u1 == true && u3 == true)
            {

                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<photogr>();
                con.Query<photogr>("Update Decorator Set DecoratorName = ?, DecoratorPrice = ? where DecoratorId = ?", e1.Text.ToString(), Convert.ToInt32(e3.Text), SId);
                DisplayAlert("Success", "Decorator Edited Successfully", "Ok");
            }

            else
            {
                DisplayAlert("Error", err, "Ok");
            }











        }
    }
}