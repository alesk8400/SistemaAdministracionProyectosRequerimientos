using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPR.App_Code.DataSets.DataSetProyectosTableAdapters;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras {
    /*Esta clase se encarga de comunicar la controladora de proyecto con la tabla de proyecto en la base de datos*/
    public class ControladoraBDProyecto {
        adap adapProyecto;
        adapCliente adapClient;
        AdapterUsuarioProyecto adapUsuaProyecto;

        /*Este es el constructor de la clase. Se encarga de inicializar los adaptores de los dataSets.*/
        public ControladoraBDProyecto() {
            adapProyecto = new adap();
            adapClient = new adapCliente();
            adapUsuaProyecto = new AdapterUsuarioProyecto();
        }

        /*Este método se encarga de la inserción de un proyecto, recibe como parámetro una entidad de proyecto y una entidad de cliente. Retorna un resultado de éxito en caso
         de realizar una inserción correcta, o un mensaje error en caso de una inserción incorrecta*/
        public String[] insertarProyecto(EntidadProyecto proyectoNuevo, EntidadCliente cliente)
        {
            String[] resultado = new String[1];
            try {
                int idProy;  //se llama al dataSet de proyectos para insertar el proyecto nuevo
                this.adapProyecto.InsertProyecto(proyectoNuevo.Nombre, proyectoNuevo.Objetivos, proyectoNuevo.Estado, proyectoNuevo.FechaIni, proyectoNuevo.FechaFin, proyectoNuevo.FechaAsig, proyectoNuevo.Lider);
                idProy = Int32.Parse(this.adapProyecto.getIdProyecto(proyectoNuevo.Nombre).ToString());
                this.adapClient.InsertarCliente(idProy, cliente.Nombre, cliente.Telefono, cliente.Celular, cliente.Oficina, cliente.Correo);
                resultado[0] = "Exito";
            }
            catch (SqlException e){
              int n = e.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }
            }
            
                
            
            return resultado;
        }

        /*Este método se encarga de la modificación de un proyecto, recibe como parámetro una entidad de proyecto conmlos datos nuevos así como el nombre "viejo" del proyecto. 
          Retorna un resultado de éxito en caso de realizar una modificación correcta, o un mensaje error en caso de una modificación incorrecta*/
        public String[] modificarProyecto(EntidadProyecto proyectoNuevo, String nombreviejo)
        {
            String[] resultado = new String[1];
            try
            {   //se llama al dataSet de proyectos para modificar el proyecto
                this.adapProyecto.actualizarProyecto(proyectoNuevo.Nombre, proyectoNuevo.Objetivos, proyectoNuevo.Estado, proyectoNuevo.FechaIni, proyectoNuevo.FechaFin, proyectoNuevo.FechaAsig, proyectoNuevo.Lider, nombreviejo);
                resultado[0] = "Exito";
            }
            catch (SqlException e)
            {
                int n = e.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }
            }
            return resultado;
        }

        /*Este método se encarga de la eliminación de un proyecto, recibe como parámetro el nombre del proyecto a eliminar. Retorna un resultado de éxito en caso
         de realizar una eliminación correcta, o un mensaje error en caso de una eliminación incorrecta*/
        public String[] eliminarProyecto(String nombre)
        { 
            String[] resultado = new String[1];

            try
            {
                this.adapProyecto.BorrarProyecto(nombre); //se llama al dataSet de proyectos para eliminar el proyecto
                resultado[0] = "Exito";
            }
            catch (SqlException e)
            {
                int n = e.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }
            }
            return resultado;
        }

        /*Este método se encarga de la consulta de un proyecto, recibe como parámetro el nombre del proyecto a consultar. Retorna el data table del proyecto
         que se consultó que contiene todos los datos del proyecto consultado*/
        public DataTable consultarProyecto(String nombre)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adapProyecto.ConsultarProyecto(nombre); //se llama al dataSet de proyectos para consultar el proyecto
            }
            catch (Exception e) { }
            return resultado;
        }

        /*Este método retorna el id de un proyecto. Recibe como parámetro el nombre del proyecto*/
        public int getIdProy( String nombre) {
            int idProy;
            idProy = Int32.Parse(this.adapProyecto.getIdProyecto(nombre).ToString());
            return idProy;
        }

        /*Este método se encarga de retornar el dataTable con los datos del cliente asignado a un proyecto. Recibe como parámetro el id del proyecto.*/
        public DataTable consultarCliente(int idProy)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adapClient.consultarCliente(idProy);
            }
            catch (Exception e) { }
            return resultado;
        }

        /*Este método se encarga de ingresar un nuevo miembro a un proyecto. Recibe como parámetro la cédula del miembro y el id del proyecto.*/
        public void InsertarUsuarioProyecto(int idP, string cedula){

            this.adapUsuaProyecto.InsertarUsuarioProyecto(idP, cedula);
        }

        /*Este método se encarga de retornar la lista de usuarios asignados a un proyecto específico. Recibe como parámetro el id del proyecto.*/
        public DataTable getUsuariosAsignados(int idProy)
        {
            DataTable resp = adapUsuaProyecto.getUsuariosProyecto(idProy);
            return resp;
        }

        /*Este método se encarga de eliminar miembros de un proyecto. Recibe como parámetro el id del proyecto.*/
        public void eliminarMiembros(int idProy)
        {
            adapUsuaProyecto.deleteUsuarioProyecto(idProy);
        }

        /*Este método se encarga de eliminar un miembro de un proyecto. Recibe como parámetro el id del proyecto y la cedula del miembro.*/
        public void eliminarUsuarioProyecto(int idProy, String cedula)
        {
            adapUsuaProyecto.eliminarUsuarioProyecto(cedula, idProy);
        }
    }
}