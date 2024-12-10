using EVmain.Model;
using Plugin.Media;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminFood : ContentPage
    {
        public AdminFood()
        {
            InitializeComponent();
            
            Edit.IsVisible = true;
            Add.IsVisible = false;
        }

        byte[] imagearray;
        protected override void OnAppearing()
        {
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<FoodIt>();
            var nms = con.Query<FoodIt>("Select FoodName from FoodIt");
            foreach (var s in nms)
            {
                pik.Items.Add(s.FoodName);
            }
            con.Close();
        }
            int id;
        private void pik_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteConnection conb = new SQLiteConnection(App.Databaselocation);
            var x = conb.Query<FoodIt>("Select * from FoodIt where FoodName = ?", pik.SelectedItem);
            foreach (var s in x)
            {
                id = s.FoodId;
                e1.Text = s.FoodName;
                e3.Text = s.FoodPrice.ToString();
                if (s.imgbyte == null)
                { img1.Source = s.FoodPic; }
                else if(s.imgbyte != null)
                {
                    Stream ms = new MemoryStream(s.imgbyte);
                    img1.Source = ImageSource.FromStream(() => ms);
                }
            }
            conb.Close();
           
            if(pik.SelectedItem == "Biryani")
            {
                img1.Source = "biryani";
            }
            else if (pik.SelectedItem == "Kabab")
            {
                img1.Source = "kabab";
            }
            else if (pik.SelectedItem == "Korma")
            {
                img1.Source = "korma";
            }
            else if (pik.SelectedItem == "Palak Gosht")
            {
                img1.Source = "pg";
            }
            else if (pik.SelectedItem == "Roast")
            {
                img1.Source = "roast";
            }


        }
        

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



            img1.Source = ImageSource.FromStream(() =>
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


        byte[] imagearray1;

        private async void Button_Clicked1(object sender, EventArgs e)
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



            img2.Source = ImageSource.FromStream(() =>
            {
                var Str = file.GetStream();

                return Str;
            });

            using (MemoryStream memory = new MemoryStream())
            {

                Stream stream = file.GetStream();
                stream.CopyTo(memory);
                imagearray1 = memory.ToArray();
            }
        }


        private void btn_Clicked(object sender, EventArgs e)
        {
            bool n1C,n3C;
            String err = "Following Errors Occured:\n";
           

            if (e1.Text != null && e1.Text != "")
            {
                n1C = true;
            }

            else
            {
                n1C = false;
                err += "Food Name is Empty or Incorrect\n";
            }

            if (e3.Text != null && e3.Text != "")
            {
                n3C = true;
            }

            else
            {
                n3C = false;
                err += "Food Price is Empty or Incorrect\n";
            }

            if(n1C == true && n3C == true)
            { 
            SQLiteConnection cong = new SQLiteConnection(App.Databaselocation);
            var x = cong.Query<FoodIt>("Update FoodIt set FoodName = ?, imgbyte = ?, FoodPrice = ?", e1.Text, imagearray, Convert.ToInt32(e3.Text));
            DisplayAlert("Successfull", "Item edited Successfully", "ok");
            }
            else
            {
                DisplayAlert("Error", err, "Ok");
            }
        }

        private void sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw.IsToggled == true)
            {
                Edit.IsVisible = false;
                Add.IsVisible = true;
            }
            else if (sw.IsToggled == false)
            {
                Edit.IsVisible = true;
                Add.IsVisible = false;
            }

        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            bool n1C, n2C, n3C;
            String err = "Following Errors Occured:\n";


            if (f1.Text != null && f1.Text != "")
            {
                n1C = true;
            }

            else
            {
                n1C = false;
                err += "Food Name is Empty or Incorrect\n";
            }

            if (imagearray1 != null)
            {
                n2C = true;
            }

            else
            {
                n2C = false;
                err += "Food Picture Source is Empty or Incorrect\n";
            }

            if (f3.Text != null && f3.Text != "")
            {
                n3C = true;
            }

            else
            {
                n3C = false;
                err += "Food Price is Empty or Incorrect\n";
            }

            if (n1C == true && n2C == true && n3C == true)
            {
                FoodIt FoodItems = new FoodIt()
                {
                    FoodName = f1.Text.ToString(),
                    imgbyte = imagearray1,
                    FoodPrice = Convert.ToInt32(f3.Text),
                };
                SQLiteConnection conn = new SQLiteConnection(App.Databaselocation);
                conn.CreateTable<FoodIt>();
                conn.Insert(FoodItems);
                conn.Close();
                DisplayAlert("Successfull", "Item Added Successfully", "ok");
            }
            else
            {
                DisplayAlert("Error", err, "Ok");
            }
           
            
        }
    }
}