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

            var header = new BoxView
            {
                Color = new Color(39, 134, 171),
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform<int>(20, 0, 0), 0, 0),
                Children = {
                    logo,
                    home,
                new MainLink("Общая информация"),
                new MainLink("Достопримечательности"),
                new MainLink("Отдых"),
            }
            };
            Title = "Master";
            BackgroundColor = ((Color.Red.WithHue(0.5638)).WithSaturation(0.73)).WithLuminosity(0.794);

            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : "menu.png";
        }
    }
}