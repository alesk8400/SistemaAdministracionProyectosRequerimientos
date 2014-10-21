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
    public partial class FormularioUsuario : System.Web.UI.Page
    {

        private static ControladoraUsuario controladora = new ControladoraUsuario();
        private static EntidadUsuario entidadConsultada;
        private static int modo = 0;
        private bool revisado = false;
     
        protected void Page_Load(object sender, EventArgs e){

            restaurarPantallaSinLimpiar();

            //String handler = ClientScript.GetPostBackEventReference(this.btnAceptar, "");
            //txtCedula.Attributes.Add("onblur", handler);
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e){          
            modo = 1;
            limpiarCampos();
            habilitarCampos(true);
            btnAceptar.Disabled = false;
            btnCancelar.Disabled = false;
            

            if(cmbProyecto.Items.Contains(new ListItem("Ninguno"))){
            } else{
            cmbProyecto.Items.Add("Ninguno");
            }
            
            

        }

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
            }
            catch {
                entidadConsultada = null;
            }

            btnModificarUsuario.Disabled = false;
            btnEliminarUsuario.Disabled = false;

        }

        protected void btnAceptar_Click(object sender, EventArgs e){

            String []resultado = new String[1];
            //RevisarDuplicado();

                if (modo == 1) // si se quiere insertar
                {
                    resultado = controladora.insertarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString() , this.password.Value.ToString());

                    if (resultado[0] == "Exito")
                    { // si inserto el proveedor : va a modo consultar con ese proveedor


                        String proyecto = cmbProyecto.SelectedValue.ToString();

                        if (!proyecto.Equals("Ninguno"))
                        {
                            int IdProy = controladora.getProyecto(proyecto);
                            controladora.insertarUsuarioProyecto(IdProy, this.txtCedula.Value.ToString());
                        }
                        gridUsuarios.DataBind();
                        restaurarPantalla();
                    } // si no lo inserto no debe cambiar de modo ni limpiar la pantalla.
                }
                else if (modo == 2)//si se quiere modificar
                {
                    String[] result = controladora.modificarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString(), this.password.Value.ToString(),entidadConsultada);

                    String proyecto = cmbProyecto.SelectedValue.ToString();

                    if (!proyecto.Equals("Ninguno"))
                    {
                        int IdProy = controladora.getProyecto(proyecto);
                        controladora.insertarUsuarioProyecto(IdProy, this.txtCedula.Value.ToString());
                    }
                    gridUsuarios.DataBind();
                    restaurarPantalla();

                }                           
       
        }

        //private void RevisarDuplicado()
        //{
        //    String cedulaUsuario = this.txtCedula.Value.ToString();
        //    int resultado = controladora.validarUsuario(cedulaUsuario);


        //    if (resultado != 0){
        //        errorCedulaRepetida.Text = "Error";
        //    }
          
        //}

        protected void btnCancelar_Click(object sender, EventArgs e) {
            if(modo == 1){
                limpiarCampos();        
            } 
            
            
            if(modo == 2){
                entidadConsultada = controladora.consultarUsuario(gridUsuarios.SelectedRow.Cells[0].Text.ToString());
                txtNombreUsuario.Value = entidadConsultada.Nombre;
                txtCedula.Value = entidadConsultada.Cedula;
                textTelefono.Value = entidadConsultada.Telefono;
                textCelular.Value = entidadConsultada.Celular;
                textEmail.Value = entidadConsultada.Correo;
                cmbRoles.Text = controladora.getRolUsuario(entidadConsultada.Cedula);
            
            }

        }

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

        protected void ocultarMensaje() {
            alertAlerta.Attributes.Add("hidden", "hidden");
        }
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje) {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }

        protected void clickAceptarEliminar(object sender, EventArgs e) {
            String[] result = new String[1];
            result = controladora.eliminarUsuario(entidadConsultada.Cedula);
            mostrarMensaje(result[0], result[0], result[0]); // se muestra el resultado
            if (result[0].Contains("Exito"))// si fue exitoso
            {
 
                limpiarCampos();
                gridUsuarios.DataBind();
            }
        }
        protected void btnModificarUsuario_Click(object sender, EventArgs e){
            this.txtNombreUsuario.Disabled = false;
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
            if (cmbProyecto.Items.Contains(new ListItem("Ninguno")))
            {
            }
            else
            {
                cmbProyecto.Items.Add("Ninguno");
            }
            
        }

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