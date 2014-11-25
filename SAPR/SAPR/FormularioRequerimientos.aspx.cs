using SAPR.App_Code.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using SAPR.App_Code.Entidades;

namespace SAPR
{
    public partial class FormularioRequerimientos : System.Web.UI.Page
    {

        ControladoraRequerimiento controladora = new ControladoraRequerimiento();
        private static int modo = 0;
        private static EntidadRequerimientos consultado;
        private static EntidadCriterio criterioConsultado; 
        private static int idProyecto = 0;
        private static int idRequerimiento = 0;
        private static int idCriterio = 0;

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack)
            {
                llenarCmbProy();
            }
            
            if (modo != 1 && modo != 2)
            {
                restaurarPantallaSinLimpiar();
            }
        }

        protected void btnAgregarReque_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCamposR(true);
            limpiarCamposR();
        }

        protected void btnModificarReque_Click(object sender, EventArgs e)
        {
            modo = 2;
            habilitarCamposR(true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void GridRequerimientos_SelectedIndexChanged(object sender, EventArgs e)  // consultar
        {
            idRequerimiento = Int32.Parse(gridRequerimientos.SelectedRow.Cells[4].Text.ToString());
            consultado = controladora.getRequerimiento(idRequerimiento);
            txtCantidadR.Value = consultado.Cantidad.ToString();
            textNombreR.Value = consultado.Nombre;
            textD.Value = consultado.Descripcion;
            cmbPrioridad.SelectedValue = consultado.Prioridad.ToString();
            cmbEstado.SelectedValue = consultado.Estado.ToString();
            cmbMedida.SelectedValue = consultado.Medida.ToString();
            //cmbSprint.SelectedValue = consultado.
            cmbModulo.SelectedValue = consultado.IdModulo.ToString();
            btnModificarReque.Disabled = false;
            btnEliminarReque.Disabled = false;
            DataTable criterios = controladora.getCriteriosDeRequerimiento(idRequerimiento);
            gridCriterios.DataSource = criterios;
            gridCriterios.DataBind();
        }

        private void llenarCmbProy()
        {
            //cmbProyecto.Items.Clear();
            DataTable datos_proyecto = controladora.getNombresProyectos();
            cmbProyecto.DataSource = datos_proyecto;
            cmbProyecto.DataTextField = "Nombre";
            cmbProyecto.DataValueField = "idProyecto";
            cmbProyecto.DataBind();

        }



        protected void btnAceptarC_Click(object sender, EventArgs e)
        {
            modo = 1;
            //habilitarCampos(true);
        }

        protected void restaurarPantallaSinLimpiar()
        {
            habilitarCamposR(false);
            botonAceptarR.Disabled = true;
            btnModificarReque.Disabled = true;
            btnEliminarReque.Disabled = true;
            botonCancelar.Disabled = true;
        }

        protected void habilitarCamposR(Boolean habilitar)
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
            idProyecto = Int32.Parse(cmbProyecto.SelectedValue.ToString());
            cmbSprint.DataSource = controladora.getNombresSprints(idProyecto);
            cmbSprint.DataValueField = "Identificador";
            cmbSprint.DataTextField = "Nombre";
            cmbSprint.DataBind();

        }

        protected void botonAceptarR_ServerClick(object sender, EventArgs e) {
            String[] resultado = new String[1];
            Stream strm;
            BinaryReader br;
            Byte[] filesize = null;
            if (subirArchivo.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(subirArchivo.PostedFile.FileName);
                    strm = subirArchivo.PostedFile.InputStream;
                    br = new BinaryReader(strm);
                    filesize = br.ReadBytes((int)strm.Length);
                    string filetype = subirArchivo.PostedFile.ContentType;

                }
                catch {
                }
            }
            int idModulo = Int32.Parse(cmbModulo.SelectedValue.ToString());
            int prioridad = Int32.Parse(cmbPrioridad.SelectedValue.ToString());
            int cantidad = Int32.Parse(txtCantidadR.Value.ToString());
            string estado = cmbEstado.SelectedValue.ToString();
            string medida = cmbMedida.SelectedValue.ToString();
            string nombre = textNombreR.Value.ToString();
            string descrip = textD.Value.ToString();
            if (modo == 1) {
                resultado = controladora.insertarRequerimiento(idModulo, idProyecto, nombre, descrip, prioridad, estado,cantidad, medida, filesize);             
            }
            if (modo == 2) {
                resultado = controladora.modificarRequerimiento(idModulo,idProyecto,nombre,descrip,prioridad,estado,cantidad,medida,filesize,consultado);
            }
            restaurarPantallaSinLimpiar();
            DataTable datos_reque = controladora.getRequerimientosDeProyecto(Int32.Parse(cmbProyecto.SelectedItem.Value));
            gridRequerimientos.DataSource = datos_reque; 
            gridRequerimientos.DataBind();

        }


        protected void cmbSprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSprint = Int32.Parse(cmbSprint.SelectedValue.ToString());
            cmbModulo.DataSource = controladora.getNombresModulos(idSprint);
            cmbModulo.DataValueField = "Identificador";
            cmbModulo.DataTextField = "Nombre";
            cmbModulo.DataBind();
        }

        protected void botonAceptarModalReque_ServerClick(object sender, EventArgs e){
            int idMod = Int32.Parse(cmbModulo.SelectedValue.ToString());
            string nombre = textNombreR.Value.ToString();
            //string resultado[];
            //resultado = controladora.eliminarRequerimiento(consultado.Nombre, idMod, idProyecto);
        }

        protected void limpiarCamposR() {
            this.textNombreR.Value = "";
            this.textD.Value = "";
            this.txtCantidadR.Value = "";
        }

        protected void gridCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCriterio = Int32.Parse(gridCriterios.SelectedRow.Cells[1].Text.ToString());
            criterioConsultado = controladora.getCriterio(idCriterio);
            this.nombreCriterio.Value = criterioConsultado.NombreCriterio;
            this.txtEscenario.Value = criterioConsultado.Escenario.ToString();
            this.txtContexto.Value = criterioConsultado.Contexto;
            this.txtRes.Value = criterioConsultado.Resultado;

        }
    }
}