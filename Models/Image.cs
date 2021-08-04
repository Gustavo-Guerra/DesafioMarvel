namespace Marvel.Models{

    public class Image{
        public string path { get; set;}//"http://caminhodoido/foto"
        public string extension { get; set;}//"png"
        public string url { get
        
        {
            return $"{path}.{extension}"; //"http://caminho/foto.png"
        }}
    }
}