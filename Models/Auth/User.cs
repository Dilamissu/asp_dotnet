namespace DotnetPractice.Models;

public class User
{
    public required int Id {get;init;}
    public required string UserId {get;init;}
    public required string Username {get; set;}
    public required string Password {get; set;}
}