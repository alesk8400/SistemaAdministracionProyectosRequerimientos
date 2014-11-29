using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadCriterio
    {
        private String nombreCriterio;
        private int escenario;
        private String contexto;
        private String resultado;
        private int idRequerimiento;


        /* 
         * Constructor de una Entidad Criterio (de Aceptación) con la
         * información especificada en el vector de datos 
         * que entra como parámetro.
         */
        public EntidadCriterio(Object[] datos) {
            this.nombreCriterio = datos[0].ToString();
            this.escenario = Int32.Parse(datos[1].ToString());
            this.contexto = datos[2].ToString();
            this.resultado = datos[3].ToString();
            this.idRequerimiento = Int32.Parse(datos[4].ToString());
        }


        /*
         * Getters y Setters para cada atributo de la Entidad        
         */
        public String NombreCriterio
        {
            get { return nombreCriterio; }
            set { nombreCriterio = value; }
        }
        public int Escenario
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