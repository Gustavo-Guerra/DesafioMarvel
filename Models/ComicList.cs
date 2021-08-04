namespace Marvel.Models{
    public class ComicList{
        public int? available{ get; set;}
        public int? returned { get; set;}
        public string collectionURI { get; set;}
        public ComicSummary[] items { get; set;}
    }
}