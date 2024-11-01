using Microsoft.EntityFrameworkCore;
using SuKien.Models;

namespace SuKien.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<EventLike> EventLikes { get; set; }
        public DbSet<QRCheckin> QRCheckins { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
    }
}

