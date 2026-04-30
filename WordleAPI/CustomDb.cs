using System.Text.Json;
using System.Text.Json.Serialization;
using WordleAPI.Classes;

namespace WordleAPI;
//TODO: put this into the wwwroot to save and update the json dynamically
public class CustomDb<TItem>
{
    public List<TItem> Items { get; set; } = new();

    // Accept optional basePath (useful for passing env.ContentRootPath from server)
}


public class DataBase
{
    public CustomDb<Stats?> Stats { get; set; }
    public CustomDb<Login> Login { get; set; }

    // Optionally pass a basePath from the host (for example IWebHostEnvironment.ContentRootPath)
    public DataBase()
    {
        Stats = new CustomDb<Stats?>();
        Login = new CustomDb<Login>();
    }
    public void UpdateStoredDB(DataBase dataBase)
    {
        Stats = dataBase.Stats;
        Login = dataBase.Login;
    }
}