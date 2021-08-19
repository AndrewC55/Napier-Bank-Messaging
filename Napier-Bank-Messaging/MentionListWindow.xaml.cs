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
            InitializeComponent();
            DisplayMentionList();
        }

        private void DisplayMentionList()
        {
            string[] values = File.ReadAllLines(FilePathEnum.MentionsListFilePath);
            lblDisplay.Content = "\n";
            foreach (string value in values)
            {
                lblDisplay.Content = lblDisplay.Content + value + "\n";
            }
        }
    }
}
