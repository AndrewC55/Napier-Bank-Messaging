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
using Napier_Bank_Messaging.Messages;
using Napier_Bank_Messaging.Tools;

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
            // define string values for values of text boxes
            string headerDisplay = txtHeader.Text,  bodyDisplay = txtBody.Text;
            // create instance of header validator
            HeaderValidator headerValidator = new HeaderValidator();

            if (!headerValidator.IsHeaderLengthValid(headerDisplay))
            {
                // if length of message ID is wrong then message is changed to error message
                headerDisplay = "Sorry, message ID must be 10 characters long, please try again";
            } else if (!headerValidator.isMessageTypeValid(headerDisplay))
            {
                // if message ID doesn't contain a message type then message is changed to error message
                headerDisplay = "Sorry, message ID must constain a message type ('S' = 'SMS', 'E' = 'Email', 'T' = 'Tweet')";
            } else if (!headerValidator.isMessageFormatCorrect(headerDisplay))
            {
                // if message ID is wrongly formatted then message is changed to error message
                headerDisplay = "Sorry, message must be in the format of message type followed by 9 numbers (e.g. E123456789)";
            }

            MessageFactory messageFactory = new MessageFactory();
            Message message = messageFactory.Factory(headerDisplay[0]);
            JsonAPI jsonAPI = new JsonAPI();

            if (!message.Format(bodyDisplay))
            {
                message.MessageBody = "Sorry there was an error with your formatting, please try again";
            } else
            {
                message.Sanatise(headerDisplay, bodyDisplay);
                jsonAPI.ToJson(message);
            }

            lblHeaderDisplay.Content = message.MessageHeader;
            lblBodyDisplay.Content = message.MessageBody;
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            SirListWindow sirListWindow = new SirListWindow();
            MentionListWindow mentionListWindow = new MentionListWindow();
            HashtagListWindow hashtagListWindow = new HashtagListWindow();
            sirListWindow.Show();
            mentionListWindow.Show();
            hashtagListWindow.Show();
            Close();
        }
    }
}
