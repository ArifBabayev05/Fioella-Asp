using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Repositories;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Floria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {

        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public ProductsController(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products;

            try
            {
                products =await _productRepository.GetAll();
            }
            catch(NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Product product;
            try
            {
                product= await _productRepository.Get(id);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAll();
            ViewData["categories"] = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product)
        {
            var categories = await _categoryRepository.GetAll(); 
            ViewData["categories"] = categories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _productRepository.Create(product);

            return RedirectToAction(nameof(Index));

           
        }

        public async Task<IActionResult> Update(int? id)
        {

            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _categoryRepository.Get(id);
            if (data is null)
            {
                throw new NullReferenceException();
            }
            var categories = await _categoryRepository.GetAll();
            ViewData["categories"] = categories;
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Product product)
        {
            var categories = await _categoryRepository.GetAll();
            ViewData["categories"] = categories;


            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productRepository.Update(id, product);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _productRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
            return RedirectToAction(nameof(Index));
        }
     
     
    }
}

