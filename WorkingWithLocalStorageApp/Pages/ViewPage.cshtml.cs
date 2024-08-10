using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkingWithLocalStorageApp.Classes;
using WorkingWithLocalStorageApp.Models;

namespace WorkingWithLocalStorageApp.Pages;

public class ViewPageModel : PageModel
{
    private LocalStorage _localStorage;

    [BindProperty]
    public Person Person { get; set; }

    public ViewPageModel(ILocalStorage storage) 
        => _localStorage = storage as LocalStorage;

    public void OnGet()
    {
        Person = _localStorage.Get<Person>(LocalSetup.Instance.Key);
    }
}