using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadProyecto{
        private String nombre;
        private String lider;
        private String objetivos;
        private String estado;
        private String fechaIni;
        private String fechaFin;
        private String fechaAsig;


        /* 
         * Constructor de una Entidad Proyecto con la
         * información especificada en el vector de datos 
         * que entra como parámetro.
         */
        public EntidadProyecto(Object[] datos) {

            this.nombre = datos[0].ToString();
            this.objetivos = datos[1].ToString();
            this.estado = datos[2].ToString();
            this.fechaIni = datos[3].ToString();
            this.fechaFin = datos[4].ToString();
            this.fechaAsig = datos[5].ToString();
            this.lider = datos[6].ToString();
        }


        /*
         * Getters y Setters para cada atributo de la Entidad        
         */
        public String Nombre{
            get { return nombre; }
            set { nombre = value; }
        }

        public String Lider {
            get { return lider; }
            set { lider = value; }
        }

        public String Objetivos
        {
            get { return objetivos; }
            set { objetivos = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String FechaIni
        {
            get { return fechaIni; }
            set { fechaIni = value; }
        }

        public String FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public String FechaAsig
        {
            get { return fechaAsig; }
            set { fechaAsig = value; }
        }
    }
}