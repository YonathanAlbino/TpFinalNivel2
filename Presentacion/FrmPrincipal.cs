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
                
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                FrmAltaArticulo ventana = new FrmAltaArticulo("Modificar el articulo", seleccionado);
                ventana.ShowDialog();
                if (ventana.actualizarDgv())
                    cargar();
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
                    listaFiltrada = lista.FindAll(x => x.MarcaArticulo.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.CategoriaArticulo.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()));
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
    }
}
