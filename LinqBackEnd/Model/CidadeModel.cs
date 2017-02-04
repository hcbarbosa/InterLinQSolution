using LinqBackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Model
{
   public class CidadeModel:Connect
    {
        public List<CidadeEnt> GetCidade(int id)
        {
            List<CidadeEnt> lc = new List<CidadeEnt>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"Select * from Cidade where id_estado=@stad";

            cmd.Parameters.AddWithValue("@stad", id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                CidadeEnt es = new CidadeEnt();
                es.idCidade = (int)r["id"];
                es.idEstado = (int)r["id_estado"];
                es.Nome = (string)r["nome"];

                lc.Add(es);
            }

            return lc;


        }

        public CidadeEnt REcCidade(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select ci.id,ci.nome from Estado e
                                join Cidade ci on (e.id = ci.id_estado)
                                where ci.id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader r = cmd.ExecuteReader();
            CidadeEnt es = new CidadeEnt();
            while (r.Read())
            {

                es.idCidade = (int)r["id"];

                es.Nome = (string)r["nome"];


            }

            return es;

        }


    }

}

