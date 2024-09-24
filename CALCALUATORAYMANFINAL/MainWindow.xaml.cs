using System;
using System.Windows;
using System.Windows.Controls;
using static System.Math; // Importation de la bibliothèque pour les fonctions mathématiques

namespace WpfCalculator
{
    public partial class MainWindow : Window
    {
        private string _operation = "";
        private double _firstNumber = 0;
        private double _secondNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Gère le clic des boutons pour les nombres
        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string btnContent = btn.Content.ToString();

            // Ajoute le contenu du bouton au display
            if (TB_Display.Text == "0")
                TB_Display.Text = "";

            TB_Display.Text += btnContent;
        }

        // Gère les opérations (+, -, *, /)
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            _firstNumber = Convert.ToDouble(TB_Display.Text);
            _operation = btn.Content.ToString();
            TB_Display.Text = "";
        }

        // Gère le calcul final lorsque l'utilisateur appuie sur le bouton "="
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            _secondNumber = Convert.ToDouble(TB_Display.Text);
            double result = 0;

            switch (_operation)
            {
                case "+":
                    result = _firstNumber + _secondNumber;
                    break;
                case "-":
                    result = _firstNumber - _secondNumber;
                    break;
                case "*":
                    result = _firstNumber * _secondNumber;
                    break;
                case "/":
                    if (_secondNumber != 0)
                        result = _firstNumber / _secondNumber;
                    else
                        MessageBox.Show("Erreur : Division par zéro !");
                    break;
                default:
                    MessageBox.Show("Erreur : Opération non reconnue !");
                    break;
            }

            TB_Display.Text = result.ToString();
        }

        // Gère l'action du bouton "CLR" pour réinitialiser la calculatrice
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "0";
            _firstNumber = 0;
            _secondNumber = 0;
            _operation = "";
        }

        // Multiplication par 10
        private void MultiplyByTen_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(TB_Display.Text);
            TB_Display.Text = (number * 10).ToString();
        }

        // Racine carrée
        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(TB_Display.Text);
            TB_Display.Text = Math.Sqrt(number).ToString();
        }

        // Puissance (x^y)
        private void Power_Click(object sender, RoutedEventArgs e)
        {
            _firstNumber = Convert.ToDouble(TB_Display.Text);
            _operation = "power";
            TB_Display.Text = "";
        }

        // Logarithme (log base 10)
        private void Log_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(TB_Display.Text);
            TB_Display.Text = Math.Log10(number).ToString();
        }
    }
}
