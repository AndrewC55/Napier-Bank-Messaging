using System.Windows;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging
{
    /// <summary>
    /// Interaction logic for HashtagListWindow.xaml
    /// </summary>
    public partial class HashtagListWindow : Window
    {
        public HashtagListWindow()
        {
            InitializeComponent();
            DisplayHashtagReport();
        }

        private void DisplayHashtagReport()
        {
            string[] values = File.ReadAllLines(FilePathEnum.HashtagListFilePath);
            lblDisplay.Content = "\n";
            foreach (string value in values)
            {
                lblDisplay.Content = lblDisplay.Content + value + "\n";
            }
        }
    }
}
