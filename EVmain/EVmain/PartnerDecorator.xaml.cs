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
    public partial class PartnerDecorator : ContentPage
    {
        int sID, y;
        public PartnerDecorator(int Uid)
        {
            InitializeComponent();

            sID = Uid;
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Decorator>();
            var nms = con.Query<Decorator>("Select * from Decorator where DecoratorId = ?", sID);
            int x = nms.Count;
            y = x;


            if (x > 0)
            {
                cp.Title = "Edit Photographer Info";
                btn.Text = "Edit";

                foreach (var s in nms)
                {
                    e1.Text = s.DecoratorName;
                    imagearray = s.imgbyte;
                    e3.Text = s.DecoratorPrice.ToString();
                }
            }

            else
            {
                cp.Title = "Enter Decorator Info";
                btn.Text = "Create Decorator";
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
            bool u1, u2, u3;
            String err = "Following Errors Occured:\n";

            if (e1.Text != null && e1.Text != "" && Regex.IsMatch(e1.Text, "^(([A-za-z]+[ ]{1}[A-za-z]+)|([A-Za-z]+|[A-za-z]+[ ]{1}[A-za-z]+[ ]{1}[A-za-z]+))$"))
            {
                u1 = true;
            }
            else
            {
                u1 = false;
                err += "Photographer Name is Empty or Incorrect\n";
            }

            if (imagearray != null)
            {
                u2 = true;
            }
            else
            {
                u2 = false;
                err += "Photographer Picture Source is Empty or Does not Match\n";
            }

            if (e3.Text != null && e3.Text != "")
            {
                u3 = true;
            }
            else
            {
                u3 = false;
                err += "Photographer Price is Empty or Does not Match\n";
            }

            if (u1 == true && u2 == true && u3 == true)
            {
                if (y <= 0)
                {
                    Decorator decorator = new Decorator()
                    {
                        DecoratorId = sID,
                        DecoratorName = e1.Text.ToString(),
                        DecoratorRating = 3,
                        DecoratorPrice = Convert.ToInt32(e3.Text),
                        imgbyte = imagearray,
                        TotalRatings = 1,
                        OverallRatings = 3,
                    };




                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Decorator>();
                    con.Insert(decorator);
                    con.Close();
                    y++;
                    btn.Text = "Edit";
                    cp.Title = "Edit Photographer Info";
                    DisplayAlert("Success", "Decorator Id Created Successfully", "Ok");
                }

                else
                {
                    SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                    con.CreateTable<Decorator>();
                    con.Query<Decorator>("Update Decorator Set DecoratorName = ?,imgbyte = ?,  DecoratorPrice = ? where DecoratorId = ?", e1.Text.ToString(), imagearray, e3.Text.ToString(), sID);
                    DisplayAlert("Success", "Decorator Edited Successfully", "Ok");
                }
            }
            else
            {
                DisplayAlert("Error", err, "Ok");
            }

        }
    }
}