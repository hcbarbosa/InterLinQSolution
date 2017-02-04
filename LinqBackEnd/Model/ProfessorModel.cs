using LinqBackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Model
{
    public class ProfessorModel : Connect
    {
       
        public void SaveProf(ProfessorEnt p)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO  Pessoa VALUES(@nome,@data_nasc ,@sexo,@cpf,@rg,@rua,@bairro,@complemento,@localidade)
                                SELECT @@IDENTITY";

            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@data_nasc", " ");
            cmd.Parameters.AddWithValue("@sexo", " ");
            cmd.Parameters.AddWithValue("@cpf", p.CPF);
            cmd.Parameters.AddWithValue("@rg", p.RG);
            cmd.Parameters.AddWithValue("@rua", p.Rua);
            cmd.Parameters.AddWithValue("@bairro", p.Bairro);
            cmd.Parameters.AddWithValue("@complemento", p.Complemento);
            cmd.Parameters.AddWithValue("@localidade", p.Localidade);


            p.Id = Convert.ToInt32(cmd.ExecuteScalar());


            cmd.CommandText = @"INSERT INTO Professor VALUES(@id,@reg)";

            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@reg", p.Registro);


            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO Telefone VALUES(@id_pessoa,@t_pessoal,@t_comer)";

            cmd.Parameters.AddWithValue("@t_pessoal", p.Tel1);
            cmd.Parameters.AddWithValue("@t_comer", p.Tel2);
            cmd.Parameters.AddWithValue("@id_pessoa", p.Id);
            cmd.ExecuteNonQuery();

        }

        public List<ProfessorEnt> GetListProf()
        {
            List<ProfessorEnt> lp = new List<ProfessorEnt>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from  Pessoa p join Professor pr on (p.id = pr.id)
                             join Telefone t on (p.id = t.id )";

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {

                ProfessorEnt p = new ProfessorEnt();
                p.Nome = r["nome"].ToString();
                p.Registro = r["registr"].ToString();
                p.Id = (int)r["id"];
                lp.Add(p);

            }
            return lp;


        }

        public ProfessorEnt LoadProf(int id)
        {
            ProfessorEnt al = new ProfessorEnt();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from  Pessoa p join Professor pr on (p.id = pr.id)
                             join Telefone t on (p.id = t.id ) where p.id = "+id+"";

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {


                al.Id = (int)r["id"];
                al.Nome = (string)r["nome"];
                al.Registro = r["registr"].ToString();
                al.CPF = (string)r["cpf"];
                al.RG = (string)r["rg"];
                al.Rua = (string)r["rua"];
                al.Bairro = (string)r["bairro"];
                al.Complemento = (string)r["complemento"];
                al.Localidade = (int)r["localidade"];
                al.Tel1 = (string)r["tel_pessoal"];
                al.Tel2 = (string)r["tel_residencia"];

            }

            return al;
        }

        public void UpdateProf(ProfessorEnt p)
        {

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"UPDATE  Pessoa SET nome=@nome,data_nasc=@data_nasc,sexo=@sexo,cpf=@cpf,rg=@rg,rua=@rua,bairro=@bairro,
                                complemento=@complemento,localidade=@localidade 
                                WHERE id=@id";

                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@data_nasc", " ");
                cmd.Parameters.AddWithValue("@sexo", " ");
                cmd.Parameters.AddWithValue("@cpf", p.CPF);
                cmd.Parameters.AddWithValue("@rg", p.RG);
                cmd.Parameters.AddWithValue("@rua", p.Rua);
                cmd.Parameters.AddWithValue("@bairro", p.Bairro);
                cmd.Parameters.AddWithValue("@complemento", p.Complemento);
                cmd.Parameters.AddWithValue("@localidade", p.Localidade);

                cmd.ExecuteNonQuery();

                cmd.CommandText = @"UPDATE Professor set registr=@regis
                                    WHERE id=@id1";

                cmd.Parameters.AddWithValue("@id1", p.Id);
                cmd.Parameters.AddWithValue("@regis", p.Registro);

                cmd.ExecuteNonQuery();

                cmd.CommandText = @"UPDATE Telefone set tel_pessoal=@t_pessoal,tel_residencia=@t_comer
                                    WHERE id=@id_pessoa";

                cmd.Parameters.AddWithValue("@t_pessoal", p.Tel1);
                cmd.Parameters.AddWithValue("@t_comer", p.Tel2);
                cmd.Parameters.AddWithValue("@id_pessoa", p.Id);
                cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {


                Console.WriteLine(e);


            }






        }

        public void Delet(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            
            cmd.CommandText = @"DELETE FROM Pessoa
                                WHERE id = @id2";

            cmd.Parameters.AddWithValue("@id2", id);
            cmd.ExecuteNonQuery();


        }
    }
}