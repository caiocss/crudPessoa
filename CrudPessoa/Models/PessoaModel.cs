using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPessoa.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public decimal Dinheiro { get; set; }
        public DateTime DataDeCadastro { get; set; }


        /// <summary>
        /// Método que verifica em uma lista de pessoas quem tem mais dinheiro.
        /// </summary>
        /// <param name="listaDePessoas">Lista de pessoas</param>
        /// <returns>Retorna uma string informando a pessoa com </returns>
        public static Pessoa CapturaPessoaComMenosDinheiro(IList<Pessoa> listaDePessoas)
        {
            Pessoa pessoaComMenosGrana = new Pessoa();
            pessoaComMenosGrana = listaDePessoas.OrderBy(x => x.Dinheiro).First();

            return pessoaComMenosGrana;
        }

        /// <summary>
        /// Método que verifica em uma lista de pessoas quem tem mais dinheiro.
        /// </summary>
        /// <param name="listaDePessoas">Lista de pessoas</param>
        /// <returns>Retorna uma string informando a pessoa com </returns>
        public static Pessoa CapturaPessoaComMaisDinheiro(IList<Pessoa> listaDePessoas)
        {
            Pessoa pessoaComMaisGrana = new Pessoa();
            pessoaComMaisGrana = listaDePessoas.OrderByDescending(x => x.Dinheiro).First();

            return pessoaComMaisGrana;
        }
    }
}
