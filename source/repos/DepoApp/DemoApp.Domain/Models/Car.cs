using DemoApp.Domain.Enums;

namespace DemoApp.Domain.Models
{



    public class Car : Auditable
    {
        public string Name { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public DateOnly MadeYear { get; set; }

        public ItemState ItemState { get; set; }
    }
}
