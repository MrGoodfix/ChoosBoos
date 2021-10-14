using ChoosBoos.Core.Models;
using System;
using System.Collections.Generic;

namespace ChoosBoos.Core.Editor
{
    public class PageEditor
    {
        private Page _page;

        public int BookID => _page.BookId;
        public int PageID => _page.ID;

        public string Name
        {
            get => _page.Name;
            set => _page.Name = value;
        }

        public List<Paragraph> Paragraphs => _page.Paragraphs;

        public PageEditor(Page page)
        {
            _page = page;
        }

        public ChoiceEditor NewChoice(PageEditor destination, string text)
        {
            Choice choice = new Choice
            {
                Text = text,
                PageID = _page.ID,
                DestinationPageID = destination._page.ID
            };

            if (_page.Choices is null)
            {
                _page.Choices = new List<Choice>();
            }

            _page.Choices.Add(choice);

            return new ChoiceEditor(choice);
        }
    }
}