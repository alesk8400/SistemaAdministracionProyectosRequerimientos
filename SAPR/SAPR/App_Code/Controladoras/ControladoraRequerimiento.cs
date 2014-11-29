using SAPR.App_Code.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace SAPR.App_Code.Controladoras
{
    public class ControladoraRequerimiento
    {
        //Creación de variables estaticas que permiten movernos entre métodos y creacion de las instancias que se necesitan
        ControladoraBDRequerimiento controladoraBDRequerimiento;
        ControladoraProyecto controladoraProyecto;
        ControladoraEstructura controladoraEstructura;
        public static int idRequerimiento = 0;

        public ControladoraRequerimiento()
        {

            controladoraBDRequerimiento = new ControladoraBDRequerimiento();           
            controladoraEstructura = new ControladoraEstructura();

        }

        /*
         * Método que recibe los datos para un nuevo requerimiento, los encapsula
         * y pasa a la controladora de BD para su posterior inserción. Retorna un 
         * String[] con el estado de la transacción.               
         */
        public String[] insertarRequerimiento(int idModulo, int idProyecto, String nombre, String descripcion, int prioridad, String estado,
        int cantidad, String medida, byte[] archivo)
        {
            
            Object[] datosRequerimiento = new Object[9];
            datosRequerimiento[0] = idModulo;
            datosRequerimiento[1] = idProyecto;
            datosRequerimiento[2] = nombre;
            datosRequerimiento[3] = descripcion;
            datosRequerimiento[4] = prioridad;
            datosRequerimiento[5] = estado;
            datosRequerimiento[6] = cantidad;
            datosRequerimiento[7] = medida;
            datosRequerimiento[8] = archivo;

            EntidadRequerimientos requerimiento = new EntidadRequerimientos(datosRequerimiento);
            return controladoraBDRequerimiento.insertarRequerimiento(requerimiento);

        }

        /*
         * Método que recibe la Entidad a modificar, además de los datos modificados de un requerimiento, 
         * los cuales encapsula y pasa a la controladora de BD para realizar la actualización.    
         * Retorna un String[] con el estado de la transacción.
         */
        public String[] modificarRequerimiento(int idModulo, int idProyecto, String nombre, String descripcion, int prioridad, String estado,
        int cantidad, String medida, byte[] archivo, EntidadRequerimientos requerimientoViejo)
        {
            int idRequerimientoViejo = controladoraBDRequerimiento.getIdRequerimiento(requerimientoViejo.Nombre, requerimientoViejo.IdModulo, requerimientoViejo.IdProyecto);
            Object[] datosRequerimiento = new Object[9];
            datosRequerimiento[0] = idModulo;
            datosRequerimiento[1] = idProyecto;
            datosRequerimiento[2] = nombre;
            datosRequerimiento[3] = descripcion;
            datosRequerimiento[4] = prioridad;
            datosRequerimiento[5] = estado;
            datosRequerimiento[6] = cantidad;
            datosRequerimiento[7] = medida;
            datosRequerimiento[8] = archivo;

            EntidadRequerimientos requerimientoNuevo = new EntidadRequerimientos(datosRequerimiento);

            return controladoraBDRequerimiento.modificarRequerimiento(idRequerimientoViejo, requerimientoNuevo);
        }


        /*
         * Método que a partir del nombre de un requerimiento, el identificador del módulo y proyecto
         * al que pertenece, busca el identificador del requerimiento para que este sea eliminado 
         * desde la controladora de BD. Se asume que no pueden haber 2 requerimientos con el mismo nombre
         * pertenecientes al mismo proyecto y al mismo módulo. Retorna un String[] con el estado de la transacción.
         */
        public String[] eliminarRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto)
        {
            idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);
            return controladoraBDRequerimiento.eliminarRequerimiento(idRequerimiento);
        }

        /*
         * Método que a partir del identificador de un proyecto, elimina todos los requerimientos asociados.
         * Retorna un String[] con el estado de la transacción.
         */
        public String[] eliminarRequerimientosDeProyecto(int idProyecto)
        {
            return controladoraBDRequerimiento.eliminarRequerimientosDeProyecto(idProyecto);
        }

        /*
         * Método que a partir del nombre de un requerimiento, el módulo al que está asociado y el proyecto
         * al que pertenece, obtiene su identificador.
         */
        public int getIdRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto)
        {

            idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);
            return idRequerimiento;
        
        }

        /*
         * Método que a partir del identificador de un requerimiento, obtiene una entidad con la información 
         * de este.
         */
        public EntidadRequerimientos getRequerimiento(int idReq) {

            EntidadRequerimientos resultado = null;
            Object[] entidadTemporal = new Object[9];
            DataTable resultadoT = new DataTable();
            try {
                resultadoT = controladoraBDRequerimiento.getRequerimiento(idReq);   
                if(resultadoT.Rows.Count == 1){
                    entidadTemporal[0] = resultadoT.Rows[0][1];
                    entidadTemporal[1] = resultadoT.Rows[0][2];
                    entidadTemporal[2] = resultadoT.Rows[0][3];
                    entidadTemporal[3] = resultadoT.Rows[0][4];
                    entidadTemporal[4] = resultadoT.Rows[0][5];
                    entidadTemporal[5] = resultadoT.Rows[0][6];
                    entidadTemporal[6] = resultadoT.Rows[0][7];
                    entidadTemporal[7] = resultadoT.Rows[0][8];
                    entidadTemporal[8] = resultadoT.Rows[0][9];

                    resultado = new EntidadRequerimientos(entidadTemporal);                   
                }

            } catch (Exception ex){
            
            
            }


            return resultado;
        
        }


        /*
         * Procedimiento que crea una tabla con nombre e identificador de proyecto con el propósito de ser usada
         * en la interfaz para llenar el combobox respectivo.
         */
        protected DataTable crearTablaProyecto()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;
            //se agrega el campo de Nombre
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "idProyecto";
            tabla.Columns.Add(columna);


            return tabla;
        }


        /*
         * Procedimiento que crea una tabla con nombre, estado y lider de un proyecto con el propósito de ser usada
         * en la interfaz para llenar la información del proyecto seleccionado. 
         */
        protected DataTable crearTablaInfoProyecto()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;
            //se agrega el campo de Nombre
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Estado";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Lider";
            tabla.Columns.Add(columna);


            return tabla;
        }

        /*
         * Procedimiento que crea una tabla con nombre, estado y lider de un proyecto con el propósito de ser usada
         * en la interfaz para llenar la información de los criterios de aceptación. 
         */
        protected DataTable crearTablaCriterios()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;
            //se agrega el campo de Nombre
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Identificador";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Escenario";
            tabla.Columns.Add(columna);


            return tabla;
        }

        /*
         * Método que retorna un 'DataTable' con la información de los proyectos del Sistema con el propósito
         * de llenar el combobox de Proyectos, utiliza el procedimiento especificado anteriormente.
         */
        public DataTable getNombresProyectos()
        {
            DataTable resultado = crearTablaProyecto(); //Este método crea la tabla
            ControladoraProyecto controladoraProyecto = new ControladoraProyecto();
            Object[] datos = new Object[2];
            try
            {
                DataTable consulta = controladoraProyecto.getProyectos();
                if (consulta.Rows.Count > 0)
                {
                    foreach (DataRow fila in consulta.Rows)
                    {
                        datos[0] = fila[1].ToString(); // Van los Nombres
                        datos[1] = fila[0].ToString(); // Van los ids del Proyecto
                        resultado.Rows.Add(datos);// cargar en la tabla los datos de cada Proyecto
                    }
                }
                else // en cualquier otro caso se pone vacía la tabla
                {
                    datos[0] = "-";
                    resultado.Rows.Add(datos);
                }
            }
            catch (Exception e)
            {
                resultado = null;
            }

            return resultado;
        }


        /*
         * Método que retorna un 'DataTable' con la información del Proyecto seleccionado en el combobox
         * para que estos datos puedan ser mostrados al usuario.
         */
        public DataTable getInfoProyecto(string nombre)
        {
            DataTable resultado = crearTablaInfoProyecto(); //Este método crea la tabla
            ControladoraProyecto controladoraProyecto = new ControladoraProyecto();
            Object[] datos = new Object[3];
            try
            {
                DataTable consulta = controladoraProyecto.getInfoProyecto(nombre);
                if (consulta.Rows.Count > 0)
                {
                    foreach (DataRow fila in consulta.Rows)
                    {
                        datos[0] = fila[1].ToString(); // Van los Nombres
                        datos[1] = fila[2].ToString(); // Van los ids del Proyecto
                        datos[2] = fila[3].ToString(); // Van los ids del Proyecto
                        resultado.Rows.Add(datos);// cargar en la tabla los datos de cada Proyecto
                    }
                }
                else // en cualquier otro caso se pone vacía la tabla
                {
                    datos[0] = "-";
                    resultado.Rows.Add(datos);
                }
            }
            catch (Exception e)
            {
                resultado = null;
            }

            return resultado;
        }


        /*
         * Método que retorna un 'DataTable' con la información de los criterios de aceptación asociados a 
         * un requerimiento con el fin de llenar una tabla para mostrarlos. Utiliza el procedimiento
         * especificado anteriormente.
         */
        public DataTable getInfoCriterios(int req)
        {
            DataTable resultado = crearTablaCriterios(); //Este método crea la tabla
            ControladoraProyecto controladoraProyecto = new ControladoraProyecto();
            Object[] datos = new Object[3];
            try
            {
                DataTable consulta = controladoraBDRequerimiento.getCriteriosDeRequerimiento(req);
                if (consulta.Rows.Count > 0)
                {
                    foreach (DataRow fila in consulta.Rows)
                    {
                        datos[0] = fila[2].ToString(); // Van los Nombres
                        datos[1] = fila[1].ToString(); // Van los ids del Proyecto
                        datos[2] = fila[0].ToString(); // Van los ids del Proyecto
                        resultado.Rows.Add(datos);// cargar en la tabla los datos de cada Proyecto
                    }
                }
                else // en cualquier otro caso se pone vacía la tabla
                {
                    datos[0] = "-";
                    resultado.Rows.Add(datos);
                }
            }
            catch (Exception e)
            {
                resultado = null;
            }

            return resultado;
        }

        /*
         * Hace un llamado a la Controladora de Estructura para obtener una estructura 'DataTable' 
         * que contenga la información de los sprints asociados un proyecto específico
         * con el propósito de llenar el combobox respectivo.
         */
        public DataTable getNombresSprints(int idProyecto) {
            return controladoraEstructura.getNombresSprint(idProyecto);
        }

        /*
         * Hace un llamado a la Controladora de Estructura para obtener una estructura 'DataTable' 
         * que contenga la información de los módulos asociados un sprint específico
         * con el propósito de llenar el combobox respectivo.
         */
        public DataTable getNombresModulos(int idSprint)
        {
            return controladoraEstructura.getNombresModulo(idSprint);
        }

        /*
         * Procedimiento que retorna un 'DataTable' con la información de los requerimientos.
         */
        public DataTable getRequerimientos() {

            return controladoraBDRequerimiento.getRequerimientos();
        }


        /*
         * Método que recibe los datos para un nuevo criterio de aceptación, los encapsula
         * y pasa a la controladora de BD para su posterior inserción. Retorna un String[] 
         * con el estado de la transacción.                   
         */
        public String[] insertarCriterio(String nombreCriterio, int escenario, String contexto, String resultado,
            int idRequerimiento)
        {
            Object[] datosCriterio = new Object[5];
            datosCriterio[0] = nombreCriterio;
            datosCriterio[1] = escenario;
            datosCriterio[2] = contexto;
            datosCriterio[3] = resultado;
            datosCriterio[4] = idRequerimiento;

            EntidadCriterio criterio = new EntidadCriterio(datosCriterio);
            return controladoraBDRequerimiento.insertarCriterio(criterio);
        }

        /*
         * Método que recibe la Entidad a modificar, además de los datos modificados de un criterio de aceptación, 
         * los cuales encapsula y pasa a la controladora de BD para realizar la actualización. Retorna un String[] 
         * con el estado de la transacción.                   
         */
        public String[] modificarCriterio(String nombreCriterio, int escenario, String contexto, String resultado,
        int idRequerimiento, EntidadCriterio criterioViejo)
        {
            int idCriterioViejo = controladoraBDRequerimiento.getIdCriterio(criterioViejo.NombreCriterio, idRequerimiento);

            Object[] datosCriterio = new Object[5];
            datosCriterio[0] = nombreCriterio;
            datosCriterio[1] = escenario;
            datosCriterio[2] = contexto;
            datosCriterio[3] = resultado;
            datosCriterio[4] = idRequerimiento;

            EntidadCriterio criterioNuevo = new EntidadCriterio(datosCriterio);
            return controladoraBDRequerimiento.modificarCriterio(idCriterioViejo, criterioNuevo);
        }

        /*
         * Método que recibe el identificador de un criterio de aceptación y lo pasa a la Controladora de
         * BD para su eliminación. Retorna un String[] con el estado de la transacción.
         */
        public String[] eliminarCriterio(int idCriterio) {
            return controladoraBDRequerimiento.eliminarCriterio(idCriterio);               
        }

        /*
         * Método que recibe el identificador de un requerimiento y retorna una estructura 'DataTable' con 
         * la información de los criterios de aceptación asociados a este.
         */
        public DataTable getCriteriosDeRequerimiento(int idRequerimiento) {
            return getInfoCriterios(idRequerimiento);        
        }

        /*
         * Método que a partir del identificador de un criterio de aceptación, obtiene una entidad 
         * con la información de este.
         */
        public EntidadCriterio getCriterio(int idCriterio)
        {
            EntidadCriterio resultado = null;
            Object[] entidadTemporal = new Object[5];
            DataTable resultadoT = new DataTable();

            try
            {
                resultadoT = controladoraBDRequerimiento.getCriterio(idCriterio);
                if (resultadoT.Rows.Count == 1)
                {
                    entidadTemporal[0] = resultadoT.Rows[0][1];
                    entidadTemporal[1] = resultadoT.Rows[0][2];
                    entidadTemporal[2] = resultadoT.Rows[0][3];
                    entidadTemporal[3] = resultadoT.Rows[0][4];
                    entidadTemporal[4] = resultadoT.Rows[0][5];
                    resultado = new EntidadCriterio(entidadTemporal);
                }

            }
            catch (Exception ex)
            {


            }


            return resultado;
        }

        /*
         * Procedimiento que se utiliza para convertir un objeto a un arreglo de bytes, se utiliza para
         * el manejo de archivos de la aplicación.
         */
        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /*
         * Método que a partir del identificador de un proyecto, retorna una estructura 'DataTable'
         * con la información de los requerimientos asociados a este.
         */
        public DataTable getRequerimientosDeProyecto(int idProyecto) { 
            return controladoraBDRequerimiento.getRequerimientosDeProyecto(idProyecto);
        }

        /*
         * Método que a partir del identificador de un módulo, retorna una hilera con su nombre.
         */
        public String getNombreModulo(int idModulo)
        {
            return controladoraEstructura.getNombreModulo(idModulo);
        }

        /*
         * Método que a partir del identificador de un módulo, retorna un
         * entero con el identificador del sprint al que pertenece.
         */
        public int getidS(int idModulo)
        {
            return controladoraEstructura.getidS(idModulo);
        }
    }
}