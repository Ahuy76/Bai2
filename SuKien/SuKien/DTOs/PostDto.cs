namespace SuKien.DTOs
{
    public class PostDTO
    {
        public int PostID { get; set; }
        public int EventID { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
