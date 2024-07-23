using DocumentFormat.OpenXml.Drawing;
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
    [Authorize]
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
            return View(await _context.Arquivos.ToListAsync());
        }

        // GET: Arquivo/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos.FirstOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            ViewBag.Upload = await _context.Auditorias.CountAsync(m => m.Identificador == id && m.Acao == "upload");

            ViewBag.Download = await _context.Auditorias.CountAsync(m => m.Identificador == id && m.Acao == "download");

            return View(arquivo);
        }

        // GET: Arquivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arquivo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Arquivo arquivo, IFormFile file)
        {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string[] fileSplit = file.FileName.Split(".");
                arquivo.Nome = fileSplit[0] + DateTime.Now.ToString("yymmssfff") + "." + fileSplit[1];
                string path = System.IO.Path.Combine(wwwRootPath + "/Uploads/", arquivo.Nome);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                arquivo.PathArquivo = "/Uploads/" + arquivo.Nome;

                // Generate thumbnail
                string thumbnailPath = System.IO.Path.Combine(wwwRootPath + "/Thumbnails/", arquivo.Nome);
                using (var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream()))
                {
                    image.Mutate(x => x.Resize(150, 150));
                    image.Save(thumbnailPath);
                }
                // Thumbnail generation logic here

                arquivo.PathThumbnail = "/Thumbnails/" + arquivo.Nome;
                arquivo.DataUpload = DateTime.Now;
                            
                _context.Arquivos.Add(arquivo);
                _context.SaveChanges();

                var auditoria = new Auditoria
                {
                    Identificador = arquivo.Id,
                    Acao = "upload",
                    DataCriacao = DateTime.Now
                };

                _context.Auditorias.Add(auditoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Arquivo/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos.FindAsync(id);
            if (arquivo == null)
            {
                return NotFound();
            }
            return View(arquivo);
        }

        // POST: Arquivo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Arquivo arquivo)
        {
            if (id != arquivo.Id)
            {
                return NotFound();
            }

                try
                {
                    var arquivoOriginal = await _context.Arquivos.FindAsync(id);
                    arquivoOriginal.Descricao = arquivo.Descricao;
                    _context.Update(arquivoOriginal);
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

        // GET: Arquivo/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // POST: Arquivo/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arquivo = await _context.Arquivos.FindAsync(id);
            if (arquivo != null)
            {
                _context.Arquivos.Remove(arquivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArquivoExists(int id)
        {
            return _context.Arquivos.Any(e => e.Id == id);
        }

        public async Task<FileResult> Download(int id)
        {
            var arquivo = await _context.Arquivos.FindAsync(id);
            var auditoria = new Auditoria
            {
                Identificador = arquivo.Id,
                Acao = "download",
                DataCriacao = DateTime.Now
            };

            _context.Auditorias.Add(auditoria);
            await _context.SaveChangesAsync();

            return File(arquivo.PathArquivo, "application/image", arquivo.Nome);
        }

    }
}
