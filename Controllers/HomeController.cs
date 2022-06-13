using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManGaStore.Models;
using ManGaStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ManGaStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManGaStoreDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ManGaStoreDbContext _context;        
        private IManGaStoreRepository repository;
        public int PageSize = 3;

        public HomeController(IManGaStoreRepository repo, ManGaStoreDbContext context, IWebHostEnvironment hostEnvironment)
        {
            repository = repo;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _context = context;
        }

        public IActionResult Index(string genre, int manGaPage = 1)
            => View(new ManGaListViewModel
            {
                ManGas = repository.ManGas
                    .Where(p => genre == null || p.Genre == genre)
                    .OrderBy(p => p.ManGaID)
                    .Skip((manGaPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = manGaPage,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                    repository.ManGas.Count() :
                    repository.ManGas.Where(e =>
                    e.Genre == genre).Count()
                },
                CurrentGenre = genre
            });

        public IActionResult Created()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Created(ManGaViewModels model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                ManGa coffee = new ManGa
                {

                    Title = model.Title,                    
                    Genre = model.Genre,
                    Price = model.Price,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(coffee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(ManGaViewModels model)
        {
            string uniqueFileName = null;

            if (model.ImageManGa != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageManGa.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageManGa.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.ManGas
                .FirstOrDefaultAsync(m => m.ManGaID == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // POST: SMartPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sMartPhone = await _context.ManGas.FindAsync(id);
            _context.ManGas.Remove(sMartPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SMartPhoneExists(long id)
        {
            return _context.ManGas.Any(e => e.ManGaID == id);
        }
    }
}
