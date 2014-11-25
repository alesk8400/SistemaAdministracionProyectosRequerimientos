using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPR.App_Code.DataSets.DataSetsEstructurasTableAdapters;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras
{
    //Esta clase se encarga de conectar la clase controladora Estructura con la Base de Datos. Cotiene métodos para IMEC de Sprint y Modulos
    public class ControladoraBDEstructura{
        AdaptSprint adaptS;
        AdaptModulo adaptM;
        RequerimientoTableAdapter adapAux;  // Desaparecera

        //Constructor de la clase se encarga de inicilizar los adaptadores de los distintos DataSets
        public ControladoraBDEstructura() {
            adaptS = new AdaptSprint();
            adaptM = new AdaptModulo();
            adapAux = new RequerimientoTableAdapter();
        }

        //Este método se encarga de insertar un sprint. recibe como parámetro una entidad Sprint y el id de Proyecto donde insertarlo
        public String[] insertarSprint(EntidadSprint sprintNuevo,int idProyecto)
        {
            String[] resultado = new String[1];
            try
            {
                this.adaptS.InsertarSprint(sprintNuevo.Nombre, sprintNuevo.Descripcion, idProyecto);
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

        //Este método se encarga de modificar un sprint. recibe como parámetro una entidad SprintNueva con los nuevos datos y el id de Proyecto donde modificarlo y el nombre viejo del sprint
        public String[] modificarSprint(EntidadSprint sprintNuevo,int idProyecto,String nombreViejo)
        {
            String[] resultado = new String[1];
            try
            {   //se llama al dataSet de Estructura para modificar el sprint

                this.adaptS.actualizarSprint(sprintNuevo.Nombre,sprintNuevo.Descripcion,idProyecto,nombreViejo);
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

        //Este método se encarga de eliminar un sprint. recibe como parámetro el nombre del Sprint y el id de Proyecto donde eliminarlo
        public String[] eliminarSprint(String nombreSprint,int idProyecto)
        {
            String[] resultado = new String[1];

            try
            {
                this.adaptS.eliminarSprint(nombreSprint,idProyecto); //se llama al dataSet de Estructura para eliminar el Sprint
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

        //Este metodo se encarga de devolver un datatable con los datos de un sprint, se requiere como parámetro el nombre del sprint y el id del proyecto
        public DataTable consultarSprint(String nombreSprint,int idProyecto)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptS.ConsultarSprint(nombreSprint,idProyecto); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }

        //Este método se encarga de devolver el id del sprint, requiere el nombre del sprint y id del proyecto
        public int getIdSprint(String nombreSprint, int idProyecto)
        {
            int idSprint;
        
                idSprint = Int32.Parse(this.adaptS.getIdSprint(nombreSprint, idProyecto).ToString());
         
            
            return idSprint;
        }

        //Este método se encarga de insertar un modulo. recibe como parámetro una entidad moduloy el id del sprint donde insertarlo
        public String[] insertarModulo(EntidadModulo moduloNuevo, int idSprint)
        {
            String[] resultado = new String[1];
            try
            {
                this.adaptM.insertarModulo(moduloNuevo.Nombre, moduloNuevo.Descripcion, idSprint);
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

        //Este método se encarga de modificar un modulo. recibe como parámetro una entidad moduloNueva con los nuevos datos y el id de sprint donde modificarlo y el nombre viejo del modulo
        public String[] modificarModulo(EntidadModulo moduloNuevo, int idSprint, String nombreViejo)
        {
            String[] resultado = new String[1];
            try
            {   //se llama al dataSet de Estructura para modificar el sprint

                this.adaptM.modificarModulo(moduloNuevo.Nombre, moduloNuevo.Descripcion, nombreViejo, idSprint);
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

        //Este método se encarga de eliminar un modulo. recibe como parámetro el nombre del modulo y el id de Sprint donde eliminarlo
        public String[] eliminarModulo(String nombreModulo, int idSprint)
        {
            String[] resultado = new String[1];

            try
            {
                this.adaptM.eliminarModulo(nombreModulo, idSprint); 
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

        //Este metodo se encarga de devolver un datatable con los datos de un modulo, se requiere como parámetro el nombre del modulo y el id del sprint
        public DataTable consultarModulo(String nombreModulo, int idSprint)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptM.consultarModulo(nombreModulo, idSprint); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }

        //Este metodo devuelve todos los ID de los sprints que pertenecen al proyecto que recibe como parametro
        public DataTable getSprints(int proyecto)  
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptS.getSprints(proyecto); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }


        //Retorna los modulos de un sprint, recibe el id del sprint 
        public DataTable getModulo(int sprintId)  
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptM.getModulo(sprintId); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }


        //Metodo Temporal que para tomar requerimientos y cargarlos (se borrara posteriormente)
        public DataTable getRequerimientos(int moduloId)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adapAux.getReqs(moduloId); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) {
                resultado = null;
            }
            return resultado;
        }

        public String getNombreModulo(int idModulo)
        {
            return adaptM.getNombreModulo(idModulo);
        }


        public int getidS(int idModulo)
        {
            return Int32.Parse(adaptM.getidS(idModulo).ToString());
        }

    }
}