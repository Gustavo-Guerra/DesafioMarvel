namespace Marvel.Models{
    public class CharacterDataWrapper {
        public int? code { get; set;}
        public string status { get; set;}
        public string copyright { get; set;}
        public string attribuitionText { get; set;}
        public string attribuitionHTML { get; set;}
        public CharacterDataContainer data { get; set;}
        public string etag { get; set;}
    }
}