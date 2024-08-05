namespace WorkingWithLocalStorageApp.Interfaces;

public interface ISecretVault
{
    string Key { get; set; }
    string Password { get; set; }
    string Salt { get; set; }
}