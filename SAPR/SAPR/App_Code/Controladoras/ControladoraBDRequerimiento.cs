using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPR.App_Code.DataSets.DataSetRequerimientoTableAdapters;
using SAPR.App_Code.Entidades;
namespace SAPR.App_Code.Controladoras
{
    public class ControladoraBDRequerimiento
    {

        //Adapters
        RequerimientoAdapter requerimientoTableAdapter;
        CriteriosTableAdapter criteriosTableAdapter;
        Requerimiento1TableAdapter adpatadorAux;
        Criterios1TableAdapter adapCriterios2;



        //Constructor de la clase se encarga de inicilizar los adaptadores de los distintos DataSets
        public ControladoraBDRequerimiento() {
            requerimientoTableAdapter = new RequerimientoAdapter();
            criteriosTableAdapter = new CriteriosTableAdapter();
            adpatadorAux = new Requerimiento1TableAdapter();
            adapCriterios2 = new Criterios1TableAdapter();
        }

        /*
         * Método que recibe una Entidad con la información de un nuevo Requerimiento, utiliza el 
         * adaptador del 'DataSet' para realizar la inserción. Retorna un String[] con el estado de la transacción.               
         */
        public string[] insertarRequerimiento(EntidadRequerimientos requerimiento)
        {
            String[] resultado = new String[1];

            try {
                this.requerimientoTableAdapter.insertarRequerimiento(requerimiento.IdModulo, requerimiento.IdProyecto,
                    requerimiento.Nombre, requerimiento.Descripcion, requerimiento.Prioridad, requerimiento.Estado, requerimiento.Cantidad, requerimiento.Medida, requerimiento.Archivo);

                resultado[0] = "Éxito";
            
            } catch (SqlException ex){

                int n = ex.Number;
                if(n==2627){
                    resultado[0] = "Error";
                }
                else{
                    resultado[0] = "Error";
                }            

            }


            return resultado;
        }

        /*
         * Método que recibe una Entidad con la información a modificar del Requerimiento, además del identificador
         * de este Requerimiento y utiliza el adaptador del 'DataSet' para realizar la modificación. 
         * Retorna un String[] con el estado de la transacción.               
         */
        public string[] modificarRequerimiento(int idRequerimiento, EntidadRequerimientos requerimientoNuevo)
        {
            String[] resultado = new String[1];

            try {

                this.requerimientoTableAdapter.modificarRequerimiento(requerimientoNuevo.IdModulo, requerimientoNuevo.IdProyecto, requerimientoNuevo.Nombre,
                requerimientoNuevo.Descripcion, requerimientoNuevo.Prioridad, requerimientoNuevo.Estado, requerimientoNuevo.Cantidad, requerimientoNuevo.Medida, requerimientoNuevo.Archivo, idRequerimiento);
            
            } catch (SqlException ex){

                int n = ex.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }   
            
            }


            return resultado;
        }

        /*
         * Procedimiento que recibe el identificador del Requerimiento a eliminar y utiliza el adaptador del 
         * 'DataSet' para realizar la eliminación. Retorna un String[] con el estado de la transacción.               
         */
        public string[] eliminarRequerimiento(int idRequerimiento)
        {
            String[] resultado = new String[1];

            try
            {
                this.requerimientoTableAdapter.eliminarRequerimiento(idRequerimiento);
                resultado[0] = "Éxito";
            }
            catch (SqlException ex)
            {

                int n = ex.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }

            }
            return resultado;
        }

        /*
         * Procedimiento que recibe el identificador un proyecto y utiliza el adaptador del 
         * 'DataSet' para eliminar del Sistema todos los requerimientos asociados a él.
         * Retorna un String[] con el estado de la transacción.               
         */
        public string[] eliminarRequerimientosDeProyecto(int idProyecto)
        {
            String[] resultado = new String[1];

            try
            {
                this.requerimientoTableAdapter.eliminarRequerimientosDeProyecto(idProyecto);
                resultado[0] = "Éxito";
            }
            catch (SqlException ex)
            {

                int n = ex.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }

            }
            return resultado;
        }

        /*
         * Método que retorna una estructura 'DataTable' con la información de un Requerimiento
         * a partir de su identificador.
         */
        public DataTable getRequerimiento(int idReq)
        {
            DataTable resultado = new DataTable();
            try{

                resultado = this.requerimientoTableAdapter.getRequerimiento(idReq);


            } catch(Exception ex){
            
            
            }

            return resultado;

        }

        /*
         * Método que retorna el identificador de un requerimiento a partir de su nombre, módulo en el que
         * está incluido y proyecto al que pertenece.
         */
        public int getIdRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto) {

            int idRequerimiento = -1;
            try{
                idRequerimiento = Int32.Parse(this.requerimientoTableAdapter.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto).ToString());
            }
            catch (Exception ex) {
                
            
            }

            return idRequerimiento;
        }

        /*
         * Método que retorna una estructura 'DataTable' con la información de los requerimientos
         * almacenados en el Sistema.
         */
        public DataTable getRequerimientos() {

            DataTable resultado = new DataTable();

            try {
                resultado = this.requerimientoTableAdapter.GetData();
            
            } catch (Exception ex){

                
            }

            return resultado;

        }

        /*
         * Método que recibe una Entidad con la información de un nuevo Criterio de Aceptación, utiliza el 
         * adaptador del 'DataSet' para realizar la inserción. Retorna un String[] con el estado de la transacción.               
         */
        public String[] insertarCriterio(EntidadCriterio criterio) {

            String[] resultado = new String[1];

            try {

                this.criteriosTableAdapter.insertarCriterio(criterio.NombreCriterio, criterio.Escenario, criterio.Contexto, 
                criterio.Resultado, criterio.IdRequerimiento);
                resultado[0] = "Éxito";
            }
            catch (SqlException ex)
            {

                int n = ex.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }

            }
            return resultado;
        }

        /*
         * Método que recibe una Entidad con la información a modificar del Criterio de Aceptación,
         * además del identificador de este y utiliza el adaptador del 'DataSet' para realizar la modificación. 
         * Retorna un String[] con el estado de la transacción.               
         */
        public string[] modificarCriterio(int idCriterioViejo, EntidadCriterio criterioNuevo)
        {
            String[] resultado = new String[1];

            try
            {

                this.criteriosTableAdapter.modificarCriterio(criterioNuevo.NombreCriterio, criterioNuevo.Escenario, 
                criterioNuevo.Contexto, criterioNuevo.Resultado, criterioNuevo.IdRequerimiento, idCriterioViejo);
            
                resultado[0] = "Éxito";
            }
            catch (SqlException ex)
            {

                int n = ex.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }

            }
            return resultado;
        }

        /*
         * Procedimiento que recibe el identificador del Requerimiento a eliminar y utiliza el adaptador del 
         * 'DataSet' para realizar la eliminación de este. Retorna un String[] con el estado de la transacción.               
         */
        public string[] eliminarCriterio(int idCriterio)
        {
            String[] resultado = new String[1];

            try
            {
                this.criteriosTableAdapter.eliminarCriterio(idCriterio);
                resultado[0] = "Éxito";
            }
            catch (SqlException ex)
            {

                int n = ex.Number;
                if (n == 2627)
                {
                    resultado[0] = "Error";
                }
                else
                {
                    resultado[0] = "Error";
                }

            }
            return resultado;
        }

        /*
         * Procedimiento que retorna el identificador de un Criterio de Aceptación a partir de su nombre
         * y el identificador del Requerimiento al que pertenece.
         */
        public int getIdCriterio(string nombreCriterio, int idRequerimiento)
        {
            int idCriterio = -1;
            try
            {
                idCriterio = Int32.Parse(this.criteriosTableAdapter.getIdCriterio(nombreCriterio, idRequerimiento).ToString());
            }
            catch (Exception ex)
            {


            }

            return idCriterio;
        }

        /*
         * Método que retorna una estructura 'DataTable' con la información de los Criterios de Aceptación
         * asociados a un Requerimiento específico.
         */
        public DataTable getCriteriosDeRequerimiento(int idRequerimiento)
        {

            DataTable resultado = new DataTable();

            try
            {
                resultado = this.adapCriterios2.getCriteriosDeRequerimiento(idRequerimiento);

            }
            catch (Exception ex)
            {


            }

            return resultado;

        }

        /*
         * Método que retorna una estructura 'DataTable' con la información de los Requerimientos
         * asociados a un Proyecto específico.
         */
        public DataTable getRequerimientosDeProyecto(int idProyecto)
        {

            DataTable resultado = new DataTable();

            try
            {
                resultado = this.adpatadorAux.getRequerimientosDeProyecto(idProyecto);

            }
            catch (Exception ex)
            {


            }

            return resultado;

        }

        /*
         * Retorna una estructura 'DataTable' con la información de un Criterio de Aceptación específico
         * a partir del identificador de este.
         */
        public DataTable getCriterio(int idCriterio)
        {

            DataTable resultado = new DataTable();

            try
            {
                resultado = this.criteriosTableAdapter.getCriterio(idCriterio);

            }
            catch (Exception ex)
            {


            }

            return resultado;
        

        }

    }
}