using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkingWithLocalStorageApp.Classes;
using WorkingWithLocalStorageApp.Models;


namespace WorkingWithLocalStorageApp.Pages;
public class IndexModel : PageModel
{
    string LocalStorageKey = LocalSetup.Instance.Key;
    private LocalStorage _localStorage;

    [BindProperty]
    public Person Person { get; set; }

    public IndexModel(ILocalStorage storage) => _localStorage = storage as LocalStorage;

    public void OnGet() { }

    public RedirectToPageResult OnPostSetLocalToLocalStorage()
    {
        Person.Id = 1;
        _localStorage.Store(LocalStorageKey,Person);
        _localStorage.Persist();
        
        return RedirectToPage("ViewPage");
    }

    public void OnPostGetFromLocalStorage()
    {
        var person = _localStorage.Get<Person>(LocalStorageKey);

        Log.Information("Person: {person}", person);
    }
}
