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
        public String[] insertarUsuario(EntidadUsuario usuarioNuevo) {
            String[] resultado = new String[1];
            try {
                this.ds.InsertUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefonos);
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

        public String[] modificarUsuario(EntidadUsuario usuarioNuevo, EntidadUsuario usuarioViejo){
            String[] resultado = new String[1];
            try
            {
                this.ds.UpdateUser(usuarioNuevo.Cedula,usuarioNuevo.Nombre,usuarioNuevo.Correo,usuarioNuevo.Telefonos,usuarioViejo.Cedula);
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

        public String[] eliminarUsuario(String idUsuario){ //metodo getidusuario
            String[] resultado = new String[1];
            int idUser = 0;
            idUser = Int32.Parse(idUsuario);
            try
            {
                this.ds.Delete(idUser);
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
                resultado = ds.consultarFila(cedula);
            }
            catch (Exception e) { }
            return resultado;
        }

        public DataTable getListadoUsuarios(){
            DataTable filasUsuario = new DataTable();
            try
            {
                filasUsuario = ds.getFilasUsuario();
            }
            catch (Exception e) { }
            return filasUsuario;
        }
    }     
}