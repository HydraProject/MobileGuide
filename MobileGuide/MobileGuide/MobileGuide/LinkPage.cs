using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MobileGuide
{
    public class LinkPage : ContentPage
    {
        public LinkPage(string name)
        {
            BackgroundColor = ((Color.Red.WithHue(0.5638)).WithSaturation(0.73)).WithLuminosity(0.794);
            Title = name;

            var attic = new Image();

            var fish = new Label
            {
                
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.Black,
                FormattedText = "Ut facilisis varius condimentum.\nCras hendrerit quam ex," +
                " sed blandit mauris iaculis at. Aliquam erat volutpat. Vestibulum laoreet nisl " +
                "augue, ultricies porttitor purus lobortis sit amet. Quisque sagittis pulvinar erat," +
                " eget iaculis dolor ornare eget. Fusce nunc ipsum, fermentum eu nulla a, eleifend elementum metus. " +
                "Suspendisse potenti. Cras eleifend rhoncus turpis id volutpat. Curabitur cursus volutpat ipsum in volutpat.",
                FontSize = 12
                
                //BackgroundColor = new Color(164, 211, 241)
            };

            Content = new StackLayout
            {
                Children =
                {
                    fish,
                    new Button{Text = "piu"},
                    new Button{Text = "Pou"}
                }
            };
        }
    }
}