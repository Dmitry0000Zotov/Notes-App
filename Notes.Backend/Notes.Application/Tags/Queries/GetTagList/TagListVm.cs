using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Tags.Queries.GetTagList
{
    public class TagListVm
    {
        public IList<TagLookupDto> Tags { get; set; }
    }
}
