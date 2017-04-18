﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileGuide
{
    public partial class MainPage : ContentPage
    {
        static int secret = 0;

        public Options _potato = new Options();
        public MainPage()
        {
            async Task open_Guides_Catalog()
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

            Application.Current.PropertyChanged += (sender, args) =>
            {
                  _potato.Namechange(CheckGuide());
            };

            var tapTap = new TapGestureRecognizer();

            tapTap.Tapped += tapImage_Tapped;

            Image attic = new Image
            {
                Source = ImageSource.FromResource("MobileGuide.images.logo.png"),
                HeightRequest = 100,
                WidthRequest = 100        
            };
            attic.GestureRecognizers.Add(tapTap);

            Button niburu = new Button
            {
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent
            };

            Label header = new Label
            {
                Text = "HAIL HYDRA",
                FontSize = 16,
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };

            Button openCatalog = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Open guides Catalog"
               // Command = new Command(async () => await open_Guides_Catalog())
            };
            openCatalog.Clicked += async (sender, args) =>
              {
                  openCatalog.IsEnabled = false;
                  await open_Guides_Catalog();
                  openCatalog.IsEnabled = true;
              };

            Label info = new Label
            {
                Text = _potato.Name,
                HorizontalOptions = LayoutOptions.Center
            };

            info.SetBinding(Label.TextProperty, "Name");
            info.BindingContext = _potato;
            

            Content = new StackLayout
            {
                Children =
                {
                    attic,
                    header,
                    openCatalog,
                    info
                }
            };
        }

        //Если есть записанный гид - возвращаем его имя
        //Если нет - пишем "none"
        private string CheckGuide()
        {
            if(!Application.Current.Properties.TryGetValue("CurrentGuide",out object result))
            {
                return "none";
            }
            return result.ToString();
        }

        void tapImage_Tapped(object sender,EventArgs e)
        {
            if(secret == 5)
            {
                Navigation.PushModalAsync(new Secret());
                secret = 0;
            }
            else
            {
                secret++;
            }

        }

        public void guideChange(string text)
        {
            _potato.Name = text;
        }
    }
}