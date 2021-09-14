using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace crud_2021
{
    public class Empleado
    {
        ConexionBD conectar;

        private DataTable drop_puesto()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            string strConsulta = string.Format("SELECT id_puesto as id,puesto FROM puestos;");
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public void drop_puesto(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<<< Elige Puesto >>>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_empleados()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            string strConsulta = string.Format("SELECT e.id_empleados as id,e.codigo,e.nombres,e.apellidos,e.direccion,e.telefono, p.puesto, e.fecha_nacimiento, p.id_puesto FROM empleados as e inner join puestos as p on e.id_puesto = p.id_puesto order by id_empleados;");
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta,conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public void grid_empleados(GridView grid)
        {
            grid.DataSource = grid_empleados();
            grid.DataBind();

        }
    }
}