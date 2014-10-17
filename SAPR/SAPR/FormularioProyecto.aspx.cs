﻿using System;
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
        private static EntidadCliente clienteConsultado;
        private static ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
        private static ControladoraProyecto controladora = new ControladoraProyecto();
        private static Object[] idsGrid;
        private static int modo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
                if(!IsPostBack){
                    llenarGridUsuarios(1);
                }
               // restaurarPantallaSinLimpiar();
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

                int idProy;
                idProy = controladora.getIdProyecto(entidadConsultada.Nombre.ToString());

                clienteConsultado = controladora.consultarCliente(idProy);
                textRepresentante.Value = clienteConsultado.Nombre.ToString();
                textTelRepresentante.Value = clienteConsultado.Telefono.ToString();
                textTelSecundario.Value = clienteConsultado.Celular.ToString();
                TextOficina.Value = clienteConsultado.Oficina.ToString();
                textEmailRepresentante.Value = clienteConsultado.Correo.ToString();
                btnModificarProyecto.Disabled = false;
                habilitarCampos(true);
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



        protected void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            modo = 1;
            limpiarCampos();
            habilitarCampos(true);
            botonAceptar.Disabled = false;
            botonCancelar.Disabled = false;


        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            String[] resultado = new String[1];
            String[] miembros = new String[gridUsuarios.Rows.Count];
            String cedulaLider = "";

            for (int i = 0; i < gridUsuarios.Rows.Count; i++)
            {
                GridViewRow row = gridUsuarios.Rows[i];
                bool estaSeleccionadoLider = ((CheckBox)row.FindControl("cbLider")).Checked;
                bool estaSeleccionadoMiembro = ((CheckBox)row.FindControl("cbMiembros")).Checked;

                if (estaSeleccionadoLider)
                {
                    cedulaLider = gridUsuarios.Rows[i].Cells[2].Text.ToString();
                }

                if (estaSeleccionadoMiembro)
                {
                    miembros[i] = gridUsuarios.Rows[i].Cells[2].Text.ToString();
                }

            }

            if (modo == 1) // si se quiere insertar
            {
                

                
                String[] r = new String[1];
                try
                {

                    
                    r = controladora.insertarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), cedulaLider,
                                                        this.textRepresentante.Value.ToString(), this.textTelRepresentante.Value.ToString(), this.textTelSecundario.Value.ToString(), this.TextOficina.Value.ToString(), this.textEmailRepresentante.Value.ToString());
                    
                }
                catch (Exception jh)
                {
                    int x = 9;
                }

                //FALTA LO DEL EXITO
            }
            else if (modo == 2)//si se quiere modificar
            {
                String[] result = controladora.modificarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), cedulaLider, entidadConsultada);
                
                
            }
            restaurarPantalla();
            gridProyecto.DataBind();
        }

        


    /*
     * METODOS INTERFAZ #####################################################################################################
     * */
        protected void limpiarCampos()
        {
               
                this.textNombre.Value = "";
                this.textObjetivo.Value = "";
                this.textFechaA.Value = "";
                this.textFechaF.Value = "";
                this.textFechaI.Value = "";
                this.textRepresentante.Value = "";
                this.textTelRepresentante.Value = "";
                this.textTelSecundario.Value = "";
                this.TextOficina.Value = "";
                this.textEmailRepresentante.Value = "";
        }

        protected void habilitarCampos(Boolean habilitar)
        {
            this.textNombre.Disabled = !habilitar;
            this.textObjetivo.Disabled = !habilitar;
            this.textFechaA.Disabled = !habilitar;
            this.textFechaF.Disabled = !habilitar;
            this.textFechaI.Disabled = !habilitar;
            this.textRepresentante.Disabled = !habilitar;
            this.textTelRepresentante.Disabled = !habilitar;
            this.textTelSecundario.Disabled = !habilitar;
            this.TextOficina.Disabled = !habilitar;
            this.textEmailRepresentante.Disabled = !habilitar;
            this.cmbEstado.Enabled = habilitar;
        }

        protected void restaurarPantalla()
        {
            habilitarCampos(false);
            btnAgregarProyecto.Disabled = false;
            btnModificarProyecto.Disabled = true;
            btnEliminarProyecto.Disabled = true;
            botonAceptar.Disabled = true;
            botonCancelar.Disabled = true;
            cmbEstado.Enabled = false;
            limpiarCampos();
        }

        protected void restaurarPantallaSinLimpiar()
        {
            habilitarCampos(false);
            btnAgregarProyecto.Disabled = false;
            btnModificarProyecto.Disabled = true;
            btnEliminarProyecto.Disabled = true;
            botonAceptar.Disabled = true;
            botonCancelar.Disabled = true;
        }



        protected void modificar_Click(object sender, EventArgs e)
        {
            this.textNombre.Disabled = false;
            this.textObjetivo.Disabled = false;
            this.textFechaA.Disabled = true;
            this.textFechaF.Disabled = false;
            this.textFechaI.Disabled = false;
            this.textRepresentante.Disabled = false;
            this.textTelRepresentante.Disabled = false;
            this.textTelSecundario.Disabled = false ;
            this.TextOficina.Disabled = false;
            this.textEmailRepresentante.Disabled = false;
            this.cmbEstado.Enabled =true;
            botonAceptar.Disabled = false;
            botonCancelar.Disabled = false;
            modo = 2;
        }

        protected void cbLider_CheckedChanged1(object sender, EventArgs e)
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


    }
}