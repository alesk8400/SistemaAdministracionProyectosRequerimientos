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
        private static int modo = 0;

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

        protected void btnAceptar_Click(object sender, EventArgs e){

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void limpiarCampos()
        {
            this.txtNombreUsuario.Value = "";
            this.txtCedula.Value = "";
            this.textEmail.Value = "";
            this.textTelefono.Value = "";
            this.textCelular.Value = "";
            this.cmbRoles.ClearSelection();
        }

        protected void irAModo()
        {
            if (modo == 0)
            { // el modo 0 se usa para resetear la interfaz
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = false;
                btnEliminarUsuario.Enabled = false;
                habilitarCampos(false);
            }
            else if (modo == 1)
            { // se desea insertar
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = true;
                btnEliminarUsuario.Enabled = false;

            }
            else if (modo == 2)
            { //modificar
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = true;
                btnAgregarUsuario.Enabled = false;
                btnEliminarUsuario.Enabled = false;
            }
            else if (modo == 3)
            { // eliminar
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = false;
                btnEliminarUsuario.Enabled = true;
            }
            else if (modo == 4)
            { //consultar
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = true;
                btnEliminarUsuario.Enabled = false;
            }

           // aplicarPermisos();// se aplican los permisos del usuario para el acceso a funcionalidades
        }

        protected void habilitarCampos(Boolean habilitar){
            this.txtNombreUsuario.Disabled = !habilitar;
            this.txtCedula.Disabled = !habilitar;
            this.textEmail.Disabled = !habilitar;
            this.textTelefono.Disabled = !habilitar;
            this.textCelular.Disabled = !habilitar;
            this.cmbRoles.Enabled = habilitar;
        }

    }

}