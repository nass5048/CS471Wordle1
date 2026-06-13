using CS471Wordle1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WordleAPI;
using WordleAPI.Classes;
using WordleBackend;
using static System.Net.Mime.MediaTypeNames;


// Create and configure the Blazor WebAssembly app
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register root app components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register services and app data
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Shared services and app data
builder.Services.AddSingleton<Services.SpinnerService>();
builder.Services.AddSingleton<DataBase>();
builder.Services.AddSingleton<ValidWords>();
builder.Services.AddSingleton<Login>();

// Browser local storage helper service
builder.Services.AddScoped<BrowserStorage>();

// Build and launch app
await builder.Build().RunAsync();
