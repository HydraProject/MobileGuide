using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileGuide
{
    public class GuidesPage : ContentPage
    {
        public GuidesPage( MenuPage that)
        {
            //--Объявление элементов страницы
            Image attic = new Image
            {
                Source = ImageSource.FromResource("MobileGuide.images.city_3.png"),
                HeightRequest = 100,
                WidthRequest = 177
            };

            Label header = new Label
            {
                Text = "Мобильный Гид",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
        
            TableView tableView = new TableView
            {
                BackgroundColor = ((Color.Red.WithHue(0.5638)).WithSaturation(0.73)).WithLuminosity(0.794),
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new ImageCell
                        {
                            ImageSource = ImageSource.FromResource("MobileGuide.images.city_1.png"),
                            TextColor = Color.White,
                            DetailColor = Color.White,
                            Text = "Вручную созданный",
                            Detail = "Путеводитель",
                            Command = new Command(async () => await table_Elem_Click("1",that) )
                        }
                    }
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            //Padding = new Thickness(0, Device.OnPlatform(20,0,0), 0, 0);

            // Build the page.
            Content = new StackLayout
            {
                Children =
                {
                    attic,
                    header,
                    tableView
                }
            };
        }
        

        private async Task table_Elem_Click(string text,MenuPage that)
        {
            that.guideChange(text);
            Application.Current.Properties["CurrentGuide"] = text;

            try
            {
                await Navigation.PopModalAsync();
            }
            catch (Exception e)
            {
                await DisplayAlert("error", e.Message, "cancer");
            }
        }
    }
}
