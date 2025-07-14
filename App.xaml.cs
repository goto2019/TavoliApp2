
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System;

namespace TavoliApp
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Services = serviceProvider;

            MainPage = new NavigationPage(new AppViews.LoginPage(serviceProvider));
        }
    }
}
