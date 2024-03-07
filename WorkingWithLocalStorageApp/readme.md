# About

Example for NuGet package [localstorage](https://www.nuget.org/packages/LocalStorage) with [docs](https://github.com/hanssens/localstorage?tab=readme-ov-file#examples).

In this example the following model is used to store information in a json file.


```csharp
public class Person
{
    public int Id { get; set; }
    public string  FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString() => $"{Id,-4}{FirstName} {LastName}";
}
```

Using default file name `localstorage`

Here we have two settings

```json
{
  "name": "\"John Doe\"",
  "user": "{\"Id\":1,\"FirstName\":\"Karen\",\"LastName\":\"Payne\"}"
}
```

## Remarks

- Yes we can do this with [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to)
- Guess what, this library uses [Json.NET](https://www.newtonsoft.com/json)

With the above known, why use it? For one, its a nice package for .NET Framework 4.6 and higher. Some developer may not want to mess with writing out serializing and deserializing to and from json along with this library does encryption.

Is it perfect? Nope, has 18 outstanding issues. 

## Recommendation

Consider using it for .NET Framework 4.6 and higher. Know that using this library as shown here the information is a plain json file, consider using encryption which the library supports.

Do not use it for .NET Core, learn how to properly serialize and deserialize. See my [article](https://dev.to/karenpayneoregon/c-systemtextjson-37m1) which has source code.