using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadRequerimientos{
        private String nombre;
        private String descripcion;
        private String prioridad;
        private String estado;
        private String cantidad;
        private String medida;

        public EntidadRequerimientos(Object[] datos) {
            this.nombre = datos[0].ToString();
            this.descripcion = datos[1].ToString();
            this.prioridad = datos[2].ToString();
            this.estado = datos[3].ToString();
            this.cantidad = datos[4].ToString();
            this.medida = datos[5].ToString();
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
        public String Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public String Medida
        {
            get { return medida; }
            set { medida = value; }
        }
    }
}