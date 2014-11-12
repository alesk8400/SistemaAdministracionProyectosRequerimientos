using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadRequerimientos{
        private int idModulo;
        private int idProyecto;
        private String nombre;
        private String descripcion;
        private int prioridad;
        private String estado;
        private int cantidad;
        private String medida;

        public EntidadRequerimientos(Object[] datos) {
            this.idModulo = (int)datos[0];
            this.idProyecto = (int)datos[0];
            this.nombre = datos[2].ToString();
            this.descripcion = datos[3].ToString();
            this.prioridad = (int)datos[4];
            this.estado = datos[5].ToString();
            this.cantidad = (int)datos[6];
            this.medida = datos[7].ToString();
        }

        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
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
        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public int Cantidad
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