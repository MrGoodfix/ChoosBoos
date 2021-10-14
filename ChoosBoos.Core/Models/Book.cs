using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int FirstPageID { get; set; }
        public List<Page> Pages { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
