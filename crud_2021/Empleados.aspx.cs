using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud_2021
{
    public partial class empleados : System.Web.UI.Page
    {
        Empleado empleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                empleado = new Empleado();
                empleado.drop_puesto(drop_puesto);
                empleado.grid_empleados(grid_empleados);
            }
        }

        protected void grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            cn.CerrarConexion();

        }
    }
}