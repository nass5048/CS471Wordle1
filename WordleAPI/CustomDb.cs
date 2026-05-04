using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WordleAPI.Classes;
using WordleBackend.Classes;

namespace WordleAPI;
public class DataBase
{
    public List<DailyWords> DailyWords { get; set; }


    public List<Stats?> Stats { get; set; }
    public List<Login> Login { get; set; }

    // Optionally pass a basePath from the host (for example IWebHostEnvironment.ContentRootPath)
    public DataBase()
    {
        Stats = new List<Stats?>();
        Login = new List<Login>();
        DailyWords = new List<DailyWords>();
    }
    public void UpdateStoredDB(DataBase dataBase)
    {
        Stats = dataBase.Stats;
        Login = dataBase.Login;
        DailyWords = dataBase.DailyWords;
    }

    public async Task LoadData(HttpClient Http)
    {
        var test = await Http.GetFromJsonAsync<DataBase>("https://localhost:7160/api/data");
        if (test != null)
            UpdateStoredDB(test);
    }
    public async Task SaveData(HttpClient Http)
    {
        await Http.PostAsJsonAsync("https://localhost:7160/api/data", this);
    }

    public void UpdateUserData(Login login)
    {
        var existingLogin = Login.FirstOrDefault(l => l.UserID == login.UserID);
        if (existingLogin != null)
        {
            existingLogin.SetUserLogin(login);
        }
    }
}