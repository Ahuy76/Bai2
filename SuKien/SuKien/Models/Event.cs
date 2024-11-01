﻿namespace SuKien.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timeline { get; set; }
        public string ImageURL { get; set; }
        public int CreatedBy { get; set; }
        public string QRCode { get; set; }

        public Admin CreatedByAdmin { get; set; }
    }

}
