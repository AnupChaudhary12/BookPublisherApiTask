using BookPublisher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Application.Dto
{
    public class PublisherDto
    {
        [Required,Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<BookDto>? Books { get; set; }
    }
}
