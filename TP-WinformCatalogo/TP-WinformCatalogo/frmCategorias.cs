﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP_WinformCatalogo
{
    public partial class frmCategorias : Form
    {



        private List<Categoria> listaCategorias;
        public frmCategorias()
        {
            InitializeComponent();
        }


        private void cargar()
        {
            //Aca invoco la lectura a la BD...
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {

                listaCategorias = negocio.listar(); // Asigna los datos obtenidos de la base de datos a listaArticulo

                dgvCategorias.DataSource = listaCategorias; // Asigna listaArticulo como origen de datos para el DataGridView





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }




        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategorias.DataSource = negocio.listar();
        }

        private void btnAgregarCategorias_Click(object sender, EventArgs e)
        {
            frmAltaCategorias ventana = new frmAltaCategorias();
            ventana.ShowDialog();
        }

        private void btnEliminarCategorias_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria seleccionada;

            try
            {
                DialogResult respuesta = MessageBox.Show("Confirme nuevamente si quiere eliminarlo.", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    negocio.eliminarCategoria(seleccionada.ID);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
