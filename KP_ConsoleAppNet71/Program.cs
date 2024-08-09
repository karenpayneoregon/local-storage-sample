using KP_ConsoleAppNet71.Classes;
using KP_ConsoleAppNet71.Models;
using System.Reflection;

namespace KP_ConsoleAppNet71;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await ReadCustomersAsyncExample();
        
        Console.ReadLine();
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