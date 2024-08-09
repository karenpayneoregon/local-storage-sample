using Hanssens.Net;
using WorkingWithLocalStorageApp.Classes;
using WorkingWithLocalStorageApp.Interfaces;

namespace WorkingWithLocalStorageApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        SetupLogging.Development();

        /*
         * service to get configuration and password from appsettings.json
         * setup with user secrets (Azure is a better option).
         */
        builder.Services.AddSingleton<ILocalSetup, LocalSetup>();

        // service to read and write to local storage file
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
