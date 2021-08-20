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
            // initialize window
            InitializeComponent();
            // call function to display all hastags
            DisplayHashtagReport();
        }

        // function to display list
        private void DisplayHashtagReport()
        {
            // read all files and store them in a string array
            string[] values = File.ReadAllLines(FilePathEnum.HashtagListFilePath);
            // foreach through string array
            foreach (string value in values)
            {
                // redisplay content of label with new values
                lblDisplay.Content = "\n" + lblDisplay.Content + value + "\n";
            }

            // clear file for next use
            File.WriteAllText(FilePathEnum.HashtagListFilePath, string.Empty);
        }
    }
}
