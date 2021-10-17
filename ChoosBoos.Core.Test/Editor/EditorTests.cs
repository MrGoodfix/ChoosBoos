using ChoosBoos.Core.DataInterface;
using ChoosBoos.Core.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Editor
{
    [TestFixture]
    public class EditorTests
    {
        private Mock<IBookDAO> _bookDaoMock;

        [SetUp]
        public void Setup()
        {
            _bookDaoMock = new Mock<IBookDAO>();
            _bookDaoMock.Setup(x => x.Save(It.IsAny<Book>())).Returns<Book>(b =>
            {
                b.ID = 1;
                return b;
            });
        }

        [Test]
        public void ShouldReturnBook()
        {
            // Arrange
            BookEditor editor = new BookEditor(_bookDaoMock.Object);
            editor.NewBook();
            editor.Title = "Test";
            editor.Author = "Me";

            Page opening = editor.NewPage("Opening");
            Page badEnding = editor.NewPage("Bad Ending");
            Page goodEnding = editor.NewPage("Good Ending");

            editor.AddChoice(opening, badEnding, "Would you like to make a bad decision?");
            editor.AddChoice(opening, goodEnding, "Would you like to make a good decision?");

            // Act 
            Book book = editor.Prepare();

            // Assert
            Assert.NotNull(book);
            Assert.That(book.Pages, Has.Count.EqualTo(3));
        }

        [Test]
        public void ShouldThrowExceptionIfManuscriptIsEmpty()
        {
            // Arrange
            BookEditor editor = new BookEditor(_bookDaoMock.Object);
            editor.NewBook();
            editor.Title = "Test";
            editor.Author = "Me";

            // Act 
            // Assert
            Assert.Throws<InvalidOperationException>(() => editor.Prepare());
        }

        [Test]
        public void ShouldAssignCorrectIds()
        {
            // Arrange
            BookEditor editor = new BookEditor(_bookDaoMock.Object);
            editor.NewBook();
            editor.Title = "Test";
            editor.Author = "Me";

            Page opening = editor.NewPage("Opening");
            Page badEnding = editor.NewPage("Bad Ending");
            Page goodEnding = editor.NewPage("Good Ending");

            editor.AddChoice(opening, badEnding, "Would you like to make a bad decision?");
            editor.AddChoice(opening, goodEnding, "Would you like to make a good decision?");

            // Act 
            Book book = editor.Prepare();

            // Assert
            Assert.That(book.ID, Is.EqualTo(1));
            Assert.That(opening.ID, Is.EqualTo(1));
            Assert.That(opening.BookID, Is.EqualTo(1));
            Assert.That(badEnding.ID, Is.EqualTo(2));
            Assert.That(badEnding.BookID, Is.EqualTo(1));
            Assert.That(goodEnding.ID, Is.EqualTo(3));
            Assert.That(goodEnding.BookID, Is.EqualTo(1));
        }
    }
}
