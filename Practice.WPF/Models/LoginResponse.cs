namespace Practice.WPF.Models;

public class LoginResponse
{
    public int UserId { get; set; }

    public string FullName { get; set; } = "";

    public string Role { get; set; } = "";
}