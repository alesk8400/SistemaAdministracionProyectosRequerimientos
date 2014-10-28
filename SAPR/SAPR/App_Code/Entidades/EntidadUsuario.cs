using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadUsuario{
        private String cedula;
        private String nombre;
        private String correo;
        private String telefono;
        private String celular;
        private String pass;

        /* 
         * Constructor de una Entidad Usuario con la
         * información especificada en el vector de datos 
         * que entra como parámetro.
         */
        public EntidadUsuario(Object[] datos) {
            this.nombre = datos[0].ToString();
            this.cedula = datos[1].ToString();
            this.correo = datos[2].ToString();
            this.telefono = datos[3].ToString();
            this.celular = datos[4].ToString();
            this.pass = datos[5].ToString(); 
        }

        /*
         * Getters y Setters para cada atributo de la Entidad        
         */
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
}