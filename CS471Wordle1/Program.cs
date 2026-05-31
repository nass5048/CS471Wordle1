using CS471Wordle1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WordleAPI;
using WordleAPI.Classes;
using WordleBackend;
using static System.Net.Mime.MediaTypeNames;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<Services.SpinnerService>();
builder.Services.AddSingleton<DataBase>();
builder.Services.AddSingleton<Login>();
builder.Services.AddScoped<BrowserStorage>();

await builder.Build().RunAsync();
