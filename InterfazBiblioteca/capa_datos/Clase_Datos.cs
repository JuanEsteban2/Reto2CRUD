using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capa_logica;

namespace capa_datos
{
    public class Clase_Datos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_ver_libros() //Tablas para los procedimientos almacenados
        {
            SqlCommand cmd = new SqlCommand("sp_ver_libros", cn); //Permite obtener el procedimiento
            SqlDataAdapter da = new SqlDataAdapter(cmd); //Hace de puente entre la base de datos y la tabla del formulario
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_libro(Clase_Logica obje) //Es bastante distinto
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_libro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo", obje.titulo);
            cmd.Parameters.AddWithValue("@editorial", obje.editorial);
            cmd.Parameters.AddWithValue("@autor", obje.autor);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_modificar_libro(Clase_Logica obje) //Tiene más parámetros
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("sp_modificar_libro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.codigo);
            cmd.Parameters.AddWithValue("@titulo", obje.titulo);
            cmd.Parameters.AddWithValue("@autor", obje.autor);
            cmd.Parameters.AddWithValue("@editorial", obje.editorial);
            cmd.Parameters.AddWithValue("@precio", obje.precio);
            cmd.Parameters.AddWithValue("@cantidad", obje.cantidad);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }
    }
}
