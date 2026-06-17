using Practice.WPF.Models;
using Practice.WPF.Services;
using System.Windows;
using System.Windows.Controls;

namespace Practice.WPF
{
    public partial class MainWindow : Window
    {
        private readonly ApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();

            _apiService = new ApiService();
        }

        private async void LoginButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            var user = await _apiService.Login(
                LoginBox.Text,
                PasswordBox.Password);

            if (user == null)
            {
                MessageBox.Show(
                    "Неверный логин или пароль");

                return;
            }
            CurrentUser.Role = user.Role;

            MessageBox.Show(
                $"Добро пожаловать!\n\n{user.FullName}\nРоль: {user.Role}");

            var productsWindow = new ProductsWindow();

            productsWindow.Show();

            this.Close();
        }

        private void LoginBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
        }
    }
}