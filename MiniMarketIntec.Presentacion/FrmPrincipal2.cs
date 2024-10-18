using MiniMarket.Presentacion;
using MiniMarketIntec.Entidad;
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
    public partial class FrmPrincipal2 : Form
    {
        private int childFormNumber = 0;

        public FrmPrincipal2()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductos productos = new FrmProductos();
            productos.MdiParent = this;
            productos.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Proveedores proveedores = new Frm_Proveedores();
            proveedores.MdiParent = this;
            proveedores.Show(); 
        }

        private void rubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRubros rubros = new FrmRubros();
            rubros.MdiParent = this;    
            rubros.Show();  
        }

        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlmacenes almacenes = new FrmAlmacenes();    
            almacenes.MdiParent = this;
            almacenes.Show();   
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias categorias = new FrmCategorias(); 
            categorias.MdiParent = this;    
            categorias.Show();
        }

        private void municipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPaises paises = new FrmPaises();
            paises.MdiParent = this;
            paises.Show();
        }

        private void municipiosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMunicipio municipio = new FrmMunicipio();
            municipio.MdiParent = this;
            municipio.Show();
        }

        private void unidadDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnidad_Medida unidad_Medida = new FrmUnidad_Medida();
            unidad_Medida.MdiParent = this;
            unidad_Medida.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcas marcas = new FrmMarcas();
            marcas.MdiParent = this;
            marcas.Show();
        }
    }
}
