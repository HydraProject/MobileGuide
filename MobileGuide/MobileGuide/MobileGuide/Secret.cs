using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MobileGuide
{
    public class Secret : ContentPage
    {
        private static string BASE_PATH = "file:///android_asset/";

        public Secret()
        {
            BackgroundColor = Color.Black;
            //Creating TapGestureRecognizers  
            var tapTaped = new TapGestureRecognizer();
            //Binding events  
            tapTaped.Tapped += anything_Tapped;

            void anything_Tapped(object sender, EventArgs e)
            {
                Navigation.PopModalAsync();
            }
            Image Nibiru = new Image
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = ImageSource.FromResource("MobileGuide.images.thisisnotporn.gif"),
                WidthRequest = 500,
                HeightRequest = 500,
                
            };
            Nibiru.GestureRecognizers.Add(tapTaped);


    Content = new StackLayout
            {
                Children =
                {

                    Nibiru
                }
            };
        }
    }
}
