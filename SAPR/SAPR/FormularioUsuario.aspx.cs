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
            controladora.insertarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString());
            gridUsuarios.DataBind();
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)  {

            
            try
            {
                entidadConsultada = controladora.consultarUsuario(gridUsuarios.SelectedRow.Cells[0].Text.ToString());
                txtNombreUsuario.Value = entidadConsultada.Nombre;
                txtCedula.Value = entidadConsultada.Cedula;
                textTelefono.Value = entidadConsultada.Telefono;
                textCelular.Value = entidadConsultada.Celular;
                textEmail.Value = entidadConsultada.Correo;
            }
            catch {

                entidadConsultada = null;
                // Hacer algo para indicar error
            }

            



        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                controladora.eliminarUsuario(entidadConsultada.ID.ToString());
                gridUsuarios.DataBind();
            }
            catch { 
            
            }
        }

    }

}