using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WestWindWebApp.Data;
using WestWindSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//retrieve the connection string from the appsettings
//The connection string will be passed to the class library extension method
//  for use in registering the access to the required database
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//setup the registration of services to be available for use by this web application
//the technique used in this example has the registration encapsulated within the
//  class library extension class
//technically, you could do all the setup within this file
builder.Services.WWExtensions(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
