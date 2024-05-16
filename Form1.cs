using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploPrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string rol = txtRol.Text;
    
            string query = "INSERT INTO dbo.usuarios (id, name, rol) VALUES (" + id + ", '" + nombre + "', '" + rol + "')";

            // MessageBox.Show(query);
            try{ 
                SqlConnection conexion = new SqlConnection("server=IQQ042MDALU0206; database=prueba ; integrated security = true");
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                int resultado = comando.ExecuteNonQuery();
                if( resultado == 0 )
                {
                    MessageBox.Show("Registro no insertado");
                }
                else
                {
                    MessageBox.Show("Registros Agregado exitosamente");
                }
                conexion.Close();
                txtId.Text = "";
                txtNombre.Text = "";
                txtRol.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string query = "DELETE FROM dbo.usuarios WHERE id = " + id;

            if ( id.Length > 0)
            {
                try
                {
                    SqlConnection conexion = new SqlConnection("server=IQQ042MDALU0206; database=prueba ; integrated security = true");
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    int resultado = comando.ExecuteNonQuery();
                    if( resultado == 0 )
                    {
                        MessageBox.Show("Registro no existe");
                    }
                    else
                    {
                        MessageBox.Show("Registros Eliminado exitosamente");
                    }
                    conexion.Close();
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtRol.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;    // id a actualizar
            string nombre = txtNombre.Text;
            string rol = txtRol.Text;

            string query = "UPDATE dbo.usuarios SET name= '" + nombre + "', rol = '" + rol + "' WHERE id = " + id;
            //MessageBox.Show(query);
            if ( id.Length > 0 )
            {
                try
                {
                    SqlConnection conexion = new SqlConnection("server=IQQ042MDALU0206; database=prueba ; integrated security = true");
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado == 0)
                    {
                        MessageBox.Show("Registro NO Actualizado");
                    }
                    else
                    {
                        MessageBox.Show("Actualizacion Existosa");
                    }
                    conexion.Close();
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtRol.Text = "";
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
