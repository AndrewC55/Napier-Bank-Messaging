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
using Napier_Bank_Messaging.Validators;

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
            string headerDisplay = txtHeader.Text,  bodyDisplay = txtBody.Text;
            HeaderValidator headerValidator = new HeaderValidator();

            if (!headerValidator.IsHeaderLengthValid(txtHeader.Text))
            {
                headerDisplay = "Sorry, message ID must be 10 characters long, please try again";
            } else if (!headerValidator.isMessageTypeValid(txtHeader.Text))
            {
                headerDisplay = "Sorry, message ID must constain a message type ('S' = 'SMS', 'E' = 'Email', 'T' = 'Tweet')";
            } else if (!headerValidator.isMessageFormatCorrect(txtHeader.Text))
            {
                headerDisplay = "Sorry, message must be in the format of message type followed by 9 numbers (e.g. E123456789)";
            }

            lblHeaderDisplay.Content = headerDisplay;
            lblBodyDisplay.Content = bodyDisplay;
        }
    }
}
