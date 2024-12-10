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
    public partial class DBTableView : ContentPage
    {
        public DBTableView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsersTable_View());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MarriageEventTableView());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HallsTableView());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PhotographerTableView());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DecoratorTableView());

        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CateringTableView());

        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HallBookingTableView());

        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PhotographerBookingTableView());

        }

        private void Button_Clicked_8(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DecoratorBookingTableView());

        }

        private void Button_Clicked_9(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CateringBookingTableView());

        }
    }
}