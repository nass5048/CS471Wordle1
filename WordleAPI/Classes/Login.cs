using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WordleBackend.Classes;

namespace WordleAPI.Classes;

public class Login
{
    public long UserID { get; set; }

    public string Username { get; set; }

    public string Password { get; set; } //TODO need to implement hash and salt for security

    public Settings UserSettings { get; set; } = new Settings();

    public Stats UserStats { get; set; } = new Stats();

    public void SetUserLogin(Login login)
    {
        UserID = login.UserID;
        Username = login.Username;
        Password = login.Password;
        UserSettings = login.UserSettings;
        UserStats = login.UserStats;
    }
}
