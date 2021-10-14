using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Models
{
    public class Page
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public int? ImageID { get; set; }
        public int PageNumber { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
