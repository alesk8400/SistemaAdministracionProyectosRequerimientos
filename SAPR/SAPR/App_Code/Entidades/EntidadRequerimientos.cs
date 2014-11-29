using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace SAPR.App_Code.Entidades
{
    public class EntidadRequerimientos{
        private int idModulo;
        private int idProyecto;
        private String nombre;
        private String descripcion;
        private int prioridad;
        private String estado;
        private int cantidad;
        private String medida;
        private byte[] archivo;


        /* 
         * Constructor de una Entidad Requerimiento con la
         * información especificada en el vector de datos 
         * que entra como parámetro.
         */
        public EntidadRequerimientos(Object[] datos) {
            this.idModulo = Int32.Parse(datos[0].ToString());
            this.idProyecto = Int32.Parse(datos[1].ToString());
            this.nombre = datos[2].ToString();
            this.descripcion = datos[3].ToString();
            this.prioridad = Int32.Parse(datos[4].ToString());
            this.estado = datos[5].ToString();
            this.cantidad = Int32.Parse(datos[6].ToString());
            this.medida = datos[7].ToString();
            this.archivo = ObjectToByteArray(datos[8]);
        }


        /*
         * Getters y Setters para cada atributo de la Entidad        
         */
        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public String Medida
        {
            get { return medida; }
            set { medida = value; }
        }

        public byte[] Archivo 
        {
            get { return archivo; }
            set { archivo = value; }
        
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