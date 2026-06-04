using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WordleAPI.Classes;
using WordleBackend.Classes;

namespace WordleAPI;

public class DataBase
{
    // Lists that store main data 
    public List<DailyWords> DailyWords { get; set; }
    //public List<Stats?> Stats { get; set; }
    public List<Login> Login { get; set; }
    public List<FriendRequest> FriendRequests { get; set; }
    public List<BugReport> BugReports { get; set; }

    // Optionally pass a basePath from the host (for example IWebHostEnvironment.ContentRootPath)
    /*
        Function Name: DataBase
        Input: N/A
        Output: Database object
        Brief Description:
            Initializes lists to store data
    */

    public DataBase()
    {
        //Stats = new List<Stats?>();
        Login = new List<Login>();
        DailyWords = new List<DailyWords>();
        FriendRequests = new List<FriendRequest>();
        BugReports = new List<BugReport>();
    }

    /*
        Function Name: UpdateStoredDB
        Input: Database object
        Output: N/A
        Brief Description:
            Replace data stored with data from database
    */

    public void UpdateStoredDB(DataBase dataBase)
    {
        //Stats = dataBase.Stats;
        Login = dataBase.Login;
        DailyWords = dataBase.DailyWords;
        FriendRequests = dataBase.FriendRequests;
        BugReports = dataBase.BugReports;
    }

    /*
        Function Name: LoadData
        Input: HTTP client that requests data from API
        Output: N/A
        Brief Description:
            Loads current database info from the backend API and updates the local storage
    */

    public async Task LoadData(HttpClient Http)
    {
        var test = await Http.GetFromJsonAsync<DataBase>("https://localhost:7160/api/data");
        if (test != null)
            UpdateStoredDB(test);
    }

    /*
        Function Name: SaveData
        Input: HTTP client that saves data from API
        Output: N/A
        Brief Description:
            Sends current database info to the backend API for storage
    */

    public async Task SaveData(HttpClient Http)
    {
        await Http.PostAsJsonAsync("https://localhost:7160/api/data", this);
    }

    /*
        Function Name: UpdateUserData
        Input: Updated login info for the user that requests the change
        Output: N/A
        Brief Description:
            Finds user via UserID and updates saved login/account infor
    */

    public void UpdateUserData(Login login)
    {
        var existingLogin = Login.FirstOrDefault(l => l.UserID == login.UserID);
        if (existingLogin != null)
        {
            existingLogin.SetUserLogin(login);
        }
    }
}