using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator()
        {
            RuleFor(deleteTagCommand => deleteTagCommand.TagId).NotEqual(Guid.Empty);
        }
    }
}
