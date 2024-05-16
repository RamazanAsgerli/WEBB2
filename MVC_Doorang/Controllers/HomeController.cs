using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace MVC_Doorang.Controllers
{
    public class HomeController : Controller
    {
        IExploreService _exploreService;

        public HomeController(IExploreService exploreService)
        {
            _exploreService = exploreService;
        }

        public IActionResult Index()
        {
            List<Explore> explores = _exploreService.GetAllExplore();
            return View(explores);
        }


    }
}