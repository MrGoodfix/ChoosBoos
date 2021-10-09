using ChoosBoos.Core.Models;
using System;

namespace ChoosBoos.Core.Editor
{
    public class ManuscriptEditor
    {
        private Manuscript _manuscript;

        public string Title
        {
            get => _manuscript.Title;
            set => _manuscript.Title = value;
        }

        public string Author
        {
            get => _manuscript.Author;
            set => _manuscript.Author = value;
        }

        public ManuscriptEditor()
        {
            _manuscript = new Manuscript();
            Title = "Untitled";
            Author = "Anonymous";
        }

        public PageEditor NewPage(string pageName)
        {
            PageDraft page = new PageDraft
            {
                Name = pageName,
                ManuscriptID = _manuscript.ID
            };

            return new PageEditor(page);
        }

        public Book Prepare()
        {
            Book book = new Book();
            book.Author = _manuscript.Author;
            book.Title = _manuscript.Title;
            return book;
        }
    }
}