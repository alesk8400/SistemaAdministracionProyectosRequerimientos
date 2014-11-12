using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SAPR.App_Code.Entidades;

namespace SAPR.App_Code.Controladoras
{
    /*
     Clase controladora de estructura que maneja los métodos para Sprints y módulos
     */
    public class ControladoraEstructura{
        ControladoraBDEstructura controladoraBDEstructura;
        ControladoraProyecto controladoraProyecto;

        /*
            Constructor que inicializa el objeto controladoraBDEstructura y controladoraProyecto para manajar base de datos y solicitar datos de proyecto
         */
        public ControladoraEstructura() {
            controladoraBDEstructura = new ControladoraBDEstructura();
            controladoraProyecto = new ControladoraProyecto();
        }

        /*
         Método que recibe nombre, descripción y el nombre del proyecto, deja los datos del Sprint en un objeto vector que es encapsulado en la entidad Sprint, 
         se solicita el ID de Proyecto con el nombre y se manda la controladora BD a insertar un Sprint.
         */
        public String[] insertarSprint(String nombre, String descripcion,String nombreProyecto)
        {
            Object[] datos = new Object[2];  //Se crea un objeto con los datos del sprint
            int idProyecto=0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadSprint sprint = new EntidadSprint(datos);  //Se encapsulan los datos del sprint
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.insertarSprint(sprint, idProyecto);
        }

        /*
         Método que recibe nombre, descripción, el nombre del proyecto y la entidad del Sprint viejo, deja los datos del Sprint en un objeto vector que es
         encapsulado en la entidad Sprint, se solicita el ID de Proyecto con el nombre y se manda la controladora BD a modificar enviandole el Sprint nuevo, 
         el id del proyecto y el nombre del sprint viejo.
         */
        public string[] modificarSprint(String nombre, String descripcion, String nombreProyecto,EntidadSprint sprintViejo)
        {
            Object[] datos = new Object[2];
            int idProyecto = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadSprint sprintNuevo = new EntidadSprint(datos);  //se encapsulan los datos del sprint a modificar
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.modificarSprint(sprintNuevo, idProyecto, sprintViejo.Nombre);
        }

        /*
         Método que recibe nombre del sprint y el nombre del proyecto, solicita el ID de Proyecto con el nombre y se manda la controladora BD a eliminar 
         */
        public String[] eliminarSprint(String nombreSprint, String nombreProyecto)
        { 
            int idProyecto = 0;
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.eliminarSprint(nombreSprint,idProyecto);
        }

        /*
         Método que solicita los datos de un Sprint a la controladora de BD, los encapsula en la entidad y lo retorna, recibiendo el nombre del sprint y el nombre del proyecto
         */
        public EntidadSprint consultarSprint(String nombreSprint,String nombreProyecto)
        {  
            EntidadSprint sprint = null; //para encapsular los datos consultados.
            Object[] datosConsultados = new Object[2]; //para guardar los datos obtenidos de la consulta temporalmente
            int idProyecto = 0;
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            DataTable filaSprint = controladoraBDEstructura.consultarSprint(nombreSprint,idProyecto);

            if (filaSprint.Rows.Count == 1)
            { //se recorre el dataTable de estructura tomando los datos de los sprint
                for (int i = 0; i < 2; i++)
                {
                    datosConsultados[i] = filaSprint.Rows[0][i].ToString();
                }
                sprint = new EntidadSprint(datosConsultados); //se encapsulan los datos del sprint
            }
            return sprint;
        }

        /*
         Método que recibe nombre, descripción, nombre del sprint y el nombre del proyecto, deja los datos del Sprint en un objeto vector que es encapsulado en la entidad módulo, 
         se solicita el ID del Sprint con el nombre y nombre de proyecto y se manda la controladora BD a insertar un Módulo.
         */
        public String[] insertarModulo(String nombre, String descripcion, String nombreSprint, String nombreProyecto)
        {
            Object[] datos = new Object[2];  //Se crea un objeto con los datos del sprint
            int idSprint = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadModulo modulo = new EntidadModulo(datos);  //Se encapsulan los datos del sprint
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            return controladoraBDEstructura.insertarModulo(modulo, idSprint);
        }

        /*
         Método que recibe el nombre del sprint y el nombre del proyecto, manda la controladora de proyecto a obtener el ID y a la controladora BD a obtener el ID con el nombre 
         del Sprint y el id del proyecto
         */
        public int getIdSprint(String nombreSprint, String nombreProyecto) { //Requiere el proyecto para que en la consulta solo busque los sprints de ese proyecto. (No debe haber nombres de sprints iguales en un mismo proyecto)
            int idProyecto = 0;
            idProyecto = controladoraProyecto.getIdProyecto(nombreProyecto);
            return controladoraBDEstructura.getIdSprint(nombreSprint, idProyecto);
        }

        /*
         Método que recibe nombre, descripción, nombre del sprint, nombre del proyecto y la entidad del Módulo viejo, deja los datos del Módulo en un objeto vector que es
         encapsulado en la entidad Módulo, se solicita el ID del Sprint con el nombre y se manda la controladora BD a modificar enviandole el Módulo nuevo, 
         el id del Sprint y el nombre del módulo viejo.
         */
        public string[] modificarModulo(String nombre, String descripcion, String nombreSprint, String nombreProyecto, EntidadModulo moduloViejo) //En un sprint no deben existir módulos con el mismo nombre
        {
            Object[] datos = new Object[2];
            int idSprint = 0;
            datos[0] = nombre;
            datos[1] = descripcion;
            EntidadModulo moduloNuevo = new EntidadModulo(datos);  //se encapsulan los datos del modulo a modificar
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            return controladoraBDEstructura.modificarModulo(moduloNuevo, idSprint, moduloViejo.Nombre);
        }

        /*
         Método que recibe nombre del módulo, el nombre del sprint y el nombre del proyecto, solicita el ID del sprint con el nombre y se manda la controladora BD a
         eliminar el módulo
         */
        public String[] eliminarModulo(String nombreModulo, String nombreSprint, String nombreProyecto)
        { //Requiere mandar el id del sprint para poder identificar cual módulo se eliminará, con solo el nombre no se puede saber
            int idSprint = 0;
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            return controladoraBDEstructura.eliminarModulo(nombreModulo, idSprint);
        }

        /*
         Método que solicita los datos de un Módulo a la controladora de BD con el nombre del módulo y el id del sprint, los encapsula en la entidad y lo retorna
         */
        public EntidadModulo consultarModulo(String nombreModulo, String nombreSprint, String nombreProyecto)
        { //Requiere mandar el id del sprint para poder identificar cual módulo se consultará, con solo el nombre no se puede saber
            int idSprint = 0;
            EntidadModulo modulo = null; //para encapsular los datos consultados.
            Object[] datosConsultados = new Object[2]; //para guardar los datos obtenidos de la consulta temporalmente
            idSprint = this.getIdSprint(nombreSprint, nombreProyecto);
            DataTable filaModulo = controladoraBDEstructura.consultarModulo(nombreModulo, idSprint);

            if (filaModulo.Rows.Count == 1)
            { //se recorre el dataTable de estructura tomando los datos del módulo
                for (int i = 0; i < 2; i++)
                {
                    datosConsultados[i] = filaModulo.Rows[0][i].ToString();
                }
                modulo = new EntidadModulo(datosConsultados); //se encapsulan los datos del modulo
            }
            return modulo;
        }

        /*
         Método que solicita a la controladora de BD todos los sprints de un proyecto, con su id
         */
        public DataTable getSprints(int proyecto)
        {
            return controladoraBDEstructura.getSprints(proyecto);
        }

        /*
         Método que solicita a la controladora de BD todos los módulo de un sprint, con su id
         */
        public DataTable getModulo(int sprintId)
        {
            return controladoraBDEstructura.getModulo(sprintId); ;
        }

        /*
         Método que solicita a la controladora de BD todos los requeriminetos de un módulo, con su id
         */
        public DataTable getRequerimientos(int moduloId)
        {
            return controladoraBDEstructura.getRequerimientos(moduloId); ;
        }

        /*
         Método que solicita a la controladora de BD todos los nombres de sprint de un proyecto con su id
         */
        public DataTable getNombresSprint(int proyecto)
        {
            DataTable resultado = crearTablaSprint(); //Este método crea la tabla

            Object[] datos = new Object[2];
            try
            {
                DataTable consulta = controladoraBDEstructura.getSprints(proyecto);
                if (consulta.Rows.Count > 0)
                {
                    foreach (DataRow fila in consulta.Rows)
                    {
                        datos[0] = fila[0].ToString(); // Van los Nombres
                        datos[1] = fila[2].ToString(); // Van los ids del sprint
                        resultado.Rows.Add(datos);// cargar en la tabla los datos de cada usuario
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
          Método que crea la tabla de Sprints con solo el nombre y el id como columnas
          */
        protected DataTable crearTablaSprint()
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
            columna.ColumnName = "Identificador";
            tabla.Columns.Add(columna);


            return tabla;
        }


        /*
          Método que crea la tabla de proyectos con solo el nombre y el id como columnas
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
         Método que solicita a la controladora de BD todos los nombres de un proyecto con su id
         */
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
                        datos[1] = fila[0].ToString(); // Van los ids del sprint
                        resultado.Rows.Add(datos);// cargar en la tabla los datos de cada usuario
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
         Método que solicita a la controladora de BD todos los nombres de un módulo, con id del sprint
         */
        public DataTable getNombresModulo(int idSprint)
        {
            return controladoraBDEstructura.getModulo(idSprint);
        }
    }
}