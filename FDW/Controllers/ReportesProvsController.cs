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
    public class ReportesProvsController : Controller
    {
        private readonly FDWContext _context;

        public ReportesProvsController(FDWContext context)
        {
            _context = context;
        }

        // GET: ReportesProvs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportesProv.ToListAsync());
        }

        // GET: ReportesProvs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportesProv = await _context.ReportesProv
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportesProv == null)
            {
                return NotFound();
            }

            return View(reportesProv);
        }

        // GET: ReportesProvs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportesProvs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_Pro,Empresa_Pro,Estado_Pro")] ReportesProv reportesProv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportesProv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportesProv);
        }

        // GET: ReportesProvs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportesProv = await _context.ReportesProv.FindAsync(id);
            if (reportesProv == null)
            {
                return NotFound();
            }
            return View(reportesProv);
        }

        // POST: ReportesProvs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_Pro,Empresa_Pro,Estado_Pro")] ReportesProv reportesProv)
        {
            if (id != reportesProv.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportesProv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportesProvExists(reportesProv.Id))
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
            return View(reportesProv);
        }

        // GET: ReportesProvs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportesProv = await _context.ReportesProv
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportesProv == null)
            {
                return NotFound();
            }

            return View(reportesProv);
        }

        // POST: ReportesProvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportesProv = await _context.ReportesProv.FindAsync(id);
            _context.ReportesProv.Remove(reportesProv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportesProvExists(int id)
        {
            return _context.ReportesProv.Any(e => e.Id == id);
        }
    }
}
