using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using SAPR.App_Code.Controladoras;
using SAPR.App_Code.Entidades;



namespace SAPR
{
    public partial class Contact : Page
    {

        private static ControladoraEstructura controladora = new ControladoraEstructura();
        private static EntidadSprint entidadS;
        private static EntidadModulo entidadM;
        private static int idProyecto = 0;
        private static int modoS = 0;  //modo 1 in modo 2 mod modo 3 eli
        private static int modoM = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                llenarCmbProy();
                if(cmbProyecto.Text==""){
                    btnAgregarSprint.Disabled = true;
                } else{
                    btnAgregarSprint.Disabled = false;
                }
                try {
                    idProyecto = Convert.ToInt32(cmbProyecto.SelectedItem.Value.ToString());
                }
                catch { }
                
                llenarCmbSprint();
                gridSprints.DataSource = getSprints(idProyecto);
                gridSprints.DataBind();
                this.txtNombreSprint.Disabled = true;
                this.txtDescripcionSprint.Disabled = true;
                try{
                    entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                    this.txtNombreSprint.Value = entidadS.Nombre;
                    this.txtDescripcionSprint.Value = entidadS.Descripcion;
                    entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                    this.txtNombreModulo.Value = entidadM.Nombre;
                    this.txtDescripcionModulo.Value = entidadM.Descripcion;
                }
                catch (Exception a) { 
                
                }               
                this.txtNombreModulo.Disabled = true;
                this.txtDescripcionModulo.Disabled = true;
                this.btnAceptarS.Disabled = true;
                this.btnCancelarS.Disabled = true;
                this.btnAceptarM.Disabled = true;
                this.btnCancelarM.Disabled = true;
            }
        }

         private static DataTable getSprints (int proyecto){

             return controladora.getSprints(proyecto);
         }
         private static DataTable getModulo(int sprintId)  // pruebilla
         {

             return controladora.getModulo(sprintId);
         }

         private static DataTable getRequerimiento(int moduloId)  // pruebilla
         {

             return controladora.getRequerimientos(moduloId);
         }

        //Método para cargar el grid de Modulos 
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 string sprintId = gridSprints.DataKeys[e.Row.RowIndex].Value.ToString();
                 GridView gridModulo = e.Row.FindControl("gridModulos") as GridView;
                 gridModulo.DataSource = getModulo(Convert.ToInt32(sprintId));
                 gridModulo.DataBind();
             }
         }

        //Método para cargar el grid de Requerimientos
         protected void OnRowDataBound2(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 string moduloId = e.Row.Cells[1].Text.ToString();
                 GridView gridRequerimientos = e.Row.FindControl("gridReq") as GridView;
                 gridRequerimientos.DataSource = getRequerimiento(Convert.ToInt32(moduloId));
                 gridRequerimientos.DataBind();
             }
         }



         private void llenarCmbProy() {
            cmbProyecto.DataSource = controladora.getNombresProyectos();
            cmbProyecto.DataTextField = "Nombre";
            cmbProyecto.DataValueField = "idProyecto";
            cmbProyecto.DataBind();
         }

         private void llenarCmbSprint()
         {
             cmbSprints.DataSource = controladora.getNombresSprint(idProyecto);
             cmbSprints.DataTextField = "Nombre";
             cmbSprints.DataValueField = "idSprint";
             cmbSprints.DataBind();
             if (cmbSprints.Text == "")
             {
                 this.btnModificarSprint.Disabled = true;
                 this.btnEliminarSprint.Disabled = true;
                 this.txtNombreSprint.Value = "";
                 this.txtDescripcionSprint.Value = "";
                 this.btnAgregarModulo.Disabled = true;
                 this.btnModificarModulo.Disabled = true;
                 this.modaleliminarModulo.Disabled = true;
                 this.txtNombreModulo.Value = "";
                 this.txtDescripcionModulo.Value = "";
             }
             try
             {
                 llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
                
             }
             catch { }
             if (cmbSprints.Text == "")
             {
                 this.cmbModulo.Items.Clear();
             }
             
         }



         protected void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
         {
             idProyecto = Convert.ToInt32(cmbProyecto.SelectedItem.Value.ToString());
             gridSprints.DataSource = getSprints(idProyecto);
             gridSprints.DataBind();
             llenarCmbSprint();

         }

         protected void cmbSprints_SelectedIndexChanged(object sender, EventArgs e)
         {
             entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
             llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));         
             this.txtNombreSprint.Value = entidadS.Nombre;
             this.txtDescripcionSprint.Value = entidadS.Descripcion;
         }


         private void llenarCmbModulo(int idSprint)
         {
             cmbModulo.DataSource = controladora.getNombresModulo(idSprint);
             cmbModulo.DataTextField = "Nombre";
             cmbModulo.DataValueField = "idModulo";
             cmbModulo.DataBind();
             entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
             this.txtNombreModulo.Value = entidadM.Nombre;
             this.txtDescripcionModulo.Value = entidadM.Descripcion;
             if (cmbModulo.Text == "")
             {
                 this.btnModificarModulo.Disabled = true;
                 this.modaleliminarModulo.Disabled = true;
                 this.txtNombreModulo.Value = "";
                 this.txtDescripcionModulo.Value = "";
             }
         }
         protected void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
         {
             entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
             this.txtNombreModulo.Value = entidadM.Nombre;
             this.txtDescripcionModulo.Value = entidadM.Descripcion;
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
             this.btnModificarModulo.Disabled = true;
             this.btnAgregarModulo.Disabled = true;
             this.modaleliminarModulo.Disabled = true;
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
             this.btnModificarModulo.Disabled = true;
             this.btnAgregarModulo.Disabled = true;
             this.modaleliminarModulo.Disabled = true;
         }

         protected void clickAceptarEliminarSprint(object sender, EventArgs e)
         {

             controladora.eliminarSprint(txtNombreSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString());
             gridSprints.DataSource = getSprints(idProyecto);
             gridSprints.DataBind();
             llenarCmbSprint();
             mostrarMensaje("success", "Éxito", "Sprint eliminado correctamente");
             this.txtNombreSprint.Value = "";
             this.txtDescripcionSprint.Value = "";
             try
             {
                 entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                 this.txtNombreSprint.Value = entidadS.Nombre;
                 this.txtDescripcionSprint.Value = entidadS.Descripcion;
             }
             catch (Exception a)
             {

             } 
         }

         protected void btnAceptar1(object sender, EventArgs e){
             

             if(modoS == 1){
                 controladora.insertarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString());
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
                 mostrarMensaje("success", "Éxito", "Sprint ingresado correctamente");
             }
             if (modoS == 2)
             {
                 controladora.modificarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString(),entidadS);              
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
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
             int idSprint = controladora.getIdSprint(txtNombreSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString());
             this.cmbSprints.Text = idSprint.ToString();
             this.btnAgregarModulo.Disabled = false;
             if(cmbModulo.Text !=""){
                 this.btnModificarModulo.Disabled = false;
                 this.modaleliminarModulo.Disabled = false;
             }
             llenarCmbSprint();
         }



         protected void btnCancelar1(object sender, EventArgs e)
         {             
                 entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                 this.txtNombreSprint.Value = entidadS.Nombre;
                 this.txtDescripcionSprint.Value = entidadS.Descripcion;
                 this.txtNombreSprint.Disabled = true;
                 this.txtDescripcionSprint.Disabled = true;
                 this.btnAgregarSprint.Disabled = false;
                 this.btnModificarSprint.Disabled = false;
                 this.btnEliminarSprint.Disabled = false;
                 this.btnModificarModulo.Disabled = false;
                 this.btnAgregarModulo.Disabled = false;
                 this.modaleliminarModulo.Disabled = false;
                 this.btnAceptarS.Disabled = true;
                 this.btnCancelarS.Disabled = true;
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
             this.btnAgregarSprint.Disabled = true;
             this.btnModificarSprint.Disabled = true;
             this.btnEliminarSprint.Disabled = true;
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
             this.btnAgregarSprint.Disabled = true;
             this.btnModificarSprint.Disabled = true;
             this.btnEliminarSprint.Disabled = true;
         }

         protected void clickAceptarEliminarModulo(object sender, EventArgs e)
         {

             controladora.eliminarModulo(txtNombreModulo.Value.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
             gridSprints.DataSource = getSprints(idProyecto);
             gridSprints.DataBind();
             llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
             mostrarMensaje("success", "Éxito", "Módulo eliminado correctamente");
             try
             {
                 entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                 this.txtNombreModulo.Value = entidadM.Nombre;
                 this.txtDescripcionModulo.Value = entidadM.Descripcion;
             }
             catch (Exception a)
             {

             } 
         }
         protected void btnAceptar2(object sender, EventArgs e)
         {

             if (modoM == 1)
             {
                 controladora.insertarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
                 llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
                 mostrarMensaje("success", "Éxito", "Módulo ingresado correctamente");
             }
             if (modoM == 2)
             {
                 entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                 controladora.modificarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString(), entidadM);
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
                 llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
                 mostrarMensaje("success", "Éxito", "Módulo modificado correctamente");
             }
             this.btnAceptarS.Disabled = false;
             this.btnCancelarS.Disabled = false;
             this.txtNombreModulo.Disabled = true;
             this.txtDescripcionModulo.Disabled = true;
             this.btnModificarModulo.Disabled = false;
             this.btnAgregarModulo.Disabled = false;
             this.modaleliminarModulo.Disabled = false;
             this.btnAgregarSprint.Disabled = false;
             this.btnModificarSprint.Disabled = false;
             this.btnEliminarSprint.Disabled = false;
             this.btnAceptarS.Disabled = true;
             this.btnCancelarS.Disabled = true;
             this.btnAceptarM.Disabled = true;
             this.btnCancelarM.Disabled = true;
         }

         protected void btnCancelar2(object sender, EventArgs e)
         {
             entidadM = controladora.consultarModulo(cmbModulo.SelectedItem.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
             this.txtNombreModulo.Value = entidadM.Nombre;
             this.txtDescripcionModulo.Value = entidadM.Descripcion;
             this.txtNombreModulo.Disabled = true;
             this.txtDescripcionModulo.Disabled = true;
             this.btnModificarModulo.Disabled = false;
             this.btnAgregarModulo.Disabled = false;
             this.modaleliminarModulo.Disabled = false;
             this.btnAgregarSprint.Disabled = false;
             this.btnModificarSprint.Disabled = false;
             this.btnEliminarSprint.Disabled = false;
             this.btnAceptarM.Disabled = true;
             this.btnCancelarM.Disabled = true;

         }
         /*
         * Ocultar el mensaje de exito o error.
         */
         protected void ocultarMensaje()
         {
             alertAlerta.Attributes.Add("hidden", "hidden");
         }

         /*
         * Muestra mensaje de exito o error.
         */
         protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
         {
             alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
             labelTipoAlerta.Text = alerta + " ";
             labelAlerta.Text = mensaje;
             alertAlerta.Attributes.Remove("hidden");
         }
    }
}