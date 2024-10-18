using Microsoft.Win32;
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
    public partial class FrmUnidad_Medida : Form
    {

        private int opcionGuardar = 0;
        public FrmUnidad_Medida()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //aqui haremos que se mueva el formulario
            Utilitarios obj = new Utilitarios();
            obj.MoverFormulario(this);
        }

        //Metodo para mostrar mensajes de OK
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarket Intec", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Metodo para mostrar mensajes de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MiniMarket Intec", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Metodo para controlar el estado de los botones
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

        //Metodo para controlar el estado de los botones de procesos
        private void EstadoBotonesProcesos(bool estado)
        {
            btnGuardar.Visible = estado;
            btnCancelar.Visible = estado;
            btnActualizar.Visible = !estado;
            btnRetornar.Visible = !estado;
        }

        //Metodo para dar formato al DataGrid View Listado
        private void Formato()
        {
            dgvPrincipal.Columns[0].Width = 150;
            dgvPrincipal.Columns[0].HeaderText = "Código";
            dgvPrincipal.Columns[1].HeaderText = "Abreviatura";
            dgvPrincipal.Columns[1].Width = 150;
            dgvPrincipal.Columns[2].HeaderText = "Descripción";
            dgvPrincipal.Columns[2].Width = 250;
            dgvPrincipal.Columns[3].HeaderText = "Estado";
        }

        //Listar las unidades de medida en el Data Grid View
        private void ListarUM(string valor)
        {
            try
            {
                //llenamos el dgv
                dgvPrincipal.DataSource = NUnidad_Medida.ListarUM(valor);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo para obtener los datos del registro o fila seleccionada en el DGV
        private void SelecionarFila()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_um"].Value)))
            {
                txtAbreviatura.Text = dgvPrincipal.CurrentRow.Cells["abreviatura_um"].Value.ToString();
                txtDescripcion.Text = dgvPrincipal.CurrentRow.Cells["descripcion_um"].Value.ToString();
                txtId.Text = dgvPrincipal.CurrentRow.Cells["codigo_um"].Value.ToString();
            }
            else
            {
                MensajeError("Debe seleccionar una Unidad de Medida");
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUnidad_Medida_Load(object sender, EventArgs e)
        {
            //deshabilitar el txtDescripcion
            txtAbreviatura.Enabled = false;
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            this.ListarUM("%");
            this.Formato();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Respuesta = "";
            //control para mostrar un error
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Ingrese un Nombre para la Unidad de Medida");
            }
            if (txtAbreviatura.Text == "")
            {
                errorProvider.SetError(txtAbreviatura, "Ingrese un Nombre para la Unidad de Medida");
            }
            else
            {

                //revisamos si ya hay una unidad de medida con ese nombre
                if (NUnidad_Medida.Existe(txtDescripcion.Text.Trim()) == "1" || NUnidad_Medida.Existe(txtAbreviatura.Text.Trim()) == "1")
                {
                    MensajeError("La Unidad de Medida ya Existe");
                }
                else
                {
                    //limpiamos cualquier mensaje de error
                    errorProvider.Clear();
                    Respuesta = NUnidad_Medida.RegistrarUM(opcionGuardar, 0, txtDescripcion.Text.Trim(), txtAbreviatura.Text.Trim());
                    if (Respuesta == "OK")
                    {
                        //La unidad de medida se registró satisfactoriamente
                        MensajeOK("La Unidad de Medida se Registró Adecuadamente");
                        opcionGuardar = 0;
                        EstadoBotones(true);
                        EstadoBotonesProcesos(false);
                        //refrescamos el DGV
                        this.ListarUM("%");
                        tabPrincipal.SelectedIndex = 0; //para que se devuelva a la pestaña listado
                    }
                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
        }   

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //indicamos que queremos crear una nueva unidad de medida
            opcionGuardar = 1;
            EstadoBotones(false);
            EstadoBotonesProcesos(true);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            txtDescripcion.Text = "";
            tabPrincipal.SelectedIndex = 1;
            txtAbreviatura.Enabled = true;
            txtAbreviatura.Focus();
            txtAbreviatura.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            txtAbreviatura.Text = "";
            txtAbreviatura.Enabled = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            opcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarUM(txtBuscar.Text.Trim());
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarFila();
            EstadoBotonesProcesos(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            txtAbreviatura.Enabled = true;
            txtAbreviatura.Focus();
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            opcionGuardar = 2; //deseamos actualizar la unidad de medida
            string Respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Introduzca un nombre para la Unidad de Medida");
            }
            if (txtAbreviatura.Text == "")
            {
                errorProvider.SetError(txtAbreviatura, "Introduzca un nombre para la Unidad de Medidad");
            }
            else
            {
                errorProvider.Clear(); //limpia el mensaje de error anterior
                Respuesta = NUnidad_Medida.RegistrarUM(opcionGuardar, int.Parse(txtId.Text), txtDescripcion.Text.Trim(), txtAbreviatura.Text.Trim());
                if (Respuesta == "OK")
                {
                    MensajeOK("La Unidad de Medida se actualizó correctamente");
                    opcionGuardar = 0;
                    EstadoBotones(true);
                    EstadoBotonesProcesos(false);
                    txtDescripcion.Text = "";
                    txtAbreviatura.Text = "";
                    txtId.Text = "";
                    txtDescripcion.Enabled = false;
                    txtAbreviatura.Enabled = false;
                    this.ListarUM("%"); //refrescar el datagridview
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
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            txtAbreviatura.Text = "";
            txtAbreviatura.Enabled = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            opcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_um"].Value)))
            {
                if (MessageBox.Show("¿Seguro que desea eliminar la Unidad de Medida?", "Eliminar Unidad de Medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //desactivamos la marca
                    //obtener el id de la fila o unidad de medida seleccionada
                    int codigoUM = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_um"].Value);
                    string Respuesta = NUnidad_Medida.Desactivar(codigoUM);
                    if (Respuesta == "OK")
                    {
                        MensajeOK("La Unidad de Medida se eliminó correctamente");
                        this.ListarUM("%");
                    }

                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
            else
            {
                MensajeError("Debe seleccionar una Unidad de Medida");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
