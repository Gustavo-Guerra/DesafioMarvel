namespace Marvel.Models{

    public class StoryList{
        public int? available { get; set;}
        public int? returned { get; set;}
        public string collectionURI { get; set;}
        public StorySummary[] items { get; set;}
    }
}