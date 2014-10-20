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
        private static Object[] idAsignados;
        private static int idProy;
        private static String liderModificado;

        private static int modo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
                if(!IsPostBack){
                    llenarGridUsuarios();
                }

            if(modo != 1 && modo != 2){
                restaurarPantallaSinLimpiar();
            }
                
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


        // METODO PARA LLENAR LOS USUARIOS DISPONIBLES PARA EL AGREGAR O EL MODIFICAR
        protected void llenarGridUsuarios()
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

        }



        // METODO PARA LLENAR GRID DE USUARIOS ASIGNADOS PARA EL MODIFICAR
        public void llenarUsuariosAsignados() { 
                DataTable tablaAsignados = crearTablaUsuarios(); // se crea la tabla
                int i = 0;
                Object[] datos = new Object[2];         
                DataTable usuariosAsignados = controladora.getUsuariosAsignados(idProy);// se consultan todos los proveedores
                idAsignados = new Object[usuariosAsignados.Rows.Count]; //crear el vector para ids de proveedores en el grid
                    if (usuariosAsignados.Rows.Count > 0)
                    {
                        foreach (DataRow fila in usuariosAsignados.Rows)
                        {
                            idAsignados[i] = fila[0].ToString();// guardar el id del proveedor para su posterior consulta
                            datos[0] = fila[1].ToString();//obtener los datos a mostrar
                            datos[1] = fila[2].ToString();
                            tablaAsignados.Rows.Add(datos);
                            i++;
                        }
                    }
                    else // en cualquier otro caso se pone vacía la tabla
                    {
                        datos[0] = "-";
                        datos[1] = "-";
                        tablaAsignados.Rows.Add(datos);
                    }
                

                   this.gridUsuariosAsignados.DataSource = tablaAsignados; // se colocan los datos en la tabla
                   this.gridUsuariosAsignados.DataBind();
                   for (int t = 0; t < gridUsuariosAsignados.Rows.Count; t++)
                   {
                       CheckBox chkIndividual = (CheckBox)gridUsuariosAsignados.Rows[t].FindControl("cbMiembrosAsignados");
                       chkIndividual.Checked = true;
                       CheckBox chkLider = (CheckBox)gridUsuariosAsignados.Rows[t].FindControl("cbLiderAsignado");
                       String cedulaAux = gridUsuariosAsignados.Rows[t].Cells[2].Text.ToString();
                       if (entidadConsultada.Lider == cedulaAux) {
                           chkLider.Checked = true;
                        }
                    
            }    
        }


        // EVENTO que se activa al CONSULTAR un proyecto
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[1].Text.ToString());
                textNombre.Value = entidadConsultada.Nombre.ToString();
                textObjetivo.Value = entidadConsultada.Objetivos.ToString();
                textFechaA.Value = entidadConsultada.FechaAsig.ToString();
                textFechaF.Value = entidadConsultada.FechaFin.ToString();
                textFechaI.Value = entidadConsultada.FechaIni.ToString();
                cmbEstado.SelectedValue = entidadConsultada.Estado.ToString();

                idProy = controladora.getIdProyecto(entidadConsultada.Nombre.ToString());    // ESTAAAAAAAAAAAAAAAAAAAAAAAAAAAAATICO

                clienteConsultado = controladora.consultarCliente(idProy);
                textRepresentante.Value = clienteConsultado.Nombre.ToString();
                textTelRepresentante.Value = clienteConsultado.Telefono.ToString();
                textTelSecundario.Value = clienteConsultado.Celular.ToString();
                TextOficina.Value = clienteConsultado.Oficina.ToString();
                textEmailRepresentante.Value = clienteConsultado.Correo.ToString();
                btnModificarProyecto.Disabled = false;
                btnEliminarProyecto.Disabled = false;
                this.gridUsuariosAsignados.Visible = true;
               // habilitarCampos(true);
                gridProyecto.DataBind();
                llenarUsuariosAsignados();
                llenarGridUsuarios();
                }
                catch (Exception o){ 
                
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
            this.gridUsuariosAsignados.Visible = false;
            btnModificarProyecto.Disabled = true;
            btnEliminarProyecto.Disabled = true;
            this.gridProyecto.Enabled = false;
            btnAgregarProyecto.Disabled = true;

            
            
            for (int i = 0; i < gridUsuarios.Rows.Count; i++)
            {
                CheckBox chkIndividual = (CheckBox)gridUsuarios.Rows[i].FindControl("cbLider");
                chkIndividual.Enabled = true;
            }


        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // Parte para captar los miembros y el lider que se decidieron agregar al proyecto
            // ###################################################
            String[] resultado = new String[1];
            String[] miembros = new String[gridUsuarios.Rows.Count];
            String cedulaLider = "";
            String[] r = new String[1];
            int contador = 0;

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
                    String nuevoMiembro =gridUsuarios.Rows[i].Cells[2].Text.ToString() ;
                    miembros[contador] = nuevoMiembro;
                    contador++;
                }

            }
            //###################################################################

            if (modo == 1) // si se quiere insertar
            {  
            
                try
                {
                    r = controladora.insertarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), cedulaLider,
                                                        this.textRepresentante.Value.ToString(), this.textTelRepresentante.Value.ToString(), this.textTelSecundario.Value.ToString(), this.TextOficina.Value.ToString(), this.textEmailRepresentante.Value.ToString());
                    int k = 0;
                    int idP = 0;
                    while (gridUsuarios.Rows[k].Cells[2].Text != null){
                        idP = controladora.getIdProyecto(this.textNombre.Value.ToString());
                        controladora.insertarUsuarioProyecto(idP,miembros[k]);
                        k++;
                    }
                   // llenarGridUsuarios();
                }
                catch (Exception jh)
                {
                    int x = 9;
                }

                //FALTA LO DEL EXITO
            }
            else if (modo == 2)// MOOOOOOODIFICAR
            {

                // --------------------------Se llena con los Usuarios Originales (gridUsuariosAsignados)
                String[] miembrosOriginales = new String[gridUsuariosAsignados.Rows.Count];
                contador = 0;
                for (int i = 0; i < gridUsuariosAsignados.Rows.Count; i++)
                {
                    GridViewRow row = gridUsuariosAsignados.Rows[i];
                    bool estaSeleccionadoLider = ((CheckBox)row.FindControl("cbLiderAsignado")).Checked;
                    bool estaSeleccionadoMiembro = ((CheckBox)row.FindControl("cbMiembrosAsignados")).Checked;

                    if (estaSeleccionadoLider)
                    {
                        cedulaLider = gridUsuariosAsignados.Rows[i].Cells[2].Text.ToString();
                    }

                    if (estaSeleccionadoMiembro)
                    {
                        String nuevoMiembro = gridUsuariosAsignados.Rows[i].Cells[2].Text.ToString();
                        miembrosOriginales[contador] = nuevoMiembro;
                        contador++;
                    }

                }
               //--------------------------------------------------------------------------- 
                
                
                
                controladora.eliminarMiembros(idProy);  // Elimina los usuarios del proyecto perfecto
         
                int k = 0;

                for (int u = 0; u < gridUsuarios.Rows.Count && miembros[k] != null && miembros[k] != "-"; u++)  // Inserción de los nuevos miembros
                { 
                        controladora.insertarUsuarioProyecto(idProy, miembros[k]);
                        k++;
                }   

                k = 0;

                for (int u = 0; u < gridUsuariosAsignados.Rows.Count && miembrosOriginales[k] != null && miembrosOriginales[k] != "-"; u++)
                {
                    controladora.insertarUsuarioProyecto(idProy, miembrosOriginales[k]); // RE-Inserción de los miembros originales
                    k++;
                }
                    String[] result = controladora.modificarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), entidadConsultada.Lider, entidadConsultada);
                    llenarUsuariosAsignados();
            }

            if (r[0].Equals("Exito"))
            {
                modo = 0;
                restaurarPantalla();
                gridProyecto.DataBind();
                llenarGridUsuarios();
                this.gridUsuariosAsignados.Visible = false;
                this.gridProyecto.Enabled = true;
            }
            else {
                alertAlerta.Attributes["class"] = "alert alert-" + "PELIGRO" + " alert-dismissable fade in";
                labelTipoAlerta.Text = "" + " ";
                labelAlerta.Text ="¡Problema al insertar proyecto! Intente de nuevo.";
                alertAlerta.Attributes.Remove("hidden");
            }
           
            
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
                this.cmbEstado.Text = "Sin Iniciar";
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
            this.gridUsuarios.Enabled = habilitar;
            this.gridUsuariosAsignados.Enabled = habilitar;
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
            this.gridUsuarios.Enabled = true;
            this.gridUsuariosAsignados.Enabled = true;
            this.gridProyecto.Enabled = false;
            btnAgregarProyecto.Disabled = true;
            botonAceptar.Disabled = false;
            botonCancelar.Disabled = false;
            modo = 2;
            for (int i = 0; i < gridUsuarios.Rows.Count; i++)
            {
                CheckBox chkIndividual = (CheckBox)gridUsuarios.Rows[i].FindControl("cbLider");
                chkIndividual.Checked = false;
                chkIndividual.Enabled = false;
                chkIndividual = (CheckBox)gridUsuarios.Rows[i].FindControl("cbMiembros");
                chkIndividual.Checked = false;
            }


        }

        protected void cbLider_CheckedChanged1(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow gv = (GridViewRow)chk.NamingContainer;
            int rownumber = gv.RowIndex;

            if (chk.Checked)
            {
                try
                {
                    CheckBox chkIndividual = (CheckBox)gridUsuarios.Rows[rownumber].FindControl("cbMiembros");  // Checkea al lider de una vez
                    chkIndividual.Checked = true;
                }
                catch
                {

                }

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
            else {

                try
                {
                    CheckBox chkIndividual = (CheckBox)gridUsuarios.Rows[rownumber].FindControl("cbMiembros");
                    chkIndividual.Checked = false;
                }
                catch
                {

                }
            
            }
        }

        protected void clickAceptarEliminarProyecto(object sender, EventArgs e)
        {
            String[] result = new String[1];
            result = controladora.eliminarProyecto(entidadConsultada.Nombre);
            this.gridUsuariosAsignados.Visible = false;
            this.gridProyecto.Enabled = true;
            llenarGridUsuarios();
          //  mostrarMensaje(result[0], result[0], result[0]); // se muestra el resultado
           // if (result[0].Contains("Exito"))// si fue exitoso
            //{

                limpiarCampos();
                gridProyecto.DataBind();
           // }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (modo == 1)
            {
                limpiarCampos();
                this.gridUsuariosAsignados.Visible = false;
            }


            if (modo == 2)
            {
                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[1].Text.ToString());
                textNombre.Value = entidadConsultada.Nombre.ToString();
                textObjetivo.Value = entidadConsultada.Objetivos.ToString();
                textFechaA.Value = entidadConsultada.FechaAsig.ToString();
                textFechaF.Value = entidadConsultada.FechaFin.ToString();
                textFechaI.Value = entidadConsultada.FechaIni.ToString();
                cmbEstado.SelectedValue = entidadConsultada.Estado.ToString();

                
                idProy = controladora.getIdProyecto(entidadConsultada.Nombre.ToString());

                clienteConsultado = controladora.consultarCliente(idProy);
                textRepresentante.Value = clienteConsultado.Nombre.ToString();
                textTelRepresentante.Value = clienteConsultado.Telefono.ToString();
                textTelSecundario.Value = clienteConsultado.Celular.ToString();
                TextOficina.Value = clienteConsultado.Oficina.ToString();
                textEmailRepresentante.Value = clienteConsultado.Correo.ToString();
                btnModificarProyecto.Disabled = true;
                
                //cmbEstado.SelectedIndex = 2;
                gridProyecto.DataBind();
                this.gridUsuariosAsignados.Visible = true;

            }
            habilitarCampos(false);
            modo = 0;
            botonAceptar.Disabled = true;
            botonCancelar.Disabled = true;
            this.gridProyecto.Enabled = true;
            btnAgregarProyecto.Disabled = false;
         

        }




    }
}