using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_Martos_Stefania
{
    public partial class CreateCta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcuenta.Text.Trim()))
            {
                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                try
                {
                    // agregar CUENTA
                    string addCta = $"insert into Cuentas(descripcion) values ('{txtcuenta.Text.Trim()}')";
                    SqlCommand comando = new SqlCommand(addCta, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    lblInfo.Text = "LA cuenta se registro Correctamente";
                    dpLCuentas.DataBind();
                }
                catch (Exception)
                {

                    lblInfo.Text = "la Cuenta no se pudo registrar";
                }



            }

        }

        protected void dpLCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcuenta.Text = dpLCuentas.SelectedItem.Text;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcuenta.Text))
            {
             
                    string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                    SqlConnection conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    try
                    {
                        // agregar CUENTA
                        string addCta = $"update  Cuentas set descripcion = @descripcion where id = @id";
                        SqlCommand comando = new SqlCommand(addCta, conexion);
                        comando.Parameters.AddWithValue("@descripcion", txtcuenta.Text.Trim());
                        comando.Parameters.AddWithValue("@id", dpLCuentas.SelectedValue);
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        lblInfo.Text = "La cuenta se actualizó Correctamente";
                        dpLCuentas.DataBind();
                    }
                    catch (Exception)
                    {

                        lblInfo.Text = "la Cuenta no se pudo actualizar";
                    }




            
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcuenta.Text))
            {

                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                try
                {
                    // agregar CUENTA
                    string addCta = $"delete  Cuentas where id = @id";
                    SqlCommand comando = new SqlCommand(addCta, conexion);
            
                    comando.Parameters.AddWithValue("@id", dpLCuentas.SelectedValue);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    lblInfo.Text = "La cuenta se eliminó Correctamente";
                    dpLCuentas.DataBind();
                }
                catch (Exception)
                {

                    lblInfo.Text = "la Cuenta no se pudo eliminar";
                }





            }

        }
    }
}