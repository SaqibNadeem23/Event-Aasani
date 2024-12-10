
using Android.App;
using Android.Content.PM;
using Android.OS;
using System.IO;
using PanCardView.Droid;

namespace EVmain.Droid
{
    [Activity(Label = "Event Aasani", Icon = "@mipmap/EventE", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CardsViewRenderer.Preserve();

            string dbName = "test9";
            string folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderpath, dbName);
            LoadApplication(new App(fullpath));

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

        }
    }
        namespace splashscreen.Droid
    {
        [Activity(Label = "Event Aasani", Icon = "@mipmap/EventE", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
        public class Activity1 : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);

                // Create your application here
                StartActivity(typeof(MainActivity));
            }
        }
    }

}
