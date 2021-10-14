using ChoosBoos.Core.Models;
using ChoosBoos.Core.Utilities;
using System;
using System.Collections.Generic;

namespace ChoosBoos.Core.Editor
{
    public class BookEditor
    {
        private Book _book;
        private NumberSeq _pageNumberGen;

        public string Title
        {
            get => _book.Title;
            set => _book.Title = value;
        }

        public string Author
        {
            get => _book.Author;
            set => _book.Author = value;
        }

        public BookEditor()
        {
            _book = new Book();
            Title = "Untitled";
            Author = "Anonymous";
            _pageNumberGen = new NumberSeq(1);
        }

        public PageEditor NewPage(string pageName)
        {
            Page page = new Page
            {
                ID = _pageNumberGen.GetNext(),
                Name = pageName,
                BookId = _book.ID
            };

            if (_book.Pages is null)
            {
                _book.Pages = new List<Page>();
                _book.Pages.Add(page);
                _book.FirstPageID = page.ID;
            }
            else
            {
                _book.Pages.Add(page);
            }

            return new PageEditor(page);
        }

        public Book Prepare()
        {
            if (_book.Pages is null || _book.Pages.Count == 0)
            {
                throw new InvalidOperationException("Cannot prepare a book if the manuscript does not have any pages.");
            }
            
            return _book;
        }

        
    }
}