using DotnetPractice.Repository.Auth;
using DotnetPractice.Models;

namespace DotnetPractice.Services.Auth;

public static class UserService
{
    // example https://ithelp.ithome.com.tw/articles/10193802
    // to change string format
    private static UserRepository userDB = new UserRepository();
    public static bool Register(User user)
    {
        return userDB.AddUser(user);
    }

    public static bool DeleteAccount(User user)
    {
        return userDB.RemoveUser(user);
    }

    public static User? SearchAccount(string userID)
    {
        return userDB.SearchUser(userID);
    }   
}