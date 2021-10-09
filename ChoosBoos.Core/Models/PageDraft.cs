using System.Collections.Generic;

namespace ChoosBoos.Core.Models
{
    public class PageDraft
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManuscriptID { get; set; }
        public List<ParagraphDraft> Paragraphs { get; set; }
    }
}