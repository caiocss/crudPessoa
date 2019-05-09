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
        [RegularExpression("([0-9])", ErrorMessage = "Só é permitido numeros")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public decimal Dinheiro { get; set; }



        public static string VerificaMaiorEMenor(IList<Pessoa> list)
        {
            decimal menorDin = 0;            
            Pessoa pessoaComMenosGrana = new Pessoa();            
            foreach (var pessoa in list)
            {

                if (menorDin < pessoa.Dinheiro)
                {
                    menorDin = pessoa.Dinheiro;
                    pessoaComMenosGrana = pessoa;
                }
            }

            return $"A pessoa que tem menos dinheiro é:{pessoaComMenosGrana.Nome}, valor: {pessoaComMenosGrana.Dinheiro} , A pessoa que tem mais dinheiro é: ";
        }
    }
}
