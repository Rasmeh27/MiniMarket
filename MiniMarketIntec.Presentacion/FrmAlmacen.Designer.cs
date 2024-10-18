namespace MiniMarketIntec.Presentacion
{
    partial class FrmAlmacen
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
            this.components = new System.ComponentModel.Container();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new Guna.UI.WinForms.GunaButton();
            this.txtBuscar = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtId = new Guna.UI.WinForms.GunaTextBox();
            this.btnActualizar = new Guna.UI.WinForms.GunaButton();
            this.btnCancelar = new Guna.UI.WinForms.GunaButton();
            this.btnRetornar = new Guna.UI.WinForms.GunaButton();
            this.btnGuardar = new Guna.UI.WinForms.GunaButton();
            this.txtDescripcion = new Guna.UI.WinForms.GunaTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new Guna.UI.WinForms.GunaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnElminar = new Guna.UI.WinForms.GunaButton();
            this.btnReporte = new Guna.UI.WinForms.GunaButton();
            this.btnNuevo = new Guna.UI.WinForms.GunaButton();
            this.btnSalida = new Guna.UI.WinForms.GunaButton();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Location = new System.Drawing.Point(12, 131);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(768, 253);
            this.tabPrincipal.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvListado);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(760, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(114, 74);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersWidth = 82;
            this.dgvListado.Size = new System.Drawing.Size(511, 150);
            this.dgvListado.TabIndex = 3;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AnimationHoverSpeed = 0.07F;
            this.btnBuscar.AnimationSpeed = 0.03F;
            this.btnBuscar.BaseColor = System.Drawing.Color.White;
            this.btnBuscar.BorderColor = System.Drawing.Color.LightGray;
            this.btnBuscar.BorderSize = 1;
            this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBuscar.FocusedColor = System.Drawing.Color.Empty;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscar.Image = null;
            this.btnBuscar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscar.Location = new System.Drawing.Point(491, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBuscar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBuscar.OnHoverImage = null;
            this.btnBuscar.OnPressedColor = System.Drawing.Color.Black;
            this.btnBuscar.Size = new System.Drawing.Size(114, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.Transparent;
            this.txtBuscar.BaseColor = System.Drawing.Color.White;
            this.txtBuscar.BorderColor = System.Drawing.Color.Silver;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBuscar.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtBuscar.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(194, 26);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.Radius = 5;
            this.txtBuscar.Size = new System.Drawing.Size(291, 42);
            this.txtBuscar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtId);
            this.tabPage2.Controls.Add(this.btnActualizar);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnRetornar);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.txtDescripcion);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(760, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.BaseColor = System.Drawing.Color.White;
            this.txtId.BorderColor = System.Drawing.Color.Silver;
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.FocusedBaseColor = System.Drawing.Color.White;
            this.txtId.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtId.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtId.Location = new System.Drawing.Point(411, 102);
            this.txtId.Name = "txtId";
            this.txtId.PasswordChar = '\0';
            this.txtId.Size = new System.Drawing.Size(160, 42);
            this.txtId.TabIndex = 9;
            this.txtId.Text = "gunaTextBox1";
            this.txtId.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.AnimationHoverSpeed = 0.07F;
            this.btnActualizar.AnimationSpeed = 0.03F;
            this.btnActualizar.BaseColor = System.Drawing.Color.White;
            this.btnActualizar.BorderColor = System.Drawing.Color.Teal;
            this.btnActualizar.BorderSize = 1;
            this.btnActualizar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnActualizar.FocusedColor = System.Drawing.Color.Empty;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnActualizar.Image = null;
            this.btnActualizar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnActualizar.Location = new System.Drawing.Point(120, 130);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnActualizar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnActualizar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnActualizar.OnHoverImage = null;
            this.btnActualizar.OnPressedColor = System.Drawing.Color.Black;
            this.btnActualizar.Size = new System.Drawing.Size(114, 30);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AnimationHoverSpeed = 0.07F;
            this.btnCancelar.AnimationSpeed = 0.03F;
            this.btnCancelar.BaseColor = System.Drawing.Color.White;
            this.btnCancelar.BorderColor = System.Drawing.Color.Teal;
            this.btnCancelar.BorderSize = 1;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelar.FocusedColor = System.Drawing.Color.Empty;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCancelar.Image = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCancelar.Location = new System.Drawing.Point(274, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCancelar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCancelar.OnHoverImage = null;
            this.btnCancelar.OnPressedColor = System.Drawing.Color.Black;
            this.btnCancelar.Size = new System.Drawing.Size(114, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRetornar
            // 
            this.btnRetornar.AnimationHoverSpeed = 0.07F;
            this.btnRetornar.AnimationSpeed = 0.03F;
            this.btnRetornar.BaseColor = System.Drawing.Color.White;
            this.btnRetornar.BorderColor = System.Drawing.Color.Teal;
            this.btnRetornar.BorderSize = 1;
            this.btnRetornar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRetornar.FocusedColor = System.Drawing.Color.Empty;
            this.btnRetornar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetornar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRetornar.Image = null;
            this.btnRetornar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRetornar.Location = new System.Drawing.Point(274, 130);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRetornar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRetornar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRetornar.OnHoverImage = null;
            this.btnRetornar.OnPressedColor = System.Drawing.Color.Black;
            this.btnRetornar.Size = new System.Drawing.Size(114, 30);
            this.btnRetornar.TabIndex = 6;
            this.btnRetornar.Text = "Retornar";
            this.btnRetornar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AnimationHoverSpeed = 0.07F;
            this.btnGuardar.AnimationSpeed = 0.03F;
            this.btnGuardar.BaseColor = System.Drawing.Color.White;
            this.btnGuardar.BorderColor = System.Drawing.Color.Teal;
            this.btnGuardar.BorderSize = 1;
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.FocusedColor = System.Drawing.Color.Empty;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnGuardar.Image = null;
            this.btnGuardar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnGuardar.Location = new System.Drawing.Point(120, 84);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGuardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGuardar.OnHoverImage = null;
            this.btnGuardar.OnPressedColor = System.Drawing.Color.Black;
            this.btnGuardar.Size = new System.Drawing.Size(114, 30);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.txtDescripcion.BaseColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderColor = System.Drawing.Color.Silver;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.FocusedBaseColor = System.Drawing.Color.White;
            this.txtDescripcion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDescripcion.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.Location = new System.Drawing.Point(175, 34);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.Radius = 5;
            this.txtDescripcion.Size = new System.Drawing.Size(291, 42);
            this.txtDescripcion.TabIndex = 4;
//            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Buscar:";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(803, 113);
            this.panel1.TabIndex = 14;
            this.panel1.Tag = "";
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // btnCerrar
            // 
            this.btnCerrar.AnimationHoverSpeed = 0.07F;
            this.btnCerrar.AnimationSpeed = 0.03F;
            this.btnCerrar.BaseColor = System.Drawing.Color.Orange;
            this.btnCerrar.BorderColor = System.Drawing.Color.Black;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrar.FocusedColor = System.Drawing.Color.Empty;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = null;
            this.btnCerrar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCerrar.Location = new System.Drawing.Point(677, 34);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCerrar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCerrar.OnHoverImage = null;
            this.btnCerrar.OnPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.Size = new System.Drawing.Size(90, 42);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "X";
            this.btnCerrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(333, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almacenes";
            // 
            // btnElminar
            // 
            this.btnElminar.AnimationHoverSpeed = 0.07F;
            this.btnElminar.AnimationSpeed = 0.03F;
            this.btnElminar.BaseColor = System.Drawing.Color.White;
            this.btnElminar.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnElminar.BorderSize = 1;
            this.btnElminar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnElminar.FocusedColor = System.Drawing.Color.Empty;
            this.btnElminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElminar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnElminar.Image = null;
            this.btnElminar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnElminar.Location = new System.Drawing.Point(136, 402);
            this.btnElminar.Name = "btnElminar";
            this.btnElminar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnElminar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnElminar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnElminar.OnHoverImage = null;
            this.btnElminar.OnPressedColor = System.Drawing.Color.Black;
            this.btnElminar.Size = new System.Drawing.Size(114, 30);
            this.btnElminar.TabIndex = 18;
            this.btnElminar.Text = "Eliminar";
            this.btnElminar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnElminar.Click += new System.EventHandler(this.btnElminar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.AnimationHoverSpeed = 0.07F;
            this.btnReporte.AnimationSpeed = 0.03F;
            this.btnReporte.BaseColor = System.Drawing.Color.White;
            this.btnReporte.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnReporte.BorderSize = 1;
            this.btnReporte.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReporte.FocusedColor = System.Drawing.Color.Empty;
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnReporte.Image = null;
            this.btnReporte.ImageSize = new System.Drawing.Size(20, 20);
            this.btnReporte.Location = new System.Drawing.Point(256, 402);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReporte.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnReporte.OnHoverForeColor = System.Drawing.Color.White;
            this.btnReporte.OnHoverImage = null;
            this.btnReporte.OnPressedColor = System.Drawing.Color.Black;
            this.btnReporte.Size = new System.Drawing.Size(114, 30);
            this.btnReporte.TabIndex = 17;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AnimationHoverSpeed = 0.07F;
            this.btnNuevo.AnimationSpeed = 0.03F;
            this.btnNuevo.BaseColor = System.Drawing.Color.White;
            this.btnNuevo.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnNuevo.BorderSize = 1;
            this.btnNuevo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNuevo.FocusedColor = System.Drawing.Color.Empty;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnNuevo.Image = null;
            this.btnNuevo.ImageSize = new System.Drawing.Size(20, 20);
            this.btnNuevo.Location = new System.Drawing.Point(17, 402);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnNuevo.OnHoverForeColor = System.Drawing.Color.White;
            this.btnNuevo.OnHoverImage = null;
            this.btnNuevo.OnPressedColor = System.Drawing.Color.Black;
            this.btnNuevo.Size = new System.Drawing.Size(114, 30);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.AnimationHoverSpeed = 0.07F;
            this.btnSalida.AnimationSpeed = 0.03F;
            this.btnSalida.BaseColor = System.Drawing.Color.White;
            this.btnSalida.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnSalida.BorderSize = 1;
            this.btnSalida.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSalida.FocusedColor = System.Drawing.Color.Empty;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSalida.Image = null;
            this.btnSalida.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSalida.Location = new System.Drawing.Point(376, 402);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalida.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSalida.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSalida.OnHoverImage = null;
            this.btnSalida.OnPressedColor = System.Drawing.Color.Black;
            this.btnSalida.Size = new System.Drawing.Size(114, 30);
            this.btnSalida.TabIndex = 16;
            this.btnSalida.Text = "Salir";
            this.btnSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // FrmAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 443);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnElminar);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAlmacen";
            this.Text = "FrmAlamacen";
            this.Load += new System.EventHandler(this.FrmAlmacen_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvListado;
        private Guna.UI.WinForms.GunaButton btnBuscar;
        private Guna.UI.WinForms.GunaTextBox txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI.WinForms.GunaTextBox txtId;
        private Guna.UI.WinForms.GunaButton btnActualizar;
        private Guna.UI.WinForms.GunaButton btnCancelar;
        private Guna.UI.WinForms.GunaButton btnRetornar;
        private Guna.UI.WinForms.GunaButton btnGuardar;
        private Guna.UI.WinForms.GunaTextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaButton btnCerrar;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton btnElminar;
        private Guna.UI.WinForms.GunaButton btnReporte;
        private Guna.UI.WinForms.GunaButton btnNuevo;
        private Guna.UI.WinForms.GunaButton btnSalida;
    }
}