using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Model
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Rating { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsTaken { get; set; }

        public ICollection<AuthorDTO> Authors { get; set; }
    }
    public class BookCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public string Image { get; set; }
        public float Rating { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsTaken { get; set; }

        public ICollection<AuthorCreateModel> Authors { get; set; }
    }
}
