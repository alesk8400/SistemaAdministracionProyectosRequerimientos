using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadModulo
    {
        private String nombre;
        private String descripcion;

        public EntidadModulo(Object[] datos)
        {
            this.nombre = datos[0].ToString();
            this.descripcion = datos[1].ToString();
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}