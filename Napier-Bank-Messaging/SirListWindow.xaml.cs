using System.Windows;
using System.IO;

namespace Napier_Bank_Messaging
{
    /// <summary>
    /// Interaction logic for SirListWindow.xaml
    /// </summary>
    public partial class SirListWindow : Window
    {

        private const string SirFilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\SirList.txt";

        public SirListWindow()
        {
            InitializeComponent();
            DisplaySirReport();
        }

        private void DisplaySirReport()
        {
            string[] values = File.ReadAllLines(SirFilePath);
            lblDisplay.Content = "\n";
            foreach (string value in values)
            {
                lblDisplay.Content = lblDisplay.Content + value + "\n";
            }
        }
    }
}
