namespace Presentacion
{
    partial class FrmAltaArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigoArticulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtCodigoArt = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtImagen = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lvlCategoria = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.btbAgregarMarca = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarMarca = new System.Windows.Forms.Button();
            this.pcbAltaArticulo = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagenLocal = new System.Windows.Forms.Button();
            this.lblCamposVacios = new System.Windows.Forms.Label();
            this.lblComa = new System.Windows.Forms.Label();
            this.lblVacioCboMarca = new System.Windows.Forms.Label();
            this.lblVacioCboCategoria = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAltaArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigoArticulo
            // 
            this.lblCodigoArticulo.AutoSize = true;
            this.lblCodigoArticulo.Location = new System.Drawing.Point(36, 52);
            this.lblCodigoArticulo.Name = "lblCodigoArticulo";
            this.lblCodigoArticulo.Size = new System.Drawing.Size(95, 13);
            this.lblCodigoArticulo.TabIndex = 0;
            this.lblCodigoArticulo.Text = "Código de articulo:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(36, 96);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(36, 140);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descipción:";
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Location = new System.Drawing.Point(36, 272);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(45, 13);
            this.lblImagen.TabIndex = 3;
            this.lblImagen.Text = "Imagen:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(36, 316);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtCodigoArt
            // 
            this.txtCodigoArt.Location = new System.Drawing.Point(158, 52);
            this.txtCodigoArt.Name = "txtCodigoArt";
            this.txtCodigoArt.Size = new System.Drawing.Size(121, 20);
            this.txtCodigoArt.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(158, 96);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(158, 140);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(121, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtImagen
            // 
            this.txtImagen.Location = new System.Drawing.Point(158, 274);
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Size = new System.Drawing.Size(121, 20);
            this.txtImagen.TabIndex = 5;
            this.txtImagen.Leave += new System.EventHandler(this.txtImagen_Leave);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(158, 318);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(121, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(39, 403);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(69, 21);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(179, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 21);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(36, 184);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 12;
            this.lblMarca.Text = "Marca:";
            // 
            // lvlCategoria
            // 
            this.lvlCategoria.AutoSize = true;
            this.lvlCategoria.Location = new System.Drawing.Point(36, 228);
            this.lvlCategoria.Name = "lvlCategoria";
            this.lvlCategoria.Size = new System.Drawing.Size(52, 13);
            this.lvlCategoria.TabIndex = 13;
            this.lvlCategoria.Text = "Categoria";
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(158, 184);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 21);
            this.cboMarca.TabIndex = 3;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(158, 229);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 21);
            this.cboCategoria.TabIndex = 4;
            // 
            // btbAgregarMarca
            // 
            this.btbAgregarMarca.Location = new System.Drawing.Point(315, 184);
            this.btbAgregarMarca.Name = "btbAgregarMarca";
            this.btbAgregarMarca.Size = new System.Drawing.Size(24, 23);
            this.btbAgregarMarca.TabIndex = 16;
            this.btbAgregarMarca.Text = "+";
            this.btbAgregarMarca.UseVisualStyleBackColor = true;
            this.btbAgregarMarca.Click += new System.EventHandler(this.btbAgregarMarca_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(315, 229);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(24, 23);
            this.btnAgregarCategoria.TabIndex = 17;
            this.btnAgregarCategoria.Text = "+";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarDescripcion_Click);
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Location = new System.Drawing.Point(345, 229);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(24, 23);
            this.btnEliminarCategoria.TabIndex = 18;
            this.btnEliminarCategoria.Text = "-";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarDescripcion_Click);
            // 
            // btnEliminarMarca
            // 
            this.btnEliminarMarca.Location = new System.Drawing.Point(345, 184);
            this.btnEliminarMarca.Name = "btnEliminarMarca";
            this.btnEliminarMarca.Size = new System.Drawing.Size(24, 23);
            this.btnEliminarMarca.TabIndex = 19;
            this.btnEliminarMarca.Text = "-";
            this.btnEliminarMarca.UseVisualStyleBackColor = true;
            this.btnEliminarMarca.Click += new System.EventHandler(this.btnEliminarMarca_Click);
            // 
            // pcbAltaArticulo
            // 
            this.pcbAltaArticulo.Location = new System.Drawing.Point(390, 24);
            this.pcbAltaArticulo.Name = "pcbAltaArticulo";
            this.pcbAltaArticulo.Size = new System.Drawing.Size(250, 330);
            this.pcbAltaArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAltaArticulo.TabIndex = 22;
            this.pcbAltaArticulo.TabStop = false;
            // 
            // btnAgregarImagenLocal
            // 
            this.btnAgregarImagenLocal.Location = new System.Drawing.Point(315, 271);
            this.btnAgregarImagenLocal.Name = "btnAgregarImagenLocal";
            this.btnAgregarImagenLocal.Size = new System.Drawing.Size(24, 23);
            this.btnAgregarImagenLocal.TabIndex = 23;
            this.btnAgregarImagenLocal.Text = "+";
            this.btnAgregarImagenLocal.UseVisualStyleBackColor = true;
            this.btnAgregarImagenLocal.Click += new System.EventHandler(this.btnAgregarImagenLocal_Click);
            // 
            // lblCamposVacios
            // 
            this.lblCamposVacios.AutoSize = true;
            this.lblCamposVacios.BackColor = System.Drawing.Color.White;
            this.lblCamposVacios.ForeColor = System.Drawing.Color.Red;
            this.lblCamposVacios.Location = new System.Drawing.Point(36, 359);
            this.lblCamposVacios.Name = "lblCamposVacios";
            this.lblCamposVacios.Size = new System.Drawing.Size(215, 13);
            this.lblCamposVacios.TabIndex = 24;
            this.lblCamposVacios.Text = "Los campos en rojo no pueden estar vacíos";
            this.lblCamposVacios.Visible = false;
            // 
            // lblComa
            // 
            this.lblComa.AutoSize = true;
            this.lblComa.Location = new System.Drawing.Point(155, 341);
            this.lblComa.Name = "lblComa";
            this.lblComa.Size = new System.Drawing.Size(188, 13);
            this.lblComa.TabIndex = 25;
            this.lblComa.Text = "Utilice una coma para el campo precio";
            this.lblComa.Visible = false;
            // 
            // lblVacioCboMarca
            // 
            this.lblVacioCboMarca.AutoSize = true;
            this.lblVacioCboMarca.ForeColor = System.Drawing.Color.Red;
            this.lblVacioCboMarca.Location = new System.Drawing.Point(285, 189);
            this.lblVacioCboMarca.Name = "lblVacioCboMarca";
            this.lblVacioCboMarca.Size = new System.Drawing.Size(14, 13);
            this.lblVacioCboMarca.TabIndex = 26;
            this.lblVacioCboMarca.Text = "X";
            this.lblVacioCboMarca.Visible = false;
            // 
            // lblVacioCboCategoria
            // 
            this.lblVacioCboCategoria.AutoSize = true;
            this.lblVacioCboCategoria.ForeColor = System.Drawing.Color.Red;
            this.lblVacioCboCategoria.Location = new System.Drawing.Point(285, 232);
            this.lblVacioCboCategoria.Name = "lblVacioCboCategoria";
            this.lblVacioCboCategoria.Size = new System.Drawing.Size(14, 13);
            this.lblVacioCboCategoria.TabIndex = 27;
            this.lblVacioCboCategoria.Text = "X";
            this.lblVacioCboCategoria.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAltaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblVacioCboCategoria);
            this.Controls.Add(this.lblVacioCboMarca);
            this.Controls.Add(this.lblComa);
            this.Controls.Add(this.lblCamposVacios);
            this.Controls.Add(this.btnAgregarImagenLocal);
            this.Controls.Add(this.pcbAltaArticulo);
            this.Controls.Add(this.btnEliminarMarca);
            this.Controls.Add(this.btnEliminarCategoria);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.btbAgregarMarca);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.lvlCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtImagen);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigoArt);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigoArticulo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(678, 477);
            this.MinimumSize = new System.Drawing.Size(678, 477);
            this.Name = "FrmAltaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FrmAltaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAltaArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigoArticulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtCodigoArt;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtImagen;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lvlCategoria;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Button btbAgregarMarca;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnEliminarMarca;
        private System.Windows.Forms.PictureBox pcbAltaArticulo;
        private System.Windows.Forms.Button btnAgregarImagenLocal;
        private System.Windows.Forms.Label lblCamposVacios;
        private System.Windows.Forms.Label lblComa;
        private System.Windows.Forms.Label lblVacioCboMarca;
        private System.Windows.Forms.Label lblVacioCboCategoria;
        private System.Windows.Forms.Button button1;
    }
}