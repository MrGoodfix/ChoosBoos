using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Models
{
    public class Choice
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int PageID { get; set; }
        public int DestinationPageID { get; set; }
    }
}
