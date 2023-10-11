using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Domain;

namespace Notes.Api.Controllers
{
    [Route("notes/[controller]/[action]")]
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteLookupDto>>> GetNoteList()
        {
            var query = new GetNoteListQuery();
            var vm = await Mediator.Send(query);
            List<NoteLookupDto> notes = new List<NoteLookupDto>();
            foreach (var note in vm.Notes)
            {
                notes.Add(note);
            }
            return Ok(notes);
        }

        [HttpGet]
        public async Task<ActionResult<Note>> GetNote(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                NoteId = id
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote([FromBody]CreateNoteCommand createNoteCommand)
        {
            var note = await Mediator.Send(createNoteCommand);
            return Ok(note);
        }

        [HttpPut]
        public async Task<ActionResult<Note>> UpdateNote([FromBody]UpdateNoteCommand updateNoteCommand)
        {
            var updatedNote = await Mediator.Send(updateNoteCommand);
            return Ok(updatedNote);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                NoteId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
