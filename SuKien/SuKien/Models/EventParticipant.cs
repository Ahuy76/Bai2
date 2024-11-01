namespace SuKien.Models
{
    public class EventParticipant
    {
        public int EventParticipantID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Participant Participant { get; set; }
        public Event Event { get; set; }
    }

}
