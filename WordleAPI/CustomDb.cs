using System.Text.Json;
using System.Text.Json.Serialization;
using WordleAPI.Classes;

namespace WordleAPI;
public class DataBase
{
    public List<Stats?> Stats { get; set; }
    public List<Login> Login { get; set; }

    // Optionally pass a basePath from the host (for example IWebHostEnvironment.ContentRootPath)
    public DataBase()
    {
        Stats = new List<Stats?>();
        Login = new List<Login>();
    }
    public void UpdateStoredDB(DataBase dataBase)
    {
        Stats = dataBase.Stats;
        Login = dataBase.Login;
    }
}