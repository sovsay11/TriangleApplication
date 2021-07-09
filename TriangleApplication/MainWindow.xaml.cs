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
            // validate current textbox input
            if (double.TryParse(TxtBoxSideA.Text, out sideA) || TxtBoxSideA.Text == string.Empty)
            {
                TxtBoxSideA.Background = Brushes.White;

                // validate all other user input
                if (ValidateUserInput())
                {
                    // check if the sides produce a valid triangle
                    if (IsTriangle())
                    {
                        TxtBlockResults.Text = $"These side lengths produce a valid {GetTriangleSideType()} triangle.";
                    }
                    else
                    {
                        TxtBlockResults.Text = "A triangle is not possible with the given values.";
                    }
                }
            }
            else
            {
                TxtBoxSideA.Background = Brushes.LightPink;
                TxtBlockResults.Text = "Please enter valid numbers";
            }
        }

        private void TxtBoxSideB_TextChanged(object sender, TextChangedEventArgs e)
        {
            // validate current textbox input
            if (double.TryParse(TxtBoxSideB.Text, out sideB) || TxtBoxSideB.Text == string.Empty)
            {
                TxtBoxSideB.Background = Brushes.White;

                // validate all other user input
                if (ValidateUserInput())
                {
                    // check if the sides produce a valid triangle
                    if (IsTriangle())
                    {
                        TxtBlockResults.Text = $"These side lengths produce a valid {GetTriangleSideType()} triangle.";
                    }
                    else
                    {
                        TxtBlockResults.Text = "A triangle is not possible with the given values.";
                    }
                }
            }
            else
            {
                TxtBoxSideB.Background = Brushes.LightPink;
                TxtBlockResults.Text = "Please enter valid numbers";
            }
        }

        private void TxtBoxSideC_TextChanged(object sender, TextChangedEventArgs e)
        {
            // validate current textbox input
            if (double.TryParse(TxtBoxSideC.Text, out sideC) || TxtBoxSideC.Text == string.Empty)
            {
                TxtBoxSideC.Background = Brushes.White;

                // validate all other user input
                if (ValidateUserInput())
                {
                    // check if the sides produce a valid triangle
                    if (IsTriangle())
                    {
                        TxtBlockResults.Text = $"These side lengths produce a valid {GetTriangleSideType()} triangle.";
                    }
                    else
                    {
                        TxtBlockResults.Text = "A triangle is not possible with the given values.";
                    }
                }
            }
            else
            {
                TxtBoxSideC.Background = Brushes.LightPink;
                TxtBlockResults.Text = "Please enter valid numbers";
            }
        }

        /// <summary>
        /// Validates all user input. Checks if the text boxes
        /// are empty and if they have valid values (integers and floats).
        /// </summary>
        /// <returns></returns>
        private bool ValidateUserInput()
        {
            if (TxtBoxSideA.Text != string.Empty && TxtBoxSideB.Text != string.Empty && TxtBoxSideC.Text != string.Empty &&
                sideA != 0 && sideB != 0 && sideC != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the type of triangle based on the side lengths.
        /// Will return either scalene, isosceles, or equilateral.
        /// Returns a string value.
        /// </summary>
        /// <returns></returns>
        private string GetTriangleSideType()
        {
            // we can assume all the values are valid at this point
            // the types
            // Scalene(side)
            // Isosceles(side)
            // Equilateral(side)
            if (sideA == sideB && sideA == sideC)
            {
                return "equilateral";
            }
            else if (sideA != sideB && sideA != sideC && sideB != sideC)
            {
                return "scalene";
            }
            else
            {
                return "isosceles";
            }
        }

        /// <summary>
        /// Checks if the provided side values
        /// produces a valid triangle. Returns a boolean value.
        /// </summary>
        /// <returns></returns>
        private bool IsTriangle()
        {
            if (sideA + sideB > sideC &&
                sideA + sideC > sideB &&
                sideB + sideC > sideA)
            {
                return true;
            }
            return false;
        }
    }
}
