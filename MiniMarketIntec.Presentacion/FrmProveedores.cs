using MiniMarketIntec.Negocio;
using System;
using MiniMarketIntec.Presentacion;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarket.Presentacion
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int estadoGuardar = 0; //variable para decidir si guardar o actualizar una marca

        int codigoProveedor = 0;
        int codigoTipoDocCP = 0;
        int codigoSexo = 0;
        int codigoRubro = 0;
        int codigoDistrito = 0;

        #endregion

        #region "Metodos Auxiliares"

        //Mensajes de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Mensajes de OK
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Estado de los botones
        private void EstadoBotones(bool estado)
        {
            //this.btnNuevo.Visible = estado;


            this.btnNuevo.Enabled = estado;
            this.btnActualizar.Enabled = estado;
            this.btnEliminar.Enabled = estado;
            this.btnReporte.Enabled = estado;
            this.btnSalir.Enabled = estado;
        }

        private void EstadoBotonesProcesos(bool estado)
        {
            this.btnCancelar.Visible = estado;
            this.btnGuardar.Visible = estado;
            this.btnRetornar.Visible = !estado;
            //this.btnActualizar.Visible = !estado;
        }


        //Formato al DataGridView
        private void Formato()
        {
            dgvPrincipal.Columns[0].Width = 60;
            dgvPrincipal.Columns[0].HeaderText = "CÓDIGO";
            dgvPrincipal.Columns[1].Width = 120;
            dgvPrincipal.Columns[1].HeaderText = "TIPO DOC";
            dgvPrincipal.Columns[2].Width = 125;
            dgvPrincipal.Columns[2].HeaderText = "NUM DOC";
            dgvPrincipal.Columns[3].Width = 250;
            dgvPrincipal.Columns[3].HeaderText = "RAZÓN SOCIAL";
            dgvPrincipal.Columns[4].Width = 100;
            dgvPrincipal.Columns[4].HeaderText = "NOMBRES";
            dgvPrincipal.Columns[5].Width = 100;
            dgvPrincipal.Columns[5].HeaderText = "APELLIDOS";
            dgvPrincipal.Columns[6].Width = 100;
            dgvPrincipal.Columns[6].HeaderText = "RUBRO";
            dgvPrincipal.Columns[7].Width = 100;
            dgvPrincipal.Columns[7].HeaderText = "EMAIL";
            dgvPrincipal.Columns[8].Visible = false;
            dgvPrincipal.Columns[8].Visible = false;
            dgvPrincipal.Columns[9].Visible = false;
            dgvPrincipal.Columns[10].Visible = false;
            dgvPrincipal.Columns[11].Visible = false;
            dgvPrincipal.Columns[12].Visible = false;
            dgvPrincipal.Columns[13].Visible = false;
            dgvPrincipal.Columns[14].Visible = false;
            dgvPrincipal.Columns[15].Visible = false;
            dgvPrincipal.Columns[16].Visible = false;
            dgvPrincipal.Columns[17].Visible = false;
            dgvPrincipal.Columns[18].Visible = false;

        }

        //listar los proveedores
        private void ListarProveedores(string valor)
        {
            try
            {

                dgvPrincipal.DataSource = NProveedor.ListarProveedores(valor);
                this.Formato();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //listar los tipos de documentos proveedor-cliente
        private void ListarTipoDocPC()
        {
            try
            {
                cmbTipoDocumento.DataSource = NProveedor.ListarTipoDocPC();
                cmbTipoDocumento.ValueMember = "codigo_tipo_doc_pc";
                cmbTipoDocumento.DisplayMember = "descripcion_tipo_doc_cp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //listar los sexos
        private void ListarSexos()
        {
            try
            {
                cmbSexo.DataSource = NProveedor.ListarSexos();
                cmbSexo.ValueMember = "codigo_sexo";
                cmbSexo.DisplayMember = "descripcion_sexo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //listar los rubros
        private void ListarRubros()
        {
            try
            {
                cmbRubro.DataSource = NProveedor.ListarRubros();
                cmbRubro.ValueMember = "codigo_ru";
                cmbRubro.DisplayMember = "descripcion_ru";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        //listar los los paises, privincias y distritos o municipios para el dgv
        private void ListarPaisesProvinciasDistritos(string valor)
        {
            try
            {

                dgvPPD.DataSource = NProveedor.ListarPaisesProvinciasDistritos(valor);
                //this.FormatoPPD();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Formato al DataGridView de marcas
        private void FormatoPPD()
        {
            dgvPPD.Columns[0].Width = 60;
            dgvPPD.Columns[0].HeaderText = "CÓDIGO";
            dgvPPD.Columns[1].Width = 195;
            dgvPPD.Columns[1].HeaderText = "MARCA";
        }


        //Seleccionar una fila del DataGridView
        private void SeleccionarItem()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_proveedor"].Value)))
            {
                cmbTipoDocumento.SelectedValue = dgvPrincipal.CurrentRow.Cells["codigo_tipo_doc_pc"].Value.ToString();
                txtNoDocumento.Text = dgvPrincipal.CurrentRow.Cells["numero_doc_proveedor"].Value.ToString();
                txtRazonSocial.Text = dgvPrincipal.CurrentRow.Cells["razon_social_proveedor"].Value.ToString();
                txtNombres.Text = dgvPrincipal.CurrentRow.Cells["nombres"].Value.ToString();
                txtApellidos.Text = dgvPrincipal.CurrentRow.Cells["apellidos"].Value.ToString();
                cmbSexo.SelectedValue = Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_sexo"].Value);
                cmbRubro.SelectedValue = Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_ru"].Value);
                txtEmail.Text = dgvPrincipal.CurrentRow.Cells["email_proveedor"].Value.ToString();
                txtTelefono.Text = dgvPrincipal.CurrentRow.Cells["telefono_proveedor"].Value.ToString();
                txtMovil.Text = dgvPrincipal.CurrentRow.Cells["movil_proveedor"].Value.ToString();
                txtDireccion.Text = dgvPrincipal.CurrentRow.Cells["direccion_proveedor"].Value.ToString();
                txtDistrito.Text = dgvPrincipal.CurrentRow.Cells["codigo_distrito"].Value.ToString();
                txtObservaciones.Text = dgvPrincipal.CurrentRow.Cells["comentarios"].Value.ToString();


                codigoProveedor = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_proveedor"].Value);
                codigoTipoDocCP = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_tipo_doc_pc"].Value);
                codigoSexo = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_sexo"].Value);
                codigoRubro = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ru"].Value);
                codigoDistrito = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_distrito"].Value);

            }
            else
            {
                MensajeError("Debe Seleccionar un Proveedor");
            }
        }




        #endregion

        private void Frm_Proveedores_Load(object sender, EventArgs e)
        {
            this.EstadoBotonesProcesos(false);
            this.ListarProveedores("%");
            this.ListarTipoDocPC();
            this.ListarSexos();
            this.ListarRubros();
            this.ListarPaisesProvinciasDistritos("%");
        }

        private void btnBuscarDistrito_Click(object sender, EventArgs e)
        {
            pnlPPD.Visible = true;
        }

        private void btnCancelarPPD_Click(object sender, EventArgs e)
        {
            pnlPPD.Visible = false;
        }

        private void btnBuscarPPD_Click(object sender, EventArgs e)
        {
            this.ListarPaisesProvinciasDistritos(txtFiltrarPPD.Text);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitarios objeto = new Utilitarios();
            objeto.MoverFormulario(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtNoDocumento.Text == string.Empty || txtEmail.Text == string.Empty || txtApellidos.Text == string.Empty || txtNombres.Text == string.Empty || txtRazonSocial.Text == string.Empty)
            {
                MensajeError("Complete todos los campos obligatorios");
            }
            else
            {

                if (NProveedor.Existe(txtRazonSocial.Text.Trim()) == "1")
                {
                    MensajeError("El Proveedor ya Existe. Si se ha eliminado previamente, contactar al Admin");
                }
                else
                {


                    errorProvider.Clear();
                    Respuesta = NProveedor.RegistrarProveedor(
                        estadoGuardar,
                        codigoProveedor,
                        Convert.ToInt32(cmbTipoDocumento.SelectedValue),
                        txtNoDocumento.Text.Trim(),
                        txtRazonSocial.Text.Trim(),
                        txtNombres.Text.Trim(),
                        txtApellidos.Text.Trim(),
                        Convert.ToInt32(cmbSexo.SelectedValue),
                        Convert.ToInt32(cmbRubro.SelectedValue),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtMovil.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        codigoDistrito,
                        txtObservaciones.Text.Trim()

                        //Convert.ToDecimal(txtStockMaximo.Text)
                        );

                    if (Respuesta == "OK")
                    {
                        if (estadoGuardar == 1)
                        {
                            MensajeOk("El producto se Registró Correctamente");
                        }
                        else
                        {
                            MensajeOk("El producto se Actualizó Correctamente");
                        }

                        estadoGuardar = 0; //sin ninguna accion
                        this.EstadoBotones(true);
                        this.EstadoBotonesProcesos(false);
                        this.ListarProveedores("%");
                        tabPrincipal.SelectedIndex = 0;
                    }
                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
        }

        private void dgvPPD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codigoDistrito = Convert.ToInt32(dgvPPD.CurrentRow.Cells["codigo_distrito"].Value);
            txtDistrito.Text = Convert.ToString(dgvPPD.CurrentRow.Cells["descripcion_distrito"].Value);
            pnlPPD.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoGuardar = 1; //registrar un poducto
            codigoProveedor = 0;
            this.EstadoBotones(false);
            this.EstadoBotonesProcesos(true);
            tabPrincipal.SelectedIndex = 1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoGuardar = 0; //reseta la opcion
            this.codigoProveedor = 0;
            this.EstadoBotones(true);
            this.EstadoBotonesProcesos(false);
            tabPrincipal.SelectedIndex = 0;
        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItem();
            this.EstadoBotonesProcesos(false);
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.EstadoBotonesProcesos(true);
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_proveedor"].Value)))
            {
                if (MessageBox.Show("¿Seguro que desea eliminar este registro?", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int codigo_proveedor = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_proveedor"].Value);
                    //ejecutar la desativacion del proveedor
                    string Respuesta = NProveedor.Desactivar(codigo_proveedor);
                    if (Respuesta == "OK")
                    {
                        MensajeOk("Se eliminó el DIstrito correctamente");
                    }
                    this.ListarProveedores("%");
                }

            }
            else
            {
                MensajeError("Debe Seleccionar un Distrito");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarProveedores(txtBuscar.Text.Trim());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //SeleccionarItem();
            estadoGuardar = 2;
            codigoProveedor = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_proveedor"].Value);
            this.EstadoBotones(false);
            this.EstadoBotonesProcesos(true);
            tabPrincipal.SelectedIndex = 1;

            string Respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtNoDocumento.Text == string.Empty || txtNombres.Text == string.Empty || txtApellidos.Text == string.Empty)
            {
                MensajeError("Complete los Campos Obligatorios");
            }
            else
            {
                errorProvider.Clear();
                Respuesta = NProveedor.RegistrarProveedor(
                        estadoGuardar,
                        codigoProveedor,
                        codigoTipoDocCP,
                        txtNoDocumento.Text.Trim(),
                        txtRazonSocial.Text.Trim(),
                        txtNombres.Text.Trim(),
                        txtApellidos.Text.Trim(),
                        Convert.ToInt32(cmbSexo.SelectedValue),
                        Convert.ToInt32(cmbRubro.SelectedValue),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtMovil.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        codigoDistrito,
                        txtObservaciones.Text.Trim()
                        );

                if (Respuesta == "OK")
                {
                    MensajeOk("El Distrito se Actualizó Correctamente");
                    estadoGuardar = 0; //sin ninguna accion
                    this.EstadoBotones(true);
                    this.EstadoBotonesProcesos(false);
                    this.ListarProveedores("%");
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                {
                    MensajeError(Respuesta);
                }
            }
        }
    }
}
