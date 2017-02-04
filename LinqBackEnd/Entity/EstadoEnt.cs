using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Entity
{
  public  class EstadoEnt
    {
        public int idEstado { get; set; }
        public int idPais { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}
