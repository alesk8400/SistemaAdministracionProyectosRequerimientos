//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using SAPR.App_Code.Entidades;
//using System.Data.SqlClient;



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
        


        //Constructor que inicializa adapters

        public ControladoraBDRequerimiento() {
            requerimientoTableAdapter = new RequerimientoAdapter();
            criteriosTableAdapter = new CriteriosTableAdapter();            
        }


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

        public DataTable getRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto)
        {
            DataTable resultado = new DataTable();
            try{

                resultado = this.requerimientoTableAdapter.getRequerimiento(nombreRequerimiento, idModulo, idProyecto);


            } catch(Exception ex){
            
            
            }

            return resultado;

        }

        public int getIdRequerimiento(String nombreRequerimiento, int idModulo, int idProyecto) {

            int idRequerimiento = -1;
            try{
                idRequerimiento = Int32.Parse(this.requerimientoTableAdapter.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto).ToString());
            }
            catch (Exception ex) {
                
            
            }

            return idRequerimiento;
        }

        public DataTable getRequerimientos() {

            DataTable resultado = new DataTable();

            try {
                resultado = this.requerimientoTableAdapter.GetData();
            
            } catch (Exception ex){

                
            }

            return resultado;

        }

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

        public DataTable getCriteriosDeRequerimiento(int idRequerimiento)
        {

            DataTable resultado = new DataTable();

            try
            {
                resultado = this.criteriosTableAdapter.getCriteriosDeRequerimiento(idRequerimiento);

            }
            catch (Exception ex)
            {


            }

            return resultado;

        }

        public DataTable getCriteriosDeProyecto(int idProyecto)
        {

            DataTable resultado = new DataTable();

            try
            {
                //resultado = this.criteriosTableAdapter.getCriteriosDeProyecto(idProyecto);

            }
            catch (Exception ex)
            {


            }

            return resultado;

        }

        public DataTable getCriterio(String nombreCriterio, int idRequerimiento) {

            DataTable resultado = new DataTable();

            try
            {
                resultado = this.criteriosTableAdapter.getCriterio(nombreCriterio, idRequerimiento);

            }
            catch (Exception ex)
            {


            }

            return resultado;
        

        }


    }
}