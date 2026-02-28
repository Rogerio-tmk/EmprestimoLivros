using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ✅ EXCLUIR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}