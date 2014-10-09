using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras
{
    public class ControladoraUsuario{
        ControladoraBDUsuario controladoraBDUsuario;

        public ControladoraUsuario() {
            controladoraBDUsuario = new ControladoraBDUsuario();
        }

        public String[] insertarUsuario(String nombre,String cedula,String correo,String telefonos) { 
             Object[] datos = new Object[4]; 
             datos[0] = nombre;
             datos[1] = cedula;
             datos[2] = correo;
             datos[3] = telefonos;
             EntidadUsuario usuario = new EntidadUsuario(datos);
             return controladoraBDUsuario.insertarUsuario(usuario);
        }

        public String[] modificarUsuario(String nombre, String cedula, String correo, String telefonos,EntidadUsuario usuarioViejo){
            Object[] datos = new Object[4];
            datos[0] = nombre;
            datos[1] = cedula;
            datos[2] = correo;
            datos[3] = telefonos;
            EntidadUsuario usuarioNuevo = new EntidadUsuario(datos);
            return controladoraBDUsuario.modificarUsuario(usuarioNuevo,usuarioViejo);
        }

        public String[] eliminarUsuario(String idUsuario) { //metodo getidusuario
            return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        /*
        public String[] consultarUsuario(String idUsuario){ //metodo getidusuario
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        public String[] listadoRoles(){ 
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        public String[] getRolesUsuario(String idUsuario){ //metodo getidusuario
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        public void validarCedula(String cedula) { 
        
        }

        public String[] getListadoUsuario() { 
        
        }

        public String[] getNombreProyectos() { 
        
        }

        public String[] getProyectosDeUsuario(String idUsuario){

        }*/
    }
}