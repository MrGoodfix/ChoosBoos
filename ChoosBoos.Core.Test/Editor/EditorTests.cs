using ChoosBoos.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Editor
{
    [TestFixture]
    public class EditorTests
    {
        [Test]
        public void ShouldReturnBook()
        {
            // Arrange
            ManuscriptEditor editor = new ManuscriptEditor();
            editor.Title = "Test";
            editor.Author = "Me";

            PageEditor opening = editor.NewPage("Opening");
            PageEditor badEnding = editor.NewPage("Bad Ending");
            PageEditor goodEnding = editor.NewPage("Good Ending");

            opening.NewChoice(badEnding, "Would you like to make a bad decision?");
            opening.NewChoice(goodEnding, "Would you like to make a good decision?");

            // Act 
            Book book = editor.Prepare();

            // Assert
            Assert.NotNull(book);
        }

        [Test]
        public void ShouldThrowExceptionIfManuscriptIsEmpty()
        {
            // Arrange
            ManuscriptEditor editor = new ManuscriptEditor();
            editor.Title = "Test";
            editor.Author = "Me";

            // Act 
            // Assert
            Assert.Throws<InvalidOperationException>(() => editor.Prepare());
        }
    }
}
