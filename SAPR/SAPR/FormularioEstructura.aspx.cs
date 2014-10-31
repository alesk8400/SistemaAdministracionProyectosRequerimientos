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
         private static DataTable getModulo()  // pruebilla
         {

             return controladora.getSprints();
         }

         protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 GridView gridModulo = e.Row.FindControl("gridModulos") as GridView;
                 gridModulo.DataSource = getModulo();
                 gridModulo.DataBind();
             }
         }


         protected void OnRowDataBound2(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 GridView gridModulo = e.Row.FindControl("gridReq") as GridView;
                 gridModulo.DataSource = getModulo();
                 gridModulo.DataBind();
             }
         }









    }












}