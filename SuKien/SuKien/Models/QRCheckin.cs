namespace SuKien.Models
{
    public class QRCheckin
    {
        public int CheckinID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public DateTime CheckinTime { get; set; }

        public Participant Participant { get; set; }
        public Event Event { get; set; }
    }
}
