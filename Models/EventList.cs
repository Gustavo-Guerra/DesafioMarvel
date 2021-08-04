namespace Marvel.Models{

    public class EventList{
        public int? available { get; set;}
        public int? returned { get; set;}
        public string collectedURI { get; set;}
        public EventSummary[] items { get; set;}
    }
}