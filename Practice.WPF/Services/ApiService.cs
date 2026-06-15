using Practice.WPF.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Practice.WPF.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();

        _httpClient.BaseAddress =
            new Uri("http://localhost:5005/");
    }

    public async Task<LoginResponse?> Login(
        string login,
        string password)
    {
        var request = new LoginRequest
        {
            Login = login,
            Password = password
        };

        var response =
            await _httpClient.PostAsJsonAsync(
                "api/auth/login",
                request);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content
            .ReadFromJsonAsync<LoginResponse>();
    }
}