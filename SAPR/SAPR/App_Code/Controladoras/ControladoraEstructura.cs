using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras
{
    public class ControladoraEstructura{
        ControladoraBDEstructura controladoraBDEstructura;
        ControladoraProyecto controladoraProyecto;

        public ControladoraEstructura() {
            controladoraBDEstructura = new ControladoraBDEstructura();
            controladoraProyecto = new ControladoraProyecto();
        }
        public String[] insertarSprint(String nombre, String descripcion,String nombreProyecto)
        {
            Object[] datos = new Object[2];  //Se crea un objeto con los datos del proyecto
            int idProyecto=0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadSprint sprint = new EntidadSprint(datos);  //Se encapsulan los datos del proyecto
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.insertarSprint(sprint, idProyecto);
        }
        public String[] insertarModulo(String nombre, String descripcion, String nombreSprint)
        {
            Object[] datos = new Object[2];  //Se crea un objeto con los datos del proyecto
            int idSprint = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadModulo modulo = new EntidadModulo(datos);  //Se encapsulan los datos del proyecto
            idSprint = this.getIdSprint(nombreSprint);
            return controladoraBDEstructura.insertarModulo(modulo, idSprint);
        }

        public int getIdSprint(String nombreSprint) {
            return controladoraBDEstructura.getIdSprint(nombreSprint);
        }
    }
}