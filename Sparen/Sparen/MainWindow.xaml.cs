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
            decimal weekGeld = decimal.Parse(pocketTextBox.Text);
            decimal verhoging = decimal.Parse(weeklyRaiseTextBox.Text);
            decimal gewenstBedrag = decimal.Parse(desiredSavingsTextBox.Text);
            StringBuilder berekening = new StringBuilder();
            //berekening
            int weekCounter = 0;
            decimal savedDecmicals = 0;
            decimal savedWeekGeld = 0;
            while (savedDecmicals < gewenstBedrag)
            {
                savedDecmicals += weekGeld;
                savedDecmicals += verhoging;
                savedWeekGeld += weekGeld;
               // total += savedDecmicals += extra;
                weekCounter++;

            }
            berekening.AppendLine($"Spaarbedrag na {weekCounter} weken:€{Math.Round(savedWeekGeld,2)}\n");
            berekening.AppendLine($"Extra weekgeld op dat moment:€{Math.Round(savedDecmicals - savedWeekGeld,2)}\n");
            berekening.AppendLine($"Totaal spaargeld:€{Math.Round(savedDecmicals,2)}\n");
            resultTextBox.Text = berekening.ToString();
        }
    }
}