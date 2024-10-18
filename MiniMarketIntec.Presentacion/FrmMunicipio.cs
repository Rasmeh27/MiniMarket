    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniMarketIntec.Negocios;

namespace MiniMarketIntec.Presentacion
{
    public partial class FrmMunicipio : Form
    {
        private int opcion;
        public FrmMunicipio()
        {
            InitializeComponent();
        }
        #region "Mis Métodos personalizados"
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarketIntec", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private ErrorProvider errorProvider = new ErrorProvider();
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarketIntec", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EstadoBotones(bool estado)
        {
            btnNuevo.Enabled = estado;
            btnEliminar.Enabled = estado;
            btnReporte.Enabled = estado;
            btnSalir.Enabled = estado;

            btnGuardar.Visible = !estado;
            btnCancelar.Visible = !estado;
            btnActualizar.Visible = !estado;
            btnRetornar.Visible = !estado;
        }

        private void EstadoBotonesProcesos(bool estado)
        {
            btnGuardar.Visible = estado;
            btnCancelar.Visible = estado;
            btnActualizar.Visible = !estado;
            btnRetornar.Visible = !estado;
        }

        private void Formato()
        {
            dgvListado.Columns[0].Width = 150;
            dgvListado.Columns[0].HeaderText = "Código Municipio";
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "Nombre Municipio";
            dgvListado.Columns[2].Width = 150;
            dgvListado.Columns[2].HeaderText = "Provincia";
            dgvListado.Columns[3].Width = 150;
            dgvListado.Columns[3].HeaderText = "País";
            dgvListado.Columns[4].Width = 150;
            dgvListado.Columns[4].HeaderText = "Estado";
        }

        private void ListarMunicipios(string valor)
        {
            try
            {
                dgvListado.DataSource = NMunicipio.ListarMunicipios(valor);
                this.Formato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FormatoPro()
        {
            dgvProvincia.Columns[0].Width = 150;
            dgvProvincia.Columns[0].HeaderText = "Provincia";
            dgvProvincia.Columns[1].Width = 150;
            dgvProvincia.Columns[1].HeaderText = "Pais";
            dgvProvincia.Columns[2].Width = 150;
            dgvProvincia.Columns[2].HeaderText = "Codigo";

        }
        private void ListarPro(string paisprovincia)
        {
            try
            {
                dgvProvincia.DataSource = NProvincia.Seleccionar(paisprovincia);
                this.FormatoPro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SeleccionarItem()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_municipio"].Value)))
            {
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["descripcion_municipio"].Value.ToString();
                txtID.Text = dgvListado.CurrentRow.Cells["codigo_municipio"].Value.ToString();
            }
            else
            {
                MensajeError("Debe seleccionar un Municipio");
            }
        }
        #endregion

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null && dgvListado.CurrentRow.Cells["codigo_municipio"].Value != null)
            {
                btnAbrirPnl.Enabled = true;
                SeleccionarItem(); // Método para cargar los datos seleccionados
                EstadoBotonesProcesos(false);
                txtDescripcion.Enabled = true;
                txtDescripcion.Focus();
                txtProvincia.Enabled = true;
                txtProvincia.Focus();
                tabPrincipal.SelectedIndex = 1; // Mueve el foco a la pestaña de edición
            }
            else
            {
                MensajeError("Debe seleccionar un municipio válido.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarMunicipios(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcion = 1; // New option
            EstadoBotones(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = ""; // Clear the textbox
            txtDescripcion.Focus();
            txtProvincia.Enabled = true;
            txtProvincia.Focus();
            txtProvincia.Text = "";
            EstadoBotonesProcesos(true);
            tabPrincipal.SelectedIndex = 1;
            btnAbrirPnl.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada
            if (dgvListado.CurrentRow != null && dgvListado.CurrentRow.Cells["codigo_municipio"].Value != null)
            {
                int codigoMunicipio = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_municipio"].Value);

                // Confirmación para eliminar
                DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar el municipio seleccionado?", "Eliminar municipio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    string respuesta = NMunicipio.Desactivar(codigoMunicipio);

                    if (respuesta == "OK")
                    {
                        MensajeOK("El municipio se eliminó correctamente");
                        ListarMunicipios("%");
                    }
                    else
                    {
                        MensajeError(respuesta); 
                    }
                }
            }
            else
            {
                MensajeError("Debe seleccionar un municipio para eliminar");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int codigoProvinciaSeleccionada;

        private void btnAbrirPnl_Click(object sender, EventArgs e)
        {
            pnlProvincia.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Ingrese el nombre de un Municipio");
            }
            else if (codigoProvinciaSeleccionada == 0) // Verifica si el código de provincia ha sido seleccionado
            {
                errorProvider.SetError(txtProvincia, "Seleccione una Provincia válida");
            }
            else
            {
                // Verificar si el distrito ya existe usando el método Existe de NDistritos
                string existe = NMunicipio.Existe(txtDescripcion.Text.Trim());

                if (existe.Equals("1")) // Asumiendo que el método Existe retorna "1" si el distrito ya existe
                {
                    MensajeError("El Municipio ya existe.");
                    return; // Sale de la función para no continuar con el guardado
                }

                // Registrar la provincia con el código numérico de provincia
                respuesta = NMunicipio.RegistrarMunicipio(opcion, 0, codigoProvinciaSeleccionada, txtDescripcion.Text.Trim());

                if (respuesta == "OK")
                {
                    MensajeOK("El Municipio se registró correctamente");
                    opcion = 0;
                    EstadoBotones(true);
                    EstadoBotonesProcesos(false);
                    txtDescripcion.Text = "";
                    txtDescripcion.Enabled = false;
                    txtProvincia.Text = "";
                    txtProvincia.Enabled = false;
                    ListarMunicipios("%");
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                {
                    MensajeError(respuesta);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Introduzca un nombre de distrito");
                return;
            }

            if (codigoProvinciaSeleccionada == 0) // Verifica que se haya seleccionado una provincia
            {
                errorProvider.SetError(txtProvincia, "Seleccione una Provincia válida");
                return;
            }

            // Actualiza el distrito con el código de la provincia seleccionada
            string respuesta = NProvincia.RegistrarProvincias(opcion, Convert.ToInt32(txtID.Text), codigoProvinciaSeleccionada, txtDescripcion.Text.Trim());

            if (respuesta == "OK")
            {
                MensajeOK("El Distrito se actualizó correctamente");
                opcion = 0;
                EstadoBotones(true);
                EstadoBotonesProcesos(false);
                txtDescripcion.Text = "";
                txtDescripcion.Enabled = false;
                txtProvincia.Text = "";
                txtProvincia.Enabled = false;
                ListarMunicipios("%");
                tabPrincipal.SelectedIndex = 0;
            }
            else
            {
                MensajeError(respuesta);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcion = 0;
            pnlProvincia.Visible = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            btnAbrirPnl.Enabled = false;
            txtProvincia.Enabled = false;
            txtProvincia.Text = "";
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            opcion = 0;
            pnlProvincia.Visible = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            btnAbrirPnl.Enabled = false;
            txtProvincia.Enabled = false;
            txtProvincia.Text = "";
            tabPrincipal.SelectedIndex = 0;
        }

        private void dgvProvincia_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProvincia.CurrentRow != null)
            {
                // Captura el código y la descripción de la provincia seleccionada
                btnAbrirPnl.Enabled = true;
                codigoProvinciaSeleccionada = Convert.ToInt32(dgvProvincia.CurrentRow.Cells["codigo_provincia"].Value);
                txtProvincia.Text = dgvProvincia.CurrentRow.Cells["descripcion_provincia"].Value.ToString(); // Muestra el nombre en txtProvincia
                pnlProvincia.Visible = false;
            }
            else
            {
                MensajeError("Debe seleccionar una provincia válida.");
            }
        }

        private void btnBuscarP_Click(object sender, EventArgs e)
        {
            this.ListarPro(txtBuscarP.Text.Trim());
        }

        private void btnCerrarPnl_Click(object sender, EventArgs e)
        {
            pnlProvincia.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMunicipio_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            this.ListarMunicipios("%");
            this.ListarPro("%");
            this.Formato();
        }
    }
}
