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
        public GuidesPage( MainPage that)
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
                BackgroundColor = Color.Black,
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
                        },
                        createTableElem("С помощью метода созданный",that)
                    }
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

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



        private async Task table_Elem_Click(string text,MainPage that)
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

        private ImageCell createTableElem(string text,MainPage that)
        {
            //Да, так работает
            return new ImageCell
            {
                ImageSource = ImageSource.FromResource("MobileGuide.images.city_2.png"),
                TextColor = Color.White,
                DetailColor = Color.White,
                Text = text,
                Detail = "Путеводитель",
                Command = new Command(async () => await table_Elem_Click("2", that))
            };

        }
    }
}
