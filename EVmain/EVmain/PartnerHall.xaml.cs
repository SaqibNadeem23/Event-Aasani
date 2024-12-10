using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EVmain.Model;
using Plugin.Media;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartnerHall : ContentPage
    {
        int sID,y;
        public PartnerHall(int Uid)
        {
            InitializeComponent();
            sID = Uid;
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Halls>();
            var nms = con.Query<Halls>("Select * from Halls where HallId = ?", sID);
            int x = nms.Count;
            y = x;


            if(x>0)
            {
                cp.Title = "Edit Hall Info";
                btn.Text = "Edit";

                foreach (var s in nms)
                {
                    e1.Text = s.HallName;
                    imagearray = s.imgbyte;
                    e3.Text = s.Address;
                    e4.Text = s.HallPrice.ToString();
                    e5.Text = s.HallLong.ToString();
                    e6.Text = s.HallLang.ToString();
                }




            }

            else
            {
                cp.Title = "Enter Hall Info";
                btn.Text = "Create Hall";
            }

        }

        byte[] imagearray;

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "Camera is not supported", "ok");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();


            if (file == null)
                return;



            img.Source = ImageSource.FromStream(() =>
            {
                var Str = file.GetStream();

                return Str;
            });

            using (MemoryStream memory = new MemoryStream())
            {

                Stream stream = file.GetStream();
                stream.CopyTo(memory);
                imagearray = memory.ToArray();
            }
        }
        private void btn_Clicked(object sender, EventArgs e)
        {
            bool u1, u2, u3, u4, u5, u6;
            String err = "Following Errors Occured:\n";

            if(e1.Text != null && e1.Text != "" && Regex.IsMatch(e1.Text, "^(([A-za-z]+[ ]{1}[A-za-z]+)|([A-Za-z]+|[A-za-z]+[ ]{1}[A-za-z]+[ ]{1}[A-za-z]+))$"))
                {
                u1 = true;
                }
            else
            {
                u1 = false;
                err += "Hall Name is Empty or Incorrect\n";
            }

            if (imagearray != null)
            {
                u2 = true;
            }
            else
            {
                u2 = false;
                err += "Hall Picture Source is Empty or Does not Match\n";
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

            if(u1 == true && u2 == true && u3 == true && u4 == true && u5 == true && u6 == true)
            {
                if (y <= 0)
                {
                    Halls halls = new Halls()
                    {
                        HallId = sID,
                        HallName = e1.Text.ToString(),
                        imgbyte = imagearray,
                        Address = e3.Text.ToString(),
                        HallRating = 3,
                        HallPrice = Convert.ToInt32(e4.Text),
                        HallLong = Convert.ToDouble(e5.Text),
                        HallLang = Convert.ToDouble(e6.Text),
                        TotalRatings = 1,
                        OverallRatings = 3,
                    };

                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Halls>();
                    con.Insert(halls);
                    con.Close();
                    y++;
                    btn.Text = "Edit";
                    cp.Title = "Edit Hall Info";
                    DisplayAlert("Success", "Hall Created Successfully", "Ok");
                }

                else
                {
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Halls>();
                    con.Query<Halls>("Update Halls Set HallName = ?, imgbyte = ?, Address = ?,  HallPrice = ?, HallLong= ?,  HallLang= ? where HallId = ?", e1.Text.ToString(), imagearray, e3.Text.ToString(), Convert.ToInt32(e4.Text), Convert.ToDouble(e5.Text), Convert.ToDouble(e6.Text), sID);
                    DisplayAlert("Success", "Hall Edited Successfully", "Ok");
                }
            }
            else
                {
                    DisplayAlert("Error", err, "Ok");
                }
            






            



        }
    }
}