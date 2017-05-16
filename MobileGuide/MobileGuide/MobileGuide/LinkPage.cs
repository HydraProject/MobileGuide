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
            Title = name;
            Content = new StackLayout
            {
                Children =
                {
                    new Button{Text = "piu"},
                    new Button{Text = "Pou"}
                }
            };
        }
    }
}