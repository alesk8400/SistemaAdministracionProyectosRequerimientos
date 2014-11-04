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
	/*
	* Clase para manejar el modulo de Usuario.
	*/
    public partial class FormularioUsuario : System.Web.UI.Page
    {

        private static ControladoraUsuario controladora = new ControladoraUsuario();
        private static EntidadUsuario entidadConsultada;
        private static int modo = 0; //Para manejar modos de agregar, modificar y consultar.
        private bool revisado = false;
     
		/*
		* Carga de página que deshabilita botones.
		*/
        protected void Page_Load(object sender, EventArgs e){
            if (cmbProyecto.Items.Contains(new ListItem("Ninguno")))
            {
            }
            else
            {
                cmbProyecto.Items.Add("Ninguno");
                
            }
            
            if (modo != 1 && modo != 2)
            {
                restaurarPantallaSinLimpiar();
            }
        }

		/*
		* Metodo que se activa al darle click al boton Agregar en modulo Usuario.
		*/
        protected void btnAgregarUsuario_Click(object sender, EventArgs e){          
            modo = 1; //Modo agregar.
            limpiarCampos();
            habilitarCampos(true);
            btnAceptar.Disabled = false;
            btnCancelar.Disabled = false;
			//Se le agrega al combo box de Proyectos, la opción de asociarse a NINGUNO.
            if(cmbProyecto.Items.Contains(new ListItem("Ninguno"))){
            } else{
				cmbProyecto.Items.Add("Ninguno");
            }
        }
		
		/*
		* Metodo que se activa al seleccionar un usuario
		*/
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)  {           
            try
            {
                entidadConsultada = controladora.consultarUsuario(gridUsuarios.SelectedRow.Cells[0].Text.ToString());
                txtNombreUsuario.Value = entidadConsultada.Nombre;
                txtCedula.Value = entidadConsultada.Cedula;
                textTelefono.Value = entidadConsultada.Telefono;
                textCelular.Value = entidadConsultada.Celular;
                textEmail.Value = entidadConsultada.Correo;
                cmbRoles.Text = controladora.getRolUsuario(entidadConsultada.Cedula);
                cmbProyecto.Text = controladora.getProyectoUsuario(entidadConsultada.Cedula);
            }
            catch {
                entidadConsultada = null;
            }
            btnModificarUsuario.Disabled = false;
            btnEliminarUsuario.Disabled = false;

        }
		
		/*
		* Metodo que se activa al apretar el boton Aceptar. Tanto en modificar como agregar.
		*/
        protected void btnAceptar_Click(object sender, EventArgs e){

            String []resultado = new String[1];
                if (modo == 1) // si se quiere insertar
                {
                    resultado = controladora.insertarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString() , this.password.Value.ToString());

                    if (resultado[0] == "Exito")
                    { // si inserto el proveedor : va a modo consultar con ese proveedor
                        mostrarMensaje("success", "Exito!!!", "El usuario se ha ingresado correctamente");
                       
                        String proyecto = cmbProyecto.SelectedValue.ToString();
                        if (!proyecto.Equals("Ninguno"))
                        {
                            int IdProy = controladora.getProyecto(proyecto);
                            controladora.insertarUsuarioProyecto(IdProy, this.txtCedula.Value.ToString());
                        }
                        gridUsuarios.DataBind();
                        gridUsuarios.SelectRow(0);
                        restaurarPantallaSinLimpiar();
                    }
                    else {
                        mostrarMensaje("danger","Error","La cédula ingresada ya existe");
                        this.txtCedula.Value = "";
                    } // si no lo inserto no debe cambiar de modo ni limpiar la pantalla.
                }
                else if (modo == 2)//si se quiere modificar
                {
                    String[] result = controladora.modificarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString(), this.password.Value.ToString(),entidadConsultada);
                    String proyecto = cmbProyecto.SelectedValue.ToString();
					
					//Si el proyecto es diferente a ninguno si lo asocia a un proyecto.
                    if (!proyecto.Equals("Ninguno"))
                    {
                        int IdProy = controladora.getProyecto(proyecto);
                        controladora.eliminarUsuarioProyecto(IdProy, this.txtCedula.Value.ToString());
                        controladora.insertarUsuarioProyecto(IdProy, this.txtCedula.Value.ToString());
                    }
                    gridUsuarios.DataBind();
                    restaurarPantalla();

                }                           
       
        }

		/*
		* Si se cancela un usuario, ya sea en agregar o modificar.
		*/
        protected void btnCancelar_Click(object sender, EventArgs e) {
            if(modo == 1){ //En agregar limpia los campos.
                limpiarCampos();        
            }                     
            if(modo == 2){ //EN modificar no limpia los campos sino que vuelve a su estado inicial.
                entidadConsultada = controladora.consultarUsuario(gridUsuarios.SelectedRow.Cells[0].Text.ToString());
                txtNombreUsuario.Value = entidadConsultada.Nombre;
                txtCedula.Value = entidadConsultada.Cedula;
                textTelefono.Value = entidadConsultada.Telefono;
                textCelular.Value = entidadConsultada.Celular;
                textEmail.Value = entidadConsultada.Correo;
                cmbRoles.Text = controladora.getRolUsuario(entidadConsultada.Cedula);
                cmbProyecto.Text = controladora.getProyectoUsuario(entidadConsultada.Cedula);
            }
            restaurarPantallaSinLimpiar();
            modo = 0;
        }
		
		/*
		* Metodo que limpia todos los campos de textfields.
		*/
        protected void limpiarCampos() {
            this.txtNombreUsuario.Value = "";
            this.txtCedula.Value = "";
            this.textEmail.Value = "";
            this.textTelefono.Value = "";
            this.textCelular.Value = "";
            this.password.Value = "";
            this.password1.Value = "";
            this.cmbRoles.ClearSelection();
        }
		
		/*
		* Metodo para habilitar los campos en agregar o modificar.
		*/
        protected void habilitarCampos(Boolean habilitar){
            this.txtNombreUsuario.Disabled = !habilitar;
            this.txtCedula.Disabled = !habilitar;
            this.textEmail.Disabled = !habilitar;
            this.textTelefono.Disabled = !habilitar;
            this.textCelular.Disabled = !habilitar;
            this.password.Disabled = !habilitar;
            this.password1.Disabled = !habilitar;
            this.cmbRoles.Enabled = habilitar;
            this.cmbProyecto.Enabled = habilitar;
        }

		/*
		* Ocultar el mensaje de exito o error.
		*/
        protected void ocultarMensaje() {
            alertAlerta.Attributes.Add("hidden", "hidden");
        }
		
		/*
		* Muestra mensaje de exito o error.
		*/
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje) {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }
		
		/*
		* Metodo cuando se acepta el eliminar en el modal.
		*/
        protected void clickAceptarEliminar(object sender, EventArgs e) {
            String[] result = new String[1];
            result = controladora.eliminarUsuario(entidadConsultada.Cedula); //Obtiene la cedula para elimianr al usuario.
            
            //Si encontró la cédula, result[0] guarda EXITO.
			if (result[0].Contains("Exito"))// si fue exitoso
            {
                mostrarMensaje("success", "Exito:", "Se eliminó el usuario correctamente"); // se muestra el resultado
                limpiarCampos();
                gridUsuarios.DataBind();
            }
        }
		
		/*
		* Cuando se le da click al botón modificar en modulo Usuario.
		*/
        protected void btnModificarUsuario_Click(object sender, EventArgs e){
            this.txtNombreUsuario.Disabled = false;
            this.txtCedula.Disabled = false;
            this.textEmail.Disabled = false;
            this.textTelefono.Disabled = false;
            this.textCelular.Disabled = false;
            this.password.Disabled = false;
            this.password1.Disabled = false;
            this.cmbRoles.Enabled = true;
            this.cmbProyecto.Enabled = true;
            btnAceptar.Disabled = false;
            btnCancelar.Disabled = false;
            modo = 2;
			
			//Si no hay un ninguno(en el combo box) lo agrega.
            if (cmbProyecto.Items.Contains(new ListItem("Ninguno")))
            {
            }
            else
            {
                cmbProyecto.Items.Add("Ninguno");
            }
            
        }

		/*
		* Metodo para deshabilitar los campos en modo consulta. Limpia pantalla.
		*/
        protected void restaurarPantalla()
        {
            habilitarCampos(false);
            btnModificarUsuario.Disabled = true;
            btnEliminarUsuario.Disabled = true;
            btnAgregarUsuario.Disabled = false;
            btnAceptar.Disabled = true;
            btnCancelar.Disabled = true;
            limpiarCampos();
        }

		/*
		* Metodo para deshabilitar los campos en modo consulta.
		*/
        protected void restaurarPantallaSinLimpiar()
        {
            habilitarCampos(false);
            btnModificarUsuario.Disabled = true;
            btnEliminarUsuario.Disabled = true;
            btnAgregarUsuario.Disabled = false;
            btnAceptar.Disabled = true;
            btnCancelar.Disabled = true;
        }



    }

}