using Hanssens.Net;
using WorkingWithLocalStorageApp.Classes;
using WorkingWithLocalStorageApp.Interfaces;
using WorkingWithLocalStorageApp.Models;

namespace WorkingWithLocalStorageApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        SetupLogging.Development();

        builder.Services.AddSingleton<ILocalSetup, LocalSetup>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
