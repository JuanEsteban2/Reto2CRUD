using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using capa_logica;
using capa_datos;

namespace capa_negocio
{
    public class Clase_Presentacion
    {
        Clase_Datos objd = new Clase_Datos();

        public DataTable N_ver_libros()
        {
            return objd.D_ver_libros(); 
        }

        public DataTable N_buscar_libro (Clase_Logica obje)
        {
            return objd.D_buscar_libro (obje);
        }

        public String N_modificar_libro (Clase_Logica obje)
        {
            return objd.D_modificar_libro(obje);
        }
    }
}
