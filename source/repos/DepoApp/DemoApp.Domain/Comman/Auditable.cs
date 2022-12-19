using DemoApp.Domain.Comman;

namespace DemoApp.Domain.Models
{
    public class Auditable : BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


    }
}
