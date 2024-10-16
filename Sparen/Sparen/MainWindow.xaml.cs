using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sparen
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
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            pocketTextBox.Clear();
            weeklyRaiseTextBox.Clear();
            desiredSavingsTextBox.Clear();
            pocketTextBox.Text = "0";
            weeklyRaiseTextBox.Text = "0";
            desiredSavingsTextBox.Text = "0";
            pocketTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //input
            double weekGeld = double.Parse(pocketTextBox.Text);
            double verhoging = double.Parse(weeklyRaiseTextBox.Text);
            double gewenstBedrag = double.Parse(desiredSavingsTextBox.Text);
            StringBuilder berekening = new StringBuilder();
            //berekening
            int i = 0;
            double input = 0;
            while (input < gewenstBedrag)
            {
                input += weekGeld;
                weekGeld += verhoging;
                i++;

            }
            berekening.AppendLine($"Spaarbedrag na {i} weken:€{Math.Round(input - weekGeld,2)}\n");
            berekening.AppendLine($"Extra weekgeld op dat moment:€{Math.Round(weekGeld,2)}\n");
            berekening.AppendLine($"Totaal spaargeld:€{Math.Round(input,2)}\n");
            resultTextBox.Text = berekening.ToString();
        }
    }
}