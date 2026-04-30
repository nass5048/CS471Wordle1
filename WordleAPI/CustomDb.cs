using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using WordleAPI.Classes;

namespace WordleAPI;
//TODO: put this into the wwwroot to save and update the json dynamically
public class CustomDb<TItem>
{
    string FilePath { get; set; }
    string StoredString { get; set; } = "";
    public List<TItem> Item { get; set; } = new();
    public CustomDb(string filePath)
    {
        FilePath = filePath;
        try
        {
            StoredString = File.ReadAllText(FilePath);
            //retrieve from file so we dont have to setup DB 
            Item = JsonSerializer.Deserialize<List<TItem>>(StoredString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from file: {ex.Message}");
            Item = new List<TItem>();
        }
    }
    public bool SaveToDB()
    {
        StoredString = JsonSerializer.Serialize(Item);
        File.WriteAllText(FilePath, StoredString);
        Console.WriteLine($"Error reaasdqdage");
        return true;
    }
}

public class DataBase
{
    public CustomDb<Stats> Stats { get; set; }
    public CustomDb<Login> Login { get; set; }

    public DataBase()
    {
        Stats = new CustomDb<Stats>("Stats.json");
        Login = new CustomDb<Login>("Login.json");
    }
    public void SaveToDatabase()
    {
        Stats.SaveToDB();
        Login.SaveToDB();
    }
}
