namespace Napier_Bank_Messaging.Tools
{
    public class TextSpeak
    {
        private string _abbreviation, _phrase;

        public string Abbreviation
        {
            get => _abbreviation;
            set => _abbreviation = value;
        }

        public string Phrase
        {
            get => _phrase;
            set => _phrase = value;
        }
    }
}
