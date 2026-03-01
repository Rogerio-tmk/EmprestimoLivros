using Microsoft.AspNetCore.Mvc;
using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using System.Linq;

namespace EmprestimoLivros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===== LISTA =====
        public IActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        // ===== ABRIR PAGINA ADD =====
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // ===== SALVAR ADD =====
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string titulo, string autor, string status)
        {
            var livro = new Livro
            {
                Nome = titulo,
                Autor = autor,
                Status = status
            };

            _context.Livros.Add(livro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}