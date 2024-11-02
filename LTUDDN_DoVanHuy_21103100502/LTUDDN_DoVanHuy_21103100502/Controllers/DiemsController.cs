using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTUDDN_DoVanHuy_21103100502.Models.DB;

namespace LTUDDN_DoVanHuy_21103100502.Controllers
{
    public class DiemsController : Controller
    {
        private readonly DCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext _context;

        public DiemsController(DCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext context)
        {
            _context = context;
        }

        // GET: Diems
        public async Task<IActionResult> Index()
        {
            var dCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext = _context.Diems.Include(d => d.MasvNavigation);

            return View(await dCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext.ToListAsync());
        }

        // GET: Diems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diems
                .Include(d => d.MasvNavigation)
                .FirstOrDefaultAsync(m => m.Masv == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // GET: Diems/Create
        public IActionResult Create()
        {
            ViewData["Masv"] = new SelectList(_context.SinhViens, "Masv", "Masv");
            return View();
        }

        // POST: Diems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masv,Tenmh,Diem1")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Masv"] = new SelectList(_context.SinhViens, "Masv", "Masv", diem.Masv);
            return View(diem);
        }

        // GET: Diems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }
            ViewData["Masv"] = new SelectList(_context.SinhViens, "Masv", "Masv", diem.Masv);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masv,Tenmh,Diem1")] Diem diem)
        {
            if (id != diem.Masv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemExists(diem.Masv))
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
            ViewData["Masv"] = new SelectList(_context.SinhViens, "Masv", "Masv", diem.Masv);
            return View(diem);
        }

        // GET: Diems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diems
                .Include(d => d.MasvNavigation)
                .FirstOrDefaultAsync(m => m.Masv == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diem = await _context.Diems.FindAsync(id);
            if (diem != null)
            {
                _context.Diems.Remove(diem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemExists(string id)
        {
            return _context.Diems.Any(e => e.Masv == id);
        }
    }
}
