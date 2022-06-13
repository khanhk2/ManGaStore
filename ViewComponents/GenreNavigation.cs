using Microsoft.AspNetCore.Mvc;
using ManGaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IManGaStoreRepository repository;
        public GenreNavigation(IManGaStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.ManGas
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
