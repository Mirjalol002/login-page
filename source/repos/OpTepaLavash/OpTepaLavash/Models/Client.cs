using OpTepaLavash.Enum;
using System.ComponentModel.DataAnnotations;

namespace OpTepaLavash.Models
{
    //[Table("Clients")]
    public class Client
    {
        //[Column("id")]
        [Key]
        public int Id { get; set; }

        //[Column("first_name"), MaxLength(70)]
        [Required, MaxLength(80)]
        public string FirstName { get; set; } = string.Empty;

        //[Column("last_name"), MaxLength(70)]
        [Required, MaxLength(80)]
        public string LastName { get; set; } = string.Empty;

        //[Column("age")]
        public int Age { get; set; }

        //[Column("Gender")]
        public Gender Gender { get; set; }


    }
}