using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileGuide
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Label header = new Label
            {
                Text = "Мобильный Гид",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var layout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            async Task table_Elem_Click()
            {
                await Navigation.PushModalAsync(new GuidePage());
            }

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
                            ImageSource = ImageSource.FromResource("MobileGuide.logo.png"),
                            TextColor = Color.White,
                            DetailColor = Color.White,
                            Text = "This is an ImageCell",
                            Detail = "This is some detail text",
                            Command = new Command(async () => await table_Elem_Click())
                        },
                        createTableElem("piu")
                    }
                },
                VerticalOptions = LayoutOptions.FillAndExpand                
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    tableView
                }
            };
        }
        private TableSection createTableElem( string text)
        {
            //Да, так работает
            return new TableSection
            {
                new ImageCell
                        {
                            ImageSource = ImageSource.FromResource("MobileGuide.logo.png"),
                            TextColor = Color.White,
                            DetailColor = Color.White,
                            Text = text,
                            Detail = "Путеводитель",
                        }
            };
            
        }
    }
}