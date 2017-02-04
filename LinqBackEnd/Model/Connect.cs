using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBackEnd.Model
{
    public class Connect : IDisposable
    {
        //classe responsavel pela conexao com o BD
        protected SqlConnection conn = null;
        public Connect()
        {
            string strConn = @"Data Source=NOTE;
                              Initial Catalog=BDEscola;
                              Integrated Security =true";


            conn = new SqlConnection(strConn);

            // Abrir conexao

            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
