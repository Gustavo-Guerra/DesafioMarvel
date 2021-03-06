using System;
namespace Marvel.Models{
    public class Character{

        public int? id { get; set;}
        public string name { get; set; }
        public string description { get; set; }
        //public DateTime modified { get; set; }
        public string resourceURI { get; set; }
        public Url[] urls { get; set; }
        public Image thumbnail { get; set; }
        public ComicList comics { get; set; }
        public StoryList stories { get; set; }
        public EventList events { get; set; }
        public SeriesList series { get; set; }
    }
}