using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using TavoliApp.AppViews;

namespace TavoliApp
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Imposta la pagina iniziale passando il serviceProvider al LoginPage
            MainPage = new LoginPage(serviceProvider);
        }
    }
}