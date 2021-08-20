namespace Napier_Bank_Messaging.Tools
{
    public class TextSpeak
    {
        // create private class variables
        private string _abbreviation, _phrase;

        // getter and setter for abbreviation
        public string Abbreviation
        {
            get => _abbreviation;
            set => _abbreviation = value;
        }

        // getter and setter for phrase
        public string Phrase
        {
            get => _phrase;
            set => _phrase = value;
        }
    }
}
