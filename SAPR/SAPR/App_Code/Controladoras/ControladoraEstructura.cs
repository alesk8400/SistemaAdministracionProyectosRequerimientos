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
            Object[] datos = new Object[2];  //Se crea un objeto con los datos del sprint
            int idProyecto=0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadSprint sprint = new EntidadSprint(datos);  //Se encapsulan los datos del sprint
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.insertarSprint(sprint, idProyecto);
        }

        public string[] modificarSprint(String nombre, String descripcion, String nombreProyecto,EntidadSprint sprintViejo)
        {
            Object[] datos = new Object[2];
            int idProyecto = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadSprint sprintNuevo = new EntidadSprint(datos);  //se encapsulan los datos del sprint a modificar
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.modificarSprint(sprintNuevo, idProyecto, sprintViejo.Nombre);
        }

        public String[] eliminarSprint(String nombreSprint)
        { //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! VER (debería recibir también el nombre del proyecto)
            return controladoraBDEstructura.eliminarSprint(nombreSprint);
        }

        public EntidadSprint consultarSprint(String nombreSprint)
        {   //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! VER (debería recibir también el nombre del proyecto)
            EntidadSprint sprint = null; //para encapsular los datos consultados.
            Object[] datosConsultados = new Object[2]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaSprint = controladoraBDEstructura.consultarSprint(nombreSprint);

            if (filaSprint.Rows.Count == 1)
            { //se recorre el dataTable de estructura tomando los datos de los sprint
                for (int i = 1; i < 3; i++)
                {
                    datosConsultados[i - 1] = filaSprint.Rows[0][i].ToString();
                }
                sprint = new EntidadSprint(datosConsultados); //se encapsulan los datos del sprint
            }
            return sprint;
        }

        public String[] insertarModulo(String nombre, String descripcion, String nombreSprint, String nombreProyecto)
        {
            Object[] datos = new Object[2];  //Se crea un objeto con los datos del sprint
            int idSprint = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadModulo modulo = new EntidadModulo(datos);  //Se encapsulan los datos del sprint
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            return controladoraBDEstructura.insertarModulo(modulo, idSprint);
        }

        public int getIdSprint(String nombreSprint, String nombreProyecto) { //Requiere el proyecto para que en la consulta solo busque los sprints de ese proyecto. (No debe haber nombres de sprints iguales en un mismo proyecto)
            int idProyecto = 0;
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.getIdSprint(nombreSprint, idProyecto);
        }
        public string[] modificarModulo(String nombre, String descripcion, String nombreSprint, String nombreProyecto, EntidadModulo moduloViejo) //En un sprint no deben existir módulos con el mismo nombre
        {
            Object[] datos = new Object[2];
            int idSprint = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadModulo moduloNuevo = new EntidadModulo(datos);  //se encapsulan los datos del modulo a modificar
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            return controladoraBDEstructura.modificarModulo(moduloNuevo, idSprint, moduloViejo.Nombre);
        }

        public String[] eliminarModulo(String nombreModulo, String nombreSprint, String nombreProyecto)
        { //Requiere mandar el id del sprint para poder identificar cual módulo se eliminará, con solo el nombre no se puede saber
            int idSprint = 0;
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            return controladoraBDEstructura.eliminarModulo(nombreModulo, idSprint);
        }

        public EntidadModulo consultarModulo(String nombreModulo, String nombreSprint, String nombreProyecto)
        { //Requiere mandar el id del sprint para poder identificar cual módulo se consultará, con solo el nombre no se puede saber
            int idSprint = 0;
            EntidadModulo modulo = null; //para encapsular los datos consultados.
            Object[] datosConsultados = new Object[2]; //para guardar los datos obtenidos de la consulta temporalmente
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            DataTable filaModulo = controladoraBDEstructura.consultarModulo(nombreModulo, idSprint);

            if (filaModulo.Rows.Count == 1)
            { //se recorre el dataTable de estructura tomando los datos del módulo
                for (int i = 1; i < 3; i++)
                {
                    datosConsultados[i - 1] = filaModulo.Rows[0][i].ToString();
                }
                modulo = new EntidadModulo(datosConsultados); //se encapsulan los datos del modulo
            }
            return modulo;
        }

        public DataTable getSprints()
        {
            return controladoraBDEstructura.getSprints();
        }


    }
}