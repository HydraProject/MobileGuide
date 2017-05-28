using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileGuide
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage;
        public static Options _appOptions = new Options();

        public App()
        {
           
            //InitializeComponent();
            MasterDetailPage  = new MasterDetailPage
            {
                Master = new MenuPage(),
                Detail = new NavigationPage(new MainPage()),
            };
            MainPage = MasterDetailPage;
            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Black);
            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
