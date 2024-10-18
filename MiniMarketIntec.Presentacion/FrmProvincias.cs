using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniMarketIntec.Datos;
using MiniMarketIntec.Entidad;
using MiniMarketIntec.Negocios;

namespace MiniMarketIntec.Presentacion
{
    public partial class FrmProvincias : Form
    {
        private int opcion;

        public FrmProvincias()
        {
            InitializeComponent();
        }

        #region "Mis Metodos Auxliares"

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarketIntec", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
            dgvListado.Columns[0].HeaderText = "Codigo Provincia";
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "Nombre Provincia";
            dgvListado.Columns[2].Width = 250;
            dgvListado.Columns[2].HeaderText = "Pais";
            dgvListado.Columns[3].HeaderText = "Estado";
        }

        private void ListarProvincias(string valor)
        {
            try
            {
                dgvListado.DataSource = NProvincia.ListarProvincias(valor);
                Formato();
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void SeleccionarItem()
        {
            if (dgvListado.CurrentRow != null)
            {
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["descripcion_provincia"].Value.ToString();
                txtID.Text = dgvListado.CurrentRow.Cells["codigo_provincia"].Value.ToString();
            }
            else
            {
                MensajeError("Debe seleccionar una Provincia");
            }
        }


        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarProvincias(txtBuscar.Text.Trim());
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarItem();
            EstadoBotonesProcesos(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            cmbPais.Enabled = true;
            cmbPais.Focus();
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Ingrese el nombre de una Provincia");
            }
            else if (cmbPais.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbPais, "Seleccione un País");
            }
            else
            {
                int codigoPais = Convert.ToInt32(cmbPais.SelectedValue); // Get the selected country code

                // Check if the province already exists
                if (NProvincia.Existe(txtDescripcion.Text.Trim()) == "1")
                {
                    MensajeError("La provincia ya existe");
                }
                else
                {
                    errorProvider.Clear();
                    // Register the province with the selected country
                    respuesta = NProvincia.RegistrarProvincias(opcion, 0, codigoPais, txtDescripcion.Text.Trim());

                    if (respuesta == "OK")
                    {
                        MensajeOK("La Provincia se registró correctamente");
                        opcion = 0;
                        EstadoBotones(true);
                        EstadoBotonesProcesos(false);
                        txtDescripcion.Text = "";
                        txtDescripcion.Enabled = false;
                        cmbPais.Enabled = false;
                        ListarProvincias("%");
                        tabPrincipal.SelectedIndex = 0;
                    }
                    else
                    {
                        MensajeError(respuesta);
                    }
                }
            }
        }

        private ErrorProvider errorProvider = new ErrorProvider();

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            opcion = 2; // Modo actualización
            string respuesta = "";

            // Verificación de campos vacíos
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Introduzca un nombre de provincia");
                return;
            }

            if (cmbPais.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbPais, "Seleccione un país");
                return;
            }

            // Si los campos están correctos, limpiamos los errores anteriores
            errorProvider.Clear();

            // Obtener el código del país seleccionado
            int codigoPais = Convert.ToInt32(cmbPais.SelectedValue);

            // Llamar a la función de actualización de provincias
            respuesta = NProvincia.RegistrarProvincias(opcion, Convert.ToInt32(txtID.Text), codigoPais, txtDescripcion.Text.Trim());

            if (respuesta == "OK")
            {
                MensajeOK("La provincia se actualizó correctamente");
                EstadoBotones(true);
                EstadoBotonesProcesos(false);
                txtDescripcion.Text = "";
                txtID.Text = "";
                txtDescripcion.Enabled = false;
                cmbPais.Enabled = false;
                ListarProvincias("%"); // Actualizar el listado de provincias
                tabPrincipal.SelectedIndex = 0; // Volver a la pestaña principal
            }
            else
            {
                MensajeError(respuesta); // Mostrar cualquier error recibido
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcion = 0; // Cancel option
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            tabPrincipal.SelectedIndex = 0;
            cmbPais.Enabled = false;
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            opcion = 0;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            tabPrincipal.SelectedIndex = 0;
            cmbPais.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcion = 1;
            EstadoBotones(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
            cmbPais.Enabled = true;
            cmbPais.Focus();
            EstadoBotonesProcesos(true);
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null && dgvListado.CurrentRow.Cells["codigo_provincia"].Value != null)
            {
                int codigoProvincia = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_provincia"].Value);


                DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar la provincia seleccionada?", "Eliminar Provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    string respuesta = NProvincia.Desactivar(codigoProvincia);

                    if (respuesta == "OK")
                    {
                        MensajeOK("La provincia se eliminó correctamente");
                        ListarProvincias("%");
                    }
                    else
                    {
                        MensajeError(respuesta);
                    }
                }
            }
            else
            {
                MensajeError("Debe seleccionar una provincia para eliminar");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarPaises()
        {
            try
            {
                DataTable dtPaises = NPais.Seleccionar("%");
                cmbPais.DataSource = dtPaises;
                cmbPais.DisplayMember = "descripcion_pais";
                cmbPais.ValueMember = "codigo_pais";
                cmbPais.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void FrmProvincias_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            ListarProvincias("%");
            Formato();
            CargarPaises();
        }
    }
}
