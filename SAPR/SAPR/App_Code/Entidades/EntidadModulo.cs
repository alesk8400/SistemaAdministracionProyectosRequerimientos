using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    /*
     Clase entidad para encapsular los datos de un módulo
     */
    public class EntidadModulo
    {
        private String nombre;
        private String descripcion;

        /*
         Constructor que guarda los datos recibidos en el objeto vector
         */
        public EntidadModulo(Object[] datos)
        {
            this.nombre = datos[0].ToString();
            this.descripcion = datos[1].ToString();
        }

        /*
         Get y set del nombre del módulo
         */
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
         /*
          Get y set de la descripción del módulo
          */
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}