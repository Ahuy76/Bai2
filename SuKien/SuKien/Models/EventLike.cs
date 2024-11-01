namespace SuKien.Models
{
    public class EventLike
    {
        public int LikeID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }

        public Participant Participant { get; set; }
        public Event Event { get; set; }
    }
}
