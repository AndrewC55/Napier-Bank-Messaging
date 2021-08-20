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
            // initialize window
            InitializeComponent();
            // call function to display all sirs
            DisplaySirReport();
        }

        // function to redisplay all sirs
        private void DisplaySirReport()
        {
            // read all files and store them in a string array
            string[] values = File.ReadAllLines(FilePathEnum.SirListFilePath);
            // foreach through string array
            foreach (string value in values)
            {
                // redisplay content of label with new values
                lblDisplay.Content = lblDisplay.Content + value + "\n";
            }

            // clear file for next use
            File.WriteAllText(FilePathEnum.SirListFilePath, string.Empty);
        }
    }
}
