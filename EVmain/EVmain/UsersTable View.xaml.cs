using SQLite;
using EVmain.Model;
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
    public partial class UsersTable_View : ContentPage
    {
        public UsersTable_View()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection con = new SQLiteConnection(App.Databaselocation);
            con.CreateTable<Users>();
            var users = con.Table<Users>();
            foreach(var x in users)
            {
                StackLayout stackLayout = new StackLayout() 
                {
                    Orientation = StackOrientation.Horizontal,
                    
                };

                MS.Children.Add(stackLayout);
                Label label = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.UserId.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label);

                Label label6 = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.UserType.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label6);

                Label label1 = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.UserName.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label1);
                Label label2 = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.FullName.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label2);
                Label label3 = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.PhoneNumber.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label3);
                Label label4 = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.Email.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label4);
                Label label5 = new Label()
                {
                    WidthRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = x.Password.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                };
                stackLayout.Children.Add(label5);
                
            }
            con.Close();
        }

    }
}