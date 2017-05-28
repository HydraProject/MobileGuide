using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace MobileGuide
{
    public class MenuPage : ContentPage
    {
        public void guideChange(string text)
        {
            App._appOptions.Name = text;
        }

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
                BorderColor = Color.Transparent,
                BackgroundColor = Color.Transparent,
                Text = "Главная информация",
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

            Button openCatalog = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
                BorderColor = Color.Transparent,
                BackgroundColor = Color.Transparent,
                Text = "Открыть каталог",
            };
            async System.Threading.Tasks.Task open_Guides_Catalog()
            {
                try
                {
                    await Navigation.PushModalAsync(new GuidesPage(this));
                }
                catch (Exception e)
                {
                    await DisplayAlert("error", e.Message, "cancer");
                }
            }
            openCatalog.Clicked += async (sender, args) =>
            {
                openCatalog.IsEnabled = false;
                await open_Guides_Catalog();
                openCatalog.IsEnabled = true;
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform<int>(20, 20, 0), 0, 0),
                Children = {
                    logo,
                    home,
                new MainLink("Общая информация"),
                new MainLink("Достопримечательности"),
                new MainLink("Отдых"),
                openCatalog
            }
            };
            Title = "Master";
            BackgroundColor = ((Color.Red.WithHue(0.5638)).WithSaturation(0.73)).WithLuminosity(0.794);
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
        }
    }
}