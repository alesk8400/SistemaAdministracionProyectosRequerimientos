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

        public String[] insertarUsuario(String nombre,String cedula,String correo,String telefonos, String rol ) { 
             Object[] datos = new Object[4]; 
             datos[0] = nombre;
             datos[1] = cedula;
             datos[2] = correo;
             datos[3] = telefonos;
             EntidadUsuario usuario = new EntidadUsuario(datos);
             return controladoraBDUsuario.insertarUsuario(usuario, rol);
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

        
        public EntidadUsuario consultarUsuario(String cedula)
        {
            EntidadUsuario usuario = null; //para encpasular los datos consultados.
            Object[] datosConsultados = new Object[4]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaUsuario = controladoraBDUsuario.consultarUsuario(cedula);

            if (filaUsuario.Rows.Count == 1)
            { // si hay un valor
                for (int i = 0; i < 4; i++){
                    datosConsultados[i] = filaUsuario.Rows[0][i].ToString();
                }
                usuario = new EntidadUsuario(datosConsultados);
            }
            return usuario;
        }

        public EntidadUsuario[] getListadoUsuario(){
            EntidadUsuario[] usuarios;
            Object[] datosConsultados = new Object[3];
            int cont = 0;
            DataTable filaUsuario = controladoraBDUsuario.getListadoUsuarios();
            usuarios = new EntidadUsuario[filaUsuario.Rows.Count];
            while (cont < filaUsuario.Rows.Count){
                for (int i = 0; i < 3; i++){
                    datosConsultados[i] = filaUsuario.Rows[cont][i].ToString();
                }
                usuarios[cont] = new EntidadUsuario(datosConsultados);
            }
            return usuarios;
        }

        /*
        public String[] listadoRoles(){ 
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        public String[] getRolesUsuario(String idUsuario){ //metodo getidusuario
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        public void validarCedula(String cedula) { 
        
        }

        

        public String[] getNombreProyectos() { 
        
        }

        public String[] getProyectosDeUsuario(String idUsuario){

        }*/
    }
}