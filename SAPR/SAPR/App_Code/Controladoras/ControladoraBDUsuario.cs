using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPR.App_Code.DataSets;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras {
    public class ControladoraBDUsuario {
        DataSetUsuarios ds;   //Este es el adapter
        //falta constructor
        public String[] insertarUsuario(EntidadUsuario usuarioNuevo) { 
             //return controladoraBDUsuario.insertarUsuario(usuario);
        }

        public String[] modificarUsuario(EntidadUsuario usuarioNuevo, EntidadUsuario usuarioViejo){
            // return controladoraBDUsuario.modificarUsuario(usuarioNuevo,usuarioViejo);
        }

        public String[] eliminarUsuario(String idUsuario)
        { //metodo getidusuario
            // return controladoraBDUsuario.eliminarUsuario(idUsuario);
        }
    }     
}