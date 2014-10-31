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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                gridSprints.DataSource = getSprints();
                gridSprints.DataBind();
            }
        }

         private static DataTable getSprints (){

             return controladora.getSprints();
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
                 //GridView gridModulo = e.Row.FindControl("gridModulos") as GridView;  //Obtengo el gridModulos
                 string moduloId = e.Row.Cells[1].Text.ToString();
                 GridView gridRequerimientos = e.Row.FindControl("gridReq") as GridView;
                 //gridRequerimientos.DataSource = getRequerimiento(1);
                 gridRequerimientos.DataSource = getRequerimiento(Convert.ToInt32(moduloId));
                 gridRequerimientos.DataBind();
             }
         }











    }












}