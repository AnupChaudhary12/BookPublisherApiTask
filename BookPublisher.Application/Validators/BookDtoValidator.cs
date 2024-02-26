using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using FluentValidation;

namespace BookPublisher.Application.Validators
{
    public class BookDtoValidator:AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Title can not be longer than 100 characters");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN is required");
            RuleFor(x => x.ISBN).MaximumLength(13).WithMessage("ISBN can not be longer than 13 characters");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.Author).MaximumLength(100).WithMessage("Author can not be longer than 100 characters");
            RuleFor(x => x.Edition).NotEmpty().WithMessage("Edition is required");
            RuleFor(x => x.Edition).MaximumLength(100).WithMessage("Edition can not be longer than 100 characters");
            RuleFor(x => x.PublisherId).NotEmpty().WithMessage("Publisher is required");
            RuleFor(x => x.PublisherId).GreaterThan(0).WithMessage("Publisher is required");
            RuleFor(x => x.PublishedDate)
                .Must(BeInThePast)
                .WithMessage("PublishedDate must not be in the future");
        }

        private bool BeInThePast(DateTime publishedDate)
        {
            return publishedDate <= DateTime.Now;
        }
    }
}
