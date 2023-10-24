using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WestWindWEbApp.Data;
using WestWindSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//retrieve the connection string from the appsetting.json file
//The connection string will be passed to the class library extension method
//   for use in registering the access to the required databse
var connectionstring = builder.Configuration.GetConnectionString("WWDB");

//setup the registration of services to be available for use by this web app project
//the technique used in this example has the registration of services encapsulated within
//   the class library via an extension class
//Technically you could do all coding for registering services within this class (Program.cs)
builder.Services.WWExtensions(options => options.UseSqlServer(connectionstring));

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
