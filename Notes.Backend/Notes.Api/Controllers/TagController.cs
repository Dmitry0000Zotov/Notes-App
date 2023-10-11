using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Tags.Commands.BindTagToNote;
using Notes.Application.Tags.Commands.BindTagToNotice;
using Notes.Application.Tags.Commands.CreateTag;
using Notes.Application.Tags.Commands.DeleteTag;
using Notes.Application.Tags.Commands.UpdateTag;
using Notes.Application.Tags.Queries.GetTag;
using Notes.Application.Tags.Queries.GetTagList;
using Notes.Domain;

namespace Notes.Api.Controllers
{
    [Route("notes/[controller]/[action]")]
    public class TagController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TagListVm>> GetTagList()
        {
            var query = new GetTagListQuery();
            var vm = await Mediator.Send(query);
            List<TagLookupDto> tags = new List<TagLookupDto>();
            foreach (var tag in vm.Tags)
            {
                tags.Add(tag);
            }

            return Ok(tags);
        }

        [HttpGet]
        public async Task<ActionResult<Tag>> GetTag(Guid id)
        {
            var query = new GetTagQuery
            {
                TagId = id
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag([FromBody]CreateTagCommand createTagCommand)
        {
            var result = await Mediator.Send(createTagCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTag([FromBody]UpdateTagCommand updateTagCommand)
        {
            await Mediator.Send(updateTagCommand);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTag(Guid id)
        {
            var command = new DeleteTagCommand
            {
                TagId = id
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> BindTagToNote([FromBody]BindTagToNoteCommand bindCommand)
        {
            await Mediator.Send(bindCommand);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> BindTagToNotice([FromBody]BindTagToNoticeCommand bindCommand)
        {
            await Mediator.Send(bindCommand);
            return NoContent();
        }
    }
}
