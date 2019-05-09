using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudPessoa.Models;

namespace CrudPessoa.Controllers
{
    public class HomeController : Controller
    {
        private static IList<Pessoa> listaPessoas = new List<Pessoa>()
        {
            new Pessoa()
            {
                Nome = "Caio",
                Idade = 29,
                Dinheiro = Convert.ToDecimal(22.30),
            },
            new Pessoa()
            {
                Nome = "Cesar",
                Idade = 29,
                Dinheiro = Convert.ToDecimal(02.50),
            }
        };

        public IActionResult Index()
        {
            return View(listaPessoas);
        }

        public IActionResult CriarPessoaForm()
        {
            return View();
        }
        public IActionResult CriarPessoa(Pessoa pessoa)
        {
            listaPessoas.Add(pessoa);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Pessoa pessoa)
        {
            return View(pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPessoa(Pessoa pessoa)
        {
            listaPessoas.Remove(pessoa);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Pessoa pessoa)
        {
            return View(pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoa(Pessoa pessoa)
        {
            listaPessoas.Remove(listaPessoas.Where(x => x == pessoa).First());
            listaPessoas.Add(pessoa);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
