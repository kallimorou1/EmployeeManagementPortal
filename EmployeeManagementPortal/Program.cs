using EmployeeManagement.Portal;
using EmployeeManagementPortal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#EmployeeManagement");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("EmployeeManagementAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7109");
    // Additional configuration (headers, timeouts, etc.)
});

builder.Services.AddScoped(sp =>
{ 
var factory = sp.GetRequiredService<IHttpClientFactory>();
var client = factory.CreateClient("EmployeeManagementAPI");
return new EmployeeService(client);
});

await builder.Build().RunAsync();