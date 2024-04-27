
namespace BobMarley.Domain.Dto
{
    public class FlowerDto
    {
        public string? Name { get; set; }
        public string? Ocpc { get; set; }
        public Entities.Secondary.Brand? Brand { get; set; }
        public string? Type { get; set; }
        public StrainDto? Strain { get; set; }
        public object? Description { get; set; }
        public string? Qr { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool? LabTest { get; set; }
        public bool? Thc { get; set; }
        public bool? Cbd { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }

    }
}
