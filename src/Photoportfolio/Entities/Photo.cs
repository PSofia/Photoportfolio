using System;
using System.Collections.Generic;

namespace Photoportfolio.Entities
{
    public class Photo : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public int AlbumId { get; set; }
        public float Rating { get; set; }
        public DateTime DateUploaded { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<UserFeedback> Feedbacks { get; set; }
    }
}
