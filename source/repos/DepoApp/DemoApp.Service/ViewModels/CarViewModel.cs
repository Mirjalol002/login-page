using DemoApp.Domain.Enums;

namespace DemoApp.Service.ViewModels
{
    public class CarViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string ImageFullPath { get; set; } = string.Empty;

        public DateOnly MadeYear { get; set; }

        public ItemState ItemState { get; set; }
    }
}
