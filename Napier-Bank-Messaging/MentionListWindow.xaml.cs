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
using System.Windows.Shapes;
using System.IO;

namespace Napier_Bank_Messaging
{
    /// <summary>
    /// Interaction logic for MentionListWindow.xaml
    /// </summary>
    public partial class MentionListWindow : Window
    {
        private const string MentionsFilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\MentionsList.txt";

        public MentionListWindow()
        {
            InitializeComponent();
            DisplayMentionList();
        }

        private void DisplayMentionList()
        {
            string[] values = File.ReadAllLines(MentionsFilePath);
            lblDisplay.Content = "\n";
            foreach (string value in values)
            {
                lblDisplay.Content = lblDisplay.Content + value + "\n";
            }
        }
    }
}
