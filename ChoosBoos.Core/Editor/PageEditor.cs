using ChoosBoos.Core.Models;
using System;
using System.Collections.Generic;

namespace ChoosBoos.Core.Editor
{
    public class PageEditor
    {
        private PageDraft _page;

        public string Name
        {
            get => _page.Name;
            set => _page.Name = value;
        }

        public List<ParagraphDraft> Paragraphs => _page.Paragraphs;

        public PageEditor(PageDraft page)
        {
            _page = page;
        }

        public ChoiceEditor NewChoice(PageEditor destination, string text)
        {
            ChoiceDraft choice = new ChoiceDraft
            {
                Text = text,
                SourcePageID = _page.ID,
                DestinationPageID = destination._page.ID
            };

            return new ChoiceEditor(choice);
        }
    }
}