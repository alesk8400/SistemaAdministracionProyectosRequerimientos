using SAPR.App_Code.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPR.App_Code.Controladoras
{
    public class ControladoraRequerimiento
    {
        ControladoraBDRequerimiento controladoraBDRequerimiento;

        public ControladoraRequerimiento()
        {

            controladoraBDRequerimiento = new ControladoraBDRequerimiento();

        }

        /*
         * Metodo que recibe los datos para un nuevo requerimiento, los encapsula
         * y pasa a la controladora de BD para su posterior insercion.                   
         */

        public String[] insertarRequerimiento(int idModulo, int idProyecto, String nombre, String descripcion, String prioridad, String estado,
        int cantidad, String medida)
        { 

            Object[] datosRequerimiento = new Object[8];
            datosRequerimiento[0] = idModulo;
            datosRequerimiento[1] = idProyecto;
            datosRequerimiento[2] = nombre;
            datosRequerimiento[3] = descripcion;
            datosRequerimiento[4] = prioridad;
            datosRequerimiento[5] = estado;
            datosRequerimiento[6] = cantidad;
            datosRequerimiento[7] = medida;

            EntidadRequerimientos requerimiento = new EntidadRequerimientos(datosRequerimiento);
            return controladoraBDRequerimiento.insertarRequerimiento(requerimiento);

        }

        public String[] modificarRequerimiento(int idModulo, int idProyecto, String nombre, String descripcion, String prioridad, String estado,
        int cantidad, String medida, EntidadRequerimientos requerimientoViejo)
        {
            Object[] datosRequerimiento = new Object[8];
            datosRequerimiento[0] = idModulo;
            datosRequerimiento[1] = idProyecto;
            datosRequerimiento[2] = nombre;
            datosRequerimiento[3] = descripcion;
            datosRequerimiento[4] = prioridad;
            datosRequerimiento[5] = estado;
            datosRequerimiento[6] = cantidad;
            datosRequerimiento[7] = medida;

            EntidadRequerimientos requerimientoNuevo = new EntidadRequerimientos(datosRequerimiento);

            return controladoraBDRequerimiento.modificarRequerimiento(requerimientoViejo, requerimientoNuevo);
        }

        public String[] eliminarRequerimiento(String nombreRequerimiento)
        {
            return controladoraBDRequerimiento.eliminarRequerimiento(nombreRequerimiento);
        }


    }
}