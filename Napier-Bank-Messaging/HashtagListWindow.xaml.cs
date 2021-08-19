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
    /// Interaction logic for HashtagListWindow.xaml
    /// </summary>
    public partial class HashtagListWindow : Window
    {
        private const string SirFilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\HashtagList.txt";

        public HashtagListWindow()
        {
            InitializeComponent();
            DisplayHashtagReport();
        }

        private void DisplayHashtagReport()
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
