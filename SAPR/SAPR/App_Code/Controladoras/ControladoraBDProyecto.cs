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
        ProyectoTableAdapter ps;

        public ControladoraBDProyecto() {
            ps = new ProyectoTableAdapter();
        }

        public String[] insertarProyecto(EntidadProyecto proyectoNuevo)
        {
            String[] resultado = new String[1];
            try
            {
               // this.ps.InsertUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefonos);
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

        public String[] modificarProyecto(EntidadProyecto proyectoNuevo, EntidadProyecto proyectoViejo)
        {
            String[] resultado = new String[1];
            try
            {
               // this.ps.UpdateUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefonos, usuarioViejo.Cedula);
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

        public String[] eliminarProyecto(String idProyecto)
        { 
            String[] resultado = new String[1];
            int idProy = 0;
            idProy = Int32.Parse(idProyecto);
            try
            {
                this.ps.Delete(idProy);
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