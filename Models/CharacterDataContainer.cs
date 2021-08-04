namespace Marvel.Models{
    public class CharacterDataContainer {
        public int? offset { get; set;}
        public int? limit { get; set;}
        public int? total { get; set;}
        public int? count { get; set;}
        public Character[] results { get; set;}
    }
}