using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPR.App_Code.Entidades;
using System.Data;


namespace SAPR.App_Code.Controladoras
{
    public class ControladoraProyecto {
        ControladoraBDProyecto controladoraBDProyecto;

        public ControladoraProyecto() {
            controladoraBDProyecto = new ControladoraBDProyecto();
        }

        public String[] insertarProyecto(String nombre, int lider, String estado, String objetivo, String fechaAsig, String fechaInic, String fechaFin, String[] listaUsuarios) {
            Object[] datos = new Object[7];
            datos[0] = nombre;
            datos[1] = lider;
            datos[2] = estado;
            datos[3] = objetivo;
            datos[4] = fechaAsig;
            datos[5] = fechaInic;
            datos[6] = fechaFin;
            EntidadProyecto proyecto = new EntidadProyecto(datos);
            return controladoraBDProyecto.insertarProyecto(proyecto);
        
        
        }

        public String[] modificarProyecto(String nombre, int lider, String estado, String objetivo, String fechaAsig, String fechaInic, String fechaFin, String[] listaUsuarios,EntidadProyecto proyectoViejo) {
            Object[] datos = new Object[7];
            datos[0] = nombre;
            datos[1] = lider;
            datos[2] = estado;
            datos[3] = objetivo;
            datos[4] = fechaAsig;
            datos[5] = fechaInic;
            datos[6] = fechaFin;
            EntidadProyecto proyectoNuevo = new EntidadProyecto(datos);
            return controladoraBDProyecto.modificarProyecto(proyectoNuevo,proyectoViejo);

        
        }

        public String[] eliminarProyecto(String idProyecto){
            return controladoraBDProyecto.eliminarProyecto(idProyecto);
        }

        public EntidadProyecto consultarProyecto(String nombre)
        {
            EntidadProyecto proyecto = null; //para encpasular los datos consultados.
            Object[] datosConsultados = new Object[7]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaProyecto = controladoraBDProyecto.consultarProyecto(nombre);

            if (filaProyecto.Rows.Count == 1)
            { // si hay un valor
                for (int i = 0; i < 7; i++)
                {
                    datosConsultados[i] = filaProyecto.Rows[0][i].ToString();
                }
                proyecto = new EntidadProyecto(datosConsultados);
            }
            return proyecto;
        }

        /*public String[] consultarProyecto() { }

        public String[] getListadoProyectos() { }

        public String[] getIdSiguienteProyecto() { }

        public String[] validarNombre() { }

        public String[] insertarMiembros() { }

        public String[] getUsuariosDeProyecto() { }

        public String[] getListadoUsuarioDisponibles() { }

        public String[] getNombreProyectos() { }*/




    }
}