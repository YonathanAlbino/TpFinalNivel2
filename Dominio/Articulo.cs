﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public Articulo(string MarcaArticulo, string CategoriaArticulo)
        {
            this.MarcaArticulo = new Marca();
            this.MarcaArticulo.Descripcion = MarcaArticulo;

            this.CategoriaArticulo = new Categoria();
            this.CategoriaArticulo.Descripcion = CategoriaArticulo;
        }
        public Articulo()
        {

        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca MarcaArticulo { get; set; }
        public Categoria CategoriaArticulo { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
    }
}