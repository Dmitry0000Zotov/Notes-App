using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityConfigurations;

namespace Notes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
