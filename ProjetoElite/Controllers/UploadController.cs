using ClosedXML.Excel;
using Projeto_Elite.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto_Elite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Elite.Controllers;

//[Authorize]
public class UploadController : Controller
{
    private readonly ApplicationDbContext _context;

    public UploadController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(IFormFile file)
    {
        
        if (file == null || file.Length == 0)
        {
            ViewBag.Message = "Por favor, selecione um arquivo.";
            return View();
        }

        // Verificar a extensão do arquivo
        var extension = Path.GetExtension(file.FileName).ToLower();
        if (extension != ".xlsx" && extension != ".xlsm" && extension != ".xltx" && extension != ".xltm")
        {
            ViewBag.Message = "Por favor, selecione um arquivo Excel válido.";
            return View();
        }

        // Salvar o arquivo com a extensão correta
        var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + extension);

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }


        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed();
            var firstColumn = worksheet.Column(1);

            var disciplina = new Disciplina
            {
                Nome = firstColumn.Cell(2).GetValue<string>(),
                NomeProfessor = firstColumn.Cell(1).GetValue<string>()
            };
            var rowsAlunos = worksheet.RangeUsed().RowsUsed().Skip(1);

            foreach (var row in rowsAlunos)
            {
                var aluno = new Aluno
                {
                    Nome = row.Cell(3).GetValue<string>(),
                    Nota1 = row.Cell(4).GetValue<double>(),
                    Nota2 = row.Cell(5).GetValue<double>(),
                    Nota3 = row.Cell(6).GetValue<double>(),
                    Nota4 = row.Cell(7).GetValue<double>()
                };

                var alunoDisciplina = new AlunoDisciplina
                {
                    Aluno = aluno,
                    Disciplina = disciplina
                };

                _context.Alunos.Add(aluno);
                _context.AlunoDisciplinas.Add(alunoDisciplina);
            }
            _context.Disciplinas.Add(disciplina);

            await _context.SaveChangesAsync();
        }

        System.IO.File.Delete(filePath);

        ViewBag.Message = "Upload e leitura do arquivo Excel realizados com sucesso!";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Disciplinas.ToListAsync());
    }

}