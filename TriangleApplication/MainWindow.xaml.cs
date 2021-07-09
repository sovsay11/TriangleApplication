using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TriangleApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double sideA, sideB, sideC, angleA, angleB, angleC;

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event handlers for when the user types something
        /// into the text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBoxSideA_TextChanged(object sender, TextChangedEventArgs e)
        {
            // validate user input
            if (double.TryParse(TxtBoxSideA.Text, out sideA) || TxtBoxSideA.Text == string.Empty)
            {
                TxtBoxSideA.Background = Brushes.White;
            }
            else
            {
                TxtBoxSideA.Background = Brushes.LightPink;
                LblResults.Content = "Please enter valid numbers";
            }
        }

        private void TxtBoxSideB_TextChanged(object sender, TextChangedEventArgs e)
        {
            // validate user input
            if (double.TryParse(TxtBoxSideB.Text, out sideB) || TxtBoxSideB.Text == string.Empty)
            {
                TxtBoxSideB.Background = Brushes.White;

                if (ValidateUserInput())
                {
                    LblResults.Content = "Inputs are valid";
                }
            }
            else
            {
                TxtBoxSideB.Background = Brushes.LightPink;
                LblResults.Content = "Please enter valid numbers";
            }
        }

        private void TxtBoxSideC_TextChanged(object sender, TextChangedEventArgs e)
        {
            // validate user input
            if (double.TryParse(TxtBoxSideC.Text, out sideC) || TxtBoxSideC.Text == string.Empty)
            {
                TxtBoxSideC.Background = Brushes.White;

                if (ValidateUserInput())
                {
                    LblResults.Content = "Inputs are valid";
                }
            }
            else
            {
                TxtBoxSideC.Background = Brushes.LightPink;
                LblResults.Content = "Please enter valid numbers";
            }
        }

        private bool ValidateUserInput()
        {
            if (TxtBoxSideA.Text != string.Empty && TxtBoxSideB.Text != string.Empty && TxtBoxSideC.Text != string.Empty &&
                sideA != 0 && sideB != 0 && sideC != 0)
            {
                return true;
            }
            return false;
        }
    }
}
