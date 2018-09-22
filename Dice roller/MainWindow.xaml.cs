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

namespace DiceRoller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the result of rolling [size]d[count].
        /// </summary>
        /// <param name="size">Size of die rolled.</param>
        /// <param name="count">number of dice rolled.</param>
        /// <returns>[count]d[size]</returns>
        public static long RollDie(int size, long count)
        {
            if (size == 0)
                return 0;

            Random roll = new Random();
            long sum = 0;

            for (long i = 0; i < count; i++)
            {
                sum += roll.Next(size) + 1;
            }

            return sum;
        }
        


        private void D4Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (D4Input.Text == "")
                D4Input.Text = "0";
        }
        private void D6Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (D6Input.Text == "")
                D6Input.Text = "0";
        }
        private void D8Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (D8Input.Text == "")
                D8Input.Text = "0";
        }
        private void D10Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (D10Input.Text == "")
                D10Input.Text = "0";
        }
        private void D12Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (D12Input.Text == "")
                D12Input.Text = "0";
        }
        private void D20Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (D20Input.Text == "")
                D20Input.Text = "0";
        }

        /// <summary>
        /// Places into ResultsBox the sum of the results of the desired dice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            long d4Count;
            long d6Count;
            long d8Count;
            long d10Count;
            long d12Count;
            long d20Count;

            try
            {
                d4Count  = long.Parse(D4Input.Text);
                d6Count  = long.Parse(D6Input.Text);
                d8Count  = long.Parse(D8Input.Text);
                d10Count = long.Parse(D10Input.Text);
                d12Count = long.Parse(D12Input.Text);
                d20Count = long.Parse(D20Input.Text);

                if (new long[] { d4Count, d6Count, d8Count, d10Count, d12Count, d20Count }.Min() < 0)
                    throw new FormatException("Oopsie poopsie");
            }
            catch (FormatException)
            {
                ResultsBox.Text = "nAn";
                return;
            }
            catch (OverflowException)
            {
                ResultsBox.Text = "! OVERFLOW ERROR !";
                return;
            }

            // Assume that the die values are legitimate

            ResultsBox.Text = "" + (
                + RollDie(4, d4Count)
                + RollDie(6, d6Count)
                + RollDie(8, d8Count)
                + RollDie(10, d10Count)
                + RollDie(12, d12Count)
                + RollDie(20, d20Count)
            );

        }                   

        /// <summary>
        /// Resets the program state to factory standard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            D4Input.Text =  "0";
            D6Input.Text =  "0";
            D8Input.Text =  "0";
            D10Input.Text = "0";
            D12Input.Text = "0";
            D20Input.Text = "0";

            ResultsBox.Text = "Results";
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F5:
                    RollButton_Click(sender, new RoutedEventArgs());
                    break;
                case Key.Escape:
                    ClearButton_Click(sender, new RoutedEventArgs());
                    break;
                default:
                    break;
            }
        }
    }

    
}
