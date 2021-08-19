using System.Windows;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging
{
    /// <summary>
    /// Interaction logic for SirListWindow.xaml
    /// </summary>
    public partial class SirListWindow : Window
    {
        public SirListWindow()
        {
            InitializeComponent();
            DisplaySirReport();
        }

        private void DisplaySirReport()
        {
            string[] values = File.ReadAllLines(FilePathEnum.SirListFilePath);
            lblDisplay.Content = "\n";
            foreach (string value in values)
            {
                lblDisplay.Content = lblDisplay.Content + value + "\n";
            }
        }
    }
}
