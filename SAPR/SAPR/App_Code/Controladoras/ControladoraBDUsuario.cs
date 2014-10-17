using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPR.App_Code.DataSets.DataSetUsuariosTableAdapters;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras {
    public class ControladoraBDUsuario {
        UsuariosTableAdapter ds;   //Este es el adapter
        //falta constructor

        public ControladoraBDUsuario() {
            ds = new UsuariosTableAdapter();
        }
        public String[] insertarUsuario(EntidadUsuario usuarioNuevo, String rol) {
            String[] resultado = new String[1];
            try {
                this.ds.InsertUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefono, usuarioNuevo.Celular, usuarioNuevo.Pass);
               // String idU = this.ds.getId(usuarioNuevo.Cedula).ToString();
                this.ds.InsertRolesUser(usuarioNuevo.Cedula, rol);
                
                resultado[0] = "Exito";
            }
            catch(SqlException e){
                int n = e.Number;
                if(n==2627){
                    resultado[0] = "Error";
                }
                else{
                    resultado[0] = "Error";
                }
            }
             return resultado;
        }

        public String[] modificarUsuario(EntidadUsuario usuarioNuevo, EntidadUsuario usuarioViejo, String rol){
            String[] resultado = new String[1];
            try
            {
                this.ds.UpdateUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefono, usuarioNuevo.Celular, usuarioNuevo.Pass ,usuarioViejo.Cedula, usuarioViejo.Nombre, usuarioViejo.Correo, usuarioViejo.Telefono, usuarioViejo.Celular, usuarioViejo.Pass);
                this.ds.updateRol(rol, usuarioNuevo.Cedula);
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

        public String[] eliminarUsuario(String cedula){ //metodo getidusuario
            String[] resultado = new String[1];
            try
            {
                this.ds.DeleteUser(cedula);
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


        public DataTable consultarUsuario(String cedula){
            DataTable resultado = new DataTable();

            try{
                resultado = ds.getUsuario(cedula);
            }
            catch (Exception e) { }
            return resultado;
        }
        public DataTable getListadoUsuarios(){
            DataTable filasUsuario = new DataTable();
            try
            {
       //         filasUsuario = ds.getFilasUsuario();
            }
            catch (Exception e) { }
            return filasUsuario;
        }

        public String getRolUsuario(String cedula)
        { //metodo getidusuario
            String rol;

            rol = ds.GetRolUsuario(cedula).ToString();

            return rol;
        }

        public DataTable getUsuariosDisponibles()
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = ds.getUsuariosDisponibles();
            }
            catch (Exception e)
            {
                resultado = null;
            }

            return resultado;

        }


        public DataTable getUsuariosProyecto(int idProyecto)
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = ds.getUsPro(4);
            }
            catch (Exception e) { }
            return resultado;
        }



    }     
}