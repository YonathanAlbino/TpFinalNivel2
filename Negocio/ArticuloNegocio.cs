using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Conexion_Base_de_datos;
using Helper;


namespace Negocio
{
    public class ArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        HelpClass help = new HelpClass();
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            
            try
            {
                datos.setearConsulta("select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion Marca, C.Descripcion Categoria from ARTICULOS A, MARCAS M, CATEGORIAS C  where A.IdMarca = M.Id and A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo((string)datos.Lector["Marca"], (string)datos.Lector["Categoria"]);
                    
                    aux.Id = (int)datos.Lector["Id"];

                    if(!(help.validarColumnaNula(datos.Lector, "Codigo")))
                        aux.Codigo = (string)datos.Lector["Codigo"];

                    if(!(help.validarColumnaNula(datos.Lector, "Nombre")))
                        aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(help.validarColumnaNula(datos.Lector, "Descripcion")))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(help.validarColumnaNula(datos.Lector, "ImagenUrl")))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(help.validarColumnaNula(datos.Lector, "Precio")))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    public void agregar(Articulo nuevo)
        {
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)values(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.MarcaArticulo.Id);
                datos.setearParametro("@IdCategoria", nuevo.CategoriaArticulo.Id);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
