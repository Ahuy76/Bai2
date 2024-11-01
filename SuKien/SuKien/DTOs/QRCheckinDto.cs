namespace SuKien.DTOs
{
    public class QRCheckinDTO
    {
        public int CheckinID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public DateTime CheckinTime { get; set; }
    }
}
