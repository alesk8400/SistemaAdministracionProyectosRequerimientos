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
        private static int idProyecto = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                gridSprints.DataSource = getSprints(96);  // Toma todos........ Falta agregar eso
                gridSprints.DataBind();
                llenarCmbSprint();
                llenarCmbProy();
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
            this.Label1.Text = cmbProyecto.SelectedItem.Value.ToString();
         }

         private void llenarCmbSprint()
         {
             cmbSprints.DataSource = controladora.getNombresSprint(96);
             cmbSprints.DataTextField = "Nombre";
             cmbSprints.DataValueField = "idSprint";
             cmbSprints.DataBind();
             this.Label1.Text = cmbSprints.SelectedItem.Value.ToString();
             //string[] nombres = controladora.getProyectos();
             //cmbProyecto.DataSource = nombres;
         }


         public void combo(object sender, EventArgs e) {
             llenarCmbSprint();
         
         }

         protected void cmbSprints_SelectedIndexChanged(object sender, EventArgs e)
         {
             string hola = cmbSprints.SelectedItem.ToString();
             this.Label1.Text = hola;
         }

         protected void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
         {
             string hola  = cmbProyecto.SelectedItem.Value.ToString();
             idProyecto = Convert.ToInt32(cmbProyecto.SelectedItem.Value.ToString());
             this.Label1.Text = idProyecto.ToString();
             gridSprints.DataSource = getSprints(idProyecto);  // Toma todos........ Falta agregar eso
             gridSprints.DataBind();



         }


    }












}