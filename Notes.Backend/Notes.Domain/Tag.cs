using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Tag
    {
        public Guid TagId { get; set; }
        public string Title { get; set; }

        //[JsonIgnore]
        public List<Note>? Notes { get; set; }
        public List<Notice>? Notices { get; set; }
    }
}
