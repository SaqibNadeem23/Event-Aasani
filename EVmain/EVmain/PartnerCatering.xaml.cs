using EVmain.Model;
using Plugin.Media;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartnerCatering : ContentPage
    {
        int sID, y;
        public PartnerCatering(int Uid)
        {
            InitializeComponent();
            sID = Uid;
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Catering>();
            var nms = con.Query<Catering>("Select * from Catering where CatId = ?", sID);
            int x = nms.Count;
            y = x;

            if (x > 0)
            {
                cp.Title = "Edit Catering Info";
                btn.Text = "Edit";

                foreach (var s in nms)
                {
                    e1.Text = s.CatName;
                    imagearray = s.imgbyte;
                    e4.Text = s.CatPrice.ToString();
                }
            }

            else
            {
                cp.Title = "Enter Catering Info";
                btn.Text = "Create Catering";
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
            bool u1, u2, u4;
            String err = "Following Errors Occured:\n";

            if (e1.Text != null && e1.Text != "" && Regex.IsMatch(e1.Text, "^(([A-za-z]+[ ]{1}[A-za-z]+)|([A-Za-z]+|[A-za-z]+[ ]{1}[A-za-z]+[ ]{1}[A-za-z]+))$"))
            {
                u1 = true;
            }
            else
            {
                u1 = false;
                err += "Catering Name is Empty or Incorrect\n";
            }

            if (imagearray != null)
            {
                u2 = true;
            }
            else
            {
                u2 = false;
                err += "Catering Picture Source is Empty or Does not Match\n";
            }

            if (e4.Text != null && e4.Text != "")
            {
                u4 = true;
            }
            else
            {
                u4 = false;
                err += "Catering Price is Empty or Does not Match\n";
            }



            if (u1 == true && u2 == true && u4 == true)
            {
                if (y <= 0)
                {
                    Catering ct = new Catering()
                    {
                        CatId = sID,
                        CatName = e1.Text.ToString(),
                        imgbyte = imagearray,
                        CatRating = 3,
                        CatPrice = Convert.ToInt32(e4.Text),
                        TotalRatings = 1,
                        OverallRatings = 3,
                    };

                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Catering>();
                    con.Insert(ct);
                    con.Close();
                    y++;
                    btn.Text = "Edit";
                    cp.Title = "Edit Catering Info";
                    DisplayAlert("Success", "Catering Created Successfully", "Ok");
                }

                else
                {
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Catering>();
                    con.Query<Catering>("Update Catering Set CatName = ?, imgbyte = ?,  CatPrice = ? where CatId = ?", e1.Text.ToString(), imagearray, Convert.ToInt32(e4.Text), sID);
                    DisplayAlert("Success", "Catering Edited Successfully", "Ok");
                }
            }
            else
            {
                DisplayAlert("Error", err, "Ok");
            }
        }
    }
}