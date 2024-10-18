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
    public partial class FrmRubros : Form
    {
        private int opcionGuardar = 0;
        public FrmRubros()
        {
            InitializeComponent();
        }

        #region "Mis Metodos Auxliares"

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
            dgvListado.Columns[0].Width = 150;
            dgvListado.Columns[0].HeaderText = "Código Rubro";
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "Nombre Rubro";
            dgvListado.Columns[2].HeaderText = "Estado";
        }

        //Listar las categorias en el Data Grid View
        private void ListarRubros(string valor)
        {
            try
            {
                //llenamos el dgv
                dgvListado.DataSource = NRubro.ListarRubros(valor);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo para obtener los datos del registro o fila seleccionada en el DGV
        private void SelecionarFila()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_ru"].Value)))
            {
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["descripcion_ru"].Value.ToString();
                txtId.Text = dgvListado.CurrentRow.Cells["codigo_ru"].Value.ToString();
            }
            else
            {
                MensajeError("Debe seleccionar un Rubro");
            }
        }

        #endregion


        private void FrmRubros_Load_1(object sender, EventArgs e)
        {
            //deshabilitar el txtDescripcion
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            this.ListarRubros("%");
            this.Formato();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string Respuesta = "";
            //control para mostrar un error
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Ingrese un Nombre para el Rubro");
            }
            else
            {
                //revisamos si ya hay una categoria con ese nombre
                if (NCategoria.Existe(txtDescripcion.Text.Trim()) == "1")
                {
                    MensajeError("El Rubro ya Existe");
                }
                else
                {
                    //limpiamos cualquier mensaje de error
                    errorProvider.Clear();
                    Respuesta = NRubro.RegistrarRubros(opcionGuardar, 0, txtDescripcion.Text.Trim());
                    if (Respuesta == "OK")
                    {
                        //La categoria se registró satisfactoriamente
                        MensajeOK("El Rubro se Registró Adecuadamente");
                        opcionGuardar = 0;
                        EstadoBotones(true);
                        EstadoBotonesProcesos(false);
                        //refrescamos el DGV
                        this.ListarRubros("%");
                        tabPrincipal.SelectedIndex = 0; //para que se devuelva a la pestaña listado
                    }
                    else
                    {
                        MensajeError(Respuesta);
                    }

                }
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            //indicamos que queremos crear un nuevo rubro
            opcionGuardar = 1;
            EstadoBotones(false);
            EstadoBotonesProcesos(true);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            txtDescripcion.Text = "";
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            opcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.ListarRubros(txtBuscar.Text.Trim());
        }

        private void dgvListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarFila();
            EstadoBotonesProcesos(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            opcionGuardar = 2; //deseamos actualizar el rubro
            string Respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Introduzca un nombre");
            }
            else
            {
                errorProvider.Clear(); //limpia el mensaje de error anterior
                Respuesta = NRubro.RegistrarRubros(opcionGuardar, int.Parse(txtId.Text), txtDescripcion.Text.Trim());
                if (Respuesta == "OK")
                {
                    MensajeOK("El Rubro se actualizó correctamente");
                    opcionGuardar = 0;
                    EstadoBotones(true);
                    EstadoBotonesProcesos(false);
                    txtDescripcion.Text = "";
                    txtId.Text = "";
                    txtDescripcion.Enabled = false;
                    this.ListarRubros("%"); //refrescar el datagridview
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                {
                    MensajeError(Respuesta);
                }
            }
        }

        private void btnRetornar_Click_1(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            opcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_ru"].Value)))
            {
                if (MessageBox.Show("¿Seguro que desea eliminar el Rubro?", "Eliminar Rubro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //desactivamos el rubro
                    //obtener el id de la fila o rubro seleccionado
                    int codigoRubros = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_ru"].Value);
                    string Respuesta = NRubro.Desactivar(codigoRubros);
                    if (Respuesta == "OK")
                    {
                        MensajeOK("El Rubro se eliminó correctamente");
                        this.ListarRubros("%");
                    }

                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
            else
            {
                MensajeError("Debe seleccionar un Rubro");
            }
        }


    }
}
