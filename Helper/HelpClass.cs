using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dominio;


namespace Helper
{
    public class HelpClass
    {
        public void cargarImagen(PictureBox pcb, string urlImagen)
        {
            try
            {
                pcb.Load(urlImagen);
            }
            catch (Exception)
            {
                pcb.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }
        public void cambiarFormatoDgv(DataGridView grilla, string columna, string formato)
        {
            try
            {
                grilla.Columns[columna].DefaultCellStyle.Format = formato;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool validarColumnaNula(SqlDataReader lector, string columna)
        {
            try
            {
                if (lector[columna] is DBNull)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool validarSiNo(string texto, string titulo)
        {
            DialogResult respuesta = MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public bool existeComboBox(ComboBox comboBox, string nuevaInclusion)
        {
            try
            {
                int i;
                i = comboBox.FindStringExact(nuevaInclusion);
                if (i != -1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string obtenerRuta(string ruta, string nombreArchivo)
        {
            try
            {
                string rutaComleta = ruta + @"\" + nombreArchivo;
                return rutaComleta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool soloNumeros(string cadena)
        {
            foreach (char item in cadena)
            {
                if (!(char.IsNumber(item)))
                {
                    return false;
                }
            }
            return true;
        }
        public bool SoloLetrasONumeros(string cadena)
        {
            foreach (char item in cadena)
            {
                if (!(char.IsLetterOrDigit(item)))
                {
                    return false;
                }
                else if(item.ToString() == "ª" || item.ToString() == "º")
                {
                    return false;
                }
            }
            return true;
        }

        public bool soloLetras(string cadena)
        {
            foreach (char item in cadena)
            {
                if (!(char.IsLetter(item)))
                {
                    return false;
                }
            }
            return true;

        }

        public bool ValidarVacio(string control)
        {
            if (string.IsNullOrEmpty(control))
               return true;
            return false;
        }

        public bool comboBoxVacio(List<ComboBox> lista)
        {
            foreach (var item in lista)
            {
                if(item.SelectedItem == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
