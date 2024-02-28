using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;
using FluentValidation;

namespace BookPublisher.Application.Validators
{
    public class PublisherDtoValidator:AbstractValidator<PublisherDto>
    {
        public PublisherDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x=>x.Name).MaximumLength(100).WithMessage("Name can not be longer than 100 characters");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x=>x.Address).MaximumLength(100).WithMessage("Address can not be longer than 100 characters");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x=>x.Email).MaximumLength(100).WithMessage("Email can not be longer than 100 characters");
        }
    }
}
