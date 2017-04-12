using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileGuide
{
    public partial class MainPage : ContentPage
    {
        public class TodoItem : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;

            
            string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    if (value.Equals(_name, StringComparison.Ordinal))
                    {
                        // Nothing to do - the value hasn't changed;
                        return;
                    }
                    _name = value;
                    OnPropertyChanged();
                }
            }

            void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        event PropertyChangedEventHandler GuideChanged;

        public MainPage()
        {



            var _todoItem = new TodoItem();


            async Task open_Guides_Catalog()
            {
                try
                {
                    await Navigation.PushModalAsync(new GuidesPage());
                }
                catch (Exception e)
                {
                    await DisplayAlert("error", e.Message, "cancer");
                }
            }

            Image attic = new Image
            {
                Source = ImageSource.FromResource("MobileGuide.images.logo.png"),
                HeightRequest = 100,
                WidthRequest = 100
            };

            Button openCatalog = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Open guides Catalog",
                Command = new Command(async () => await open_Guides_Catalog())
            };

            Label header = new Label
            {
                Text = "Hello Page",
                FontSize = 13.5,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };

            Label info = new Label
            {
                Text = _todoItem.Name
            };

            info.SetBinding(Label.TextProperty, "CurrentGuide");

            info.BindingContext = Application.Current.Properties;

            var label = new Label();
            label.Text = "0";
            label.SetBinding(Label.TextProperty, "Name");
            label.BindingContext = new { Name = CheckGuide() };



            //+= (sender, ea) =>
            //{
            //    label.Text = CheckGuide();
            //};

            Content = new StackLayout
            {
                Children =
                {
                    attic,
                    header,
                    openCatalog,
                    info,
                    label
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
    }
}