using MiniMarketIntec.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarketIntec.Presentacion
{
    public partial class FrmAlmacen : Form
    {

        private int opcion;
        public FrmAlmacen()
        {
            InitializeComponent();
        }

        #region "Mis Metodos Personalizados"
        //metodo para indicar que algo salio bien
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarketIntec", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //metodo para indicar que algo salio mal
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarketIntec", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //metodo para habilitar y deshabilitar los botones principales
        private void EstadoBotones(bool estado)
        {
            btnNuevo.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnReporte.Enabled = estado;
            btnElminar.Enabled = estado;

            btnGuardar.Visible = !estado;
            btnCancelar.Visible = !estado;
            btnActualizar.Visible = !estado;
            btnRetornar.Visible = !estado;
        }

        //metodo paras habilitar y deshabilitar los botones de proceso
        private void EstadoBotonesProcesos(bool estado)
        {
            btnGuardar.Visible = estado;
            btnCancelar.Visible = estado;
            btnActualizar.Visible = !estado;
            btnRetornar.Visible = !estado;
        }

        //metodo para dar formato al DataGridView
        private void Formato()
        {
            //id de categoria
            dgvListado.Columns[0].Width = 150;
            dgvListado.Columns[0].HeaderText = "Codigo Almacen";
            // descripcion de catgeoria
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "Nombre Almacen";
            //estado categorias
            dgvListado.Columns[2].HeaderText = "Estado";

        }

        //metodo para llenar el DataGridView
        private void ListarAlmacen(string valor)
        {
            try
            {
                dgvListado.DataSource = NAlmacen.ListarAlmacenes(valor); //me devuelve el datatable de categoria
                this.Formato();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SeleccionarItem()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_alm"].Value)))
            {
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["descripcion_alm"].Value.ToString();
                txtId.Text = dgvListado.CurrentRow.Cells["codigo_alm"].Value.ToString();

            }
            else
            {
                MensajeError("No seleccionado");
            }
        }
        #endregion
        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false; //deshabilitamos la crecacion/ edicion de categorias
            this.EstadoBotones(true);
            this.ListarAlmacen("%"); //me traera todas las categorias creadas
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //instanciar la clase utilitarios
            Utilitarios objeto = new Utilitarios();
            //le decimos que mueva el formulario
            objeto.MoverFormulario(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //el usuario quiere crear una nueva cateogria
            opcion = 1;
            this.EstadoBotones(false); //deshabilita los botones principales
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = " "; //borra cualquier contenido que hata en el textbox
            txtDescripcion.Focus();
            this.EstadoBotonesProcesos(true); //habilito los botones
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == " ") //dejar espacio
            {
                errorProvider.SetError(txtDescripcion, "Ingrese un nombre de Almacen");
            }
            else
            {
                //investigar si la categoria existe
                if (NAlmacen.Existe(txtDescripcion.Text.Trim()) == "1")
                {
                    //significa que a categoria existe
                    MensajeError("El Almacen ya Existe");
                }
                else
                {
                    //borra cualquier error del errorProvider
                    errorProvider.Clear();
                    Respuesta = NAlmacen.RegistrarAlmacen(opcion, 0, txtDescripcion.Text.Trim());
                    if (Respuesta == "OK")
                    {
                        MensajeOK("El Almacen se registro correctamente");
                        opcion = 0;
                        EstadoBotones(true);
                        EstadoBotonesProcesos(false);
                        txtDescripcion.Text = "";
                        txtDescripcion.Enabled = false;
                        this.ListarAlmacen("%");
                        tabPrincipal.SelectedIndex = 0;
                    }
                    else
                    {
                        MensajeError(Respuesta);
                    }

                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcion = 0;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarAlmacen(txtBuscar.Text.Trim());
        }

        private void btnElminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_alm"].Value)))
            {
                if (MessageBox.Show("Seguro que desea eliminar este almacen?", "Eliminar Almacen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //obtener id categoria
                    int idAlmacen = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_alm"].Value);
                    //desactivar categoria
                    string Respuesta = NAlmacen.Desactivar(idAlmacen);
                    if (Respuesta == "OK")
                    {
                        MensajeOK("El almacen se elimino correctamente");
                        this.ListarAlmacen("%");
                    }
                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarItem();
            EstadoBotonesProcesos(false);
            txtDescripcion.Enabled = true;
            tabPrincipal.SelectedIndex = 1;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            opcion = 2; //se desea actualizar la categoria
            string Respuesta = " ";
            ErrorProvider errorProvider = new ErrorProvider();

            //investigar si la categoria existe
            if (NAlmacen.Existe(txtDescripcion.Text.Trim()) == "1")
            {
                //significa que a categoria existe
                MensajeError("El almacen ya Existe");
            }
            else
            {
                //borra cualquier error del errorProvider
                errorProvider.Clear();
                Respuesta = NAlmacen.RegistrarAlmacen(opcion, Convert.ToInt32(txtId.Text), txtDescripcion.Text.Trim());
                if (Respuesta == "OK")
                {
                    MensajeOK("El almacen se actualizo correctamente");
                    opcion = 0;
                    EstadoBotones(true);
                    EstadoBotonesProcesos(false);
                    txtDescripcion.Text = "";
                    txtDescripcion.Enabled = false;
                    this.ListarAlmacen("%");
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                {
                    MensajeError(Respuesta);
                }

            }
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            opcion = 0;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
