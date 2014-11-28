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
//using ASPNetFileUpDownLoad.Utilities;

namespace SAPR
{
    /*
    * Clase para manejar la interfaz de Requerimientos.
    */
    public partial class FormularioRequerimientos : System.Web.UI.Page
    {

        //Creación de variables estaticas que permiten movernos entre métodos y creacion de las instancias que se necesitan
        ControladoraRequerimiento controladora = new ControladoraRequerimiento();
        private static int modo = 0;
        private static int modoC = 0;
        private static EntidadRequerimientos consultado;
        private static EntidadCriterio criterioConsultado; 
        private static int idProyecto = 0;
        private static int idRequerimiento = 0;
        private static int idCriterio = 0;



        /* Método que permite cargar la pagina, manejando la lógica de despliegue
         * por ejemplo deshabilida botones a través del manejo de modos 
         */

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack)
            {
                llenarCmbProy();
            }
            
            if (modo != 1 && modo != 2)  // Modos inserción y modificación
            {
                restaurarPantallaSinLimpiar();
                habilitarCamposC(false);
            }
        }

        /* Método que maneja el evento del botón de Agregar Requerimiento  de forma que limpia y habilita
         * los campos y limpiandolos, además asigna el modo agragar a la variable estática
         */
        protected void btnAgregarReque_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCamposR(true);
            limpiarCamposR();
        }

        /* Método que maneja el evento del botón de Modificar el Requerimiento de forma que NO limpia 
        * los campos pero los habilita, además asigna el modo modificación a la variable estática
        */
        protected void btnModificarReque_Click(object sender, EventArgs e)
        {
            modo = 2;
            habilitarCamposR(true);
        }

        /* Método que maneja el evento del link de consultar Requerimiento en el grid, por lo tanto se hace el llamado a la controladora
         * para traer los datos del requerimiento seleccionado, con dichos datos se poblan los diferetentes campos de texto
         * y se seleccionan las correspondientes opciones en los comboboxes
        */
        protected void GridRequerimientos_SelectedIndexChanged(object sender, EventArgs e)  // consultar
        {

            idRequerimiento = Int32.Parse(gridRequerimientos.SelectedRow.Cells[4].Text.ToString());  //Se obtiene el id del requerimiento
            consultado = controladora.getRequerimiento(idRequerimiento);  //Se trae la entidad de Requerimiento consultada con el id anterior
            txtCantidadR.Value = consultado.Cantidad.ToString();
            textNombreR.Value = consultado.Nombre;
            textD.Value = consultado.Descripcion;
            //File.WriteAllBytes(consultado.Nombre, consultado.Archivo);
            //subirArchivo.Fil
            cmbPrioridad.SelectedValue = consultado.Prioridad.ToString();
            cmbEstado.SelectedValue = consultado.Estado.ToString();
            cmbMedida.SelectedValue = consultado.Medida.ToString();
            int idSprint = controladora.getidS(consultado.IdModulo);
            cmbModulo.DataSource = controladora.getNombresModulos(idSprint);
            cmbModulo.DataValueField = "Identificador";
            cmbModulo.DataTextField = "Nombre";
            cmbModulo.DataBind();
            String nombreM = controladora.getNombreModulo(consultado.IdModulo);
            cmbModulo.SelectedValue = consultado.IdModulo.ToString();
            btnModificarReque.Disabled = false;
            btnEliminarReque.Disabled = false;     
            DataTable criterios = controladora.getCriteriosDeRequerimiento(idRequerimiento);  // Tambien se pobla el grid de Criterios de Aceptación
            gridCriterios.DataSource = criterios;
            gridCriterios.DataBind();
            btnAgregarCriterio.Disabled = false;
        }

        /* Método que permite llenar el combobox de proyecto, de forma que se cargha con los nombres de los poryectos pero
         * el valor que se obtiene al seleccionarlo es el correspondiente id
        */
        private void llenarCmbProy()
        {
            DataTable datos_proyecto = controladora.getNombresProyectos();
            cmbProyecto.DataSource = datos_proyecto;
            cmbProyecto.DataTextField = "Nombre";
            cmbProyecto.DataValueField = "idProyecto";
            cmbProyecto.DataBind();

        }


        /* Método que maneja el evento del boton aceptar Criterio, es decir es el evento que maneja la aprobación de las diferentes acciones
         * siendo estas Agregra, Modificar, eliminar CRITERIO
        */
        protected void btnAceptarC_Click(object sender, EventArgs e)
        {
            String[] resultadoF = new String[1];
            string nombreC = nombreCriterio.Value.ToString();
            string contexto = txtContexto.Value.ToString();
            int escenario = Int32.Parse(txtEscenario.Value.ToString());
            string resultado = txtRes.Value.ToString();
            if(modoC == 1){  // Modo de inserción 
                resultadoF = controladora.insertarCriterio(nombreC,escenario,contexto,resultado,idRequerimiento);
            } else if (modoC == 2){                
                resultadoF = controladora.modificarCriterio(nombreC, escenario, contexto, resultado, idRequerimiento, criterioConsultado);            
            
            }
            restaurarPantallaSinLimpiarC();
            DataTable criterios = controladora.getCriteriosDeRequerimiento(idRequerimiento);
            gridCriterios.DataSource = criterios;
            gridCriterios.DataBind();
            btnAgregarCriterio.Disabled = false;
        }


        /* Método que permite deshabilitar campos y no limpiar la pantalla requerimientos de forma que queda en modo consulta
         * es decir la informacion de un requerimiento recien insertado
        */
        protected void restaurarPantallaSinLimpiar()
        {
            habilitarCamposR(false);
            botonAceptarR.Disabled = true;
            btnModificarReque.Disabled = true;
            btnEliminarReque.Disabled = true;
            botonCancelar.Disabled = true;
        }

        /* Método que permite deshabilitar campos y no limpiar la pantalla de Criterios de Aceptación de forma que queda en modo consulta
         * es decir la informacion de un requerimiento recien insertado
        */
        protected void restaurarPantallaSinLimpiarC()
        {
            habilitarCamposC(false);
            btnModificarCriterio.Disabled = true;
            btnEliminarCriterio.Disabled = true;
            btnAcepCri.Disabled = true;
            btnCanCri.Disabled = true;
        }

        /* Método que permite habilitar campos de los requerimientos de forma que el usuario pueda agregar o
         * modificar un requerimiento.
        */
        protected void habilitarCamposR(Boolean habilitar)
        {
            this.textNombreR.Disabled = !habilitar;
            this.textD.Disabled = !habilitar;
            this.cmbPrioridad.Enabled = habilitar;
            this.cmbEstado.Enabled = habilitar;
            this.txtCantidadR.Disabled = !habilitar;
            this.cmbMedida.Enabled = habilitar;
            this.cmbSprint.Enabled = habilitar;
            this.cmbModulo.Enabled = habilitar;
            this.botonAceptarR.Disabled = !habilitar;
            this.botonCancelar.Disabled = !habilitar;
        }
        /* Método que permite habilitar campos de los requerimientos de forma que el usuario pueda agregar o
        * modificar un Criterio de Aceptación
        */
        protected void habilitarCamposC(Boolean habilitar)
        {
            this.btnAgregarCriterio.Disabled = !habilitar;
            this.btnModificarCriterio.Disabled = !habilitar;
            this.btnEliminarCriterio.Disabled = !habilitar;
            this.txtContexto.Disabled = !habilitar;
            this.txtEscenario.Disabled = !habilitar;
            this.txtRes.Disabled = !habilitar;
            this.nombreCriterio.Disabled = !habilitar;
            this.btnAcepCri.Disabled = !habilitar;
            this.btnCanCri.Disabled = !habilitar;
        }

        /* Método que maneja el evento del combobox Proyecto, que permite cargar los datos básicos del proyecto
         * además pobla los comboboxes de sus respectivos sprints
        */

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

        /* Método que maneja el evento del boton aceptar Requerimiento, es decir es el evento que maneja la aprobación de las diferentes acciones para requerimientos
        * siendo estas Agregar, Modificar, eliminar Requerimiento
        */
        protected void botonAceptarR_ServerClick(object sender, EventArgs e) {
            String[] resultado = new String[1];
            Stream strm;
            BinaryReader br;
            Byte[] filesize = null;
            if (subirArchivo.HasFile)   //Manejo del archivo, se necesita un procesamiento previo para poder guardar el archivo en la base de datos
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
            if (modo == 1) {  //Modo Insertar
                resultado = controladora.insertarRequerimiento(idModulo, idProyecto, nombre, descrip, prioridad, estado,cantidad, medida, filesize);             // llamado a la controladora para hacer inserción
            }
            if (modo == 2) {
                resultado = controladora.modificarRequerimiento(idModulo, idProyecto, nombre, descrip, prioridad, estado, cantidad, medida, filesize, consultado);  // llamado a la controladora para hacer la modificación
            }
            restaurarPantallaSinLimpiar();
            DataTable datos_reque = controladora.getRequerimientosDeProyecto(Int32.Parse(cmbProyecto.SelectedItem.Value));  //Se actualiza el grid
            gridRequerimientos.DataSource = datos_reque; 
            gridRequerimientos.DataBind();

        }

        /* Método que maneja el evento del combobox Sprint, que permite cargar o poblar el combobox de modulos 
         * al igual que los otros comboboxes se muestran los nombres de los modulos pero al seleccionarlo 
         * se obtienen los ids de los modulos
        */
        protected void cmbSprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSprint = Int32.Parse(cmbSprint.SelectedValue.ToString());
            cmbModulo.DataSource = controladora.getNombresModulos(idSprint);
            cmbModulo.DataValueField = "Identificador";
            cmbModulo.DataTextField = "Nombre";
            cmbModulo.DataBind();
        }

        /* Método que maneja el evento del boton aceptar del modal (del caso en que se quiera eliminar un Requerimiento)
         * es el encargado de comunicarse con la controladora para eliminar el requerimiento consultado
         * además de limpiar el grid de requerimientos
        */
        protected void botonAceptarModalReque_ServerClick(object sender, EventArgs e){
            int idMod = Int32.Parse(cmbModulo.SelectedValue.ToString());
            string nombre = textNombreR.Value.ToString();
            String[] resultado = new String[1];
            resultado = controladora.eliminarRequerimiento(consultado.Nombre, idMod, idProyecto);
            restaurarPantallaSinLimpiar();
            DataTable datos_reque = controladora.getRequerimientosDeProyecto(Int32.Parse(cmbProyecto.SelectedItem.Value));
            gridRequerimientos.DataSource = datos_reque;
            gridRequerimientos.DataBind();
            limpiarCamposR();
        }

        /* Método que permite limpiar campos de los requerimientos
        */
        protected void limpiarCamposR() {
            this.textNombreR.Value = "";
            this.textD.Value = "";
            this.txtCantidadR.Value = "";
        }
        /* Método que permite limpiar campos de los requerimientos
        */
        protected void limpiarCamposC()
        {
            this.nombreCriterio.Value = "";
            this.txtEscenario.Value = "";
            this.txtContexto.Value = "";
            this.txtRes.Value = "";
        }

        /* Método que maneja el evento del link de consultar en el grid Criterios, por lo tanto se hace el llamado a la controladora
        * para traer los datos del criterio seleccionado, con dichos datos se poblan los diferetentes campos de texto
        */
        protected void gridCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCriterio = Int32.Parse(gridCriterios.SelectedRow.Cells[1].Text.ToString());
            criterioConsultado = controladora.getCriterio(idCriterio);
            this.nombreCriterio.Value = criterioConsultado.NombreCriterio;
            this.txtEscenario.Value = criterioConsultado.Escenario.ToString();
            this.txtContexto.Value = criterioConsultado.Contexto;
            this.txtRes.Value = criterioConsultado.Resultado;
            btnModificarCriterio.Disabled = false;
            btnEliminarCriterio.Disabled = false;

        }


        /* Método que maneja el evento del boton Aceptar en el modal que se despliega al dar Cancelar una operación de Requerimiento, 
         * esto limpia los campos de los requerimientos y restaura la pantalla a su estado incial
        */
        protected void botonAceptarCancelar_ServerClick(object sender, EventArgs e)
        {
            limpiarCamposR();
            restaurarPantallaSinLimpiar();
        }

        /* Método que maneja el evento del boton Agregar Criterio, activando dicho modo y habilidando  (además de limpiar)
         * los campos de criterios para que el usuario pueda editarlos
        */
        protected void btnAgregarCriterio_ServerClick(object sender, EventArgs e)
        {
            btnAcepCri.Disabled = false;
            btnCanCri.Disabled = false;
            habilitarCamposC(true);
            limpiarCamposC();
            modoC = 1;
        }
        /* Método que maneja el evento del boton Modificar Criterio, activando dicho modo y habilidando 
        * los campos de criterios para que el usuario pueda editarlos, pero sin limpiar los campos por lo cual quedan los 
         * datos del criterio consultado
        */
        protected void btnModificarCriterio_ServerClick(object sender, EventArgs e)
        {
            btnAcepCri.Disabled = false;
            btnCanCri.Disabled = false;
            habilitarCamposC(true);
            modoC = 2;
        }

        /* Método que maneja el evento del boton aceptar del modal (del caso en que se quiera eliminar un Criterio)
        * es el encargado de comunicarse con la controladora para eliminar el criterio consultado
        * además de limpiar el grid de citerios
        */
        protected void botonAceptarModalCriterio_ServerClick(object sender, EventArgs e)
        {
            String[] resultado = new String[1];
            btnAcepCri.Disabled = false;
            btnCanCri.Disabled = false;
            resultado = controladora.eliminarCriterio(idCriterio);
            DataTable criterios = controladora.getCriteriosDeRequerimiento(idRequerimiento);
            gridCriterios.DataSource = criterios;
            gridCriterios.DataBind();
            restaurarPantallaSinLimpiarC();
            limpiarCamposC();

        }

        /* Método que maneja el evento del boton Aceptar en el modal que se despliega al dar Cancelar una operación de Criterio, 
        * esto no  limpia los campos de los criterios y restaura la pantalla a su estado incial
        */
        protected void botonAceptarCancelarCriterio_ServerClick(object sender, EventArgs e)
        {
            restaurarPantallaSinLimpiarC();
            btnModificarCriterio.Disabled = false;
            btnEliminarCriterio.Disabled = false;
        }
    }
}