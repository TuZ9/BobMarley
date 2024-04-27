using BobMarley.Domain.Entities.Secondary;

namespace BobMarley.Domain.Dto.Root
{
    public class RootStrain
    {
        public List<FlowerDto> data { get; set; }
        public Meta meta { get; set; }
    }
}
