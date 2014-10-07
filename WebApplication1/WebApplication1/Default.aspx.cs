using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DataSet1TableAdapters;

namespace WebApplication1
{
    
    public partial class mierda
    {
        DataSet1 da;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public mierda(){
            da = new DataSet1();
        }

        public void insertar() {
            da.Insert(1, "Juan", "hj", "nj", "08/08/2014", "08/08/2014", "08/08/2014");
        }

    }
}