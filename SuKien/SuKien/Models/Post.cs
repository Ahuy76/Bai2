namespace SuKien.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int EventID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Event Event { get; set; }
    }

}
