using DotnetPractice.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DotnetPractice.Services.Auth;

public static class UserService
{
    // example https://ithelp.ithome.com.tw/articles/10193802
    // to change string format
    private static string connectString = "server=<dummy.server>;port=<dummy.port>;user id=<dummy.id>;password=<dummy.password>;database=mvctest;charset=utf8;";
    private static MySqlConnection dbConnection = new MySqlConnection();
    public static void Open()
    {
        //should do someting with docker mysql
        dbConnection.ConnectionString = connectString;
        if(dbConnection.State != ConnectionState.Open)
        {
            dbConnection.Open();
        }

        if(dbConnection.State != ConnectionState.Open)
        {
            // not sure where to put new exceptions
            throw new Exception("DB open failed");
        }
        else
        {
            Console.WriteLine("DB opend");
        }

    }

    public static void Close()
    {
        //should do someting with docker mysql
        dbConnection.ConnectionString = connectString;
        if(dbConnection.State != ConnectionState.Closed)
        {
            dbConnection.Close();
        }

        if(dbConnection.State != ConnectionState.Closed)
        {
            // not sure where to put new exceptions
            throw new Exception("DB close failed");
        }
        else
        {
            Console.WriteLine("DB closed");
        }

    }
    public static void Create(User user)
    {
        if(dbConnection.State != ConnectionState.Open)
        {
            // not sure where to put new exceptions
            throw new InvalidOperationException("DB is not opened");
        }

        string dbSQL = @"INSERT INTO 'User'('Id', 'Username', 'Password') VALUES (0, 'test', 'test')";

        MySqlCommand cmd = new MySqlCommand(dbSQL, dbConnection);
        if(cmd.ExecuteNonQuery() > 0)
        {
            // succeed
            Console.WriteLine("Insert succeeded");
        }
        else
        {
            Console.WriteLine("Insert Failed");
        }
    }
}