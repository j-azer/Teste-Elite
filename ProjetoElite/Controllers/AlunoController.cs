using ClosedXML.Excel;
using Projeto_Elite.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto_Elite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Elite.Controllers;

//[Authorize]
public class AlunoController : Controller
{
    private readonly ApplicationDbContext _context;

    public AlunoController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] int disciplinaId)
    {
        return View(await _context.AlunoDisciplinas.Where(x => x.DisciplinaId == disciplinaId).Select(x => x.Aluno).ToListAsync());
    }

}