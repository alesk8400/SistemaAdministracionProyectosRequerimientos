﻿using SAPR.App_Code.Entidades;
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

        //public String[] insertarRequerimiento(String nombreModulo, String nombreSprint, String nombreProyecto, String nombre, String descripcion, int prioridad, String estado,
        //int cantidad, String medida, byte[]archivo)
        //{
        //    int idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);            
        //    int idSprint = controladoraEstructura.getIdSprint(nombreSprint, nombreProyecto);
        //    int idModulo;///*********

        //    if (nombreModulo == "Ninguno")/////******PUEDE CAMBIAR********
        //    {
        //        idModulo = -1;
        //    }
        //    else {
        //        idModulo = 0;
        //        //idModulo = controladoraEstructura.getIdModulo(idSprint, nombreModulo);************IMPORTANTE***************                       
        //    }     

        public String[] insertarRequerimiento(int idModulo, int idSprint, int idProyecto, String nombre, String descripcion, int prioridad, String estado,
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

        public String[] modificarRequerimiento(int idModulo, int idSprint, int idProyecto, String nombre, String descripcion, String prioridad, String estado,
        int cantidad, String medida, byte[] archivo, EntidadRequerimientos requerimientoViejo)
        {
            //int idRequerimientoViejo = controladoraBDRequerimiento.getIdRequerimiento(requerimientoViejo.Nombre, requerimientoViejo.IdModulo, requerimientoViejo.IdProyecto);
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

            return controladoraBDRequerimiento.modificarRequerimiento(idRequerimiento, requerimientoNuevo);
        }

        public String[] eliminarRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto)
        {
            //idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);
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
        public EntidadRequerimientos getRequerimiento(String nombreRequerimiento, String nombreModulo, String nombreSprint, 
            String nombreProyecto) {

            EntidadRequerimientos resultado = null;
            Object[] entidadTemporal = new Object[9];
            DataTable resultadoT = new DataTable();
            int idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);      
            int idSprint = controladoraEstructura.getIdSprint(nombreSprint, nombreProyecto);
            //int idModulo = controladoraEstructura.getIdModulo(idSprint, nombreModulo);************IMPORTANTE***************
            int idModulo;

            idModulo = 0;
            //idModulo = controladoraEstructura.getIdModulo(idSprint, nombreModulo);************IMPORTANTE***************                       


            try {
                resultadoT = controladoraBDRequerimiento.getRequerimiento(nombreRequerimiento, idModulo, idProyecto);   
                if(resultadoT.Rows.Count == 1){
                    entidadTemporal[0] = resultadoT.Rows[0][0];
                    entidadTemporal[1] = resultadoT.Rows[0][1];
                    entidadTemporal[2] = resultadoT.Rows[0][2];
                    entidadTemporal[3] = resultadoT.Rows[0][3];
                    entidadTemporal[4] = resultadoT.Rows[0][4];
                    entidadTemporal[5] = resultadoT.Rows[0][5];
                    entidadTemporal[6] = resultadoT.Rows[0][6];
                    entidadTemporal[7] = resultadoT.Rows[0][7];
                    entidadTemporal[8] = resultadoT.Rows[0][8];

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

        public DataTable getNombresProyectos()
        {
            DataTable resultado = crearTablaProyecto(); //Este método crea la tabla

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

        //public String[] insertarCriterio(String nombreCriterio, String escenario, String contexto, String resultado, 
        //    String nombreRequerimiento, String nombreProyecto, String nombreSprint, String nombreModulo)
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
        //int idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);

        public String[] insertarCriterio(String nombreCriterio, int escenario, String contexto, String resultado,
            int idRequerimiento, int idProyecto, int idSprint, int idModulo)
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

        //public String[] modificarCriterio(String nombreCriterio, String escenario, String contexto, String resultado, 
        //String nombreRequerimiento, String nombreProyecto, String nombreSprint, String nombreModulo, EntidadCriterio criterioViejo){

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

        //    int idRequerimiento = controladoraBDRequerimiento.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);

        public String[] modificarCriterio(String nombreCriterio, int escenario, String contexto, String resultado,
        int idRequerimiento, int idProyecto, int idSprint, int idModulo, EntidadCriterio criterioViejo)
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

        public String[] eliminarCriterio(String nombreCriterio, int idRequerimiento) {

            int idCriterio = controladoraBDRequerimiento.getIdCriterio(nombreCriterio, idRequerimiento);
            return controladoraBDRequerimiento.eliminarCriterio(idCriterio);               
        }

        public DataTable getCriteriosDeRequerimiento(int idRequerimiento) {
            return controladoraBDRequerimiento.getCriteriosDeRequerimiento(idRequerimiento);        
        }

        public DataTable getCriteriosDeProyecto(int idProyecto){
            return controladoraBDRequerimiento.getCriteriosDeProyecto(idProyecto);
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
    }
}