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
using System.IO;
using System.Configuration;



namespace Presentacion
{
    public partial class FrmAltaArticulo : Form
    {
        public FrmAltaArticulo(string Text, Articulo articulo)
        {
            InitializeComponent();
            this.Text = Text;
            this.articulo = articulo;
            ArchivoEnModificar.FileName = articulo.ImagenUrl;
        }

        public FrmAltaArticulo(string Text)
        {
            InitializeComponent();
            this.Text = Text;
        }

        HelpClass help = new HelpClass();
        private Articulo articulo = null; 
        private bool actualizarDGV = false;
        private OpenFileDialog archivo = null;
        private OpenFileDialog ArchivoEnModificar = new OpenFileDialog(); //Se carga al intentar modificar un Articulo
        string rutaArchivoLocal = ConfigurationManager.AppSettings["Articulo-app"];


        private void cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            CategoriaNegocio negocio1 = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = negocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = negocio1.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    help.cargarImagen(pcbAltaArticulo, articulo.ImagenUrl);
                    txtCodigoArt.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagen.Text = articulo.ImagenUrl;
                    txtPrecio.Text = articulo.Precio.ToString("0.00");
                    cboMarca.SelectedValue = articulo.MarcaArticulo.Id;
                    cboCategoria.SelectedValue = articulo.CategoriaArticulo.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

       private bool validarAlta()
        {
            try
            {
               List<TextBox> lista = new List<TextBox>();
                lista.Add(txtCodigoArt);
                lista.Add(txtNombre);
                lista.Add(txtPrecio);

                foreach (var item in lista)
                {
                    if (help.ValidarVacio(item.Text))
                    {
                        item.BackColor = Color.Red;
                        lblCamposVacios.Visible = true;
                        return true;
                    }
                    else
                    {
                        item.BackColor = Color.White;
                        lblCamposVacios.Visible = false;
                    }
                }
                if (txtPrecio.Text.Contains("."))
                {
                    lblComa.Visible = true;
                    
                }

                    if (!(help.soloNumerosInsertPrecio(txtPrecio.Text)))
                    {
                        MessageBox.Show("Formato incorrecto para el campo precio");
                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarAlta())
                    return;

                
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

                if (articulo.Id == 0)
                {
                    if(archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
                    {
                        if(File.Exists(help.obtenerRuta(rutaArchivoLocal, archivo.SafeFileName))) //Verifica si el archivo ya existe en la carpeta
                        {
                            if(help.validarSiNo("El archivo ya existe en la carpeta, ¿Desea sobreescribirlo?", "Imagen local..."))
                            {
                                File.Copy(archivo.FileName, rutaArchivoLocal + archivo.SafeFileName, true);
                            }
                        }
                        else
                        {
                            File.Copy(archivo.FileName, rutaArchivoLocal + archivo.SafeFileName);
                        }
                    }

                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                    actualizarDGV = true;

                }
                else
                {
                    if (archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
                    {
                        if (ArchivoEnModificar.FileName != archivo.FileName) //Verifica si la imagen cambio al hacer una modificacion
                        {
                            if (File.Exists(help.obtenerRuta(rutaArchivoLocal, ArchivoEnModificar.SafeFileName))) //Verifica si la imagen anterior continua en la carpeta local
                            {
                                if (help.validarSiNo("¿Desea borrar la imagen anterior?", "Imagen local.."))
                                {
                                    File.Delete(help.obtenerRuta(rutaArchivoLocal, ArchivoEnModificar.SafeFileName));
                                }
                            }
                            if (!(File.Exists(help.obtenerRuta(rutaArchivoLocal, archivo.SafeFileName)))) //Verifica si en la carpeta ya hay un archivo igual al que se intenta guardar
                                File.Copy(archivo.FileName, rutaArchivoLocal + archivo.SafeFileName);
                            else
                            {
                                MessageBox.Show("Ya existe un archivo con el mismo nombre en la carpeta");
                            }
                        }
                    }
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                    actualizarDGV = true;
                }
                Close();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.Data.SqlClient.SqlException))
                    MessageBox.Show("Uno o mas datos no son permitidos en la base de datos. (Posiblemente la dirección url de la imagen).");
                else
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
                if(help.validarSiNo("También se eliminaran los registros asociados a esta marca. ¿Desea continuar?", "Eliminando.."))
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
               if(help.validarSiNo("También se eliminaran los registros asociados a esta categoría. ¿Desea continuar?", "Eliminando"))
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

        private void btnAgregarImagenLocal_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            try
            {
                archivo.Filter = "jpg|*.jpg|png|*.png";

                if(archivo.ShowDialog() == DialogResult.OK)
                {
                    txtImagen.Text = archivo.FileName;
                    help.cargarImagen(pcbAltaArticulo, txtImagen.Text);

                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
