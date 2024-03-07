using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WorkingWithLocalStorageApp.Models;


namespace WorkingWithLocalStorageApp.Pages;
public class IndexModel : PageModel
{
    const string LocalStorageKey = "user";
    private LocalStorage _localStorage;

    [BindProperty]
    public Person Person { get; set; }
    public IndexModel()
    {
        _localStorage = new LocalStorage();
    }

    public void OnGet() { }

    public void OnPostSetLocalToLocalStorage()
    {
        Person.Id = 1;
        _localStorage.Store(LocalStorageKey,Person);
        _localStorage.Persist();

        Log.Information("Set");
    }

    public void OnPostGetFromLocalStorage()
    {
        var person = _localStorage.Get<Person>(LocalStorageKey);

        Log.Information("Person: {person}", person);
    }
}
