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
                Id = 1,
                Nome = "Caio",
                Idade = 29,
                Dinheiro = Convert.ToDecimal(22.30),
            },
            new Pessoa()
            {
                Id = 2,
                Nome = "Cesar",
                Idade = 29,
                Dinheiro = Convert.ToDecimal(02.50),
            }
        };

        public IActionResult Index()
        {
            return View(listaPessoas.OrderBy(x => x.Id));
        }

        public IActionResult CriarPessoaForm()
        {
            return View();
        }
        public IActionResult CriarPessoa(Pessoa pessoa)
        {
            listaPessoas.Add(pessoa);
            pessoa.Id = listaPessoas.Select(i => i.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Pessoa pessoa)
        {
            return View(pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPessoa(int id)
        {
            var pessoa = listaPessoas.Where(x => x.Id == id);
            listaPessoas.Remove(listaPessoas.Where(x => x.Id == id).First());
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
            listaPessoas.Remove(listaPessoas.Where(x => x.Id == pessoa.Id).First());
            listaPessoas.Add(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult VerificaMaiorEMenor()
        {
            ViewBag.texto = Pessoa.VerificaMaiorEMenor(listaPessoas);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
