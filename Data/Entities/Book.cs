using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Rating { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsTaken { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
