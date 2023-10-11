using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly INotesDbContext _context;

        public DeleteTagCommandHandler(INotesDbContext context) => _context = context;

        public async Task Handle(DeleteTagCommand request, CancellationToken cancellationtoken)
        {
            var entity = await _context.Tags.FindAsync(new object[] { request.TagId }, cancellationtoken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Tag), request.TagId);
            }

            _context.Tags.Remove(entity);
            await _context.SaveChangesAsync(cancellationtoken);
        }
    }
}
