using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Notice
    {
        public Guid NoticeId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateEdit { get; set; }
        public DateTime Deadline { get; set; }

        public List<Tag>? Tags { get; set; }
    }
}
