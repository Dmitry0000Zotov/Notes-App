using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(tag => tag.TagId).NotEqual(Guid.Empty);
        }
    }
}
