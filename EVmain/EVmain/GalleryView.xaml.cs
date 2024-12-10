using EVmain.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PanCardView;
namespace EVmain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryView : ContentPage
    {
        private int Sid;

        List<ImageSource> imgs = new List<ImageSource>();
        public GalleryView(int pid)
        {
            InitializeComponent();
            Sid = pid;
            if (Sid == 1 || Sid == 2 || Sid == 3 || Sid == 4 || Sid == 5 || Sid == 6 || Sid == 7 || Sid == 8 || Sid == 9 || Sid == 10 || Sid == 11 || Sid == 12)
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                var asf = con.Query<Gallery>("Select * from Gallery where Id = ?", Sid);

                foreach (var x in asf)
                {
                    imgs.Add(x.imgsource);
                }
            }

            else
            {
                SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
                var asf = con.Query<Gallery>("Select * from Gallery where Id = ?", Sid);

                foreach (var x in asf)
                {
                    byte[] b = x.imgbyte;
                    Stream ms = new MemoryStream(b);
                    imgs.Add(ImageSource.FromStream(() => ms));
                }
            }
            MainCarouselView.ItemsSource = imgs;
            

        }



    }

}