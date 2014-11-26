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
        ControladoraBDRequerimiento controladoraBDRequerimiento;
        ControladoraProyecto controladoraProyecto;
        ControladoraEstructura controladoraEstructura;
        public static int idRequerimiento = 0;

        public ControladoraRequerimiento()
        {

            controladoraBDRequerimiento = new ControladoraBDRequerimiento();
           // controladoraProyecto = new ControladoraProyecto();
            controladoraEstructura = new ControladoraEstructura();

        }

        /*
         * Metodo que recibe los datos para un nuevo requerimiento, los encapsula
         * y pasa a la controladora de BD para su posterior insercion.                   
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

        //public String[] modificarRequerimiento(String nombreModulo, String nombreSprint, String nombreProyecto, String nombre, String descripcion, String prioridad, String estado,
        //int cantidad, String medida, byte[] archivo, EntidadRequerimientos requerimientoViejo)
        //{
        //    int idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
        //    int idSprint = controladoraEstructura.getIdSprint(nombreSprint, nombreProyecto);
        //    int idModulo;

        //    if (nombreModulo == "Ninguno")/////******PUEDE CAMBIAR********
        //    {
        //        idModulo = -1;
        //    }
        //    else
        //    {
        //        idModulo = 0;
        //        //idModulo = controladoraEstructura.getIdModulo(idSprint, nombreModulo);************IMPORTANTE***************                       
        //    }                

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

        public String[] eliminarRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto)
        {
            idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);
            return controladoraBDRequerimiento.eliminarRequerimiento(idRequerimiento);
        }

        public String[] eliminarRequerimientosDeProyecto(int idProyecto)
        {
            return controladoraBDRequerimiento.eliminarRequerimientosDeProyecto(idProyecto);
        }

        public int getIdRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto)
        {

            idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);
            return idRequerimiento;
        
        }

        ///Bacon
        public EntidadRequerimientos getRequerimiento(int idReq) {

            EntidadRequerimientos resultado = null;
            Object[] entidadTemporal = new Object[9];
            DataTable resultadoT = new DataTable();
            //int idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);      
            //int idSprint = controladoraEstructura.getIdSprint(nombreSprint, nombreProyecto);
            //int idModulo = controladoraEstructura.getIdModulo(idSprint, nombreModulo);************IMPORTANTE***************
            //int idModulo;

    //        idModulo = 0;
            //idModulo = controladoraEstructura.getIdModulo(idSprint, nombreModulo);************IMPORTANTE***************                       


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

        public DataTable getNombresSprints(int idProyecto) {
            return controladoraEstructura.getNombresSprint(idProyecto);
        }

        public DataTable getNombresModulos(int idSprint)
        {
            return controladoraEstructura.getNombresModulo(idSprint);
        }

        public DataTable getRequerimientos() {

            return controladoraBDRequerimiento.getRequerimientos();
        }

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

        public String[] eliminarCriterio(int idCriterio) {
            return controladoraBDRequerimiento.eliminarCriterio(idCriterio);               
        }

        public DataTable getCriteriosDeRequerimiento(int idRequerimiento) {
            return getInfoCriterios(idRequerimiento);        
        }

        public DataTable getCriteriosDeProyecto(int idProyecto){
            return controladoraBDRequerimiento.getCriteriosDeProyecto(idProyecto);
        }

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


        public DataTable getRequerimientosDeProyecto(int idProyecto) { 
            return controladoraBDRequerimiento.getRequerimientosDeProyecto(idProyecto);
        }

        public String getNombreModulo(int idModulo)
        {
            return controladoraEstructura.getNombreModulo(idModulo);
        }

        public int getidS(int idModulo)
        {
            return controladoraEstructura.getidS(idModulo);
        }
    }
}