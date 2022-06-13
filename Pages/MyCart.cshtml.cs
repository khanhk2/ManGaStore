using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManGaStore.MyTagHelper;
using ManGaStore.Models;
using System.Linq;
namespace ManGaStore.Pages
{
    public class MyCartModel : PageModel
    {
        private IManGaStoreRepository repository;
        public MyCartModel(IManGaStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long mangaId, string returnUrl)
        {
            ManGa manga = repository.ManGas
            .FirstOrDefault(b => b.ManGaID == mangaId);
            myCart.AddItem(manga, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long mangaId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.ManGa.ManGaID == mangaId).ManGa);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}