using DAL.Data;
using DAL.Models;
using Floria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floria.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.Where(n => !n.IsDeleted)
                .OrderByDescending(n=>n.CreatedDate)
                .Take(8)
                .Include(n => n.Category)
                .Include(n => n.Image)
                .ToListAsync();
            List<Slider> sliders = await _context.Sliders.Where(n => !n.IsDeleted)
                .Include(n => n.Image)
                .ToListAsync();
            List<Category> categories = await _context.Categories.Where(n => !n.IsDeleted).ToListAsync();
            List<Expert> experts = await _context.Experts.Where(n => !n.IsDeleted)
                .Include(n=>n.ExpertPositions)
                .ThenInclude(n=>n.Position)
                .Include(n => n.Image)
                .ToListAsync();

            HomeVM home = new HomeVM()
            {
                Products = products,
                Sliders = sliders,
                Categories = categories,
                Experts = experts
            };
            return View(model: home);
        }
    }
}
