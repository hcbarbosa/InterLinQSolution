using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Entity
{
   public class PessoaEnt
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNasci { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Rua { get; set; }
        public int Localidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }

    }
}
