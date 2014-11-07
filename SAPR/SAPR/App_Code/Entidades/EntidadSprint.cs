using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    //Esta clase contiene los atributos de un Sprint
    public class EntidadSprint{
        private String nombre;
        private String descripcion;

        //Se encarga de encapsular los datos de un Sprint
        public EntidadSprint(Object[] datos)
        {
            this.nombre = datos[0].ToString();
            this.descripcion = datos[1].ToString();
        }

        //Get y Set del atributo nombre
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //Get y Set del atributo descripcion
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }   
}