using DotnetPractice.Models;
using DotnetPractice.Repository.Interface;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace DotnetPractice.Repository.Auth;

public class UserRepository : IUserRepository
{
    private string connectString = "server=<dummy.server>;port=<dummy.port>;user id=<dummy.id>;password=<dummy.password>;database=mvctest;charset=utf8;";
    private static MySqlConnection dbConnection = new MySqlConnection();
    public UserRepository()
    {
        string? server = Environment.GetEnvironmentVariable("DB_SERVER");
        string? port = Environment.GetEnvironmentVariable("DB_SERVER_PORT");
        string? userID = Environment.GetEnvironmentVariable("DB_SERVER_USER_ID");
        string? password = Environment.GetEnvironmentVariable("DB_SERVER_PASSWORD");
        if((server == null) || (port == null) || (userID == null) || password == null)
        {
            throw new Exception("Environment variable required");
        }
        else
        {
            connectString = string.Format("server={0};port={1};user id={2};password={3};database=mvctest;charset=utf8;", server, port, userID, password);
            dbConnection.ConnectionString = connectString;
            Console.WriteLine("connectString: %s\n", connectString);
        }
    }
    private bool CheckWhenOpen()
    {
        if(dbConnection.State != ConnectionState.Open)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckWhenClose()
    {
        if(dbConnection.State != ConnectionState.Closed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

     public void Open()
    {
        //should do someting with docker mysql
        if(CheckWhenOpen())
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

    public void Close()
    {
        //should do someting with docker mysql
        if(CheckWhenClose())
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
    public void AddUser(User user)
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