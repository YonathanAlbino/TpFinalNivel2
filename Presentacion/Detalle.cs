using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class Detalle : Form
    {
        public Detalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }
        private Articulo articulo;

        private void Detalle_Load(object sender, EventArgs e)
        {

            cargar();

        }

        private void cargar()
        {
            try
            {
                listBox1.DataBindings.Clear();

                listBox1.Items.Add("Código: " + "  " + articulo.Codigo);
                listBox1.Items.Add("Nombre:" + "  " + articulo.Nombre);
                listBox1.Items.Add("Descripción:" + "  " + articulo.Descripcion);
                listBox1.Items.Add("Marca:" + "  " + articulo.MarcaArticulo.Descripcion);
                listBox1.Items.Add("Categoría:" + "  " + articulo.CategoriaArticulo.Descripcion);
                listBox1.Items.Add("Precio:" + "  " + articulo.Precio.ToString("0.00"));
                listBox1.Items.Add("Url Imagen: " + " " + articulo.ImagenUrl);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if(listBox1.SelectedItem != null)
                    txtDetalle.Text = listBox1.SelectedItem.ToString();
            }
            catch (Exception ex) 
            {

                  MessageBox.Show(ex.Message);
            }
        }

       
    }
}
