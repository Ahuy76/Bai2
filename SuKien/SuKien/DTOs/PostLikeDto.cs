namespace SuKien.DTOs
{
    public class PostLikeDTO
    {
        public int PostLikeID { get; set; }
        public int PostID { get; set; }
        public int ParticipantID { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
