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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            
            //modo = 1;
            //irAModo();
            controladora.insertarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString());
            limpiarCampos();
            gridUsuarios.DataBind();
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
            }
            catch {

                entidadConsultada = null;
                // Hacer algo para indicar error
            }
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
       
        }

        protected void btnAceptar_Click(object sender, EventArgs e){

            String []resultado = new String[1];
            
            if (modo == 1) // si se quiere insertar
            {
                resultado = controladora.insertarUsuario(this.txtNombreUsuario.Value.ToString(), this.txtCedula.Value.ToString(), this.textEmail.Value.ToString(), this.textTelefono.Value.ToString(), this.textCelular.Value.ToString(), this.cmbRoles.SelectedItem.ToString());

                if (resultado[0] == "Exito")
                { // si inserto el proveedor : va a modo consultar con ese proveedor
                    //modo = 4;
                    habilitarCampos(false);
                } // si no lo inserto no debe cambiar de modo ni limpiar la pantalla
            }
            else if (modo == 2)//si se quiere modificar
            {
                /*
                Boolean res = true;
                Object[] datosMod = obtenerDatosFormulario();
                String[] result = controladora.modificarProveedor(datosMod, proveedorConsultado);
                mostrarMensaje(result[0], result[1], result[2]); // se muestra el resultado
                if (result[0].Contains("success"))// si fue exitoso
                {
                    llenarGrid(); //se actualiza el grid con el nuevo proveedor incluido
                }
                else if (result[2].Contains("cedula ingresada ya existe")) // si ya hay uno con esa cédula
                {
                    res = false;
                    modo = 1; //no se cambia de modo y retorna false
                }
                proveedorConsultado = controladora.consultarProveedor(this.textCedula.Value.ToString());
                llenarGrid();
                modo = 4;
                irAModo();
                 * */
                // se recuperan los datos que se hallan ingresado(existe un método para esto)

                // se le pide a la controladora que modifique el proveedor

                // se muestra el resultado de la modificación(revisar otros métodos para ver como mostrar el error devuelto)

                // se actualiza el proveedor que se consultó por última vez, es decir, se consulta el proveedor recien modificado
                //se carga el proveedor modificado en el grid(esto es volver a llenar el grid)
                // se cambia a modo consultar con el proveedor modificado
            }
                /*
            else if (modo == 3)// si se quiere eliminar
            {
                limpiarCampos(); // se limpian los campos
                modo = 0;//se va a modo reset, y no se elimina porque existe un modal de confirmacion que se muestra
            }
            if (operacionCorrecta)// si se logró la operación
            {
                irAModo();// se cambia de modo y actualiza el grid
                llenarGrid();
            }
              * */
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void limpiarCampos()
        {
            this.txtNombreUsuario.Value = "";
            this.txtCedula.Value = "";
            this.textEmail.Value = "";
            this.textTelefono.Value = "";
            this.textCelular.Value = "";
            this.cmbRoles.ClearSelection();
        }

        protected void irAModo()
        {
            if (modo == 0)
            { // el modo 0 se usa para resetear la interfaz
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = false;
                btnEliminarUsuario.Disabled = true;
                habilitarCampos(false);
            }
            else if (modo == 1)
            { // se desea insertar
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = false;
                btnEliminarUsuario.Disabled = true;

            }
            else if (modo == 2)
            { //modificar
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = true;
                btnAgregarUsuario.Enabled = false;
                btnEliminarUsuario.Disabled = true;
            }
            else if (modo == 3)
            { // eliminar
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = false;
                btnEliminarUsuario.Disabled = true;
            }
            else if (modo == 4)
            { //consultar
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = true;
                btnModificarUsuario.Enabled = false;
                btnAgregarUsuario.Enabled = true;
                btnEliminarUsuario.Disabled = true;
            }

           // aplicarPermisos();// se aplican los permisos del usuario para el acceso a funcionalidades
        }

        protected void habilitarCampos(Boolean habilitar){
            this.txtNombreUsuario.Disabled = !habilitar;
            this.txtCedula.Disabled = !habilitar;
            this.textEmail.Disabled = !habilitar;
            this.textTelefono.Disabled = !habilitar;
            this.textCelular.Disabled = !habilitar;
            this.cmbRoles.Enabled = habilitar;
        }

        protected void ocultarMensaje()
        {
            alertAlerta.Attributes.Add("hidden", "hidden");
        }
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }

        protected void clickAceptarEliminar(object sender, EventArgs e)
        {
            String[] result = new String[1];
            result = controladora.eliminarUsuario(entidadConsultada.Cedula);
            mostrarMensaje(result[0], result[0], result[0]); // se muestra el resultado
            if (result[0].Contains("Exito"))// si fue exitoso
            {
                modo = 0;
                irAModo();
                limpiarCampos();
                gridUsuarios.DataBind();
            }
            //se muestra lo que halla sucedido
            ////si lo eliminó correctamente, va al modo por defecto(reset=0), debe limpiar el proveedorConsultado,actualizar la información del grid,y limpiar todos los campos
        }

        protected void cancelarConsultar(object sender, EventArgs e)
        {
        }

    }

}