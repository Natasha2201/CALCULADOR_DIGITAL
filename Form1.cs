using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALCULADOR_DIGITAL
{
    public partial class Form1 : Form
    {

        double primerNumero, segundoNumero, resultado;
        string operacion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            segundoNumero = Convert.ToDouble(txtDisplay.Text);

            switch (operacion)
            {
                case "+":
                    resultado = primerNumero + segundoNumero;
                    break;
                case "-":
                    resultado = primerNumero - segundoNumero;
                    break;
                case "*":
                    resultado = primerNumero * segundoNumero;
                    break;
                case "/":
                    if (segundoNumero != 0)
                        resultado = primerNumero / segundoNumero;
                    else
                        MessageBox.Show("No se puede dividir por cero.");
                    break;
            }

            txtDisplay.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            primerNumero = segundoNumero = resultado = 0;
            operacion = "";
        }

        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && "+-*/".IndexOf(e.KeyChar) == -1)
                {
                    e.Handled = true; 
                }

                if (e.KeyChar == '-' && txtDisplay.Text.Length == 0)
                {
                    return;
                }

                if ("+-*/".Contains(e.KeyChar) && txtDisplay.Text.Length > 0)
                {
                    primerNumero = Convert.ToDouble(txtDisplay.Text);
                    operacion = e.KeyChar.ToString();
                    txtDisplay.Clear();
                    e.Handled = true; 
                }

                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnIgual_Click(sender, e);
                    e.Handled = true; 
                }
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtDisplay.Text += btn.Text;
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            primerNumero = Convert.ToDouble(txtDisplay.Text);
            operacion = btn.Text;
            txtDisplay.Clear();
        }


    }
}
