using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadCriterio
    {
        private String nombreCriterio;
        private String escenario;
        private String contexto;
        private String resultado;
        private int idRequerimiento;


        public EntidadCriterio(Object[] datos) {
            this.nombreCriterio = datos[0].ToString();
            this.escenario = datos[1].ToString();
            this.contexto = datos[2].ToString();
            this.resultado = datos[3].ToString();
            this.idRequerimiento = Int32.Parse(datos[4].ToString());
        }

        public String NombreCriterio
        {
            get { return nombreCriterio; }
            set { nombreCriterio = value; }
        }
        public String Escenario
        {
            get { return escenario; }
            set { escenario = value; }
        }

        public String Contexto
        {
            get { return contexto; }
            set { contexto = value; }
        }

        public String Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public int IdRequerimiento
        {
            get { return idRequerimiento; }
            set { idRequerimiento = value; }
        }

    }
}