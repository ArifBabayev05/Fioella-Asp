using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Floria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpertsController : Controller
    {

        private readonly AppDbContext _context;
        public ExpertsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var data = await _context.Experts.Where(n => !n.IsDeleted)
                                  .Include(n => n.ExpertPositions)
                                  .ThenInclude(n => n.Position)
                                  .Include(n=>n.Image)
                                  .OrderByDescending(n=>n.CreatedDate)
                                  .ToListAsync();

            return View(data);
        }
    }
}

