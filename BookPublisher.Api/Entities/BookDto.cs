using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SharedUtility;

namespace BookPublisher.Domain.Entities
{
    public class BookDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Edition { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        //[JsonConverter(typeof(JsonDateFormatConverter))]
        public DateTime PublishedDate { get; set; }

        public int PublisherId { get; set; }
        public  Publisher? Publisher { get; set; } 


    }
}
