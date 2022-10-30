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
using Negocio;
using Helper;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HelpClass help = new HelpClass();
        private bool dgvArticulo = false;
        List<Articulo> lista;
        FrmAltaArticulo detalles = new FrmAltaArticulo("Detalles");

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo ventana = new FrmAltaArticulo("Agregar nuevo articulo");
            ventana.ShowDialog();
            if(ventana.actualizarDgv())
                cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            try
            {
               if(dgvArticulos.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Solo se permite modificar un articulo a la vez");
                    return;
                }

                if (dgvArticulos.CurrentRow.DataBoundItem != null)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    FrmAltaArticulo ventana = new FrmAltaArticulo("Modificar el articulo", seleccionado);
                    ventana.ShowDialog();
                    if (ventana.actualizarDgv())
                        cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnVerArticulosEliminados_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
                if(dgvArticulos.CurrentRow != null)
                {
                    Articulo seleccionado = new Articulo();
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    help.cargarImagen(pcbArticulos, seleccionado.ImagenUrl);
                }
        }
        private void cargar()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                lista = negocio.listar();
                
                dgvArticulos.DataSource = lista;

                if(lista.Count > 0)
                    help.cargarImagen(pcbArticulos, lista[0].ImagenUrl);
                
                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "0.00";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Articulo seleccionado;
        //    ArticuloNegocio negocio = new ArticuloNegocio();
        //    try
        //    {
        //        if(help.validarSiNo("¿Desea eliminar este Articulo?", "Eliminando"))
        //        {
        //            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
        //            negocio.eliminarFisico(seleccionado);
        //            dgvArticulo = true;
        //        }
        //        if (dgvArticulo)
        //            cargar();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void EliminarVarios_Click(object sender, EventArgs e)
        {
            List <Articulo> lista = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();
            string elLos = "el", articulo = "articulo";
            try
            {
                int contadorArticulos = dgvArticulos.SelectedRows.Count;
                if (contadorArticulos > 1)
                {
                    elLos = "los" + " " + contadorArticulos;
                    articulo = "articulos";
                }

               if(help.validarSiNo("¿Desea eliminar "+elLos+ " "+ articulo+"?", "Eliminando"))
                {
                    foreach (DataGridViewRow row in dgvArticulos.SelectedRows)
                    {
                        Articulo aux;
                        aux = (Articulo)row.DataBoundItem;
                        lista.Add(aux);
                        dgvArticulo = true;
                    }
                    negocio.eliminarVarios(lista);
                }

                if (dgvArticulo)
                    cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvArticulos.MultiSelect == true)
                dgvArticulos.MultiSelect = false;
            else
                dgvArticulos.MultiSelect = true;
        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            try
            {
                string filtro = txtFiltroRapido.Text;

                if(filtro.Length >=2)
                {
                    listaFiltrada = lista.FindAll(x => x.MarcaArticulo.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.CategoriaArticulo.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = lista;
                }
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaFiltrada;

                if (lista.Count > 0)
                    help.cargarImagen(pcbArticulos, lista[0].ImagenUrl);

                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void lblFiltro_Click(object sender, EventArgs e)
        {

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if(opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Igual");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Mayor a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
        private bool validarFiltro()
        {
            List<ComboBox> lista = new List<ComboBox>();
            lista.Add(cboCampo);
            lista.Add(cboCriterio);

            if (help.comboBoxVacio(lista))
            {
                MessageBox.Show("Uno o mas desplegables se encuentran vacios");
                return true;
            }

            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (help.ValidarVacio(txtFiltro.Text))
                {
                    MessageBox.Show("El filtro de busqueda se encuentra vacio");
                    return true;
                }

                if (!(help.soloNumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("Ingrese solo numeros para busquedas númericas");
                    return true;
                }
            }
            if (cboCampo.SelectedItem.ToString() == "Nombre")
            {
                if (!(help.soloLetras(txtFiltro.Text)))
                {
                    MessageBox.Show("Ingrese letras para busquedas por nombre");
                    return true;
                }
            }
            if(cboCampo.SelectedItem.ToString() == "Marca")
            {
                if (!(help.SoloLetrasONumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("Ingrese letras o números para busquedas por marca");
                    return true;
                }
            }

            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                dgvArticulos.DataSource = negocio.FiltroAvanzado(campo, criterio, filtro);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo seleccionado;
            
            try
            {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                Detalle detalle = new Detalle(seleccionado);
                detalle.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void dgvArticulos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            lblDetalle.Visible = false;
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblDetalle.Visible = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
