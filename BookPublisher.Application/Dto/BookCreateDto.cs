using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Application.Dto
{
    public class BookCreateDto
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Edition { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public int PublisherId { get; set; }
    }
}
