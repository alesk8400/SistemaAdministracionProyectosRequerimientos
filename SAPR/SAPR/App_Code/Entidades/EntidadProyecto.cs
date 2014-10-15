using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadProyecto{
        private String nombre;
        private int lider;
        private String objetivos;
        private String estado;
        private String fechaIni;
        private String fechaFin;
        private String fechaAsig;
        private String idProyecto;

        public EntidadProyecto(Object[] datos) {

            this.idProyecto = datos[0].ToString();
            this.nombre = datos[1].ToString();
            this.objetivos = datos[2].ToString();
            this.estado = datos[3].ToString();
            this.fechaIni = datos[4].ToString();
            this.fechaFin = datos[5].ToString();
            this.fechaAsig = datos[6].ToString();
            this.lider = Int32.Parse(datos[7].ToString());
        }

        public String Id
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        public String Nombre{
            get { return nombre; }
            set { nombre = value; }
        }

        public int Lider {
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