using Hanssens.Net;

namespace WorkingWithLocalStorageApp.Interfaces;

public interface ILocalSetup
{
    LocalStorageConfiguration Configuration { get; set; }
    string Key { get; init; }
    string Password { get; init; }
}