using LinqBackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Model
{
   public class EstadoModel:Connect
    {
         public List<EstadoEnt> GetEstado()
        {
            List<EstadoEnt> e = new List<EstadoEnt>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"Select * from Estado";
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                EstadoEnt es = new EstadoEnt();
                es.idEstado = (int)r["id"];
                es.idPais = (int)r["id_pais"];
               es.Nome = (string)r["nome"];

                e.Add(es);
            }

            return e;

        }

        public EstadoEnt GetEstado(int id)
        {
            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"Select * from Estado e
                                join Cidade ci on (e.id = ci.id_estado)
                                where ci.id=@id";

            cmd.Parameters.AddWithValue("@id",id);
            SqlDataReader rs = cmd.ExecuteReader();
            EstadoEnt es = new EstadoEnt();
            while (rs.Read())
            {
                
                es.idEstado = (int)rs["id"];
                es.idPais = (int)rs["id_pais"];
                es.Nome = (string)rs["nome"];

               
            }

            return es;

        }

    }
}
    


