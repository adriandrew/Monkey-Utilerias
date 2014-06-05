using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWindows
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            try{
                grvCiudadanos.DataSource = Entidades.Ciudadano.ObtenerListado(); 
            }
            catch(Exception ex){
                MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int id;
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (grvCiudadanos.CurrentRow != null)
            {
                this.id = Convert.ToInt32(grvCiudadanos.CurrentRow.Cells[0].Value.ToString());
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Debes seleccionar un registro","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                grvCiudadanos.DataSource = Entidades.Ciudadano.ObtenerListadoCriterios(txtNombre.Text,txtApellidos.Text); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
    }
}
