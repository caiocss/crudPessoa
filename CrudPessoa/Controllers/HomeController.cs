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
        private static int _contadorParaIdade = 0;
        private static IList<Pessoa> _listaPessoas = new List<Pessoa>()
        {
                new Pessoa()
                {
                    Id = 1,
                    Nome = "Caio",
                    Idade = 29,
                    Dinheiro = Convert.ToDecimal(22.30),
                    DataDeCadastro = Convert.ToDateTime("11/27/2007")
                },
                new Pessoa()
                {
                    Id = 2,
                    Nome = "Cesar",
                    Idade = 29,
                    Dinheiro = Convert.ToDecimal(02.50),
                    DataDeCadastro = Convert.ToDateTime("11/27/2018")
                }
        };
        

        public IActionResult Index()
        {
            //Trecho que atualiza a idade conforme o ano atual, comparando com o ano em que a pessoa foi cadastrada
            //O _contadorParaIdade utiliza para executar apenas quando carrega a primeira vez o sistema;
            if(_contadorParaIdade == 0)
            {
                foreach (var pessoa in _listaPessoas)
                {
                    int anoAtual = DateTime.Now.Year;
                    int diferencaDeAno = anoAtual - pessoa.DataDeCadastro.Year;
                    pessoa.Idade += diferencaDeAno;
                }
            }
            _contadorParaIdade++;

            return View(_listaPessoas.OrderBy(x => x.Id));
        }

        //Actions para criação de pessoas
        public IActionResult CriarPessoaForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarPessoa(Pessoa pessoa)
        {
            pessoa.DataDeCadastro = DateTime.Now;
            _listaPessoas.Add(pessoa);
            pessoa.Id = _listaPessoas.Select(i => i.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        //Actions para remover pessoas
        public IActionResult Delete(Pessoa pessoa)
        {
            return View(pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPessoa(int id)
        {
            var pessoa = _listaPessoas.Where(x => x.Id == id);
            _listaPessoas.Remove(_listaPessoas.Where(x => x.Id == id).First());
            return RedirectToAction("Index");
        }

        //Actions para editar pessoas
        public IActionResult Editar(Pessoa pessoa)
        {
            return View(pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPessoa(Pessoa pessoa)
        {
            _listaPessoas.Remove(_listaPessoas.Where(x => x.Id == pessoa.Id).First());
            _listaPessoas.Add(pessoa);
            return RedirectToAction("Index");
        }

        //Action que chama os detalhes
        public IActionResult Detalhes(Pessoa pessoa)
        {
            return View(pessoa);
        }

        //Action que chama a view para visualizar qual pessoa tem menos e qual tem mais dinheiro.
        public IActionResult VerificaMaiorEMenor()
        {
            Pessoa pessoaMenosDinheiro = Pessoa.CapturaPessoaComMenosDinheiro(_listaPessoas);
            ViewBag.NomePessoaComMenosDinheiro = pessoaMenosDinheiro.Nome;
            ViewBag.DinheiroPessoaComMenosDinheiro = pessoaMenosDinheiro.Dinheiro;

            Pessoa pessoaMaisDinheiro = Pessoa.CapturaPessoaComMaisDinheiro(_listaPessoas);
            ViewBag.NomePessoaComMaisDinheiro = pessoaMaisDinheiro.Nome;
            ViewBag.DinheiroPessoaComMaisDinheiro = pessoaMaisDinheiro.Dinheiro;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
