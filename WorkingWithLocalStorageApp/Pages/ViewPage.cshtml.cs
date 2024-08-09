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

        public ViewPageModel(ILocalSetup vault, ILocalStorage storage)
        {
            _localStorage = (LocalStorage)storage;
        }

        [BindProperty]
        public Person Person { get; set; }

        public void OnGet()
        {
            Person = _localStorage.Get<Person>(LocalStorageKey);

        }
    }
}
