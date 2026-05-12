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
            System.Diagnostics.Debug.WriteLine($"server: {server}");
            System.Diagnostics.Debug.WriteLine($"port: {port}");
            System.Diagnostics.Debug.WriteLine($"userID: {userID}");
            System.Diagnostics.Debug.WriteLine($"password: {password}");
            throw new Exception("Environment variable required");
        }
        else
        {
            connectString = string.Format("server={0};port={1};user id={2};password={3};database=cvtest;charset=utf8;", server, port, userID, password);
            dbConnection.ConnectionString = connectString;
            System.Diagnostics.Debug.WriteLine("connectString: {connectString}");
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

     private void open()
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
            System.Diagnostics.Debug.WriteLine("DB opend");
        }

    }

    private void close()
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
            System.Diagnostics.Debug.WriteLine("DB closed");
        }

    }
    public bool AddUser(User user)
    {
        bool result = false;
        open();
    
        string dbSQL = @$"INSERT INTO 'User'('Username', 'Password') VALUES ('{user.Username}', '{user.Password}')";

        MySqlCommand cmd = new MySqlCommand(dbSQL, dbConnection);
        if(cmd.ExecuteNonQuery() > 0)
        {
            // succeed
            System.Diagnostics.Debug.WriteLine("Insert succeeded");
            result = true;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Insert Failed");
            result = false;
        }

        close();
        return result;
    }

    public bool RemoveUser(User user)
    {
        bool result = false;
        open();
    
        string dbSQL = @"DELETE FROM 'User' WHERE Username='{user.Username}'";

        MySqlCommand cmd = new MySqlCommand(dbSQL, dbConnection);
        if(cmd.ExecuteNonQuery() > 0)
        {
            // succeed
            System.Diagnostics.Debug.WriteLine("Insert succeeded");
            result = true;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Insert Failed");
            result = false;
        }

        close();
        return result;
    }
}