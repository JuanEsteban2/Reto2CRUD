using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capa_negocio;
using capa_logica;

namespace InterfazBiblioteca
{
    public partial class Form1 : Form
    {
        Clase_Logica objlog = new Clase_Logica();
        Clase_Presentacion objpre = new Clase_Presentacion();

        public Form1()
        {
            InitializeComponent();
        }

        void modificar(String accion)
        {
            objlog.codigo = Convert.ToInt32(entradaCodigo.Text);
            objlog.titulo = entradaTitulo.Text;
            objlog.autor = entradaAutor.Text;
            objlog.editorial = entradaEditorial.Text;
            objlog.precio = Convert.ToInt32(entradaPrecio.Text);
            objlog.cantidad = Convert.ToInt32(entradaCantidad.Text);
            objlog.accion = accion;
            String men = objpre.N_modificar_libro(objlog);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            entradaCodigo.Text = "0";
            entradaTitulo.Text = "";
            entradaAutor.Text = "";
            entradaEditorial.Text = "";
            entradaPrecio.Text = "0";
            entradaCantidad.Text = "0";
            dataGridView1.DataSource = objpre.N_ver_libros();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            limpiar();
            dataGridView1.DataSource = objpre.N_ver_libros();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // if (entradaCodigo.Text == "")
            //{
                if (MessageBox.Show("¿Deseas registrar a: " + entradaTitulo.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    modificar("1");
                    limpiar();
                }
            //}
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entradaCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a: " + entradaTitulo.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    modificar("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entradaCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a: " + entradaTitulo.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    modificar("3");
                    limpiar();
                }
            }
        }

        private void buscarTitulo_TextChanged(object sender, EventArgs e)
        {
            if ((buscarTitulo.Text != "") || (buscarAutor.Text != "") || (buscarEditorial.Text != ""))
            {
                objlog.titulo = buscarTitulo.Text;
                objlog.editorial = buscarEditorial.Text;
                objlog.autor = buscarAutor.Text;    
                DataTable dt = new DataTable();
                dt = objpre.N_buscar_libro(objlog);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objpre.N_ver_libros();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            entradaCodigo.Text = dataGridView1[0, fila].Value.ToString();
            entradaTitulo.Text = dataGridView1[1, fila].Value.ToString();
            entradaAutor.Text = dataGridView1[2, fila].Value.ToString();
            entradaEditorial.Text = dataGridView1[3, fila].Value.ToString();
            entradaPrecio.Text = dataGridView1[4, fila].Value.ToString();
            entradaCantidad.Text = dataGridView1[5, fila].Value.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void entradaCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void entradaEditorial_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
