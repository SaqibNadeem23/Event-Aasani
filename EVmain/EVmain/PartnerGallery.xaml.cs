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
    public partial class PartnerGallery : ContentPage
    {
        private int Pid, pnum;
        Image img = new Image();
        public PartnerGallery(int Id)
        {
            InitializeComponent();
            Pid = Id;

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Gallery>();
            var asd = con.Query<Gallery>("Select PicNum from Gallery where Id =?", Pid);
            if(asd.Count == 0)
            {
                pnum = 1;
            }
            else if(asd.Count >0) 
                { 
            foreach (var x in asd)
            {
                pnum = x.PicNum; 
            }
                }
            con.Close();


            SQLiteConnection con1 = new SQLiteConnection(App.Databaselocation);
            con1.CreateTable<Gallery>();
            var asdf = con1.Query<Gallery>("Select * from Gallery where Id =?", Pid);
            foreach (var x in asdf)
            {
                Pik.Items.Add(x.PicNum.ToString());
            }
            con1.Close();

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

            Gallery gallery = new Gallery()
            {
                Id = Pid,
                imgbyte = imagearray,
                PicNum = pnum,

            };

            Pik.Items.Clear();
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Gallery>();
            con.Insert(gallery);
            var asd = con.Query<Gallery>("Select * from Gallery where Id =?", Pid);
            foreach (var x in asd)
            {
                Pik.Items.Add(x.PicNum.ToString());
                Pik.SelectedItem = x.PicNum.ToString();
            }
            con.Close();

            
            pnum++;


        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (Pik.SelectedItem != null)
            { 
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Gallery>();
            var asd = con.Query<Gallery>("Delete from Gallery where PicNum =?", Pik.SelectedItem.ToString()); ;
            con.Close();
            Pik.Items.Remove(Pik.SelectedItem.ToString());
            }

            else if(Pik.SelectedItem == null)
            {
                image.Source = "";
            }

        }

        byte[] im;

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GalleryView(Pid));
        }

        private void Pik_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Gallery>();
            if (Pik.SelectedItem != null)
            {

                var asd = con.Query<Gallery>("Select * from Gallery where PicNum =? and Id = ?", Pik.SelectedItem.ToString(), Pid);
                foreach (var x in asd)
                {
                    if(Pid<=12)
                    {
                        image.Source = x.imgsource;
                    }
                    else { 
                    if (x.imgbyte != null)
                    {
                        im = x.imgbyte;
                        Stream ms = new MemoryStream(im);
                        image.Source = ImageSource.FromStream(() => ms);
                        con.Close();
                    }

                    else
                    {
                        DisplayAlert("Error", "PicSource if Empty", "Ok");
                    }
                    }

                }
            }
            else if (Pik.SelectedItem == null)
            {
                image.Source = "";
            }
        }



        
    }
}