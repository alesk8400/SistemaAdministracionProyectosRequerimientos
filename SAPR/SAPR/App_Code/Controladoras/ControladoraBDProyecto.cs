using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPR.App_Code.DataSets.DataSetProyectosTableAdapters;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras {
    public class ControladoraBDProyecto {
        adap ps;
        adapCliente cs;
        AdapterUsuarioProyecto us;

       
        public ControladoraBDProyecto() {
            ps = new adap();
            cs = new adapCliente();
            us = new AdapterUsuarioProyecto();
        }

        public String[] insertarProyecto(EntidadProyecto proyectoNuevo, EntidadCliente cliente)
        {
            String[] resultado = new String[1];
            try
            {
                //System.Globalization.DateTimeFormatInfo prueba = new System.Globalization.DateTimeFormatInfo();
                //string datetipe = "MMddyyyy";
                //prueba.LongDatePattern = datetipe;
                int idProy;
                this.ps.InsertProyecto(proyectoNuevo.Nombre, proyectoNuevo.Objetivos, proyectoNuevo.Estado, proyectoNuevo.FechaIni, proyectoNuevo.FechaFin,proyectoNuevo.FechaAsig, proyectoNuevo.Lider);
                idProy= Int32.Parse(this.ps.getIdProyecto(proyectoNuevo.Nombre).ToString());
                this.cs.InsertarCliente(idProy, cliente.Nombre, cliente.Telefono, cliente.Celular, cliente.Oficina, cliente.Correo);
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

        public String[] modificarProyecto(EntidadProyecto proyectoNuevo, String nombreviejo)
        {
            String[] resultado = new String[1];
            try
            {
                this.ps.actualizarProyecto(proyectoNuevo.Nombre, proyectoNuevo.Objetivos, proyectoNuevo.Estado, proyectoNuevo.FechaIni, proyectoNuevo.FechaFin, proyectoNuevo.FechaAsig, proyectoNuevo.Lider, nombreviejo );
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

        public String[] eliminarProyecto(String nombre)
        { 
            String[] resultado = new String[1];

            try
            {
               this.ps.BorrarProyecto(nombre);
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

        public DataTable consultarProyecto(String nombre)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = ps.ConsultarProyecto(nombre);
            }
            catch (Exception e) { }
            return resultado;
        }

        public int getIdProy( String nombre) {
            int idProy;
            idProy=  Int32.Parse(this.ps.getIdProyecto(nombre).ToString());
            return idProy;
        }

        public DataTable consultarCliente(int idProy)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = cs.consultarCliente(idProy);
            }
            catch (Exception e) { }
            return resultado;
        }




        public void InsertarUsuarioProyecto(int idP, string cedula){

            this.us.InsertarUsuarioProyecto(idP,cedula);
        }

        public DataTable getUsuariosAsignados(int idProy)
        {
            DataTable resp = us.getUsuariosProyecto(idProy);
            return resp;
        }

        public void eliminarMiembros(int idProy)
        {
            us.deleteUsuarioProyecto(idProy);
        }
    }
}