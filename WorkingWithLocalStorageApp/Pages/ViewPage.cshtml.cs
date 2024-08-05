using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkingWithLocalStorageApp.Classes;
using WorkingWithLocalStorageApp.Interfaces;
using WorkingWithLocalStorageApp.Models;

namespace WorkingWithLocalStorageApp.Pages
{

    public class ViewPageModel : PageModel
    {
        string LocalStorageKey = LocalSetup.Instance.Key;
        private LocalStorage _localStorage;

        public ViewPageModel(ILocalSetup vault)
        {
            _localStorage = new LocalStorage(vault.Configuration, vault.Password);
        }

        [BindProperty]
        public Person Person { get; set; }

        public void OnGet()
        {
            var person = _localStorage.Get<Person>(LocalStorageKey);
            Log.Information("Person: {person}", person);
        }
    }
}
