using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C4_Assignment.Data;
using C4_Assignment.Models;

namespace C4_Assignment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CungCapsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CungCapsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/CungCaps
        public async Task<IActionResult> Index()
        {
              return _context.CungCaps != null ? 
                          View(await _context.CungCaps.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.CungCaps'  is null.");
        }

        // GET: Admin/CungCaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CungCaps == null)
            {
                return NotFound();
            }

            var cungCap = await _context.CungCaps
                .FirstOrDefaultAsync(m => m.CungCapID == id);
            if (cungCap == null)
            {
                return NotFound();
            }

            return View(cungCap);
        }

        // GET: Admin/CungCaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CungCaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CungCapID,TenCungCap,ThanhPho,QuocGia")] CungCap cungCap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cungCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cungCap);
        }

        // GET: Admin/CungCaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CungCaps == null)
            {
                return NotFound();
            }

            var cungCap = await _context.CungCaps.FindAsync(id);
            if (cungCap == null)
            {
                return NotFound();
            }
            return View(cungCap);
        }

        // POST: Admin/CungCaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CungCapID,TenCungCap,ThanhPho,QuocGia")] CungCap cungCap)
        {
            if (id != cungCap.CungCapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cungCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CungCapExists(cungCap.CungCapID))
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
            return View(cungCap);
        }

        // GET: Admin/CungCaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CungCaps == null)
            {
                return NotFound();
            }

            var cungCap = await _context.CungCaps
                .FirstOrDefaultAsync(m => m.CungCapID == id);
            if (cungCap == null)
            {
                return NotFound();
            }

            return View(cungCap);
        }

        // POST: Admin/CungCaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CungCaps == null)
            {
                return Problem("Entity set 'ApplicationDBContext.CungCaps'  is null.");
            }
            var cungCap = await _context.CungCaps.FindAsync(id);
            if (cungCap != null)
            {
                _context.CungCaps.Remove(cungCap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CungCapExists(int id)
        {
          return (_context.CungCaps?.Any(e => e.CungCapID == id)).GetValueOrDefault();
        }
    }
}
