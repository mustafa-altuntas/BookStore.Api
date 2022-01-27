using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Api.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
