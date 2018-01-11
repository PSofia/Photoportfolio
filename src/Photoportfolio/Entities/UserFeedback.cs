using System;

namespace Photoportfolio.Entities
{
    // TODO: Add another fields such as creationDate and so on
    public class UserFeedback : IEntityBase
    {
        public UserFeedback()
        {
        }

        public UserFeedback(int userId, int photoId, float mark)
        {
            UserId = userId;
            PhotoId = photoId;
            Mark = mark;
        }

        public int Id { get; set; }

        public float Mark { get; set; }

        public int UserId { get; set; }

        public int PhotoId { get; set; }

        public virtual User User { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
