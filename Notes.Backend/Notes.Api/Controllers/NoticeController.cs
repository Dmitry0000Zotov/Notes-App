using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Notices.Commands.CreateNotice;
using Notes.Application.Notices.Commands.DeleteNotice;
using Notes.Application.Notices.Commands.UpdateNotice;
using Notes.Application.Notices.Queries.GetNoticeDetails;
using Notes.Application.Notices.Queries.GetNoticeList;
using Notes.Domain;

namespace Notes.Api.Controllers
{
    [Route("notes/[controller]/[action]")]
    public class NoticeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NoticeListVm>> GetNoticeList()
        {
            var query = new GetNoticeListQuery();
            var vm = await Mediator.Send(query);

            List<NoticeLookupDto> notices = new List<NoticeLookupDto>();
            foreach (var notice in vm.Notices)
            {
                notices.Add(notice);
            }
            return Ok(notices);
        }

        [HttpGet]
        public async Task<ActionResult<Notice>> GetNotice(Guid id)
        {
            var query = new GetNoticeDetailsQuery
            {
                NoticeId = id
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Notice>> CreateNotice([FromBody]CreateNoticeCommand createNoticeCommand)
        {
            var notice = await Mediator.Send(createNoticeCommand);
            return Ok(notice);
        }

        [HttpPut]
        public async Task<ActionResult<Notice>> UpdateNotice([FromBody]UpdateNoticeCommand updateNoticeCommand)
        {
            var updatedNotice = await Mediator.Send(updateNoticeCommand);
            return Ok(updatedNotice);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteNotice(Guid id)
        {
            var command = new DeleteNoticeCommand
            {
                NoticeId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
