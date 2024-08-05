using WorkingWithLocalStorageApp.Interfaces;

namespace WorkingWithLocalStorageApp.Models;

public class SecretVault : ISecretVault
{
    public string Key { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}
