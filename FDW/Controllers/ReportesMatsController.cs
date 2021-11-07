using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FDW.Data;
using FDW.Models;

namespace FDW.Controllers
{
    public class ReportesMatsController : Controller
    {
        private readonly FDWContext _context;

        public ReportesMatsController(FDWContext context)
        {
            _context = context;
        }

        // GET: ReportesMats
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportesMat.ToListAsync());
        }

        // GET: ReportesMats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportesMat = await _context.ReportesMat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportesMat == null)
            {
                return NotFound();
            }

            return View(reportesMat);
        }

        // GET: ReportesMats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportesMats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_Producto,Cantidad_Producto,Estado_Producto")] ReportesMat reportesMat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportesMat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportesMat);
        }

        // GET: ReportesMats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportesMat = await _context.ReportesMat.FindAsync(id);
            if (reportesMat == null)
            {
                return NotFound();
            }
            return View(reportesMat);
        }

        // POST: ReportesMats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_Producto,Cantidad_Producto,Estado_Producto")] ReportesMat reportesMat)
        {
            if (id != reportesMat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportesMat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportesMatExists(reportesMat.Id))
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
            return View(reportesMat);
        }

        // GET: ReportesMats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportesMat = await _context.ReportesMat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportesMat == null)
            {
                return NotFound();
            }

            return View(reportesMat);
        }

        // POST: ReportesMats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportesMat = await _context.ReportesMat.FindAsync(id);
            _context.ReportesMat.Remove(reportesMat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportesMatExists(int id)
        {
            return _context.ReportesMat.Any(e => e.Id == id);
        }
    }
}
