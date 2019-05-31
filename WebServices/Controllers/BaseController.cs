using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServices.Controllers
{
    public class BaseController : ApiController
    {
        public string InsertarAsistencia(int fila)
        {
            string cadena = ConfigurationManager.ConnectionStrings["AsistenciaDBConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand("ActualizarAsistencia", conn))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@fila", fila);
                    com.ExecuteNonQuery();
                }
            }
            return "algo";
        }
    }
}
