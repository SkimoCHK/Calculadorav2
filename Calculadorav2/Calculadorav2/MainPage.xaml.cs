using System;
using Xamarin.Forms;

namespace Calculadorav2
{
    public partial class MainPage : ContentPage
    {
        double valor1 = 0;
        double valor2 = 0;
        string operador = "";
        bool limpiarPantalla = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Numero(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string numero = boton.Text;

            if (limpiarPantalla)
            {
                ResultadoLabel.Text = "0";
                limpiarPantalla = false;
            }

            if (ResultadoLabel.Text == "0" && numero != ".")
            {
                ResultadoLabel.Text = numero;
            }
            else if (!ResultadoLabel.Text.Contains(".") || numero != ".")
            {
                ResultadoLabel.Text += numero;
            }
        }

        private void Operacion(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string nuevoOperador = boton.Text;

            if (!string.IsNullOrEmpty(operador) && !limpiarPantalla)
            {
                Calcular();
            }

            valor1 = double.Parse(ResultadoLabel.Text);
            operador = nuevoOperador;
            limpiarPantalla = true;
        }

        private void Igual(object sender, EventArgs e)
        {
            Calcular();
            operador = "";
        }

        private void LimpiarPantalla(object sender, EventArgs e)
        {
            ResultadoLabel.Text = "0";
            valor1 = 0;
            valor2 = 0;
            operador = "";
        }

        private void BorrarUnNumero(object sender, EventArgs e)
        {
            if (ResultadoLabel.Text.Length > 0)
            {
                ResultadoLabel.Text = ResultadoLabel.Text.Substring(0, ResultadoLabel.Text.Length - 1);
            }
            if (ResultadoLabel.Text == "")
            {
                ResultadoLabel.Text = "0";
            }
        }

        private void Calcular()
        {
            valor2 = double.Parse(ResultadoLabel.Text);
            ResultadoLabel.Text = RealizarOperacion(valor1, valor2, operador).ToString();
            limpiarPantalla = true;
        }

        private double RealizarOperacion(double num1, double num2, string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "x":
                    return num1 * num2;
                case "/":
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        return double.NaN;
                    }
                default:
                    return num2;
            }
        }
    }
}
