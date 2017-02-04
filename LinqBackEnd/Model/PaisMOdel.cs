using LinqBackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Model
{
   public class PaisMOdel:Connect
    { 

        public List<PaisEnt> GetPais()
        {
            List<PaisEnt> p = new List<PaisEnt>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"Select * from Pais";
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                PaisEnt pa = new PaisEnt();
                pa.idPais = (int)r["id"];
                pa.Nome = (string)r["nome"];

                p.Add(pa);
            }

            return p;

        }
    }
}