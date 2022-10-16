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
        Articulo articulo;
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

                if(cboMarca.SelectedItem == null) //Verifica si al momento de dar aceptar se agrego una nueva marca
                {
                    Marca nueva = new Marca();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    nueva.Descripcion = cboMarca.Text;
                    marcaNegocio.agregar(nueva);

                    List<Marca> lista = marcaNegocio.listar();
                    articulo.MarcaArticulo = lista.Find(x => x.Descripcion == nueva.Descripcion);
                    
                }
                if(cboCategoria.SelectedItem == null) //Verifica si al momento de dar aceptar se agrego una nueva categoria
                {
                    Categoria nueva = new Categoria();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    nueva.Descripcion = cboCategoria.Text;
                    categoriaNegocio.agregar(nueva);

                    List<Categoria> lista = categoriaNegocio.listar();
                    articulo.CategoriaArticulo = lista.Find(x => x.Descripcion == nueva.Descripcion);
                }
                
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

        private void btbAgregarMarca_Click(object sender, EventArgs e)
        {
            Marca nueva = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                nueva.Descripcion = cboMarca.Text;

                if(help.existeComboBox(cboMarca, nueva.Descripcion))
                {
                    MessageBox.Show("Ya existe la marca que desea agregar");
                    return;
                }

                negocio.agregar(nueva);
                MessageBox.Show("Nueva marca agregada");
                cboMarca.DataSource = negocio.listar();
                cboMarca.Text = nueva.Descripcion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            Marca seleccionada;
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                if(help.validarSiNo("¿Desea eliminar esta marca?", "Eliminando.."))
                {
                    seleccionada = (Marca)cboMarca.SelectedItem;
                    negocio.eliminarMarca(seleccionada);
                    cboMarca.DataSource = negocio.listar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnAgregarDescripcion_Click(object sender, EventArgs e)
        {
            Categoria nueva = new Categoria();
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                nueva.Descripcion = cboCategoria.Text;
                if(help.existeComboBox(cboCategoria, nueva.Descripcion))
                {
                    MessageBox.Show("Ya existe la categoria que desea agregar");
                    return;
                }

                negocio.agregar(nueva);
                MessageBox.Show("Nueva categoria agregada");
                cboCategoria.DataSource = negocio.listar();
                cboCategoria.Text = nueva.Descripcion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEliminarDescripcion_Click(object sender, EventArgs e)
        {
            Categoria seleccionada = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
               if(help.validarSiNo("¿Desea eliminar esta categoria?", "Eliminando"))
                {
                    seleccionada = (Categoria)cboCategoria.SelectedItem;
                    categoriaNegocio.eliminarCategoria(seleccionada);
                    cboCategoria.DataSource = categoriaNegocio.listar();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            try
            {
                help.cargarImagen(pcbAltaArticulo, txtImagen.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
