
namespace BobMarley.Domain.Entities
{
    public class Flower
    {
        public string? Name { get; set; }
        public Guid IdFlower { get; set; }
        public Guid IdBrand { get; set; }
        public string? Type { get; set; }
        public Guid IdStrain { get; set; }
        public object? Description { get; set; }
        public string? Qr { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool LabTest { get; set; }
        public bool Thc { get; set; }
        public bool Cbd { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
