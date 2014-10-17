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
        private static ControladoraProyecto controladora = new ControladoraProyecto();
        private static Object[] idsGrid;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void botonAgregarClic(object sender, EventArgs e)
        {
            //limpiarCampos();
           // modo = 1;
            //irAModo();
            // String fechaFin, String fechaInic, String estado, int lider
            controladora.insertarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.textFechaA.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaI.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), "1 2345 678");
            gridProyecto.DataBind();
        }
        protected void botonEliminarClic(object sender, EventArgs e)
        {
            //limpiarCampos();
            // modo = 1;
            //irAModo();
            // String fechaFin, String fechaInic, String estado, int lider
            controladora.eliminarProyecto(entidadConsultada.Id);
            gridProyecto.DataBind();
        }


        protected void llenarGridUsuarios(int modo)
        {
            DataTable tabla = crearTablaUsuarios(); // se crea la tabla
            int indiceNuevoProveedor = -1;
            int i = 0;
            //if (!(((SiteMaster)Page.Master).UsuarioLogueado).Equals("")) {
            try
            {
                Object[] datos = new Object[2];
                DataTable usuariosDisponibles = controladora.getUsuariosDisponibles();// se consultan todos los proveedores
                idsGrid = new Object[usuariosDisponibles.Rows.Count]; //crear el vector para ids de proveedores en el grid
                if (usuariosDisponibles.Rows.Count > 0)
                {
                    foreach (DataRow fila in usuariosDisponibles.Rows)
                    {
                        idsGrid[i] = fila[0].ToString();// guardar el id del proveedor para su posterior consulta
                        datos[0] = fila[1].ToString();//obtener los datos a mostrar
                        datos[1] = fila[3].ToString();

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
                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[0].Text.ToString());
                textNombre.Value = entidadConsultada.Nombre.ToString();
                textObjetivo.Value = entidadConsultada.Objetivos.ToString();
                textFechaA.Value = entidadConsultada.FechaAsig.ToString();
                textFechaF.Value = entidadConsultada.FechaFin.ToString();
                textFechaI.Value = entidadConsultada.FechaIni.ToString();
                cmbEstado.SelectedValue = entidadConsultada.Estado.ToString();

                //cmbEstado.SelectedIndex = 2;
                gridProyecto.DataBind();
            }
            catch { 
                
            }
        }
    }
}