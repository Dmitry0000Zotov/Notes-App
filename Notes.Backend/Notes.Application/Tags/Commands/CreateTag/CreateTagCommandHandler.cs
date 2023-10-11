using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Tag>
    {
        private readonly INotesDbContext _context;

        public CreateTagCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Tag> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                TagId = Guid.NewGuid(),
                Title = request.Title,
            };

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync(cancellationToken);

            return tag;
        }
    }
}
