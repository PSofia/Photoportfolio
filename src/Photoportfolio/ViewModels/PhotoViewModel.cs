using System;

namespace Photoportfolio.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public float Rating { get; set; }
        public string AlbumTitle { get; set; }
        public string Author { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
