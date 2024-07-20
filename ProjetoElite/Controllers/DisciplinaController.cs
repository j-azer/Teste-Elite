using ClosedXML.Excel;
using Projeto_Elite.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto_Elite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Elite.Controllers;

//[Authorize]
public class DisciplinaController : Controller
{
    private readonly ApplicationDbContext _context;

    public DisciplinaController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Disciplinas.ToListAsync());
    }

}