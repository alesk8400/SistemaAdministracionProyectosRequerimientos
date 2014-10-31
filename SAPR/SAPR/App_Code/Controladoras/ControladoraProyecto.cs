using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPR.App_Code.Entidades;
using System.Data;


namespace SAPR.App_Code.Controladoras
{
    /*Esta clase se encarga de comunicar la interfaz de proyecto con la controladora de bases de datos de proyecto*/
    public class ControladoraProyecto {
        ControladoraBDProyecto controladoraBDProyecto;
        ControladoraUsuario controladoraUsuario;

        /*Este es el constructor de la clase. Se encarga de crear una nueva instancia de la controladora de bases de datos proyecto y de controladora usuario.*/
        public ControladoraProyecto() {
            controladoraBDProyecto = new ControladoraBDProyecto();
            controladoraUsuario = new ControladoraUsuario();

        }
        /*Este método se encarga de la inserción de un proyecto, recibe como parámetro los datos que va a tener el proyecto, además de los datos del cliente. Retorna un resultado de éxito en caso
         de realizar una inserción correcta, o un mensaje error en caso de una inserción incorrecta*/
        public String[] insertarProyecto(String nombre, String objetivo, String estado, String fechaInic, String fechaFin, String fechaAsig, String lider, String nombreCliente, String telefono, String telefono1, String oficina, String correoCliente )
        {
            Object[] datos = new Object[7];  //Se crea un objeto con los datos del proyecto
            datos[0] = nombre;
            datos[1] = objetivo;
            datos[2] = estado;
            datos[3] = fechaInic;
            datos[4] = fechaFin;
            datos[5] = fechaAsig; 
            datos[6] = lider;
            Object[] datosCliente = new Object[5]; //Se crea un objeto con los datos del cliente
            datosCliente[0] = nombreCliente;
            datosCliente[1] = telefono;
            datosCliente[2] = telefono1;
            datosCliente[3] = oficina;
            datosCliente[4] = correoCliente;
            EntidadProyecto proyecto = new EntidadProyecto(datos);  //Se encapsulan los datos del proyecto
            EntidadCliente cliente = new EntidadCliente(datosCliente); //Se encapsulan los datos del cliente
            return controladoraBDProyecto.insertarProyecto(proyecto, cliente);
        
        
        }
        /*Este método se encarga de la eliminación de un proyecto, recibe como parámetro el nombre del proyecto a eliminar. Retorna un resultado de éxito en caso
         de realizar una eliminación correcta, o un mensaje error en caso de una eliminación incorrecta*/
        public String[] eliminarProyecto(String nombre){
            return controladoraBDProyecto.eliminarProyecto(nombre);
        }

        /*Este método se encarga de retornar la lista de usuarios no asignados a proyectos (Disponibles).*/
        public DataTable getUsuariosDisponibles()
        {
            return controladoraUsuario.getUsuariosDisponibles();
        }

        /*Este método se encarga de la consulta de un proyecto, recibe como parámetro el nombre del proyecto a consultar. Retorna la entidad del proyecto
         que se consultó que contiene todos los datos del proyecto consultado*/
        public EntidadProyecto consultarProyecto(String nombre)
        {
            EntidadProyecto proyecto = null; //para encapsular los datos consultados.
            Object[] datosConsultados = new Object[7]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaProyecto = controladoraBDProyecto.consultarProyecto(nombre);

            if (filaProyecto.Rows.Count == 1) { //se recorre el dataTable de proyectos tomando los datos de los proyectos
                for (int i = 1; i < 8; i++) {
                    datosConsultados[i-1] = filaProyecto.Rows[0][i].ToString();
                }
                proyecto = new EntidadProyecto(datosConsultados); //se encapsulan los datos del proyecto
            }
            return proyecto;
        }

        /*Este método retorna el id de un proyecto. Recibe como parámetro el nombre del proyecto*/
        public int getIdProyecto(String nombre)
        {
            return controladoraBDProyecto.getIdProy(nombre);
        }

        /*Este método se encarga de retornar los datos del cliente asignado a un proyecto. Recibe como parámetro el id del proyecto.*/
        public EntidadCliente consultarCliente(int idProy)
        {
            EntidadCliente cliente = null; //para encpasular los datos consultados.
            Object[] datosConsultados = new Object[5]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaCliente = controladoraBDProyecto.consultarCliente(idProy);
            if (filaCliente.Rows.Count == 1)  //se recorre el dataTable de clientes tomando los datos de los proyectos
            { // si hay un valor
                for (int i = 2; i < 7; i++)
                {
                    datosConsultados[i - 2] = filaCliente.Rows[0][i].ToString();
                }
                cliente = new EntidadCliente(datosConsultados); //se encapsulan los datos del cliente
            }
            return cliente;
        }
        /*Este método se encarga de la modificación de un proyecto, recibe como parámetro los nuevos datos que tendrá el proyecto así como una entidad de proyecto con los datos viejos. 
          Retorna un resultado de éxito en caso de realizar una modificación correcta, o un mensaje error en caso de una modificación incorrecta*/
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
            EntidadProyecto proyectoNuevo = new EntidadProyecto(datos);  //se encapsulan los datos del proyecto a modificar
            return controladoraBDProyecto.modificarProyecto(proyectoNuevo, proyectoViejo.Nombre);
        }

        /*Este método se encarga de ingresar un nuevo miembro a un proyecto. Recibe como parámetro la cédula del miembro y el id del proyecto.*/
        public void insertarUsuarioProyecto(int idP, string cedula)
        {
            controladoraBDProyecto.InsertarUsuarioProyecto(idP,cedula);
        }

        /*Este método se encarga de retornar la lista de usuarios asignados a un proyecto específico. Recibe como parámetro el id del proyecto.*/
        public DataTable getUsuariosAsignados(int idProy)
        {
            DataTable respuesta= controladoraBDProyecto.getUsuariosAsignados(idProy);
            return respuesta;
        }

        /*Este método se encarga de eliminar miembros de un proyecto. Recibe como parámetro el id del proyecto.*/
        public void eliminarMiembros(int idProy)
        {
            controladoraBDProyecto.eliminarMiembros(idProy);
        }

        /*Este método se encarga de eliminar un miembro de un proyecto. Recibe como parámetro el id del proyecto y la cedula del miembro.*/
        public void eliminarUsuarioProyecto(int IdProy, string cedula)
        {
            controladoraBDProyecto.eliminarUsuarioProyecto(IdProy, cedula);
        }

        public DataTable getProyectos()
        {
            return controladoraBDProyecto.getProyectos();
        }
    }
}