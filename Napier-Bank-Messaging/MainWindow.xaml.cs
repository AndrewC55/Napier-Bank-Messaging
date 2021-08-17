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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Napier_Bank_Messaging
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

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            String type;
            if (txtHeader.Text.Contains("S"))
            {
                type = "SMS";
            } else if (txtHeader.Text.Contains("E"))
            {
                type = "Email";
            } else if (txtHeader.Text.Contains("T"))
            {
                type = "Tweet";
            } else
            {
                type = "False";
            }

            lblHeaderDisplay.Content = txtHeader.Text;
            lblBodyDisplay.Content = type + "\n" + txtBody.Text;
        }
    }
}
