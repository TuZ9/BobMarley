using BobMarley.Domain.Entities.Secondary;

namespace BobMarley.Domain.Dto.Root
{
    public class RootExtract
    {
        public required List<ExtractDto> Data { get; set; }
        public Meta? Meta { get; set; }
    }
}
