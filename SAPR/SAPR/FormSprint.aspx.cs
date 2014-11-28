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

        //Este metodo se encarga de inicializar el comboBox de sprints, además de deshabilitar y habilitar botones 
        protected void Page_Load(object sender, EventArgs e)
        {
            NombreProyecto = FormularioEstructura.NombreProyecto;
            IdProyecto = FormularioEstructura.idProyecto;
            if (!IsPostBack)
            {
                this.txtNombreSprint.Disabled = true;
                this.txtDescripcionSprint.Disabled = true;
                llenarCmbSprint();
                try
                {
                    entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
                    this.txtNombreSprint.Value = entidadS.Nombre;
                    this.txtDescripcionSprint.Value = entidadS.Descripcion;
                }
                catch (Exception a)
                {

                }
     
                this.btnAceptarS.Disabled = true;
                this.btnCancelarS.Disabled = true;
            }
        }
        //Habilita los campos que se requieren para insertar los botones y desabilita otros
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

        //Controla el despliegue de los elementos de la interfaz al presionar el boton modificar (sprint)
        protected void btnModificarSprint_Click(object sender, EventArgs e)
        {

            this.txtNombreSprint.Disabled = false;
            this.txtDescripcionSprint.Disabled = false;
            modoS = 2;
            this.btnAceptarS.Disabled = false;
            this.btnCancelarS.Disabled = false;
            this.btnAgregarSprint.Disabled = true;
            this.btnEliminarSprint.Disabled = true;
        }

        //Actualiza el comboBox de los modulos de acuerdo al sprint seleccionado y los campos de nombre y descripción
        protected void cmbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
            this.txtNombreSprint.Value = entidadS.Nombre;
            this.txtDescripcionSprint.Value = entidadS.Descripcion;
        }

        //Al presionar el boton Aceptar valora los casos si esta insertando o modificando y hace las acciones respectivas en cada caso (sprints)
        protected void btnAceptar1(object sender, EventArgs e)
        {


            if (modoS == 1)
            {
                controladora.insertarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), NombreProyecto);
                mostrarMensaje("success", "Éxito", "Sprint ingresado correctamente");
            }
            if (modoS == 2)
            {
                controladora.modificarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), NombreProyecto, entidadS);
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
            llenarCmbSprint();
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
            this.btnAceptarS.Disabled = true;
            this.btnCancelarS.Disabled = true;
        }

        //Ocultar el mensaje de exito o error.
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

        //Llena en combobox con los sprints, habilita y desabilita los botones y campos necesarios.
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
            }

        }

        //Controla el despliegue de los elementos de la interfaz al presionar el boton eliminar (sprint)
        protected void clickAceptarEliminarSprint(object sender, EventArgs e)
        {

            controladora.eliminarSprint(txtNombreSprint.Value.ToString(), NombreProyecto);
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