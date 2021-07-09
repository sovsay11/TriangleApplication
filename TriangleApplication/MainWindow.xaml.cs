using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
