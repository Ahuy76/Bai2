namespace SuKien.Models
{
    public class PostLike
    {
        public int PostLikeID { get; set; }
        public int PostID { get; set; }
        public int ParticipantID { get; set; }
        public DateTime LikedAt { get; set; }

        public Post Post { get; set; }
        public Participant Participant { get; set; }
    }
}
