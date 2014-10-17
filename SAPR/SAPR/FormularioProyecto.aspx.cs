using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPR.App_Code.Controladoras;
using SAPR.App_Code.Entidades;
using System.Data;

namespace SAPR
{
    public partial class FormularioProyecto : System.Web.UI.Page
    {
        private static EntidadProyecto entidadConsultada;
        private static ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
        private static ControladoraProyecto controladora = new ControladoraProyecto();
        private static Object[] idsGrid;
        protected void Page_Load(object sender, EventArgs e)
        {
                if(!IsPostBack){
                    llenarGridUsuarios(1);
                }
            
        }

        protected void botonEliminarClic(object sender, EventArgs e)
        {
            //limpiarCampos();
            // modo = 1;
            //irAModo();
            // String fechaFin, String fechaInic, String estado, int lider
            controladora.eliminarProyecto(entidadConsultada.Nombre);
            gridProyecto.DataBind();
        }


        protected void llenarGridUsuarios(int modo)
        {
            DataTable tabla = crearTablaUsuarios(); // se crea la tabla
            int i = 0;
            Object[] datos = new Object[2];
            //if (!(((SiteMaster)Page.Master).UsuarioLogueado).Equals("")) {

                
                try
                {

                    DataTable usuariosDisponibles = controladora.getUsuariosDisponibles();// se consultan todos los proveedores
                    idsGrid = new Object[usuariosDisponibles.Rows.Count]; //crear el vector para ids de proveedores en el grid
                    if (usuariosDisponibles.Rows.Count > 0)
                    {
                        foreach (DataRow fila in usuariosDisponibles.Rows)
                        {
                            idsGrid[i] = fila[0].ToString();// guardar el id del proveedor para su posterior consulta
                            datos[0] = fila[0].ToString();//obtener los datos a mostrar
                            datos[1] = fila[1].ToString();

                            tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                            i++;
                        }
                    }
                    else // en cualquier otro caso se pone vacía la tabla
                    {
                        datos[0] = "-";
                        datos[1] = "-";
                        tabla.Rows.Add(datos);
                    }


                    this.gridUsuarios.DataSource = tabla; // se colocan los datos en la tabla
                    this.gridUsuarios.DataBind();

                }
                catch (Exception e)
                {

                }

                if (modo == 2){  // CASO DE QUE SE MODIFIQUE
                    DataTable usuariosDisponibles = controladora.getUsuariosProyecto();
            
                        
                }
            //}
        }


        protected DataTable crearTablaUsuarios()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            //se agrega el campo de nombre
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Cédula";
            tabla.Columns.Add(columna);

            //se agrega el campo de Telefono
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);


            return tabla;
        }




        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (entidadConsultada == null) {
                    //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", "ASJIHD");
                
                }
                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[1].Text.ToString());
                textNombre.Value = entidadConsultada.Nombre.ToString();
                textObjetivo.Value = entidadConsultada.Objetivos.ToString();
                textFechaA.Value = entidadConsultada.FechaAsig.ToString();
                textFechaF.Value = entidadConsultada.FechaFin.ToString();
                textFechaI.Value = entidadConsultada.FechaIni.ToString();
                cmbEstado.SelectedValue = entidadConsultada.Estado.ToString();
                //cmbNombreLider = controladoraUsuario.getNombre;


                //cmbEstado.SelectedIndex = 2;
                gridProyecto.DataBind();
            }
            catch { 
                
            }
        }

        protected void gridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
           //this.gridUsuarios.Columns[0].
        }

        protected void cbLider_CheckedChanged(object sender, EventArgs e)
        {
                 CheckBox chk = (CheckBox)sender;
            GridViewRow gv = (GridViewRow)chk.NamingContainer;
            int rownumber = gv.RowIndex;

            if (chk.Checked)
            {
                int i;
                for (i = 0; i <= gridUsuarios.Rows.Count - 1; i++)
                {
                    if (i != rownumber)
                    {
                        CheckBox chkcheckbox = ((CheckBox)(gridUsuarios.Rows[i].FindControl("cbLider")));
                        chkcheckbox.Checked = false;
                    }
                }
            }
        }
        

        protected void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 9;
                String[] r = new String[1];
                r = controladora.insertarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), "4 234 123");
                gridProyecto.DataBind();
            }
            catch (Exception jh) {
                int x = 9;
            }
        }



    }
}