using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPatternProduct.Data;
using WebAppPatternProduct.Models;

namespace WebAppPatternProduct.Controllers
{
    public class ProductsPOCOController : Controller
    {
        private readonly WebAppPatternProductContext _context;

        public ProductsPOCOController(WebAppPatternProductContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: ProductsPOCO
        public async Task<IActionResult> Index(string productCategory ,string searchString)
        {
            IQueryable<string> categoryQuery = from m in _context.ProductPOCO
                                               orderby m.CategoryProduct
                                               select m.CategoryProduct;
            var products = from m in _context.ProductPOCO
                           select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(productCategory))
            {
                products = products.Where(x => x.CategoryProduct == productCategory);
            }
            var productCategoryVM = new ProductCategoryViewModel
            {
                Category = new SelectList(await categoryQuery.Distinct().ToArrayAsync()),
                Products = await products.ToListAsync()
            };
              return View(productCategoryVM);
        }

        // GET: ProductsPOCO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductPOCO == null)
            {
                return NotFound();
            }

            var productPOCO = await _context.ProductPOCO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPOCO == null)
            {
                return NotFound();
            }

            return View(productPOCO);
        }

        // GET: ProductsPOCO/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsPOCO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,CategoryProduct,Price")] ProductPOCO productPOCO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productPOCO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productPOCO);
        }

        // GET: ProductsPOCO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductPOCO == null)
            {
                return NotFound();
            }

            var productPOCO = await _context.ProductPOCO.FindAsync(id);
            if (productPOCO == null)
            {
                return NotFound();
            }
            return View(productPOCO);
        }

        // POST: ProductsPOCO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,CategoryProduct,Price")] ProductPOCO productPOCO)
        {
            if (id != productPOCO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPOCO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPOCOExists(productPOCO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productPOCO);
        }

        // GET: ProductsPOCO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductPOCO == null)
            {
                return NotFound();
            }

            var productPOCO = await _context.ProductPOCO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPOCO == null)
            {
                return NotFound();
            }

            return View(productPOCO);
        }

        // POST: ProductsPOCO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductPOCO == null)
            {
                return Problem("Entity set 'WebAppPatternProductContext.ProductPOCO'  is null.");
            }
            var productPOCO = await _context.ProductPOCO.FindAsync(id);
            if (productPOCO != null)
            {
                _context.ProductPOCO.Remove(productPOCO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPOCOExists(int id)
        {
          return (_context.ProductPOCO?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
