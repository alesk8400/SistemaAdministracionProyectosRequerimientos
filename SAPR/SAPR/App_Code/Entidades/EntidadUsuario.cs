using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadUsuario{
        private String id;
        private String cedula;
        private String nombre;
        private String correo;
        private String telefono;
        private String celular;

        public EntidadUsuario(Object[] datos) {
            this.id = datos[0].ToString();
            this.cedula = datos[1].ToString();
            this.nombre = datos[2].ToString();
            this.telefono = datos[4].ToString();
            this.celular = datos[5].ToString();
            this.correo = datos[3].ToString();
        }


        public String ID
        {
            get { return id; }
            set { id = value; }
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

    }
}