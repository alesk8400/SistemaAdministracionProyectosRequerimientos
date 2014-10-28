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
        UsuariosTableAdapter adaptUsuario;   //Este es el adapter
        //falta constructor
        /*
         Constructor de la clase ControladoraBDUsuario que incializa el adapter
         */
        public ControladoraBDUsuario() {
            adaptUsuario = new UsuariosTableAdapter();
        }

        /*
         Método que recibe un objeto de tipo EntidadUsuario y su rol, tiene una variable con el resultado de la operación, 
         manda al adapter de Usuarios a insertar un usurio con los atributos de la EntidadUsuario recibida y también lo manda
         a insertar el rol mandadole la cédula y el rol recibido, luego de esto pone en resultado Éxito, en caso de error, 
         hace la excepción y pone en resultado Error y retorna resultado.
         */
        public String[] insertarUsuario(EntidadUsuario usuarioNuevo, String rol) {
            String[] resultado = new String[1];
            try {
                this.adaptUsuario.InsertUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefono, usuarioNuevo.Celular, usuarioNuevo.Pass);
                this.adaptUsuario.InsertRolesUser(usuarioNuevo.Cedula, rol);
                
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

        /*
         Método que recibe un objeto de tipo EntidadUsuario con datos nuevos, otro con datos viejos y su rol nuevo, tiene 
         una variable con el resultado de la operación, manda al adapter de Usuarios a modificar un usurio con los atributos 
         nuevos de la EntidadUsuario recibida y también los viejos, el adapter también modifica el rol mandadole la cédula 
         y el rol recibido, luego de esto pone en resultado Éxito, en caso de error, hace la excepción y pone en resultado 
         Error y retorna resultado.
         */
        public String[] modificarUsuario(EntidadUsuario usuarioNuevo, EntidadUsuario usuarioViejo, String rol){
            String[] resultado = new String[1];
            try
            {
                this.adaptUsuario.UpdateUser(usuarioNuevo.Cedula, usuarioNuevo.Nombre, usuarioNuevo.Correo, usuarioNuevo.Telefono, usuarioNuevo.Celular, usuarioNuevo.Pass, usuarioViejo.Cedula, usuarioViejo.Nombre, usuarioViejo.Correo, usuarioViejo.Telefono, usuarioViejo.Celular, usuarioViejo.Pass);
                this.adaptUsuario.updateRol(rol, usuarioNuevo.Cedula);
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

        /*
         Método que recibe la cédula de un Usuario y manda al adapter de Usuario a eleminarlo, enviandole ese cédula. 
         */
        public String[] eliminarUsuario(String cedula){ //metodo getidusuario
            String[] resultado = new String[1];
            try
            {
                this.adaptUsuario.DeleteUser(cedula);
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

        /*
         Método que recibe la cédula de un Usuario y manda al adapter a consultar un Usuario, deja los datos en un 
         DataTable y lo retorna. 
         */
        public DataTable consultarUsuario(String cedula){
            DataTable resultado = new DataTable();

            try{
                resultado = adaptUsuario.getUsuario(cedula);
            }
            catch (Exception e) { }
            return resultado;
        }

        /*
         Método que recibe la cédula de un Usuario y manda al adapter a consultar el rol de un Usuario, deja ese rol 
         en un String y lo retorna. 
         */
        public String getRolUsuario(String cedula)
        { //metodo getidusuario
            String rol;

            rol = adaptUsuario.GetRolUsuario(cedula).ToString();

            return rol;
        }

        /*
         Método que manda al adapter de Usuario a consultar los Usuarios disponibles, deja los datos en un DataTable 
         y lo retorna. 
         */
        public DataTable getUsuariosDisponibles()
        {
            DataTable resultado = new DataTable();

            try
            {
                resultado = adaptUsuario.getUsuariosDisponibles1();
            }
            catch (Exception e)
            {
                resultado = null;
            }

            return resultado;

        }

        /*
         Método que recibe la cédula de un Usuario, manda al adapter de Usuario a validar ese Usuario, deja la validación en un int resutado y lo retorna. 
         y lo retorna. 
         */
        public int validarUsuario(string cedulaUsuario)
        {
            int resultado = (int)this.adaptUsuario.validarUsuario(cedulaUsuario);
            return resultado;
        }
    }     
}