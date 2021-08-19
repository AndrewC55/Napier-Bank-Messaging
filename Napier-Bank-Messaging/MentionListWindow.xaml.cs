using System.Windows;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging
{
    /// <summary>
    /// Interaction logic for MentionListWindow.xaml
    /// </summary>
    public partial class MentionListWindow : Window
    {
        public MentionListWindow()
        {
            // initialize window
            InitializeComponent();
            // call function to display all mentions
            DisplayMentionList();
        }

        // function to display all mentions
        private void DisplayMentionList()
        {
            // read all files and store them in a string array
            string[] values = File.ReadAllLines(FilePathEnum.MentionsListFilePath);
            // foreach through string array
            foreach (string value in values)
            {
                // redisplay content of label with new value
                lblDisplay.Content = "\n" + lblDisplay.Content + value + "\n";
            }

            // clear file for next use
            File.WriteAllText(FilePathEnum.MentionsListFilePath, string.Empty);
        }
    }
}
