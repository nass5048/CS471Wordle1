using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WordleBackend.Classes;
using WordleBackend.Enums;

namespace WordleAPI.Classes;

public class Login
{
    // Identifies user ID of user
    public long UserID { get; set; }

    // Identifies user's username used for login and display in game
    public string Username { get; set; }

    // Identifies user's password used for login and account changes
    public string Password { get; set; } //TODO need to implement hash and salt for security

    // Stores user statistics
    public Stats UserStats { get; set; } = new Stats();

    // Implements user's permissions within the app
    public Permission UserPermission { get; set; } = Permission.Guest;


    /*
        Function Name: SetUserLogin
        Input: login
        Output: N/A
        Brief Description:
            Copies account info from login into current user
    */

    public void SetUserLogin(Login login)
    {
        UserID = login.UserID;
        Username = login.Username;
        Password = login.Password;
        UserStats = login.UserStats;
        UserPermission = login.UserPermission;
    }
}
