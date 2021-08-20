using System.Windows;
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
            // create instance of message factory
            MessageFactory messageFactory = new MessageFactory();
            // create instance of message class returned from factory
            Message message = messageFactory.Factory(headerDisplay[0]);
            // create instance of JSON API
            JsonAPI jsonAPI = new JsonAPI();
            
            // if format of header is correct and format of body is correct then sanitise body and write message object to JSON file
            if (message.FormatHeader(headerDisplay) && message.FormatBody(bodyDisplay))
            {
                message.Sanatise(headerDisplay, bodyDisplay);
                jsonAPI.ToJson(message);
            }

            // redisplay sanitised messages
            lblHeaderDisplay.Content = message.MessageHeader;
            lblBodyDisplay.Content = message.MessageBody;
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            // create instances of report windows
            SirListWindow sirListWindow = new SirListWindow();
            MentionListWindow mentionListWindow = new MentionListWindow();
            HashtagListWindow hashtagListWindow = new HashtagListWindow();
            // show report windows
            sirListWindow.Show();
            mentionListWindow.Show();
            hashtagListWindow.Show();
            // close this window
            Close();
        }
    }
}
