using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MobileGuide
{
    public class MainLink : Button
    {
        public MainLink(string name)
        {
            Image = "images\\logo.png";
            Text = name;
            Command = new Command(o => {
                App.MasterDetailPage.Detail = new NavigationPage(new LinkPage(name));
                App.MasterDetailPage.IsPresented = false;
            });
        }
    }
}