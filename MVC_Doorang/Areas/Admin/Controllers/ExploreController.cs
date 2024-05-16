
using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Doorang.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class ExploreController : Controller
    {
        private readonly IExploreService _exploreService;

        public ExploreController(IExploreService exploreService)
        {
            _exploreService = exploreService;
        }

        public IActionResult Index()
        {
            List<Explore> explore = _exploreService.GetAllExplore();
            return View(explore);
        }

      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Explore explore)
        {
            if (!ModelState.IsValid) return View();
            _exploreService.AddExplore(explore);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _exploreService.DeleteExplore(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Update(int id,Explore explore)
        {
            _exploreService.UpdateExplore(id, explore);
            return RedirectToAction(nameof(Index));
        }

    }
}
