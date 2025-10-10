using EmployeeManagement.Portal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EmployeeManagement.Portal.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("EmployeeManagement.API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7109/");
    // Additional configuration (headers, timeouts, etc.)
});

//Add employee service wtith DI
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

await builder.Build().RunAsync();


