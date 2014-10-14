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
    public partial class FormularioProyecto : System.Web.UI.Page
    {
        private static EntidadProyecto entidadConsultada;
        private static ControladoraProyecto controladora = new ControladoraProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (entidadConsultada == null) {
                    //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", "ASJIHD");
                
                }
                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[0].Text.ToString());
                textNombre.Value = entidadConsultada.Nombre.ToString();
                textObjetivo.Value = entidadConsultada.Objetivos.ToString();
                textFechaA.Value = entidadConsultada.FechaAsig.ToString();
                textFechaF.Value = entidadConsultada.FechaFin.ToString();
                textFechaI.Value = entidadConsultada.FechaIni.ToString();
                int i = 0;


                //cmbEsta
               /* int selectedListItem = cmbEstado.Items.FindByValue(entidadConsultada.Estado);

                if (selectedListItem != null)
                {
                    selectedListItem.Selected = true;
                };
                    
                //FindString(entidadConsultada.Estado);

                while (i < 3) {
                    if (entidadConsultada.Estado.Equals(cmbEstado.Items[i].Text.ToString())) {
                        cmbEstado.SelectedIndex = i;
                    }
                    i++;
                } */

                //cmbEstado.SelectedIndex = 2;
                gridProyecto.DataBind();
            }
            catch { 
                
            }
        }
    }
}