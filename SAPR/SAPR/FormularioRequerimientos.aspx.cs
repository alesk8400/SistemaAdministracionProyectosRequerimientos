using SAPR.App_Code.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using SAPR.App_Code.Entidades;

namespace SAPR
{
    public partial class FormularioRequerimientos : System.Web.UI.Page
    {

        ControladoraRequerimiento controladora = new ControladoraRequerimiento();
        private static int modo = 0;
        private static EntidadRequerimientos consultado; 

        protected void Page_Load(object sender, EventArgs e) {

            llenarCmbProy();
            if (modo != 1 && modo != 2)
            {
                restaurarPantallaSinLimpiar();
            }
        }

        protected void btnAgregarReque_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos(true);
            ///DataTable grid = controladora.getRequerimientosGrid();  // Falta que reciba el idProy
           // gridRequerimientos.DataSource = grid;
           // gridRequerimientos.DataBind();
        }

        protected void btnModificarReque_Click(object sender, EventArgs e)
        {
            modo = 2;
            habilitarCampos(true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void GridRequerimientos_SelectedIndexChanged(object sender, EventArgs e)  // consultar
        {
            consultado = controladora.getRequerimiento(Int32.Parse(gridRequerimientos.SelectedRow.Cells[1].Text.ToString()));
            int x = 9;

        }

        private void llenarCmbProy()
        {

            DataTable datos_proyecto = controladora.getNombresProyectos();
            cmbProyecto.DataSource = datos_proyecto;
            cmbProyecto.DataTextField = "Nombre";
            cmbProyecto.DataValueField = "idProyecto";
            cmbProyecto.DataBind();

        }

        protected void btnAceptarR_Click(object sender, EventArgs e)
        {
            String[] resultado = new String[1];
            if(modo == 1){                
               // resultado = controladora.insertarRequerimiento(65, "Salvar al mundo2", this.textNombreR.Value.ToString(), this.textD.Value.ToString(), Int32.Parse(this.cmbPrioridad.SelectedItem.ToString()), this.cmbEstado.SelectedItem.ToString(), Int32.Parse(this.txtCantidadR.Value.ToString()), this.cmbMedida.SelectedItem.ToString(), null);
            }

        }

        protected void btnAceptarC_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos(true);
           // DataTable grid = controladora.getRequerimientosGrid();  // Falta que reciba el idProy
           // gridRequerimientos.DataSource = grid;
         //   gridRequerimientos.DataBind();
        }

        protected void restaurarPantallaSinLimpiar()
        {
            habilitarCampos(false);
            botonAceptarR.Disabled = true;
            btnModificarReque.Disabled = true;
            btnEliminarReque.Disabled = true;
            botonCancelar.Disabled = true;
        }

        protected void habilitarCampos(Boolean habilitar)
        {
            this.textNombreR.Disabled = !habilitar;
            this.textD.Disabled = !habilitar;
            this.cmbPrioridad.Enabled = habilitar;
            this.cmbEstado.Enabled = habilitar;
            this.txtCantidadR.Disabled = !habilitar;
            this.cmbMedida.Enabled = habilitar;
            this.botonAceptarR.Disabled = !habilitar;
            this.botonCancelar.Disabled = !habilitar;
        }

        protected void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable datos_proyecto = controladora.getInfoProyecto(cmbProyecto.SelectedItem.ToString());
            gridProyecto.DataSource = datos_proyecto;
            gridProyecto.DataBind();
            DataTable datos_reque = controladora.getRequerimientosDeProyecto(Int32.Parse(cmbProyecto.SelectedItem.Value));
            gridRequerimientos.DataSource = datos_reque; // Cargar el grid de los requerimientos
            gridRequerimientos.DataBind();
        }
    }
}