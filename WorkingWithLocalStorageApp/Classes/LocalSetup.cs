﻿using Hanssens.Net;
using WorkingWithLocalStorageApp.Interfaces;

namespace WorkingWithLocalStorageApp.Classes;

/// <summary>
/// Setup for writing and reading local storage file.
/// </summary>
/// <remarks>
/// For demonstration user secrets are used
/// </remarks>
public sealed class LocalSetup : ILocalSetup
{
    private static readonly Lazy<LocalSetup> Lazy = new(() => new LocalSetup());
    public static LocalSetup Instance => Lazy.Value;
    public LocalStorageConfiguration Configuration { get; set; }
    public string Key { get; init; } 
    public string Password { get; init; }
    private static string Salt { get; set; }
    
    public LocalSetup()
    {
        Key = VaultReader.Key;
        Password = VaultReader.Password;
        Salt = VaultReader.Salt;

        Configuration = GetConfiguration();
    }

    private static LocalStorageConfiguration GetConfiguration() => new() { EnableEncryption = true, EncryptionSalt = Salt };
}
