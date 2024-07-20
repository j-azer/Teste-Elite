using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Elite.Data;
using Projeto_Elite.Models;

namespace Projeto_Elite.Controllers
{
    //[Authorize]
    public class ArquivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArquivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arquivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arquivo.ToListAsync());
        }

        // GET: Arquivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // GET: Arquivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arquivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Arquivo arquivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arquivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arquivo);
        }

        // GET: Arquivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivo.FindAsync(id);
            if (arquivo == null)
            {
                return NotFound();
            }
            return View(arquivo);
        }

        // POST: Arquivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] Arquivo arquivo)
        {
            if (id != arquivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arquivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArquivoExists(arquivo.Id))
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
            return View(arquivo);
        }

        // GET: Arquivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // POST: Arquivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arquivo = await _context.Arquivo.FindAsync(id);
            if (arquivo != null)
            {
                _context.Arquivo.Remove(arquivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArquivoExists(int id)
        {
            return _context.Arquivo.Any(e => e.Id == id);
        }
    }
}
