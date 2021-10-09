using System.Collections.Generic;

namespace ChoosBoos.Core.Models
{
    public class Manuscript
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public PageDraft FirstPage { get; set; }
        public List<PageDraft> Pages { get; set; }
    }
}