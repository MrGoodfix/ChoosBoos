namespace ChoosBoos.Core.Editor
{
    public class ChoiceDraft
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int SourcePageID { get; set; }
        public int DestinationPageID { get; set; }
    }
}