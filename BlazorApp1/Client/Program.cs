using BlazorApp1.Client;
using Core.Contract;
using Core.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Repository;
using Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<StoreService>();
builder.Services.AddScoped<StoreCustomerLocationService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<DeliveryService>();

// Register the specific repository if needed
builder.Services.AddScoped<IGenericRepository<Merchant>, GenericRepository<Merchant>>();
builder.Services.AddScoped<MerchantService>();
builder.Services.AddScoped<IGenericRepository<ApplicationOrMuamalah>, GenericRepository<ApplicationOrMuamalah>>();
builder.Services.AddScoped<ApplicationOrMuamalahService>();

await builder.Build().RunAsync();
