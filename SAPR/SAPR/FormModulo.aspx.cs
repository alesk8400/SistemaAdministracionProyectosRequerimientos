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
    public partial class FormModulo : System.Web.UI.Page
    {

        private static ControladoraEstructura controladora = new ControladoraEstructura();
        private static EntidadModulo entidadM;
        int idProyecto = 0;
        private static int modoM = 0;
        int idSprints = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregarModulo_Click(object sender, EventArgs e)
        {
            this.txtNombreModulo.Disabled = false;
            this.txtDescripcionModulo.Disabled = false;
            modoM = 1;
            this.btnAceptarM.Disabled = false;
            this.btnCancelarM.Disabled = false;
            this.txtNombreModulo.Value = "";
            this.txtDescripcionModulo.Value = "";
            this.btnAgregarModulo.Disabled = true;
            this.btnModificarModulo.Disabled = true;
            this.modaleliminarModulo.Disabled = true;
            //this.btnAgregarSprint.Disabled = true;
            //this.btnModificarSprint.Disabled = true;
            //this.btnEliminarSprint.Disabled = true;
        }
        protected void btnModificarModulo_Click(object sender, EventArgs e)
        {
            this.txtNombreModulo.Disabled = false;
            this.txtDescripcionModulo.Disabled = false;
            modoM = 2;
            this.btnAceptarM.Disabled = false;
            this.btnCancelarM.Disabled = false;
            this.btnAgregarModulo.Disabled = true;
            this.btnModificarModulo.Disabled = true;
            this.modaleliminarModulo.Disabled = true;
            // this.btnAgregarSprint.Disabled = true;
            //this.btnModificarSprint.Disabled = true;
            //this.btnEliminarSprint.Disabled = true;
        }
        protected void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), idSprints.ToString(), idProyecto.ToString());
            this.txtNombreModulo.Value = entidadM.Nombre;
            this.txtDescripcionModulo.Value = entidadM.Descripcion;
        }
        private void llenarCmbModulo(int idSprint)
        {
            cmbModulo.DataSource = controladora.getNombresModulo(idSprint);
            cmbModulo.DataTextField = "Nombre";
            cmbModulo.DataValueField = "Identificador";
            cmbModulo.DataBind();
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), idSprints.ToString(), idProyecto.ToString());
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch { }

            if (cmbModulo.Text == "")
            {
                this.btnModificarModulo.Disabled = true;
                this.modaleliminarModulo.Disabled = true;
                this.txtNombreModulo.Value = "";
                this.txtDescripcionModulo.Value = "";
            }
        }
        protected void clickAceptarEliminarModulo(object sender, EventArgs e)
        {

            controladora.eliminarModulo(txtNombreModulo.Value.ToString(), idSprints.ToString(), idProyecto.ToString());
            //gridSprints.DataSource = getSprints(idProyecto);
            //gridSprints.DataBind();
            llenarCmbModulo(idSprints);
            mostrarMensaje("success", "Éxito", "Módulo eliminado correctamente");
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), idSprints.ToString(), idProyecto.ToString());
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch (Exception a)
            {

            }
        }
        protected void ocultarMensaje()
        {
            alertAlerta.Attributes.Add("hidden", "hidden");
        }

        //Muestra mensaje de exito o error.
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }
        protected void btnAceptar2(object sender, EventArgs e)
        {

            if (modoM == 1)
            {
                controladora.insertarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), idSprints.ToString(), idProyecto.ToString());
                //gridSprints.DataSource = getSprints(idProyecto);
                //gridSprints.DataBind();
                llenarCmbModulo(idSprints);
                mostrarMensaje("success", "Éxito", "Módulo ingresado correctamente");
            }
            if (modoM == 2)
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), idSprints.ToString(), idProyecto.ToString());
                controladora.modificarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), idSprints.ToString(), idProyecto.ToString(), entidadM);
                //gridSprints.DataSource = getSprints(idProyecto);
                //gridSprints.DataBind();
                llenarCmbModulo(idSprints);
                mostrarMensaje("success", "Éxito", "Módulo modificado correctamente");
            }
            //this.btnAceptarS.Disabled = false;
            //this.btnCancelarS.Disabled = false;
            this.txtNombreModulo.Disabled = true;
            this.txtDescripcionModulo.Disabled = true;
            this.btnModificarModulo.Disabled = false;
            this.btnAgregarModulo.Disabled = false;
            this.modaleliminarModulo.Disabled = false;
            //this.btnAgregarSprint.Disabled = false;
            //this.btnModificarSprint.Disabled = false;
           // this.btnEliminarSprint.Disabled = false;
            //this.btnAceptarS.Disabled = true;
            //this.btnCancelarS.Disabled = true;
            this.btnAceptarM.Disabled = true;
            this.btnCancelarM.Disabled = true;
        }

        //Al presionar el boton Cancelar limpia los campos y vuelve a restaurar los valores que tenian previamente (modulos)
        protected void btnCancelar2(object sender, EventArgs e)
        {
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), idSprints.ToString(), idProyecto.ToString());
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch { }
            this.txtNombreModulo.Disabled = true;
            this.txtDescripcionModulo.Disabled = true;
            this.btnModificarModulo.Disabled = false;
            this.btnAgregarModulo.Disabled = false;
            this.modaleliminarModulo.Disabled = false;
            //this.btnAgregarSprint.Disabled = false;
            //this.btnModificarSprint.Disabled = false;
            //this.btnEliminarSprint.Disabled = false;
            this.btnAceptarM.Disabled = true;
            this.btnCancelarM.Disabled = true;

        }
    }
}