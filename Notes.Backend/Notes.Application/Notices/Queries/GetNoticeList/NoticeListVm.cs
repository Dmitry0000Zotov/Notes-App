using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notices.Queries.GetNoticeList
{
    public class NoticeListVm
    {
        public IList<NoticeLookupDto> Notices { get; set; }
    }
}
