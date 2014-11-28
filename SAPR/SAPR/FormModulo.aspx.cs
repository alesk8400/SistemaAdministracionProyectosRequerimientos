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
        private static int modoM = 0;
        private static int idSprints = 0;
        private static int IdProyecto = 0;
        private static String NombreProyecto;
        private static String NombreSprint;

        //Este metodo se encarga de inicializar el comboBox de sprints y módulos, además de deshabilitar y habilitar botones 
        protected void Page_Load(object sender, EventArgs e)
        {
            NombreProyecto = FormularioEstructura.NombreProyecto;
            IdProyecto = FormularioEstructura.idProyecto;
           
            if (!IsPostBack)
            {
                try
                {
                    llenarCmbSprint();
                    idSprints = Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString());
                    if (cmbSprints.SelectedItem.Text == "-")
                    {
                        this.btnAgregarModulo.Disabled = true;
                        this.btnModificarModulo.Disabled = true;
                        this.modaleliminarModulo.Disabled = true;
                        this.txtNombreModulo.Value = "";
                        this.txtDescripcionModulo.Value = "";
                    }
                    llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
                    entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), NombreProyecto);
                    this.txtNombreModulo.Value = entidadM.Nombre;
                    this.txtDescripcionModulo.Value = entidadM.Descripcion;
                }
                catch (Exception a)
                {

                }
                NombreSprint = cmbSprints.SelectedItem.Text;
                this.txtNombreModulo.Disabled = true;
                this.txtDescripcionModulo.Disabled = true;
                this.btnAceptarM.Disabled = true;
                this.btnCancelarM.Disabled = true;
                cmbModulo.DataBind();
            }
        }

        //Llena en combobox con los sprints con la consulta a la base de datos
        private void llenarCmbSprint()
        {
            cmbSprints.DataSource = controladora.getNombresSprint(IdProyecto);
            cmbSprints.DataTextField = "Nombre";
            cmbSprints.DataValueField = "Identificador";
            cmbSprints.DataBind();

        }

        //Controla el despliegue de los elementos de la interfaz al presionar el boton agregar (modulo)
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
        }

        //Controla el despliegue de los elementos de la interfaz al presionar el boton modificar (modulo)
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
        }

        //Actualiza los campos de nombre y descripcion de acuerdo al modulo seleccionado
        protected void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), NombreSprint, NombreProyecto);
            this.txtNombreModulo.Value = entidadM.Nombre;
            this.txtDescripcionModulo.Value = entidadM.Descripcion;
        }

        //Actualiza el comboBox de los modulos de acuerdo al sprint seleccionado y los campos de nombre y descripción
        protected void cmbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            NombreSprint = cmbSprints.SelectedItem.ToString();
            idSprints = Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString());
            controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), NombreProyecto);
            llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), NombreProyecto);
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch (Exception a)
            {

            }
            if (cmbModulo.Text == "")
            {
                this.btnModificarModulo.Disabled = true;
                this.modaleliminarModulo.Disabled = true;
                this.txtNombreModulo.Value = "";
                this.txtDescripcionModulo.Value = "";
            }else{
                this.btnModificarModulo.Disabled = false;
                this.modaleliminarModulo.Disabled = false;
            }
        }

        //Llena el comboBox de modulos
        private void llenarCmbModulo(int idSprint)
        {

            cmbModulo.DataSource = controladora.getNombresModulo(idSprint);
            cmbModulo.DataTextField = "Nombre";
            cmbModulo.DataValueField = "Identificador";
            cmbModulo.DataBind();


            if (cmbModulo.Text == "")
            {
                this.btnModificarModulo.Disabled = true;
                this.modaleliminarModulo.Disabled = true;
                this.txtNombreModulo.Value = "";
                this.txtDescripcionModulo.Value = "";
            }
        }

        //Controla el despliegue de los elementos de la interfaz al presionar el boton eliminar (modulo)
        protected void clickAceptarEliminarModulo(object sender, EventArgs e)
        {
            llenarCmbSprint();
            controladora.eliminarModulo(txtNombreModulo.Value.ToString(), NombreSprint, NombreProyecto);
            llenarCmbModulo(idSprints);          
            mostrarMensaje("success", "Éxito", "Módulo eliminado correctamente");
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), NombreSprint, NombreProyecto);
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch (Exception a)
            {

            }
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

        //Al presionar el boton Aceptar valora los casos si esta insertando o modificando y hace las acciones respectivas en cada caso (módulos)
        protected void btnAceptar2(object sender, EventArgs e)
        {

            if (modoM == 1)
            {
                controladora.insertarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), NombreSprint, NombreProyecto);
                llenarCmbModulo(idSprints);
                mostrarMensaje("success", "Éxito", "Módulo ingresado correctamente");         
            }
            if (modoM == 2)
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), NombreSprint, NombreProyecto);
                controladora.modificarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), NombreSprint, NombreProyecto, entidadM);
                llenarCmbModulo(idSprints);
                mostrarMensaje("success", "Éxito", "Módulo modificado correctamente");
            }
        
            this.txtNombreModulo.Disabled = true;
            this.txtDescripcionModulo.Disabled = true;
            this.btnModificarModulo.Disabled = false;
            this.btnAgregarModulo.Disabled = false;
            this.modaleliminarModulo.Disabled = false;         
            this.btnAceptarM.Disabled = true;
            this.btnCancelarM.Disabled = true;
            llenarCmbModulo(idSprints);
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), NombreSprint, NombreProyecto);
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch { }
          
        }

        //Al presionar el boton Cancelar limpia los campos y vuelve a restaurar los valores que tenian previamente (módulos)
        protected void btnCancelar2(object sender, EventArgs e)
        {
            try
            {
                entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), NombreSprint, NombreProyecto);
                this.txtNombreModulo.Value = entidadM.Nombre;
                this.txtDescripcionModulo.Value = entidadM.Descripcion;
            }
            catch { }
            this.txtNombreModulo.Disabled = true;
            this.txtDescripcionModulo.Disabled = true;
            this.btnModificarModulo.Disabled = false;
            this.btnAgregarModulo.Disabled = false;
            this.modaleliminarModulo.Disabled = false;
            this.btnAceptarM.Disabled = true;
            this.btnCancelarM.Disabled = true;

        }
    }
}