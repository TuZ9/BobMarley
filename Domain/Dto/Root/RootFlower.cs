using BobMarley.Domain.Entities.Secondary;

namespace BobMarley.Domain.Dto.Root
{
    public class RootStrain
    {
        public required List<FlowerDto> Data { get; set; }
        public Meta? Meta { get; set; }
    }
}
