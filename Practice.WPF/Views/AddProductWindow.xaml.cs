using System.Windows;
using Practice.WPF.Services;

namespace Practice.WPF;

public partial class AddProductWindow : Window
{
    private readonly ApiService _apiService;

    public AddProductWindow()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    private async void SaveButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        var result =
            await _apiService.AddProductAsync(
                NameBox.Text,
                DescriptionBox.Text);

        if (result)
        {
            MessageBox.Show("Товар добавлен");
            Close();
        }
        else
        {
            MessageBox.Show("Ошибка добавления");
        }
    }
}