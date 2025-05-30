using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend;
using Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<RenewBackendUrlHandler>();
builder.Services.AddScoped<BackendService>();
builder.Services.AddScoped(_ => new HttpClient {
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
    DefaultRequestHeaders = {
        { "bypass-tunnel-reminder", "true" }
    }
});

await builder.Build().RunAsync();