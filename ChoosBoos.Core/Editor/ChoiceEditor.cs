using ChoosBoos.Core.Models;

namespace ChoosBoos.Core.Editor
{
    public class ChoiceEditor
    {
        private Choice _choice;

        public string Text { get; set; }

        public ChoiceEditor(Choice choice)
        {
            _choice = choice;
        }
    }
}