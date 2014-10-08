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
        private String telefonos;

        public EntidadUsuario(Object[] datos) {
            this.cedula = datos[0].ToString();
            this.nombre = datos[1].ToString();
            this.correo = datos[2].ToString();
            this.telefonos = datos[3].ToString();
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

        public String Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }
    }
}