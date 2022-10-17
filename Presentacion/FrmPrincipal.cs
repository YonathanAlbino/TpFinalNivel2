﻿using System;
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
                List<Articulo> lista = new List<Articulo>();
                ArticuloNegocio negocio = new ArticuloNegocio();
                lista = negocio.listar();
                dgvArticulos.DataSource = lista;
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
