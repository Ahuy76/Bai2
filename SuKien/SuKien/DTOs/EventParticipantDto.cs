namespace SuKien.DTOs
{
    public class EventParticipantDTO
    {
        public int EventParticipantID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
