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
    public partial class FormularioEstructura : System.Web.UI.Page
    {

        private static ControladoraEstructura controladora = new ControladoraEstructura();
        private static EntidadSprint entidadS;
        private static EntidadModulo entidadM;
        private static int modoS = 0;  //modo 1 in modo 2 mod modo 3 eli
        private static int modoM = 0;
        public static int idProyecto = 0;
        public static  String NombreProyecto = "";
        public static int idSprint = 0;

        //Este metodo se encarga de inicializar los comboBoxes del formulario, además de cargar el frid con los datos de sprints y modulos del proyecto seleccionado ademas de deshabilitar y habilitar botones 
        protected void Page_Load(object sender, EventArgs e)
        {

           if (!IsPostBack)
            {
                llenarCmbProy();

                if (cmbProyecto.SelectedItem.Text == "-"){
                    btnManejarS.Enabled = false;
                    btnManejarM.Enabled = false;
                    
                } else{
                    btnManejarS.Enabled = true;
                    btnManejarM.Enabled = true;
                   
                }
                try {
                    idProyecto = Convert.ToInt32(cmbProyecto.SelectedItem.Value.ToString());
                    NombreProyecto = cmbProyecto.SelectedItem.Text;
                }
                catch { }
                gridSprints.DataSource = getSprints(idProyecto);
                gridSprints.DataBind();              
            }
        }
        //Este metodo devuelve todos los ID de los sprints que pertenecen al proyecto que recibe como parametro
         private static DataTable getSprints (int proyecto){

             return controladora.getSprints(proyecto);
         }

         //Retorna los modulos de un sprint, recibe el id del sprint 
         private static DataTable getModulo(int sprintId)  
         {
             return controladora.getModulo(sprintId);
         }

         //Metodo Temporal que para tomar requerimientos y cargarlos (se borrara posteriormente)
         private static DataTable getRequerimiento(int moduloId)  
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
                 string moduloId = e.Row.Cells[3].Text.ToString();
                 GridView gridRequerimientos = e.Row.FindControl("gridReq") as GridView;
                 gridRequerimientos.DataSource = getRequerimiento(Convert.ToInt32(moduloId));
                 gridRequerimientos.DataBind();
             }
         }


        //Llena el comboBox de Proyectos
         private void llenarCmbProy() {
            cmbProyecto.DataSource = controladora.getNombresProyectos();
            cmbProyecto.DataTextField = "Nombre";
            cmbProyecto.DataValueField = "idProyecto";
            cmbProyecto.DataBind();
         }


        //Actualiza el grid con la informacion de proyecto seleccionado y el comboBox de los Sprints
         protected void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
         {
             idProyecto = Convert.ToInt32(cmbProyecto.SelectedItem.Value.ToString());
             gridSprints.DataSource = getSprints(idProyecto);
             gridSprints.DataBind();
             NombreProyecto = cmbProyecto.SelectedItem.Text;
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



         protected void gridSprints_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
         {
             //string tr = e.Row.Cells[3].Text.ToString();
         }
    }
}