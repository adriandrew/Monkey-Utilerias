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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int id;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            
        }

        void Nuevo() {
            id = 0;
            txtNombre.Text =String.Empty;
            txtApellidos.Text = String.Empty;
            Fecha.Value = DateTime.Now;
            cbSexo.SelectedIndex=-1;
            txtDireccion.Text = String.Empty;
            txtEscolaridad.Text = String.Empty;
            txtOcupacion.Text = String.Empty;
            txtNombre.Focus();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtApellidos.Text) && cbSexo.SelectedIndex != -1)
                {
                    Entidades.Ciudadano c = new Entidades.Ciudadano();
                    c.Nombre = txtNombre.Text;
                    c.Apellidos = txtApellidos.Text;
                    c.FechaNacimiento = Fecha.Value;
                    c.Sexo = (Entidades.Sexo)cbSexo.SelectedIndex;
                    c.Domicilio = txtDireccion.Text;
                    c.Escolaridad = txtEscolaridad.Text;
                    c.Ocupacion = txtOcupacion.Text;
                    c.Id = this.id;

                    if (id != 0)
                        c.Editar();
                    else
                        c.Agregar();
                    Nuevo();
                }
                else
                    MessageBox.Show("Debe llenar los campos requeridos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {
                if (this.id != 0) {
                    if(MessageBox.Show("Realmente desea eliminar el registro", "Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes){
                        Entidades.Ciudadano c = new Entidades.Ciudadano();
                        c.Id = this.id;
                        c.Eliminar();
                        Nuevo();
                    }
                }
            
            }
           
            
            catch(Exception ex){
                MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar b = new Buscar();
            b.Owner = this;
            b.ShowDialog();

            if (b.DialogResult == System.Windows.Forms.DialogResult.OK) {
                this.id = b.id;
                Entidades.Ciudadano c = new Entidades.Ciudadano();
                c.Id = this.id;
                c.Obtener();
                
                //Asignar todos los campos de texto
                txtNombre.Text = c.Nombre;
                txtApellidos.Text = c.Apellidos;
                Fecha.Value = c.FechaNacimiento;
                cbSexo.SelectedIndex = (int)c.Sexo;
                txtDireccion.Text = c.Domicilio;
                txtEscolaridad.Text = c.Escolaridad;
                txtOcupacion.Text = c.Ocupacion;
            }
            b.Close();
        }
    }
}
