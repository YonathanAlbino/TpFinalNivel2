using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Helper;
using Negocio;

namespace Presentacion
{
    public partial class FrmAltaArticulo : Form
    {
        public FrmAltaArticulo(string Text)
        {
            InitializeComponent();
            this.Text = Text;
        }

        HelpClass help = new HelpClass();
        Articulo articulo = new Articulo();
        private bool actualizarDGV = false;

        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            CategoriaNegocio negocio1 = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = negocio.listar();
                cboCategoria.DataSource = negocio1.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                articulo.Codigo = txtCodigoArt.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.MarcaArticulo = (Marca)cboMarca.SelectedItem;
                articulo.CategoriaArticulo = (Categoria)cboCategoria.SelectedItem;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                negocio.agregar(articulo);
                MessageBox.Show("Agregado exitosamente");
                actualizarDGV = true;
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        public bool actualizarDgv()
        {
            return actualizarDGV;
        }

      
    }
}
