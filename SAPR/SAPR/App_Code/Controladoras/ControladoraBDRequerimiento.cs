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
            try{//**********Revisar casteo****************
                idRequerimiento = (int)this.requerimientoTableAdapter.getIdRequerimiento(nombreRequerimiento, idModulo, idProyecto);
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
    }
}