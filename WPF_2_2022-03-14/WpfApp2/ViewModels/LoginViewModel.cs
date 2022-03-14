using System;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Commands;
using WpfApp2.Data;
using WpfApp2.Views;

namespace WpfApp2.ViewModels
{
    public class LoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(SignIn);
        }

        private void SignIn()
        {
            if (Login != "test" && Password != "test")
            {
                MessageBox.Show("Invalid password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Users.CurrentUserLogin = Login;

            App.NavigateTo<SecondPage>();
        }
    }
}
