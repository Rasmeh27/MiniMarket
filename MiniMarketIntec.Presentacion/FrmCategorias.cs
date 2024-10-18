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
    public partial class FrmCategorias : Form
    {
        private int opcionGuardar = 0;

        public FrmCategorias()
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
            dgvListado.Columns[0].HeaderText = "Código Categoría";
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "Nombre Categoría";
            dgvListado.Columns[2].HeaderText = "Estado";
        }

        //Listar las categorias en el Data Grid View
        private void ListarCategorias(string valor)
        {
            try
            {
                //llenamos el dgv
                dgvListado.DataSource = NCategoria.ListarCategorias(valor);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo para obtener los datos del registro o fila seleccionada en el DGV
        private void SelecionarFila()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_cat"].Value)))
            {
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["descripcion_cat"].Value.ToString();
                txtId.Text = dgvListado.CurrentRow.Cells["codigo_cat"].Value.ToString();
            }
            else
            {
                MensajeError("Debe seleccionar una Categoría");
            }
        }
        #endregion

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //aqui haremos que se mueva el formulario
            Utilitarios obj = new Utilitarios();
            obj.MoverFormulario(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); //esto cierra el formulario
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            //deshabilitar el txtDescripcion
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            this.ListarCategorias("%");
            this.Formato();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Respuesta = "";
            //control para mostrar un error
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Ingrese un Nombre para la Categoría");
            }
            else
            {
                //revisamos si ya hay una categoria con ese nombre
                if (NCategoria.Existe(txtDescripcion.Text.Trim()) == "1")
                {
                    MensajeError("La Categoría ya Existe");
                }
                else
                {
                    //limpiamos cualquier mensaje de error
                    errorProvider.Clear();
                    Respuesta = NCategoria.RegistrarCategoria(opcionGuardar, 0, txtDescripcion.Text.Trim());
                    if (Respuesta == "OK")
                    {
                        //La categoria se registró satisfactoriamente
                        MensajeOK("La Categoría se Registró Adecuadamente");
                        opcionGuardar = 0;
                        EstadoBotones(true);
                        EstadoBotonesProcesos(false);
                        //refrescamos el DGV
                        this.ListarCategorias("%");
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
            //indicamos que queremos crear una nueva categoria
            opcionGuardar = 1;
            EstadoBotones(false);
            EstadoBotonesProcesos(true);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            txtDescripcion.Text = "";
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            opcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListarCategorias(txtBuscar.Text.Trim());
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarFila();
            EstadoBotonesProcesos(false);
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            tabPrincipal.SelectedIndex = 1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            opcionGuardar = 2; //deseamos actualizar la categoria
            string Respuesta = "";
            ErrorProvider errorProvider = new ErrorProvider();

            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(txtDescripcion, "Introduzca un nombre");
            }
            else
            {
                errorProvider.Clear(); //limpia el mensaje de error anterior
                Respuesta = NCategoria.RegistrarCategoria(opcionGuardar, int.Parse(txtId.Text), txtDescripcion.Text.Trim());
                if(Respuesta == "OK")
                {
                    MensajeOK("La Categoría se actualizó correctamente");
                    opcionGuardar = 0;
                    EstadoBotones(true);
                    EstadoBotonesProcesos(false);
                    txtDescripcion.Text = "";
                    txtId.Text = "";
                    txtDescripcion.Enabled = false;
                    this.ListarCategorias("%"); //refrescar el datagridview
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
            EstadoBotones(true);
            EstadoBotonesProcesos(false);
            opcionGuardar = 0;
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_cat"].Value)))
            {
                if (MessageBox.Show("¿Seguro que desea eliminar la Categoría?", "Eliminar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //desactivamos la categoria
                    //obtener el id de la fila o categoria seleccionada
                    int codigoCategoria = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_cat"].Value);
                    string Respuesta = NCategoria.Desactivar(codigoCategoria);
                    if (Respuesta == "OK")
                    {
                        MensajeOK("La Categoría se eliminó correctamente");
                        this.ListarCategorias("%");
                    }

                    else
                    {
                        MensajeError(Respuesta);
                    }
                }
            }
            else 
            {
                MensajeError("Debe seleccionar una Categoría");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
