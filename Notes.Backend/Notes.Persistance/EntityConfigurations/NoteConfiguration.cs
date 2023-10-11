using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notes.Persistence.EntityConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.NoteId);
            builder.HasIndex(note => note.NoteId).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
