using LinqBackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Model
{
    public class DisciplinaModel : Connect
    {
       

        public void SavaDisciplina(List<DisciplinaEnt> dis)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (DisciplinaEnt d in dis)
            {
                string str = "INSERT INTO Disciplina values('" + d.Nome + "', '" + d.Inf + "')";
                cmd.CommandText = str;


                cmd.ExecuteNonQuery();
            }

        }

        public List<DisciplinaEnt> LoadDisciplina()
        {
            List<DisciplinaEnt> ld = new List<DisciplinaEnt>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select * from Disciplina";
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DisciplinaEnt d = new DisciplinaEnt();
                d.Nome = r["nome"].ToString();
                d.Inf = r["informacoes"].ToString();
                d.Id = (int)r["id"];
                ld.Add(d);


            }


            return ld;

        }

        public DisciplinaEnt GetDisciplina(int id)
        {
            DisciplinaEnt d = new DisciplinaEnt();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select * from Disciplina Where id='" + id + "'";
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {

                d.Nome = r["nome"].ToString();
                d.Inf = r["informacoes"].ToString();
                d.Id = (int)r["id"];



            }


            return d;
        }

        public void UpdateDisciplina(DisciplinaEnt d)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "UPDATE Disciplina set nome='" + d.Nome + "', informacoes='" + d.Inf + "' Where id='" + d.Id + "'";


            cmd.ExecuteNonQuery();

        }

        public void DeletaMateria(int id)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Delete from Disciplina Where id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

        }
    }
}
