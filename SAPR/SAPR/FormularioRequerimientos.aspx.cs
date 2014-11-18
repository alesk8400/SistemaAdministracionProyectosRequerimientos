using SAPR.App_Code.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SAPR
{
    public partial class FormularioRequerimientos : System.Web.UI.Page
    {

        ControladoraRequerimiento controladora = new ControladoraRequerimiento();
        private static int modo = 0;


        protected void Page_Load(object sender, EventArgs e) {
            

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

        protected void GridViewReque_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnAceptarR_Click(object sender, EventArgs e)
        {
            String[] resultado = new String[1];
            if(modo == 1){                
                resultado = controladora.insertarRequerimiento(65, "Salvar al mundo2", this.textNombreR.Value.ToString(), this.textD.Value.ToString(), Int32.Parse(this.cmbPrioridad.SelectedItem.ToString()), this.cmbEstado.SelectedItem.ToString(), Int32.Parse(this.txtCantidadR.Value.ToString()), this.cmbMedida.SelectedItem.ToString(), null);
            }

        }

        protected void btnAceptarC_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos(true);
            DataTable grid = controladora.getRequerimientosGrid();  // Falta que reciba el idProy
            gridRequerimientos.DataSource = grid;
            gridRequerimientos.DataBind();
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
    }
}