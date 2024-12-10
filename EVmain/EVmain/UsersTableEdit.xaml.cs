using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using EVmain.Model;
using System.Text.RegularExpressions;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersTableEdit : ContentPage
    {
        string SName, SEmail, SPhone, SPass, SId;



        public UsersTableEdit()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Users>();
            var xxx = con.Query<Users>("Select UserId from Users");
            foreach (var k in xxx)
            {
                pik.Items.Add(k.UserId.ToString());
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
            con.CreateTable<Users>();
            if (SId == null || SId == "")
            {
                e1.Text = "";
                e2.Text = "";
                e3.Text = "";
                e4.Text = "";
                e5.Text = "";
            }
            else
            {
                var asd = con.Query<Users>("Select * from Users where UserId = ?", SId);
                foreach (var k in asd)
                {
                    if (k.UserId != null || k.UserId != 0)
                    {
                        e1.Text = k.UserName;
                        e2.Text = k.Email;
                        e3.Text = k.PhoneNumber;
                        e4.Text = k.Password;
                        e5.Text = k.UserType;
                    }
                }
            }
            con.Close();
        }
            




        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (SId == null || SId == "")
            {
                DisplayAlert("Error", "Select a User Id first to Delete User", "Ok");
            }

            else
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<Users>();
                con.Delete<Users>(Convert.ToInt32(SId));
                DisplayAlert("Success", "Deleted Successfully", "Ok");
                con.Close();
                pik.Items.Remove(pik.SelectedItem.ToString());
            }
        }


        private void btn_Clicked(object sender, EventArgs e)
        {
            bool nmC, phC, psC, emC,UtC;

            if (e1.Text != null && e1.Text != "" && Regex.IsMatch(e1.Text, "^(([A-za-z]+[ ]{1}[A-za-z]+)|([A-Za-z]+|[A-za-z]+[ ]{1}[A-za-z]+[ ]{1}[A-za-z]+))$"))
            {
                nmC = true;
            }
            else
            {
                nmC = false;
                DisplayAlert("Error", "Name is Empty or Incorrect", "Ok");
            }


            if (e3.Text != null && e3.Text != "" && Regex.IsMatch(e3.Text, @"^-?\d+\.?\d*$"))
            {
                phC = true;
            }
            else
            {
                phC = false;
                DisplayAlert("Error", "Phone Number is Empty or Incorrect", "Ok");
            }

            if (e2.Text != null && e2.Text != "" && Regex.IsMatch(e2.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))

            {
                emC = true;
            }
            else
            {
                emC = false;
                DisplayAlert("Error", "Email is Empty or Incorrect", "Ok");
            }


            if (e4.Text != null && e4.Text != "")
            {
                psC = true;
            }
            else
            {
                psC = false;
                DisplayAlert("Error", "Password is Empty or Incorrect", "Ok");
            }

            if (e5.Text != null && e5.Text != "")
            {
                UtC = true;
            }
            else
            {
                UtC = false;
                DisplayAlert("Error", "User Type is Empty or Incorrect", "Ok");
            }

            if (nmC == true && phC == true && psC == true && emC == true && UtC == true)
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                con.CreateTable<Users>();
                con.Query<Users>("Update Users SET FullName = ?, Email = ?, PhoneNumber = ?, Password = ?, UserType = ?, Where UserId = ?", e1.Text, e2.Text, e3.Text, e4.Text,e5.Text, SId);
                con.Close();

                DisplayAlert("Successfull", "Updated Successfully", "ok");
            }
        }
  
    }
}