using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_Martos_Stefania
{
    public partial class CreateReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int DevolverTipo()
        {
            if(dpTipo.SelectedItem.Text == "Debe")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
      
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMonto.Text.Trim()))
            {
                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                try
                {
                    // agregar CUENTA
                    string addCta = $"insert into RegistrosContables(idCuenta, monto, tipo) values (@idCuenta, @monto, @tipo)";
                    SqlCommand comando = new SqlCommand(addCta, conexion);

                    comando.Parameters.AddWithValue("@idCuenta", DdlCuenta.SelectedValue);
                    comando.Parameters.AddWithValue("@monto", txtMonto.Text);
                    comando.Parameters.AddWithValue("@tipo", DevolverTipo());
                    comando.ExecuteNonQuery();
                    conexion.Close();
                 //   lblInfo.Text = "LA cuenta se registro Correctamente";
                    DdlCuenta.DataBind();
                }
                catch (Exception)
                {

                   // lblInfo.Text = "la Cuenta no se pudo registrar";
                }



            }
        }
    }
}