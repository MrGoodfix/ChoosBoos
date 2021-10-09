namespace ChoosBoos.Core.Editor
{
    public class ChoiceEditor
    {
        private ChoiceDraft _choice;

        public string Text { get; set; }

        public ChoiceEditor(ChoiceDraft choice)
        {
            _choice = choice;
        }
    }
}