using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MobileGuide
{
    public class MenuPage : ContentPage
    {
        public MenuPage()
        {
            Image logo = new Image
            {
                Source = ImageSource.FromResource("MobileGuide.images.logo.png"),
                HeightRequest = 64,
                WidthRequest = 64
            };

            Button home = new Button
            {
                Text = "Homepage",
                Command = new Command(o =>
                {
                    App.MasterDetailPage.Detail = new NavigationPage(new MainPage());
                    App.MasterDetailPage.IsPresented = false;
                })
            };
       

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform<int>(20, 0, 0), 0, 0),
                Children = {
                    logo,
                    home,
                new MainLink("Page A"),
                new MainLink("Page B"),
                new MainLink("Page C"),
            }
            };
            Title = "Master";
            BackgroundColor = Color.Gray.WithLuminosity(0.9);
            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : "images/menu.png";
        }
    }
}