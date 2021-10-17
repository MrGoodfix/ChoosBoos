using ChoosBoos.Core.DataInterface;
using ChoosBoos.Core.Models;
using ChoosBoos.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChoosBoos.Core.Editor
{
    public class BookEditor
    {
        private Book _book;
        private NumberSeq _pageNumberGen;
        private NumberSeq _choiceNumberGen;
        private IBookDAO _dao;

        /// <summary>
        /// The public title of the entire book.
        /// </summary>
        public string Title
        {
            get => _book.Title;
            set => _book.Title = value;
        }

        /// <summary>
        /// Who wrote this?
        /// </summary>
        public string Author
        {
            get => _book.Author;
            set => _book.Author = value;
        }

        /// <summary>
        /// Instantiates a book editor... don't forget to create a new book or 
        /// load one before beginning work!
        /// </summary>
        /// <param name="bookDAO">Data Access Object</param>
        public BookEditor(IBookDAO bookDAO)
        {
            _dao = bookDAO;
        }

        /// <summary>
        /// Creates a new untitled book and points this editor at it.
        /// </summary>
        public void NewBook()
        {
            _book = new Book();
            _book.Pages = new List<Page>();
            _book.Choices = new List<Choice>();
            Title = "Untitled";
            Author = "Anonymous";
            _dao.Save(_book);
            _pageNumberGen = new NumberSeq(1);
            _choiceNumberGen = new NumberSeq(1);

        }

        /// <summary>
        /// Loads a previously saved book and points this editor at it.
        /// </summary>
        public void LoadBook(Book book)
        {
            _book = book;
            _pageNumberGen = new NumberSeq(book.Pages != null ? book.Pages.Max(p => p.ID) + 1 : 1);
            _choiceNumberGen = new NumberSeq(book.Choices != null ? book.Choices.Max(c => c.ID) + 1 : 1);
        }

        /// <summary>
        /// Adds a blank page to the book.
        /// </summary>
        /// <param name="pageName">The internal name of the page. What the writer would see in the overview.</param>
        public Page NewPage(string pageName)
        {
            Page page = new Page
            {
                ID = _pageNumberGen.GetNext(),
                Name = pageName,
                BookID = _book.ID,
                Choices = new List<Choice>()
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

            return page;
        }

        /// <summary>
        /// Adds a choice to the book.
        /// </summary>
        /// <param name="from">The page the choice appears on.</param>
        /// <param name="to">The page the choice leads to.</param>
        /// <param name="text">The text the reader sees.</param>
        /// <returns></returns>
        public Choice AddChoice(Page from, Page to, string text)
        {
            Choice choice = new Choice
            {
                ID = _choiceNumberGen.GetNext(),
                Text = text,
                PageID = from.ID,
                DestinationPageID = to.ID
            };

            if (from.Choices is null)
            {
                from.Choices = new List<Choice>();
            }

            from.Choices.Add(choice);

            return choice;
        }

        /// <summary>
        /// Last minute stuff...
        /// maybe randomize the page numbers if the book is going to be printed or
        /// exported to pdf or something...
        /// not entirely sure yet.
        /// </summary>
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