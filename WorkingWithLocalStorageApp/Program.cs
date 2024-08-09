using Hanssens.Net;
using Microsoft.Extensions.DependencyInjection;
using WorkingWithLocalStorageApp.Classes;
using WorkingWithLocalStorageApp.Interfaces;
using WorkingWithLocalStorageApp.Models;

namespace WorkingWithLocalStorageApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        SetupLogging.Development();

        builder.Services.AddSingleton<ILocalSetup, LocalSetup>();
        builder.Services.AddScoped<ILocalStorage>(provider =>
        {
            var localSetup = provider.GetRequiredService<ILocalSetup>();
            return new LocalStorage(localSetup.Configuration, localSetup.Password);
        });

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
