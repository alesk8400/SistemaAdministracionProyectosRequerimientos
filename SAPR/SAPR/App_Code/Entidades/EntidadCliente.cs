using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadCliente
    {
        private String nombre;
        private String telefono;
        private String celular;
        private String oficina;
        private String correo;
        private int fk_proyecto;

        public EntidadCliente(Object[] datos) {
            this.nombre = datos[0].ToString();
            this.telefono = datos[1].ToString();
            this.celular = datos[2].ToString();
            this.oficina = datos[3].ToString();
            this.correo = datos[4].ToString();
            this.fk_proyecto = Int32.Parse(datos[5].ToString());

        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public String Oficina
        {
            get { return oficina; }
            set { oficina = value; }
        }

        public int Fk_Proyecto
        {
            get { return fk_proyecto; }
            set { fk_proyecto = value; }
        }





    }
}






















    public class EntidadUsuario{
        private String cedula;
        private String nombre;
        private String correo;
        private String telefono;
        private String celular;
        private String pass;

        public EntidadUsuario(Object[] datos) {
            this.nombre = datos[0].ToString();
            this.cedula = datos[1].ToString();
            this.correo = datos[2].ToString();
            this.telefono = datos[3].ToString();
            this.celular = datos[4].ToString();
            this.pass = datos[5].ToString(); 
        }

        public String Cedula{
            get { return cedula; }
            set { cedula = value; }
        }

        public String Nombre{
            get { return nombre; }
            set { nombre = value; }
        }
        public String Correo{
            get { return correo; }
            set { correo = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }

    }
