using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Floria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionsController : Controller
    {

        private readonly AppDbContext _context;
        public PositionsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            var positions = await _context.Positions.Where(n => !n.IsDeleted)
                                                    .OrderByDescending(n=>n.CreatedDate)
                                                    .ToListAsync();
            return View(positions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (position is null)
            {
                throw new ArgumentNullException();
            }
            position.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
                var position = await _context.Positions.Where(n => !n.IsDeleted && n.Id==id).FirstOrDefaultAsync();

            if (position is null)
            {
                throw new NullReferenceException("Data Could Not Be Found ");
            }
            return View(position);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Position position)
        {


            if (position is null || id is null)
            {
                throw new ArgumentNullException("Id or Position is Null");
            }

            var dbPosition = await _context.Positions.Where(n => !n.IsDeleted && n.Id == id).FirstOrDefaultAsync();
            if (dbPosition is null)
            {
                throw new NullReferenceException();
            }

            dbPosition.Name = position.Name;
            dbPosition.CreatedDate = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 

        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id or Position is Null");
            }

            var dbPosition = await _context.Positions.Where(n => !n.IsDeleted && n.Id == id).FirstOrDefaultAsync();
            if (dbPosition is null)
            {
                throw new NullReferenceException();
            }

            dbPosition.IsDeleted = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //public async Task<bool> IsDataExist(string name)
        //{
        //    return  await _context.Positions.AnyAsync(n => n.Name.Trim().ToLower() == name.Trim().ToLower());
        //}
    }
}

