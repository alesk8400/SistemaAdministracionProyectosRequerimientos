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
        /*
         Método que recibe los datos de un usuario, los mete en un vector, crea un objeto EntidadUsuario con los 
         datos de ese vector y manda a la controladoraBDUsuario a insertar la entidadUsuario y su rol.
         */
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

        /*
         Método que recibe los datos modificados de un usuario, y una EntidadUsuario con los datos que tenía anteriormente, 
         mete los nuevos en un vector, crea un objeto EntidadUsuario con los datos de ese vector (los nuevos) y manda la 
         controladoraBDUsuario a modificar el usuario con la entidadUsuario Nuevo, entidadUsuario Viejo y su rol.
         */
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

        /*
         Método que recibe la cédula de un usuario y manda a la controladoraBDUsuario a eleminar un usuario con su cédula.
         */
        public String[] eliminarUsuario(String cedula) { //metodo getidusuario
            return controladoraBDUsuario.eliminarUsuario(cedula);
        }

        /*
         Método que recibe la cédula de un usuario, manda a consultar a la controladoraBDUsuario con la cédula que recibió
         y lo de deja en un DataTable, luego saca lo del DataTable y lo va metiendo en un objeto vector, para luego 
         mandarselo a el constructor de una EntidadUsuario y retorna la Entidad.
         */
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

        /*
         Método que recibe la cédula de un usuario y manda a la controladoraBDUsuario a consultar el rol del usuario 
         con esa cédula y lo retorna.
         */
        public String getRolUsuario(String cedula)
        { //metodo getidusuario
            return controladoraBDUsuario.getRolUsuario(cedula) ;
        }

        /*
         Método que manda a la controladoraBDUsuario a consultar todos los usuarios que no están asigandos a ningún proyecto, 
         y los retorna en un DataTable.
         */
        public DataTable getUsuariosDisponibles()
        {
            return controladoraBDUsuario.getUsuariosDisponibles();
        }

        /*
         Método que recibe la cédula de un usuario y manda a la controladoraBDUsuario a validar los datos de ese Usuario.
         */
        public int validarUsuario(String cedulaUsuario) {
            return controladoraBDUsuario.validarUsuario(cedulaUsuario);        
        }

        /*
         Método que recibe el nombre de un proyecto, crea un objeto ControladoraProyecto y lo manda a obtener el ID de ese proyecto.
         */
        public int getProyecto(string proyecto)
        {
            ControladoraProyecto controlProyecto = new ControladoraProyecto();
            return controlProyecto.getIdProyecto(proyecto);
        }

        /*
         Método que recibe el ID de un proyecto y la cédula de un usuario, crea un objeto ControladoraProyecto y lo manda a insertar 
         ese usuario a ese proyecto.
         */
        public void insertarUsuarioProyecto(int IdProy, string ced)
        {
            ControladoraProyecto controlProyecto = new ControladoraProyecto();
            controlProyecto.insertarUsuarioProyecto(IdProy, ced);
        }

        /*
         Método que recibe el ID de un proyecto y la cédula de un usuario, crea un objeto ControladoraProyecto y lo manda a eliminar 
         ese usuario de ese proyecto.
         */
        public void eliminarUsuarioProyecto(int IdProy, string ced)
        {
            ControladoraProyecto controlProyecto = new ControladoraProyecto();
            controlProyecto.eliminarUsuarioProyecto(IdProy, ced);
        }

        public String getProyectoUsuario(String cedula) {
            return controladoraBDUsuario.getProyectoUsuario(cedula);
        }
    }
}