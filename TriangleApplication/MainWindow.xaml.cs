using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TriangleApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TxtBoxSideA.Focus();
        }

        /// <summary>
        /// Event handler method that will trigger once the user
        /// types something into one of the text boxes. The input
        /// will then be validated and used in calculations to determine the
        /// triangle's type, shape, and other attributes based on the given input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBoxSide_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;

            // highlight errors and prompt the user to fix them
            if (double.TryParse(currentTextBox.Text, out _) || currentTextBox.Text == string.Empty)
            {
                currentTextBox.Background = Brushes.White;

                // checks if all the other text boxes are valid, will only trigger if the text boxes are all double values
                if (ValidateUserInput())
                {
                    // create a new triangle with the validated input from the text boxes
                    Triangle triangle = new Triangle(double.Parse(TxtBoxSideA.Text), double.Parse(TxtBoxSideB.Text), double.Parse(TxtBoxSideC.Text));

                    // return text to the user about triangle side type, angle type, and angle values or if a triangle cannot be created with the given values
                    TxtBlockResults.Text = triangle.IsTriangle()
                        ? $"These side lengths produce a valid {triangle.GetTriangleAngleType()} {triangle.GetTriangleSideType()} triangle.\n\n" +
                            $"The angles for the triangle are:\n{triangle.AngleA}°, {triangle.AngleB}°, {triangle.AngleC}°"
                        : "A triangle is not possible with the given values.";

                    DrawTriangle(triangle);
                }
                else
                {
                    TxtBlockResults.Text = "Please enter valid numbers";
                }
            }
            else
            {
                currentTextBox.Background = Brushes.LightPink;
                TxtBlockResults.Text = "Please enter valid numbers";
            }
        }

        private void DrawTriangle(Triangle triangle)
        {
            // canvas limits
            // top left is 0 0, bottom right is 430 300
            // Height = "300"
            // Width = "430"
            // middle of canvas = 215, 150
            // upper limits are 215, 150 for scaling

            // we also know the angles so...
            double x1 = triangle.SideA;
            double y1 = 0;

            double x2 = 0;
            double y2 = 0;

            // x = x1 + m(y2 - y1) / n
            double x3 = x1 + (triangle.SideA * (y1 - y2) / triangle.SideB);
            double y3 = triangle.SideC;
            //x = start_x + len * cos(angle);
            //y = start_y + len * sin(angle);
            // assume we draw the triangle at x, y = 0

            // need to perform calculations prior to this
            Point pointA = new Point(x1, y1);
            Point pointB = new Point(x2, y2);
            Point pointC = new Point(x3, y3);

            PointCollection points = new PointCollection() { pointA, pointB, pointC};

            PolyTriangle.Points = points;
        }

        /// <summary>
        /// Validates all user input. Checks if the text boxes
        /// are empty and if they have valid values (integers and floats).
        /// </summary>
        /// <returns></returns>
        private bool ValidateUserInput()
        {
            return double.TryParse(TxtBoxSideA.Text, out _) && double.TryParse(TxtBoxSideB.Text, out _) && double.TryParse(TxtBoxSideC.Text, out _);
        }

        /// <summary>
        /// Enable window to be dragged around
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        /// <summary>
        /// Minimize the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Exit out of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
