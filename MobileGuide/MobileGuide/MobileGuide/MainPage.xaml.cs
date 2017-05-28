using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileGuide
{
    public partial class MainPage : ContentPage
    {
        
        static int secret = 0;

        public MainPage()
        {
            
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            BackgroundColor = ((Color.Red.WithHue(0.5638)).WithSaturation(0.73)).WithLuminosity(0.794);

            var tapTap = new TapGestureRecognizer();

            tapTap.Tapped += tapImage_Tapped;


            Application.Current.PropertyChanged += (sender, args) =>
            {
                  App._appOptions.Namechange(CheckGuide());                
            };

            Image attic = new Image
            {
                Source = ImageSource.FromResource("MobileGuide.images.logo.png"),
                HeightRequest = 100,
                WidthRequest = 100        
            };
            attic.GestureRecognizers.Add(tapTap);

            Label header = new Label
            {
                Text = "HAIL HYDRA",
                FontSize = 16,
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };



            Label info = new Label
            {
                Text = App._appOptions.Name,
                HorizontalOptions = LayoutOptions.Center
            };

            info.SetBinding(Label.TextProperty, "Name");
            info.BindingContext = App._appOptions;
            

            Content = new StackLayout
            {
                Children =
                {
                    attic,
                    header,
                    info
                }
            };
        }

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
    }
}