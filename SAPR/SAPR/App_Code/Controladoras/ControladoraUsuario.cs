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

        public String[] insertarUsuario(String nombre,String cedula,String correo,String telefono, String celular, String rol, String pass ) { 
             Object[] datos = new Object[6];
             datos[0] = nombre;
             datos[1] = cedula;
             datos[2] = correo;        
             datos[3] =telefono;
             datos[4] = celular;
             datos[5] = pass;
             EntidadUsuario usuario = new EntidadUsuario(datos);
             return controladoraBDUsuario.insertarUsuario(usuario, rol);
        }

        public String[] modificarUsuario(String nombre, String cedula, String correo, String telefono, String celular,String rol, String pass, EntidadUsuario usuarioViejo){
            Object[] datos = new Object[6];
            datos[0] = nombre;
            datos[1] = cedula;
            datos[2] = correo;
            datos[3] = telefono;
            datos[4] = celular;
            datos[5] = pass;
            EntidadUsuario usuarioNuevo = new EntidadUsuario(datos);
            return controladoraBDUsuario.modificarUsuario(usuarioNuevo,usuarioViejo,rol);
        }

        public String[] eliminarUsuario(String cedula) { //metodo getidusuario
            return controladoraBDUsuario.eliminarUsuario(cedula);
        }

        
        public EntidadUsuario consultarUsuario(String cedula)
        {
            EntidadUsuario usuario = null; //para encpasular los datos consultados.
            Object[] datosConsultados = new Object[6]; //para guardar los datos obtenidos de la consulta temporalmente
            DataTable filaUsuario = controladoraBDUsuario.consultarUsuario(cedula);


            if (filaUsuario.Rows.Count == 1)
            { // si hay un valor
             
                    datosConsultados[1] = filaUsuario.Rows[0][0].ToString();
                    datosConsultados[0] = filaUsuario.Rows[0][1].ToString();
                    datosConsultados[2] = filaUsuario.Rows[0][2].ToString();
                    datosConsultados[3] = filaUsuario.Rows[0][3].ToString();
                    datosConsultados[4] = filaUsuario.Rows[0][4].ToString();
                    datosConsultados[5] = filaUsuario.Rows[0][5].ToString();
               
                usuario = new EntidadUsuario(datosConsultados);
            }
            return usuario;
        }

   /*     public EntidadUsuario[] getListadoUsuario(){
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
        } */

        public String getRolUsuario(String cedula)
        { //metodo getidusuario
            return controladoraBDUsuario.getRolUsuario(cedula) ;
        }

        public DataTable getUsuariosDisponibles()
        {
            return controladoraBDUsuario.getUsuariosDisponibles();
        }


        public DataTable getUsuariosProyecto()
        {
            return controladoraBDUsuario.getUsuariosProyecto(2);
        }

        public int validarUsuario(String cedulaUsuario) {
            return controladoraBDUsuario.validarUsuario(cedulaUsuario);        
        }


        //public string ConsultarNomLider(){
        
       // }

        /*
        public String[] listadoRoles(){ 
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }

        

        public void validarCedula(String cedula) { 
        
        }

        

        public String[] getNombreProyectos() { 
        
        }

        public String[] getProyectosDeUsuario(String idUsuario){

        }*/

        public int getProyecto(string proyecto)
        {
            ControladoraProyecto controlProyecto = new ControladoraProyecto();
            return controlProyecto.getIdProyecto(proyecto);
        }

        public void insertarUsuarioProyecto(int IdProy, string p)
        {
            ControladoraProyecto controlProyecto = new ControladoraProyecto();
            controlProyecto.insertarUsuarioProyecto(IdProy, p);
        }
    }
}