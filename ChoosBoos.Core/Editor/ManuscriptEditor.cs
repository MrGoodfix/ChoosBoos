using ChoosBoos.Core.Models;
using System;
using System.Collections.Generic;

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

            if (_manuscript.Pages is null)
            {
                _manuscript.Pages = new List<PageDraft>();
                _manuscript.Pages.Add(page);
                _manuscript.FirstPage = page;
            }
            else
            {
                _manuscript.Pages.Add(page);
            }

            return new PageEditor(page);
        }

        public Book Prepare()
        {
            if (_manuscript.Pages is null || _manuscript.Pages.Count == 0)
            {
                throw new InvalidOperationException("Cannot prepare a book if the manuscript does not have any pages.");
            }

            Book book = new Book();
            book.Author = _manuscript.Author;
            book.Title = _manuscript.Title;
            return book;
        }
    }
}