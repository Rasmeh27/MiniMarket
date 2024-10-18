using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniMarketIntec.Negocio;
using MiniMarketIntec.Negocios;

namespace MiniMarketIntec.Presentacion
{
    public partial class FrmProductos : Form
    {
        private int OpcionGuardar;
        public FrmProductos()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int estadoGuardar = 0; //variable para decidir si guardar o actualizar un producto

        int codigoProducto = 0;
        int codigoMarca = 0;
        int codigoUnidadMedida = 0;
        int codigoCategoria = 0;

        #endregion

        #region "Metodos Auxiliares"

        //Mensajes de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Mensajes de OK
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Estado de los botones
        private void EstadoBotones(bool estado)
        {
            //this.btnNuevo.Visible = estado;


            this.btnNuevo.Enabled = estado;
            //this.btnActualizar.Enabled = estado;
            this.btnEliminar.Enabled = estado;
            this.btnReporte.Enabled = estado;
            this.btnSalir.Enabled = estado;
        }

        private void EstadoBotonesProcesos(bool estado)
        {
            this.btnCancelar.Visible = estado;
            this.btnGuardar.Visible = estado;
            this.btnRetornar.Visible = !estado;
            this.btnActualizar.Visible = !estado;
        }


        //Formato al DataGridView
        private void Formato()
        {
            dgvPrincipal.Columns[0].Width = 60;
            dgvPrincipal.Columns[0].HeaderText = "CÓDIGO";
            dgvPrincipal.Columns[1].Width = 150;
            dgvPrincipal.Columns[1].HeaderText = "PRODUCTO";
            dgvPrincipal.Columns[2].Width = 115;
            dgvPrincipal.Columns[2].HeaderText = "MARCA";
            dgvPrincipal.Columns[3].Width = 150;
            dgvPrincipal.Columns[3].HeaderText = "UNIDAD MEDIDA";
            dgvPrincipal.Columns[4].Width = 150;
            dgvPrincipal.Columns[4].HeaderText = "CATEGORIA";
            dgvPrincipal.Columns[5].Width = 80;
            dgvPrincipal.Columns[5].HeaderText = "STOCK MIN";
            dgvPrincipal.Columns[6].Width = 100;
            dgvPrincipal.Columns[6].HeaderText = "STOCK MAX";
            dgvPrincipal.Columns[7].Visible = false;
            dgvPrincipal.Columns[8].Visible = false;
            dgvPrincipal.Columns[9].Visible = false;

        }

        //listar los productos
        private void ListarProductos(string valor)
        {
            try
            {

                dgvPrincipal.DataSource = NProducto.ListarProductos(valor);
                this.Formato();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void CargarCategorias()
        {
            try
            {

                var categorias = NCategoria.Seleccionar();

                if (categorias != null)
                {

                    cmbCategoria.DataSource = categorias;
                    cmbCategoria.ValueMember = "codigo_cat";  // Campo del valor
                    cmbCategoria.DisplayMember = "descripcion_cat";  // Campo que se mostrará
                }
                else
                {
                    MessageBox.Show("No se encontraron categorías.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        //Seleccionar una fila del DataGridView
        private void SeleccionarItem()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_prod"].Value)))
            {
                txtDescripcion.Text = dgvPrincipal.CurrentRow.Cells["descripcion_prod"].Value.ToString();
                txtCodigoProducto.Text = dgvPrincipal.CurrentRow.Cells["codigo_prod"].Value.ToString();
                txtMarca.Text = dgvPrincipal.CurrentRow.Cells["descripcion_marca"].Value.ToString();
                txtMedida.Text = dgvPrincipal.CurrentRow.Cells["descripcion_um"].Value.ToString();
                cmbCategoria.SelectedValue = Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_cat"].Value);
                txtStockMinimo.Text = dgvPrincipal.CurrentRow.Cells["stock_min"].Value.ToString();
                txtStockMaximo.Text = dgvPrincipal.CurrentRow.Cells["stock_max"].Value.ToString();

                grbStock.Visible = false;
                txtDescripcion.Enabled = false;
                txtMedida.Enabled = false;
                txtMarca.Enabled = false;
                cmbCategoria.Enabled = false;
                grbStock.Visible = false;

                codigoCategoria = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_cat"].Value);
                codigoMarca = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_marca"].Value);
                codigoUnidadMedida = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_um"].Value);
                codigoProducto = Convert.ToInt32(txtCodigoProducto.Text);

            }
            else
            {
                MensajeError("Debe Seleccionar una Marca");
            }
        }

        //Formato al DataGridView de marcas
        private void FormatoMA()
        {
            dgvMarcas.Columns[0].Width = 60;
            dgvMarcas.Columns[0].HeaderText = "CÓDIGO";
            dgvMarcas.Columns[1].Width = 195;
            dgvMarcas.Columns[1].HeaderText = "MARCA";

        }

        //listar los las marcas para el dgvMarcas
        private void ListarMA(string valor)
        {
            try
            {

                dgvMarcas.DataSource = NMarca.Seleccionar(valor);
                this.FormatoMA();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        //Formato al DataGridView de unidades de medida
        private void FormatoUM()
        {
            dgvMedidas.Columns[0].Width = 60;
            dgvMedidas.Columns[0].HeaderText = "CÓDIGO";
            dgvMedidas.Columns[1].Width = 195;
            dgvMedidas.Columns[1].HeaderText = "UNIDAD DE MEDIDA";
        }

        //listar los las unidades de medida para el dgvMedidas
        private void ListarUM(string valor)
        {
            try
            {

                dgvMedidas.DataSource = NUnidad_Medida.Seleccionar(valor);
                this.FormatoUM();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //formato al DataGridView de Stock
        private void FormatoStockAlmacen()
        {
            dgvStockActual.Columns[0].Width = 200;
            dgvStockActual.Columns[0].HeaderText = "ALMACEN";
            dgvStockActual.Columns[1].Width = 100;
            dgvStockActual.Columns[1].HeaderText = "STOCK ACTUAL";
            dgvStockActual.Columns[2].Width = 200;
            dgvStockActual.Columns[2].HeaderText = "PRECIO UNITARIO COMPRA";
        }

        //listar los stock por almacen
        private void ListarStockAlmacen(int valor)
        {
            try
            {

                dgvStockActual.DataSource = NProducto.ListarStockAlmacen(valor);
                this.FormatoStockAlmacen();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }




        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarProductos(txtBuscar.Text.Trim());
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitarios obj = new Utilitarios();
            obj.MoverFormulario(this);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grbStock.Visible = false;
            OpcionGuardar = 1;
            this.EstadoBotones(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = " "; //borra cualquier contenido que hata en el textbox
            txtDescripcion.Focus();

            txtMarca.Enabled = true;
            txtMarca.Text = " ";
            txtMarca.Focus();

            txtMedida.Enabled = true;
            txtMedida.Text = " ";
            txtMedida.Focus();

            cmbCategoria.Enabled = true;

            txtStockMaximo.Enabled = true;
            txtStockMaximo.Text = " ";
            txtStockMaximo.Focus();

            txtStockMinimo.Enabled = true;
            txtStockMinimo.Text = " ";
            txtStockMinimo.Focus();

            btnSeleccionMarca.Enabled = true;
            btnSeleccionMedida.Enabled = true;

            this.EstadoBotonesProcesos(true); //habilito los botones
            tabPrincipal.SelectedIndex = 1;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            txtMarca.Enabled = false;
            txtMedida.Enabled = false;
            cmbCategoria.Enabled = false;
            txtStockMaximo.Enabled = false;
            txtStockMinimo.Enabled = false;
            btnSeleccionMarca.Enabled = false;
            btnSeleccionMedida.Enabled = false;

            EstadoBotones(true);
            this.ListarProductos("%");
            this.ListarMA("%");
            this.ListarUM("%");
            this.CargarCategorias();

            this.Formato();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();

            // Validación de campos obligatorios
            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Ingrese una Descripción para el Producto");
            }
            else if (txtMarca.Text == "")
            {
                errorProvider.SetError(txtMarca, "Seleccione una Marca");
            }
            else if (txtMedida.Text == "")
            {
                errorProvider.SetError(txtMedida, "Seleccione una Medida");
            }
            else if (cmbCategoria.Text == "")
            {
                errorProvider.SetError(cmbCategoria, "Seleccione una Categoría");
            }
            else if (txtStockMaximo.Text == "")
            {
                errorProvider.SetError(txtStockMaximo, "Ingrese el stock Máximo");
            }
            else if (txtStockMinimo.Text == "")
            {
                errorProvider.SetError(txtStockMinimo, "Ingrese el stock Mínimo");
            }
            else
            {
                // Limpia los errores
                errorProvider.Clear();

                // Variables
                decimal stockMinimo = Convert.ToDecimal(txtStockMinimo.Text);
                decimal stockMaximo = Convert.ToDecimal(txtStockMaximo.Text);
                int codigoMarca = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["codigo_marca"].Value);
                int codigoMedida = Convert.ToInt32(dgvMedidas.CurrentRow.Cells["codigo_um"].Value);
                int codigoCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);

                // Llamada al método para guardar el producto
                string respuesta = NProducto.RegistrarProducto(
                    OpcionGuardar,
                    codigoProducto,
                    txtDescripcion.Text.Trim(),
                    codigoMarca,
                    codigoMedida,
                    codigoCategoria,
                    stockMinimo,
                    stockMaximo
                );

                if (respuesta == "OK")
                {
                    MensajeOK("El producto se registró correctamente");
                    OpcionGuardar = 0;
                    EstadoBotones(true);
                    EstadoBotonesProcesos(false);
                    this.ListarProductos("%");
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                {
                    MensajeError(respuesta);
                }
            }

        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            txtMarca.Enabled = false;
            txtMedida.Enabled = false;
            cmbCategoria.Enabled = false;
            txtStockMaximo.Enabled = false;
            txtStockMinimo.Enabled = false;
            btnSeleccionMarca.Enabled = false;
            btnSeleccionMedida.Enabled = false;
            EstadoBotonesProcesos(false);
            EstadoBotones(true);
            OpcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnSeleccionMarca_Click(object sender, EventArgs e)
        {
            pnlMarca.Visible = true;
        }

        private void btnSeleccionMedida_Click(object sender, EventArgs e)
        {
            pnlMedida.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            txtMarca.Enabled = false;
            txtMedida.Enabled = false;
            cmbCategoria.Enabled = false;
            txtStockMaximo.Enabled = false;
            txtStockMinimo.Enabled = false;
            btnSeleccionMarca.Enabled = false;
            btnSeleccionMedida.Enabled = false;
            EstadoBotonesProcesos(false);
            EstadoBotones(true);
            OpcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnCerrarPanelMedidas_Click(object sender, EventArgs e)
        {
            pnlMedida.Visible = false;
        }

        private void btncerrarpanel_Click(object sender, EventArgs e)
        {
            pnlMarca.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            ErrorProvider errorProvider = new ErrorProvider();


            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Ingrese una descripción para el producto.");
                return;
            }

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                errorProvider.SetError(txtMarca, "Seleccione una marca.");
                return;
            }

            if (string.IsNullOrEmpty(txtMedida.Text))
            {
                errorProvider.SetError(txtMedida, "Seleccione una medida.");
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                errorProvider.SetError(cmbCategoria, "Seleccione una categoría.");
                return;
            }

            if (string.IsNullOrEmpty(txtStockMaximo.Text))
            {
                errorProvider.SetError(txtStockMaximo, "Ingrese el stock máximo.");
                return;
            }

            if (string.IsNullOrEmpty(txtStockMinimo.Text))
            {
                errorProvider.SetError(txtStockMinimo, "Ingrese el stock mínimo.");
                return;
            }

            // Limpia los errores si todo está bien
            errorProvider.Clear();

            try
            {
                // Actualiza los valores en el DataGridView
                DataGridViewRow filaSeleccionada = dgvPrincipal.CurrentRow;

                if (filaSeleccionada != null)
                {
                    filaSeleccionada.Cells["descripcion_prod"].Value = txtDescripcion.Text.Trim();
                    filaSeleccionada.Cells["descripcion_marca"].Value = txtMarca.Text.Trim();
                    filaSeleccionada.Cells["descripcion_um"].Value = txtMedida.Text.Trim();
                    filaSeleccionada.Cells["codigo_cat"].Value = cmbCategoria.SelectedValue;
                    filaSeleccionada.Cells["stock_min"].Value = Convert.ToDecimal(txtStockMinimo.Text);
                    filaSeleccionada.Cells["stock_max"].Value = Convert.ToDecimal(txtStockMaximo.Text);

                    MensajeOK("Producto actualizado correctamente en la interfaz.");

                    // Vuelve a la pestaña principal
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                {
                    MensajeError("No se ha seleccionado ninguna fila para actualizar.");
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error al actualizar el producto: " + ex.Message);
            }
        }

        private void dgvMedidas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMedidas.CurrentRow != null)
            {
                // Captura el código de la unidad de medida seleccionada
                codigoUnidadMedida = Convert.ToInt32(dgvMedidas.CurrentRow.Cells["codigo_um"].Value);
                txtMedida.Text = dgvMedidas.CurrentRow.Cells["descripcion_um"].Value.ToString();
                pnlMedida.Visible = false;
            }
            else
            {
                MensajeError("Debe seleccionar una medida válida.");
            }
        }

        private void dgvMarcas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                // Captura el código de la marca seleccionada
                codigoMarca = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["codigo_marca"].Value);
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["descripcion_marca"].Value.ToString();
                pnlMarca.Visible = false;
            }
            else
            {
                MensajeError("Debe seleccionar una marca válida.");
            }
        }

        private void dgvPrincipal_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrincipal.CurrentRow != null && dgvPrincipal.CurrentRow.Cells.Count > 0)
                {
                    // Cargar datos del producto seleccionado en los campos
                    SeleccionarItem();

                    // Habilitar los campos para la edición
                    txtDescripcion.Enabled = true;
                    txtMarca.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbCategoria.Enabled = true;
                    txtStockMaximo.Enabled = true;
                    txtStockMinimo.Enabled = true;
                    btnSeleccionMarca.Enabled = true;
                    btnSeleccionMedida.Enabled = true;

                    // Ocultar el botón Guardar cuando se hace doble clic en una fila
                    btnGuardar.Visible = false;

                    // Cambiar el modo a actualización
                    OpcionGuardar = 2;
                    tabPrincipal.SelectedIndex = 1; // Cambiar a la pestaña de edición
                    grbStock.Visible = true;

                    // Cargar el stock actual del producto en dgvStockActual
                    int selectedProductId = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_prod"].Value);
                    ListarStockAlmacen(selectedProductId); // Cargar el stock en dgvStockActual
                }
                else
                {
                    MensajeError("Debe seleccionar un producto válido.");
                }
            }
            catch (Exception ex)
            {
                MensajeError("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.CurrentRow != null && !string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value))) // Usamos índice 0
            {
                if (MessageBox.Show("¿Seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int codigoProducto = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    string Respuesta = NProducto.Desactivar(codigoProducto);
                    if (Respuesta == "OK")
                    {
                        MensajeOK("El producto se eliminó correctamente");
                        this.ListarProductos("%");
                    }
                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
            else
            {
                MensajeError("Debe seleccionar un Producto.");
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
