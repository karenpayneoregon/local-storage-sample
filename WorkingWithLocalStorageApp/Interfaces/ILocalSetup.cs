using Hanssens.Net;

namespace WorkingWithLocalStorageApp.Interfaces;

/// <summary>
/// Members for setting up local storage.
/// </summary>
public interface ILocalSetup
{
    LocalStorageConfiguration Configuration { get; set; }
    string Key { get; init; }
    string Password { get; init; }
}