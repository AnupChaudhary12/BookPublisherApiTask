using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Application.Dto
{
    public class PublisherCreateDto
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
