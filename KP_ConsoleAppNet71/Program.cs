using KP_ConsoleAppNet71.Classes;
using KP_ConsoleAppNet71.Models;
using static System.Globalization.DateTimeFormatInfo;

namespace KP_ConsoleAppNet71;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await ReadCustomersAsyncExample();
        Question();
        Console.ReadLine();
    }

    private static void Question()
    {



        IEnumerable<Month> months = CurrentInfo!.MonthNames[..^1].Select((name, index) =>
            new Month(index + 1, name));

        //var test = CurrentInfo!.MonthNames[..^1].ToList().Details();


        List<DetailsContainer<string>> details = CurrentInfo!.MonthNames[..^1].Details();





        foreach (var container in details)
        {
            Console.WriteLine($"{container.ToString()}");
        }



    }

    private static async Task ReadCustomersAsyncExample()
    {
        List<Customer> customers = await JsonHelpers.ReadCustomersAsync("Customers.json");

        foreach (var (customer, index) in customers.Select((item, index) => (item, index)))
            Console.WriteLine($"{index,-5}{customer.Company,-40}{customer.Contact}");

        Console.WriteLine();

        foreach (var item in customers.Select((customer, index) => new { index, customer }))
            Console.WriteLine($"{item.index,-5}{item.customer.Company,-40}{item.customer.Contact}");

        {
            var index = 0;
            foreach (var customer in await JsonHelpers.ReadCustomersAsync("Customers.json"))
            {
                index++;
                Console.WriteLine($"{index,-5}{customer.Company,-40}{customer.Contact}");
            }
        }



    }

    private static void NewMethod()
    {
        Console.WriteLine(
            """
            {
              "ConnectionsConfiguration": {
                "ActiveEnvironment": "Development",
                "Development": "Server=(localdb)\\mssqllocaldb;Database=TODO;Trusted_Connection=True",
                "Stage": "Stage connection string goes here",
                "Production": "Prod connection string goes here"
              }
            }
            """);

        Console.WriteLine(
            /*lang=json*/
            """
            {
              "ConnectionsConfiguration": {
                "ActiveEnvironment": "Development",
                "Development": "Server=(localdb)\\mssqllocaldb;Database=TODO;Trusted_Connection=True",
                "Stage": "Stage connection string goes here",
                "Production": "Prod connection string goes here"
              }
            }
            """);

        Console.WriteLine(
            /*lang=xml*/
            """
            <Project Sdk="Microsoft.NET.Sdk">
            
            	<PropertyGroup>
            		<OutputType>Exe</OutputType>
            		<TargetFramework>net8.0</TargetFramework>
            		<ImplicitUsings>enable</ImplicitUsings>
            		<Nullable>disable</Nullable>
            	</PropertyGroup>

            </Project>

            """);
    }
}

public record Month(int Id, string Name)
{
    public override string ToString() => $"{{ Name = {Name}, Id = {Id} }}";
}


public static class GenericExtensions
{
    public static List<DetailsContainer<T>> Details<T>(this List<T> sender) =>
        sender.Select((element, index) => new DetailsContainer<T>
        {
            Value = element,
            StartIndex = new(index),
            EndIndex = new(sender.Count - index - 1, true),
            Index = index + 1
        }).ToList();
    
    public static List<DetailsContainer<T>> Details<T>(this T[] sender) =>
        sender.Select((element, index) => new DetailsContainer<T>
        {
            Value = element,
            StartIndex = new(index),
            EndIndex = new(sender.Length - index - 1, true),
            Index = index + 1
        }).ToList();
}

public class DetailsContainer<T>
{
    public T Value { get; init; }
    public Index StartIndex { get; init; }
    public Index EndIndex { get; init; }
    public int Index { get; init; }
    public override string ToString()
        => $"Value: {Value}, Index: {Index}, Start: {StartIndex}, End: {EndIndex}";
}
