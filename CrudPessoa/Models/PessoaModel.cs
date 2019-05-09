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
    

        public static string VerificaMaiorEMenor(IList<Pessoa> list)
        {
            decimal menorDin = Decimal.MinValue;
            decimal maiorDin = Decimal.MaxValue;
            Pessoa pessoaComMenosGrana = new Pessoa();            
            Pessoa pessoaComMaisGrana = new Pessoa();            
            foreach (var pessoa in list)
            {

                if (menorDin < pessoa.Dinheiro)
                {
                    menorDin = pessoa.Dinheiro;
                    pessoaComMenosGrana = pessoa;
                }
                
                if(maiorDin > pessoa.Dinheiro)
                {
                    maiorDin = pessoa.Dinheiro;
                    pessoaComMaisGrana = pessoa;
                }

            }

            return $"A pessoa que tem menos dinheiro é: {pessoaComMenosGrana.Nome}, com {pessoaComMenosGrana.Dinheiro} Reais <br> A pessoa que tem mais dinheiro é: {pessoaComMaisGrana.Nome}, com {pessoaComMaisGrana.Dinheiro} Reais";
        }
    }
}
