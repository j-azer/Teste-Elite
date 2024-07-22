using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Projeto_Elite.Data;
using Projeto_Elite.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace Projeto_Elite.Controllers
{
    //[Authorize]
    public class ArquivoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ArquivoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Arquivo arquivo, IFormFile file)
        {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(arquivo.Nome);
                string[] fileSplit = file.FileName.Split(".");
                arquivo.Nome = fileSplit[0] + DateTime.Now.ToString("yymmssfff") + "." + fileSplit[1];
                string path = Path.Combine(wwwRootPath + "/Uploads/", arquivo.Nome);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                arquivo.PathArquivo = "/Uploads/" + arquivo.Nome;

                // Generate thumbnail
                string thumbnailPath = Path.Combine(wwwRootPath + "/Thumbnails/", arquivo.Nome);
                using (var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream()))
                {
                    image.Mutate(x => x.Resize(150, 150));
                    image.Save(thumbnailPath);
                }
                // Thumbnail generation logic here

                arquivo.PathThumbnail = "/Thumbnails/" + arquivo.Nome;
                arquivo.DataUpload = DateTime.Now;

                _context.Add(arquivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

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
