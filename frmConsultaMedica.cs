using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stream_18_05
{
    public partial class frmConsultaMedica : Form
    {
        public frmConsultaMedica()
        {
            InitializeComponent();
        }

        private int cantCardio = 0;
        private int cantOdonto = 0;
        private int cantPediatra = 0;

        private int cantConsultas = 0;
        private double acuPrecios = 0;
        private double promPrecio = 0;

        private int especialidadMax = 0;
        private double precioMax = 0;
        private bool flag = true;

        private double porcCardio = 0;
        private double porcOdonto = 0;
        private double porcPedia = 0;

        // boton calcular/registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------
            // variables para tomar datos del formulario

            int textoMatricula = int.Parse(txtMatricula.Text);

            string textoNombre = txtNombre.Text;

            int sGenero;

            if (rboMasculino.Checked) sGenero = 1;
            else if (rboFemenino.Checked) sGenero = 2;
            else sGenero = 3;

            int comboEspecialidad = cboEspecialidad.SelectedIndex + 1;

            double textoPrecio = double.Parse(txtPrecioConsulta.Text);

            string fechaConsulta = dtpFechaConsulta.Value.ToShortDateString();

            // ------------------------------------------------------------------
            // instancia de clase

            Medico drHouse = new Medico(textoMatricula, textoNombre, sGenero, comboEspecialidad, textoPrecio, fechaConsulta);

            // ------------------------------------------------------------------
            // Calculos de datos

            // calculos de contadores de especialidades
            switch (comboEspecialidad)
            {
                case 1:
                    cantCardio++;
                    break;

                case 2:
                    cantOdonto++;
                    break;

                default:
                    cantPediatra++;
                    break;
            }

            // calculo de precio promedio

            cantConsultas++;

            acuPrecios += textoPrecio;

            promPrecio = Math.Round((acuPrecios / cantConsultas), 2);

            // calculo de precio y especialidad de la consulta mas cara

            if (flag)
            {
                flag = false;
                especialidadMax = comboEspecialidad;
                precioMax = textoPrecio;
            }
            else
            {
                if (textoPrecio > precioMax)
                {
                    precioMax = textoPrecio;
                    especialidadMax = comboEspecialidad;
                }
            }

            // calculo de porcentajes

            porcCardio = (100 * cantCardio) / cantConsultas;
            porcOdonto = (100 * cantOdonto) / cantConsultas;
            porcPedia = (100 * cantPediatra) / cantConsultas;

            // ------------------------------------------------------------------
            // asignacion de labels

            lblCantCardio.Text = cantCardio.ToString();
            lblCantOdonto.Text = cantOdonto.ToString();
            lblCantPedia.Text = cantPediatra.ToString();

            lblPrecioProm.Text = "$" + promPrecio.ToString();
            lblPrecioMax.Text = "$" + precioMax.ToString();
            lblEspecialidadMax.Text = drHouse.CalcularEspecialidad(especialidadMax);

            lblPorcCardio.Text = porcCardio.ToString() + "%";
            lblPorcOdonto.Text = porcOdonto.ToString() + "%";
            lblPorcPedia.Text = porcPedia.ToString() + "%";

            // ------------------------------------------------------------------
            // Mensaje Final Datos

            MessageBox.Show(drHouse.MostrarDatos());
        }

        // boton limpiar campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtNombre.Text = "";
            rboOtro.Checked = true;
            cboEspecialidad.SelectedIndex = -1;
            txtPrecioConsulta.Text = "";
            dtpFechaConsulta.Value = DateTime.Today;
        }

        // boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}