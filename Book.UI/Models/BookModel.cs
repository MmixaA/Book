using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Book.UI.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Rating { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PublishedDate { get; set; }
        public bool IsTaken { get; set; }

        public List<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}
