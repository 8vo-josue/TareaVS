using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace web_umg_2021
{
    public class ConexionBD
    {
        private string contenido = "server=localhost; database=db_empresa_2021; user=root; password=Mysql1234";
        public MySqlConnection conectar = new MySqlConnection();
        public MySqlDataAdapter adapador = new MySqlDataAdapter();


        public void AbrirConexion()
        {
            try
            {
                string sConn;
                sConn = contenido;
                conectar = new MySqlConnection();
                conectar.ConnectionString = sConn;
                conectar.Open();
                System.Diagnostics.Debug.WriteLine("Conexion Exitosa");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        public void CerrarConexion()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}