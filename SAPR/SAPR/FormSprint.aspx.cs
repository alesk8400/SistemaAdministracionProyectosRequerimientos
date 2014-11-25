using SAPR.App_Code.Controladoras;
using SAPR.App_Code.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SAPR
{
    public partial class FormSprint : System.Web.UI.Page
    {
        private static int modoS = 0;
        private static EntidadSprint entidadS;
        private static ControladoraEstructura controladora = new ControladoraEstructura();
        int IdProyecto = 0;
        String NombreProyecto;
        protected void Page_Load(object sender, EventArgs e)
        {
            NombreProyecto = FormularioEstructura.NombreProyecto;
            IdProyecto = FormularioEstructura.idProyecto;
            if (!IsPostBack)
            {
                this.txtNombreSprint.Disabled = true;
                this.txtDescripcionSprint.Disabled = true;
                try
                {
                    entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
                    this.txtNombreSprint.Value = entidadS.Nombre;
                    this.txtDescripcionSprint.Value = entidadS.Descripcion;
                }
                catch (Exception a)
                {

                }
                llenarCmbSprint();
                this.btnAceptarS.Disabled = true;
                this.btnCancelarS.Disabled = true;
            }
        }
        protected void btnAgregarSprint_Click(object sender, EventArgs e)
        {
            this.txtNombreSprint.Disabled = false;
            this.txtDescripcionSprint.Disabled = false;
            modoS = 1;
            this.btnAceptarS.Disabled = false;
            this.btnCancelarS.Disabled = false;
            this.txtNombreSprint.Value = "";
            this.txtDescripcionSprint.Value = "";
            this.btnAgregarSprint.Disabled = true;
            this.btnModificarSprint.Disabled = true;
            this.btnEliminarSprint.Disabled = true;

        }
        protected void btnModificarSprint_Click(object sender, EventArgs e)
        {

            this.txtNombreSprint.Disabled = false;
            this.txtDescripcionSprint.Disabled = false;
            modoS = 2;
            this.btnAceptarS.Disabled = false;
            this.btnCancelarS.Disabled = false;
            this.btnAgregarSprint.Disabled = true;
            this.btnEliminarSprint.Disabled = true;
            //this.btnModificarModulo.Disabled = true;
            //this.btnAgregarModulo.Disabled = true;
           // this.modaleliminarModulo.Disabled = true;
        }
        protected void cmbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
            //llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
            this.txtNombreSprint.Value = entidadS.Nombre;
            this.txtDescripcionSprint.Value = entidadS.Descripcion;
        }
        protected void btnAceptar1(object sender, EventArgs e)
        {


            if (modoS == 1)
            {
                controladora.insertarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), NombreProyecto);
                //gridSprints.DataSource = getSprints(idProyecto);
                //gridSprints.DataBind();
                mostrarMensaje("success", "Éxito", "Sprint ingresado correctamente");
            }
            if (modoS == 2)
            {
                controladora.modificarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), NombreProyecto, entidadS);
                //gridSprints.DataSource = getSprints(idProyecto);
                //gridSprints.DataBind();
                this.txtNombreSprint.Disabled = true;
                this.txtDescripcionSprint.Disabled = true;
                mostrarMensaje("success", "Éxito", "Sprint modificado correctamente");
            }
            llenarCmbSprint();
            this.btnAceptarS.Disabled = true;
            this.btnCancelarS.Disabled = true;
            this.txtNombreSprint.Disabled = true;
            this.txtDescripcionSprint.Disabled = true;
            this.btnAgregarSprint.Disabled = false;
            this.btnModificarSprint.Disabled = false;
            this.btnEliminarSprint.Disabled = false;
            int idSprint = controladora.getIdSprint(txtNombreSprint.Value.ToString(), NombreProyecto);
            this.cmbSprints.Text = idSprint.ToString();
            //this.btnAgregarModulo.Disabled = false;
            llenarCmbSprint();
        }


        //Al presionar el boton Cancelar limpia los campos y vuelve a restaurar los valores que tenian previamente (sprints)
        protected void btnCancelar1(object sender, EventArgs e)
        {
            try
            {
                entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
                this.txtNombreSprint.Value = entidadS.Nombre;
                this.txtDescripcionSprint.Value = entidadS.Descripcion;
            }
            catch { }

            this.txtNombreSprint.Disabled = true;
            this.txtDescripcionSprint.Disabled = true;
            this.btnAgregarSprint.Disabled = false;
            this.btnModificarSprint.Disabled = false;
            this.btnEliminarSprint.Disabled = false;
           // this.btnModificarModulo.Disabled = false;
            //this.btnAgregarModulo.Disabled = false;
            //this.modaleliminarModulo.Disabled = false;
            this.btnAceptarS.Disabled = true;
            this.btnCancelarS.Disabled = true;
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
        private void llenarCmbSprint()
        {
            cmbSprints.DataSource = controladora.getNombresSprint(IdProyecto);
            cmbSprints.DataTextField = "Nombre";
            cmbSprints.DataValueField = "Identificador";
            cmbSprints.DataBind();
            if (cmbSprints.Text == "")
            {
                this.btnModificarSprint.Disabled = true;
                this.btnEliminarSprint.Disabled = true;
                this.txtNombreSprint.Value = "";
                this.txtDescripcionSprint.Value = "";
               // this.btnAgregarModulo.Disabled = true;
                //this.btnModificarModulo.Disabled = true;
                //this.modaleliminarModulo.Disabled = true;
                //this.txtNombreModulo.Value = "";
                //this.txtDescripcionModulo.Value = "";
            }

        }
        protected void clickAceptarEliminarSprint(object sender, EventArgs e)
        {

            controladora.eliminarSprint(txtNombreSprint.Value.ToString(), NombreProyecto);
           // gridSprints.DataSource = getSprints(idProyecto);
            //gridSprints.DataBind();
            llenarCmbSprint();
            mostrarMensaje("success", "Éxito", "Sprint eliminado correctamente");
            this.txtNombreSprint.Value = "";
            this.txtDescripcionSprint.Value = "";
            try
            {
                entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
                this.txtNombreSprint.Value = entidadS.Nombre;
                this.txtDescripcionSprint.Value = entidadS.Descripcion;
            }
            catch (Exception a)
            {

            }
        }
    }
}