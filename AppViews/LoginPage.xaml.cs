using Microsoft.Maui.Controls;
using System;
using TavoliApp.ViewModels;

namespace TavoliApp.AppViews
{
    public partial class LoginPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            BindingContext = new LoginViewModel(_serviceProvider);
        }

        private void ChiudiApp_Clicked(object sender, EventArgs e)
        {
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif IOS
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#else
            Application.Current.Quit();
#endif
        }
    }
}
