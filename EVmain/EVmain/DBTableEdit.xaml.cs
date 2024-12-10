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
    public partial class DBTableEdit : ContentPage
    {
        public DBTableEdit()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsersTableEdit());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MarriageEventTableEdit());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HallTableEdit());

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PhotographerTableEdit());

        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DecoratorTableEdit());

        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CateringTableEdit());

        }
     
    }
}