﻿using System;
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

        public ControladoraBDEstructura() {
            adaptS = new AdaptSprint();
            adaptM = new AdaptModulo();
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

        public String[] eliminarSprint(String nombreSprint)
        {
            String[] resultado = new String[1];

            try
            {
                this.adaptS.eliminarSprint(nombreSprint); //se llama al dataSet de Estructura para eliminar el Sprint
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

        public DataTable consultarSprint(String nombreSprint)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptS.ConsultarSprint(nombreSprint); //se llama al dataSet de Estructura para consultar el Sprint
            }
            catch (Exception e) { }
            return resultado;
        }

        public int getIdSprint(String nombreSprint)
        {
            int idSprint;
            idSprint = Int32.Parse(this.adaptS.getIdSprint(nombreSprint).ToString());
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
    }
}