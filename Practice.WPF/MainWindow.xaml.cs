using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice.WPF.Services;

namespace Practice.WPF;

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

        MessageBox.Show(
            $"Добро пожаловать!\n\n{user.FullName}\nРоль: {user.Role}");
    }

    private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}