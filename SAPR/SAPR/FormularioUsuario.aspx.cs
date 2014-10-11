using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPR.App_Code.Controladoras;
using SAPR.App_Code.Entidades;

namespace SAPR
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {

        private static ControladoraUsuario controladora = new ControladoraUsuario();
        private static EntidadUsuario entidadConsultada;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string telefonos = this.textTelefono.Value.ToString() + " " + this.textCelular.Value.ToString();
            controladora.insertarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), telefonos, this.cmbRoles.SelectedItem.ToString());
            try
            {
                consultaGrideUsuarios.DataBind();
                //consultaGrideUsuarios." ;
            }
            catch { 
                
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadConsultada = controladora.consultarUsuario(gridUsuarios.SelectedRow.ToString());
            txtNombreUsuario.Value = entidadConsultada.Nombre.ToString();
            txtCedula.Value = entidadConsultada.Cedula.ToString();
            textTelefono.Value = entidadConsultada.Telefono.ToString();



        }


        

    }
}