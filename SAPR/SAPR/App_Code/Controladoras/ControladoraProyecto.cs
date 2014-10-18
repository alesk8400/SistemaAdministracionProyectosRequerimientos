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
        ControladoraUsuario controladoraUsuario;
        private static String lider; 
        public ControladoraProyecto() {
            controladoraBDProyecto = new ControladoraBDProyecto();
            controladoraUsuario = new ControladoraUsuario();

        }
        // Este método recibía String[] listaUsuarios, se lo quité por mientras
        public String[] insertarProyecto(String nombre, String objetivo, String estado, String fechaInic, String fechaFin, String fechaAsig, String lider, String nombreCliente, String telefono, String telefono1, String oficina, String correoCliente )
        {
            Object[] datos = new Object[7];
            datos[0] = nombre;
            datos[1] = objetivo;
            datos[2] = estado;
            datos[3] = fechaInic;
            datos[4] = fechaFin;
            datos[5] = fechaAsig; 
            datos[6] = lider;
            Object[] datosCliente = new Object[5];
            datosCliente[0] = nombreCliente;
            datosCliente[1] = telefono;
            datosCliente[2] = telefono1;
            datosCliente[3] = oficina;
            datosCliente[4] = correoCliente;
            EntidadProyecto proyecto = new EntidadProyecto(datos);
            EntidadCliente cliente = new EntidadCliente(datosCliente);
            return controladoraBDProyecto.insertarProyecto(proyecto, cliente);
        
        
        }

        public String[] eliminarProyecto(String nombre){
            return controladoraBDProyecto.eliminarProyecto(nombre);
        }


        public DataTable getUsuariosDisponibles()
        {
            return controladoraUsuario.getUsuariosDisponibles();
        }

        public EntidadProyecto consultarProyecto(String nombre)
        {
            EntidadProyecto proyecto = null; //para encpasular los datos consultados.
            Object[] datosConsultados = new Object[7]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaProyecto = controladoraBDProyecto.consultarProyecto(nombre);

            if (filaProyecto.Rows.Count == 1)
            { // si hay un valor
                for (int i = 1; i < 8; i++)
                {
                    datosConsultados[i-1] = filaProyecto.Rows[0][i].ToString();
                }
                proyecto = new EntidadProyecto(datosConsultados);
            }
            return proyecto;
        }

        /*public String[] consultarProyecto() { }

        public String[] getListadoProyectos() { }


        public String[] validarNombre() { }

        public String[] insertarMiembros() { }

        public String[] getUsuariosDeProyecto() { }

        public String[] getListadoUsuarioDisponibles() { }

        public String[] getNombreProyectos() { }*/





        public DataTable getUsuariosProyecto()
        {
            return controladoraUsuario.getUsuariosProyecto();

        }

        public int getIdProyecto(String nombre)
        {
            return controladoraBDProyecto.getIdProy(nombre);
        }

        public EntidadCliente consultarCliente(int idProy)
        {
            EntidadCliente cliente = null; //para encpasular los datos consultados.
            Object[] datosConsultados = new Object[5]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaCliente = controladoraBDProyecto.consultarCliente(idProy);
            if (filaCliente.Rows.Count == 1)
            { // si hay un valor
                for (int i = 2; i < 7; i++)
                {
                    datosConsultados[i - 2] = filaCliente.Rows[0][i].ToString();
                }
                cliente = new EntidadCliente(datosConsultados);
            }
            return cliente;
        }

        public string[] modificarProyecto(String nombre, String objetivos, String estado, String fechaIni, String fechaFin,String fechaAsig, String lider, EntidadProyecto proyectoViejo)
        {
            Object[] datos = new Object[7];
            datos[0] = nombre;
            datos[1] = objetivos;
            datos[2] = estado;
            datos[3] = fechaIni;
            datos[4] = fechaFin;
            datos[5] = fechaAsig;
            datos[6] = lider;
            EntidadProyecto proyectoNuevo = new EntidadProyecto(datos);
            return controladoraBDProyecto.modificarProyecto(proyectoNuevo, proyectoViejo.Nombre);
        }

        public void insertarUsuarioProyecto(int idP, string cedula)
        {
            controladoraBDProyecto.InsertarUsuarioProyecto(idP,cedula);
        }

        public DataTable getUsuariosAsignados(int idProy)
        {
            DataTable respuesta= controladoraBDProyecto.getUsuariosAsignados(idProy);
            return respuesta;
        }

        public void eliminarMiembros(int idProy)
        {
            controladoraBDProyecto.eliminarMiembros(idProy);
        }
    }
}