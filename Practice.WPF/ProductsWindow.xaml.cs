using Practice.WPF.Models;
using Practice.WPF.Services;
using System.Windows;

namespace Practice.WPF
{
    public partial class ProductsWindow : Window
    {
        private readonly ApiService _apiService = new();

        public ProductsWindow()
        {
            InitializeComponent();
            if (CurrentUser.Role == "Client")
            {
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }

            if (CurrentUser.Role == "Manager")
            {
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }

            Loaded += ProductsWindow_Loaded;
        }

        private async void ProductsWindow_Loaded(
    object sender,
    RoutedEventArgs e)
        {
            var products =
                await _apiService.GetProductsAsync();

            ProductsGrid.ItemsSource = products;
        }

        private void AddButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            var window = new AddProductWindow();

            window.ShowDialog();
        }
    }
}