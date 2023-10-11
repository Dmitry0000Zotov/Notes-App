using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string? Details { get; set; }
        public DateTime? DateNote { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateEdit { get; set; }

        //[JsonIgnore]
        public List<Tag>? Tags { get; set; }
    }
}
