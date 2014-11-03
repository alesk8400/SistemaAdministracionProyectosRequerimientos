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
    public class ControladoraBDEstructura{
        AdaptSprint adaptS;
        AdaptModulo adaptM;
        RequerimientoTableAdapter adapAux;  // Desaparecera
        public ControladoraBDEstructura() {
            adaptS = new AdaptSprint();
            adaptM = new AdaptModulo();
            adapAux = new RequerimientoTableAdapter();
        }

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

        public int getIdSprint(String nombreSprint, int idProyecto)
        {
            int idSprint;
            idSprint = Int32.Parse(this.adaptS.getIdSprint(nombreSprint, idProyecto).ToString());
            return idSprint;
        }

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


        public DataTable getSprints(int proyecto)  // METODO DE CALI PARA PRUEBAS
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptS.getSprints(proyecto); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }

        public DataTable getModulo(int sprintId)  //Retorna los modulos de un sprint
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptM.getModulo(sprintId); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }


        // RECORDAR QUE ESTE METODO LLEGARA A DESAPARECER CUANDO IMPLEMENTEMOS EL MODULO REQUERIMIENTO
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

    }
}