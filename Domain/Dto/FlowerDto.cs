using BobMarley.Domain.Entities.Secondary;

namespace BobMarley.Domain.Dto
{
    public class FlowerDto
    {
#pragma warning disable IDE1006 // Naming Styles
        public string? name { get; set; }
        public string? ocpc { get; set; }
        public Brand? brand { get; set; }
        public string? type { get; set; }
        public StrainDto? strain { get; set; }
        public object? description { get; set; }
        public string? qr { get; set; }
        public string? url { get; set; }
        public string? image { get; set; }
        //public bool? labTest { get; set; }
        //public bool? thc { get; set; }
        //public bool? cbd { get; set; }
        public string? createdAt { get; set; }
        public string? UpdatedAt { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
