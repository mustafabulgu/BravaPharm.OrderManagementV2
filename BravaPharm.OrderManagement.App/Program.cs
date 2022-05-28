using System.Reflection;
using BravaPharm.OrderManagement.App;
using BravaPharm.OrderManagement.App.Contracts;
using BravaPharm.OrderManagement.App.MessageHandlers;
using BravaPharm.OrderManagement.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.IdentityModel.Logging;
using MudBlazor.Services;
using Serilog;

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.BrowserConsole()
    .CreateLogger();



try
{
    Log.Information("Check logging1");
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    //IdentityModelEventSource.ShowPII = true;
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
    Log.Information("Check logging2");

    var apiUrl = builder.Configuration["ApiUrl"];
    builder.Services.AddTransient<ApiAuthorizationMessageHandler>();
    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


    builder.Services.AddHttpClient<IClient, Client>(h => h.BaseAddress = new Uri(apiUrl))
        .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();


    

    builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
    builder.Services.AddMudServices();
    builder.Services.AddMsalAuthentication(options =>
    {
        builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
        options.ProviderOptions.DefaultAccessTokenScopes.Add(builder.Configuration["AzureAdReadWriteScope"]);
    });

    await builder.Build().RunAsync();
}catch(Exception ex)
{
    Log.Error(ex.ToString());
    throw;
}
