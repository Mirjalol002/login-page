using OpTepaLavash.Enum;

namespace OpTepaLavash.Models
{
    //[Table("employee")]
    public class Employee
    {
        //[Column("id")]
        public int Id { get; set; }

        //[Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        //[Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        //[Column("possition")]
        //public Possition Possition { get; set; }

        //[Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        //[Column("email")]
        public string Email { get; set; } = string.Empty;


        public Gender Gender { get; set; }
        //[Column("description")]
        public string Description { get; set; } = string.Empty;

    }
}
