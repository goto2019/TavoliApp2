using Microsoft.Maui.Controls;
using TavoliApp.ViewModels;
using System;
using Microsoft.Maui.Storage;

namespace TavoliApp.AppViews
{
    public partial class LoginPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var viewModel = new LoginViewModel(_serviceProvider);

            if (Preferences.ContainsKey("UltimoIp"))
                viewModel.Ip = Preferences.Get("UltimoIp", "");

            BindingContext = viewModel;
        }
    }
}
