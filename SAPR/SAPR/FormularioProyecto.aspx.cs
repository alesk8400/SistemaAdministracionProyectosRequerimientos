using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPR.App_Code.Controladoras;
using SAPR.App_Code.Entidades;
using System.Data;
using System.Web.UI.HtmlControls;

namespace SAPR
{
	/*
	*	Clase que maneja la interfaz de Proyecto, y se comunica con la controladora de la misma, como también la de Usuario.
	*/
    public partial class FormularioProyecto : System.Web.UI.Page
    {
        private static EntidadProyecto entidadConsultada; //Instancias de entidades consultadas estáticas.
        private static EntidadCliente clienteConsultado;
        private static ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
        private static ControladoraProyecto controladora = new ControladoraProyecto();
        private static Object[] idsGrid;
        private static Object[] idAsignados;
        private static int idProy; //Guarda de manera estática el id del proyecto consultado
        private static String liderModificado;
        private static int modo = 0; //Manejo de modo para categorizar si se está agregando,modificando,consultando o eliminando.
		
		
		/*
		* La carga de página la cual carga el Grid de Usuarios y restaura la página si está en modo consultar.
		*/
        protected void Page_Load(object sender, EventArgs e)
        {
                if(!IsPostBack){
                    llenarGridUsuarios();
                }

            if(modo != 1 && modo != 2){
                restaurarPantallaSinLimpiar();
            }


        }

		/*
		* Metodo que crea un datatable con columnas de Cédula y Nombre de usuarios.
		*/
        protected DataTable crearTablaUsuarios()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            //se agrega el campo de Cedula
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Cédula";
            tabla.Columns.Add(columna);

            //se agrega el campo de Nombre
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);
			
            return tabla;
        }


        /*
		*  Metodo para llenar los usuarios disponibles para el agregar o el modificar.
		*/		
        protected void llenarGridUsuarios()
        {
            DataTable tabla = crearTablaUsuarios(); // Se crea la tabla de Usuarios
            int i = 0; //Contador para moverse por el Grid
            Object[] datos = new Object[2];           
                try
                {
                    DataTable usuariosDisponibles = controladora.getUsuariosDisponibles();// Se obtienen usuarios disponibles
                    idsGrid = new Object[usuariosDisponibles.Rows.Count]; //Inicializa el vector de idsGrid
                    if (usuariosDisponibles.Rows.Count > 0)
                    {
                        foreach (DataRow fila in usuariosDisponibles.Rows)
                        {
                            idsGrid[i] = fila[0].ToString(); //Guarda cédulas de los usuarios
                            datos[0] = fila[0].ToString(); //Cedulas
                            datos[1] = fila[1].ToString(); //Nombres
                            tabla.Rows.Add(datos);// cargar en la tabla los datos de cada usuario
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
                    this.gridUsuarios.DataBind(); //Se actualiza la tabla

                }
                catch (Exception e)
                {

                }

        }



        /*	
		* Metodo para llenar el grid de usuarios asignados para el modificar.
		*/		
        public void llenarUsuariosAsignados() { 
                DataTable tablaAsignados = crearTablaUsuarios(); // Se crea la tabla
                int i = 0;
                Object[] datos = new Object[2];         
                DataTable usuariosAsignados = controladora.getUsuariosAsignados(idProy); //Se traen los usuarios asignados a ese proyecto consultado.
                idAsignados = new Object[usuariosAsignados.Rows.Count]; // Vector con cédulas de usuarios asignados.
                    if (usuariosAsignados.Rows.Count > 0)
                    {
                        foreach (DataRow fila in usuariosAsignados.Rows)
                        {
                            idAsignados[i] = fila[0].ToString(); //Guarda cedulas de usuarios asignados
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
                   this.gridUsuariosAsignados.DataBind(); //Actualiza tabla
				   
				   // Ciclo que carga los checkboxes con los usuarios que ya estan asignados.
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
      
		/*
		 * Evento que se activa al consultar un proyecto.
		*/
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String estado;
            try
            {
                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[0].Text.ToString());
                textNombre.Value = entidadConsultada.Nombre.ToString();
                textObjetivo.Value = entidadConsultada.Objetivos.ToString();
                textFechaA.Value = entidadConsultada.FechaAsig.ToString();
                textFechaF.Value = entidadConsultada.FechaFin.ToString();
                textFechaI.Value = entidadConsultada.FechaIni.ToString();
                cmbEstado.SelectedValue = entidadConsultada.Estado.ToString();
                estado = cmbEstado.SelectedValue;
                if (estado == "Finalizado")
                {
                    btnEliminarProyecto.Disabled = true;
                }
                else {
                    btnEliminarProyecto.Disabled = false;
                }
                idProy = controladora.getIdProyecto(entidadConsultada.Nombre.ToString()); //ID Estático

                clienteConsultado = controladora.consultarCliente(idProy);
                textRepresentante.Value = clienteConsultado.Nombre.ToString();
                textTelRepresentante.Value = clienteConsultado.Telefono.ToString();
                textTelSecundario.Value = clienteConsultado.Celular.ToString();
                TextOficina.Value = clienteConsultado.Oficina.ToString();
                textEmailRepresentante.Value = clienteConsultado.Correo.ToString();
                btnModificarProyecto.Disabled = false;
               
                this.gridUsuariosAsignados.Visible = true;
                gridProyecto.DataBind();
                llenarUsuariosAsignados();
                llenarGridUsuarios();
                }
                catch (Exception o){ 
                
            }

        }

		/*
		* Metodo que se activa al darle Click al AGREGAR en Proyecto
		*/
        protected void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            modo = 1; //Pasa a modo de inserción
            limpiarCampos(); //Limpia todos los campos de los textfields.
            habilitarCampos(true); //Habilita los campos en pantalla
            botonAceptar.Disabled = false; //Habilita el botón aceptar
            botonCancelar.Disabled = false; //Habilita boton cancelar
            this.gridUsuariosAsignados.Visible = false; //Desaparece el grid de usuarios asignados.
            btnModificarProyecto.Disabled = true; //Deshabilita boton de modificar proyecto.
            btnEliminarProyecto.Disabled = true; //Deshabilita boton de eliminar proyecto.
            this.gridProyecto.Enabled = false; //Deshabilita la selección de proyectos.
            btnAgregarProyecto.Disabled = true; //Deshabilita el botón de agregar, hasta que se cancele el proceso o se acepte.
			
			//Se habilitan los checkboxes de usuarios disponibles.
            for (int i = 0; i < gridUsuarios.Rows.Count; i++)
            {
                CheckBox chkIndividual = (CheckBox)gridUsuarios.Rows[i].FindControl("cbLider");
                chkIndividual.Enabled = true;
            }
        }
		
		/*
		* Metodo que se activa al darle click al Modificar en Proyecto. No se habilita la cédula (por ahora)
		*/
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
            modo = 2; //Pasa a modo modificación
			
			//En usuarios disponibles se deshabilita todo.
            for (int i = 0; i < gridUsuarios.Rows.Count; i++)
            {
                CheckBox chkIndividual = (CheckBox)gridUsuarios.Rows[i].FindControl("cbLider");
                chkIndividual.Checked = false;
                chkIndividual.Enabled = false;
                chkIndividual = (CheckBox)gridUsuarios.Rows[i].FindControl("cbMiembros");
                chkIndividual.Checked = false;
            }


        }
		
		/*
		* Metodo que se activa cuando se le da click a eliminar proyecto, es un Modal de eliminacion.
		*/
		protected void clickAceptarEliminarProyecto(object sender, EventArgs e)
        {
            String[] result = new String[1];
            result = controladora.eliminarProyecto(entidadConsultada.Nombre); //Habla con la controladora de proyecto para eliminar un proyecto, según su nombre.

            if (result[0] == "Exito") {
                mostrarMensaje("Success", "Éxito!!!", "El Proyecto fue eliminado correctamente");
                this.gridUsuariosAsignados.Visible = false;
                this.gridProyecto.Enabled = true;
                llenarGridUsuarios();
                limpiarCampos();
                gridProyecto.DataBind();
            }
            else if (result[0] == "Error") {
                mostrarMensaje("Danger", "Error", "Se produjo un error al intentar borrar el Proyecto");
            
            } 
    
        }

			/*
			* Metodo que se activa cuando se cancelan los cambios tanto en agregar como en modificar.
			*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (modo == 1) //En agregar, limpia los campos. 
            {
                limpiarCampos();
                this.gridUsuariosAsignados.Visible = false;
            }


            if (modo == 2) //En modificar, todo vuelve a su estado inicial de consulta.
            {
                entidadConsultada = controladora.consultarProyecto(gridProyecto.SelectedRow.Cells[0].Text.ToString());
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
                gridProyecto.DataBind();
                this.gridUsuariosAsignados.Visible = true;
                llenarGridUsuarios();
                llenarUsuariosAsignados();

            }
			
            habilitarCampos(false);
            modo = 0; //Se devuelve a modo consulta luego de cancelar.
            botonAceptar.Disabled = true;
            botonCancelar.Disabled = true;
            this.gridProyecto.Enabled = true;
            btnAgregarProyecto.Disabled = false;
         

        }


		/*
		* Metodo importante que toma decisiones después de aceptar un Agregar o un Modificar.
		*/
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
                    cedulaLider = gridUsuarios.Rows[i].Cells[2].Text.ToString(); //Obtiene cedula del lider marcado.
                }

                if (estaSeleccionadoMiembro)
                {
                    String nuevoMiembro =gridUsuarios.Rows[i].Cells[2].Text.ToString() ;
                    miembros[contador] = nuevoMiembro; //llena vector de usuarios que se asignan a proyecto
                    contador++;
                }

            }
            //###################################################################

            if (modo == 1) // Si se quiere agregar un proyecto
            {             
                try
                {
                    r = controladora.insertarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), cedulaLider,
                                                        this.textRepresentante.Value.ToString(), this.textTelRepresentante.Value.ToString(), this.textTelSecundario.Value.ToString(), this.TextOficina.Value.ToString(), this.textEmailRepresentante.Value.ToString());

                    if (r[0] == "Exito")
                    {
                        mostrarMensaje("success", "Éxito!!!", "El Proyecto fue insertado correctamente");
                        int k = 0;
                        int idP = 0;
                        while (gridUsuarios.Rows[k].Cells[2].Text != null)
                        { //Del grid de usuarios, agarra los marcados con Check, para insertarlos en su proyecto asignado.
                            idP = controladora.getIdProyecto(this.textNombre.Value.ToString());
                            controladora.insertarUsuarioProyecto(idP, miembros[k]);
                            k++;
                        }
                    }
                    else if (r[0] == "Error")
                    {
                        mostrarMensaje("danger", "Error", "El nombre de Proyecto seleccionado ya existe");
                        this.textNombre.Value = "";
                    }

                }
                catch (Exception jh)
                {}
            }
            else if (modo == 2) //Si se quiere modificar un proyecto.
            {

                if (cmbEstado.SelectedValue == "Cerrado")
                {
                   /* controladora.eliminarMiembros(idProy);
                    String[] result = controladora.modificarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), cedulaLider, entidadConsultada);


                    if (result[0] == "Exito")
                    {
                        mostrarMensaje("Success", "Éxito!!!", "El Proyecto fue modificado correctamente");
                        llenarUsuariosAsignados();
                    }
                    else if (result[0] == "Error")
                    {
                        mostrarMensaje("Danger", "Error", "El nombre de Proyecto seleccionado ya existe");
                    }*/
                }
                else {
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
                    String[] result = controladora.modificarProyecto(this.textNombre.Value.ToString(), this.textObjetivo.Value.ToString(), this.cmbEstado.SelectedItem.ToString(), this.textFechaI.Value.ToString(), this.textFechaF.Value.ToString(), this.textFechaA.Value.ToString(), cedulaLider, entidadConsultada);


                    if (result[0] == "Exito")
                    {
                        mostrarMensaje("success", "Éxito!!!", "El Proyecto fue modificado correctamente");
                        llenarUsuariosAsignados();
                    }
                    else if (result[0] == "Error")
                    {
                        mostrarMensaje("danger", "Error", "El nombre de Proyecto seleccionado ya existe");
                    }
                
                
                }
              
            }         
                modo = 0;
                restaurarPantalla();
                gridProyecto.DataBind();
                llenarGridUsuarios();
                this.gridUsuariosAsignados.Visible = false;
                this.gridProyecto.Enabled = true;          
        }
    /*
     * METODOS INTERFAZ ##################################################################################################### 
	 */
	 
	 /*
	 * Limpia campos en vacío.
	 */
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
                this.cmbEstado.Text = "Pendiente de Asignación";
        }
	
	
		/*
		* Habilita campos para agregar o modificar.
		*/
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
		
		/*
		* Restaura pantalla, es decir pone todo en modo consulta. Limpiando campos también
		*/
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
		
		/*
		* Restaura pantalla, es decir pone todo en modo consulta. No limpia campos, para el modo modificar.
		*/
        protected void restaurarPantallaSinLimpiar()
        {
            habilitarCampos(false);
            btnAgregarProyecto.Disabled = false;
            btnModificarProyecto.Disabled = true;
            btnEliminarProyecto.Disabled = true;
            botonAceptar.Disabled = true;
            botonCancelar.Disabled = true;
        }
		
		/*
		* Metodo que se activa cuando se cambia de lider en el grid de lideres. En donde no deja que se marquen más de 1 lider.
		*/
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
                {}

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
		
		/*
		* Método que revisa el lider en el grid de usuarios asignados para que tampoco se pueda seleccionar más de un lider.
		*/
        protected void cbLiderAsignado_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chk = (CheckBox)sender;
            GridViewRow gv = (GridViewRow)chk.NamingContainer;
            int rownumber = gv.RowIndex;

            if (chk.Checked)
            {
                try
                {
                    CheckBox chkIndividual = (CheckBox)gridUsuariosAsignados.Rows[rownumber].FindControl("cbMiembrosAsignados");  
                    chkIndividual.Checked = true;
                }
                catch
                {

                }

                int i;
                for (i = 0; i <= gridUsuariosAsignados.Rows.Count - 1; i++)
                {
                    if (i != rownumber)
                    {
                        CheckBox chkcheckbox = ((CheckBox)(gridUsuariosAsignados.Rows[i].FindControl("cbLiderAsignado")));
                        chkcheckbox.Checked = false;
                    }
                }
            }
            else
            {

                try
                {
                    CheckBox chkIndividual = (CheckBox)gridUsuariosAsignados.Rows[rownumber].FindControl("cbMiembros");
                    chkIndividual.Checked = false;
                }
                catch
                {

                }

            }

        }

        protected void ocultarMensaje()
        {
            alertAlerta.Attributes.Add("hidden", "hidden");
        }

        /*
        * Muestra mensaje de exito o error.
        */
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }
    }
}