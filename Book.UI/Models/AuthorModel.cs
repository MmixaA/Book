using System.ComponentModel.DataAnnotations;

namespace Book.UI.Models
{
    public class AuthorModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        public int BookId { get; set; }
    }
}
