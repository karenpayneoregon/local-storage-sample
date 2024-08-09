using System.Text.Json;
using KP_ConsoleAppNet71.Models;

namespace KP_ConsoleAppNet71.Classes;

internal class JsonHelpers
{
    public static async Task<T> ReadJsonAsync<T>(string filePath)
    {
        await using FileStream stream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
    // example
    public static async Task<List<Customer>> ReadCustomersAsync(string filePath) 
        => await ReadJsonAsync<List<Customer>>(filePath);
}
