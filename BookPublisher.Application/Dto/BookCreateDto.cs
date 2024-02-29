using SharedUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookPublisher.Application.Dto
{
    public class BookCreateDto
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Edition { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        //[JsonConverter(typeof(JsonDateFormatConverter))]
        public DateTime PublishedDate { get; set; }
        public int PublisherId { get; set; }
    }
}
