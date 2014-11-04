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
                idProyecto = Convert.ToInt32(cmbProyecto.SelectedItem.Value.ToString());
                llenarCmbSprint();
                gridSprints.DataSource = getSprints(idProyecto);
                gridSprints.DataBind();
                this.txtNombreSprint.Disabled = true;
                this.txtDescripcionSprint.Disabled = true;
                entidadS = controladora.consultarSprint(cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                this.txtNombreSprint.Value = entidadS.Nombre;
                this.txtDescripcionSprint.Value = entidadS.Descripcion;
                this.txtNombreModulo.Disabled = true;
                this.txtDescripcionModulo.Disabled = true;
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
             llenarCmbModulo(Convert.ToInt32(cmbSprints.SelectedItem.Value.ToString()));
             //string[] nombres = controladora.getProyectos();
             //cmbProyecto.DataSource = nombres;
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
         }

         protected void btnModificarSprint_Click(object sender, EventArgs e)
         {             
             
             this.txtNombreSprint.Disabled = false;
             this.txtDescripcionSprint.Disabled = false;
             modoS = 2;
         }

            protected void btnEliminarSprint_Click(object sender, EventArgs e)
         {
             
             modoS = 3;
         }
         protected void btnAceptar1(object sender, EventArgs e){
             

             if(modoS == 1){
                 controladora.insertarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString());
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
                 llenarCmbSprint();
             }
             if (modoS == 2)
             {
                 controladora.modificarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString(),entidadS);              
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
                 llenarCmbSprint();
             }
             if (modoS == 3)
             {
                 controladora.eliminarSprint(txtNombreSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString());
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
                 llenarCmbSprint();
             }
         }
         protected void btnAgregarModulo_Click(object sender, EventArgs e)
         {
             this.txtNombreModulo.Disabled = false;
             this.txtDescripcionModulo.Disabled = false;
             modoM = 1;
         }
         protected void btnModificarModulo_Click(object sender, EventArgs e)
         {

             modoM = 2;
         }

         protected void btnEliminarModulo_Click(object sender, EventArgs e)
         {

             modoM = 3;
         }
         protected void btnAceptar2(object sender, EventArgs e)
         {

             if (modoM == 1)
             {
                 controladora.insertarModulo(txtNombreModulo.Value.ToString(), txtDescripcionModulo.Value.ToString(), cmbSprints.SelectedItem.ToString(), cmbProyecto.SelectedItem.ToString());
                 gridSprints.DataSource = getSprints(idProyecto);
                 gridSprints.DataBind();
             }
             if (modoM == 2)
             {
                 //controladora.modificarSprint(txtNombreSprint.Value.ToString(), txtDescripcionSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString(), entidadS);
                 //gridSprints.DataSource = getSprints(idProyecto);
                 //gridSprints.DataBind();
             }
             if (modoM == 3)
             {
                 //controladora.eliminarSprint(txtNombreSprint.Value.ToString(), cmbProyecto.SelectedItem.ToString());
                 //gridSprints.DataSource = getSprints(idProyecto);
                 //gridSprints.DataBind();
             }
         }
    }












}